﻿namespace Udemy_Project_1.Logging
{
    public class loggingWithColor : Ilogging
    {
        public void Log(string message, string type)
        {
         if (type == "error")
            {
                Console.BackgroundColor = ConsoleColor.Red;

                Console.WriteLine("Error -" + message);
                Console.BackgroundColor = ConsoleColor.Black;

            }
            else
            {
                if (type == "warning") {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;

                    Console.WriteLine("Error -" + message);
                    Console.BackgroundColor = ConsoleColor.Black;

                }
                else

                Console.WriteLine(message);
            }
    }
}
}
