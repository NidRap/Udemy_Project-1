﻿using System.Net.Http.Headers;
using System.Text;
using ConsumingApiSection.Models;
using ConsumingApiSection.Models.Models;
using ConsumingApiSection.Services.IServices;
using Newtonsoft.Json;
using Utility;

namespace ConsumingApiSection.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var Client = httpClient.CreateClient("MagicAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                    Encoding.UTF8, "application/json");
                }

                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;


                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;


                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;


                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponse = null;

                if (!string.IsNullOrEmpty(apiRequest.token))
                {
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.token);
                }

                apiResponse = await Client.SendAsync(message);


                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;

            }
            catch (Exception e)
            {
                var dto = new APIResponse
                {
                    ErrorsMsg = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var APIResponse = JsonConvert.DeserializeObject<T>(res);
                return APIResponse;
            }
        }

    }
}

