using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Subclassing_and_Diagram
{
    class utils
    {
        public static bool GlobalLoadEnabled = true;

        public static void FakeLoading(string LoadingMessage = "Loading in progress...", int DataAmount=20, int LoadingSpeed=10, bool CurrentLoadEnabled=true)
        {
            if (GlobalLoadEnabled && CurrentLoadEnabled)
            {
                int LoadingProgress = 0;
                Console.Write("\r\n" + LoadingMessage + ": [");
                while (LoadingProgress < DataAmount)
                {
                    Console.Write("█");
                    LoadingProgress++;
                    for (int i = 0; i < (DataAmount - LoadingProgress); i++)
                    {
                        Console.Write("_");
                    }
                    Console.Write("]");
                    Thread.Sleep(LoadingSpeed);
                    for (int i = 0; i < (DataAmount - LoadingProgress + 1); i++)
                    {
                        Console.Write("\b");
                    }
                }
                //Console.WriteLine();
            }
            else
            {
                Console.Write("\r\n" + LoadingMessage + "...\r\nLoading has been disabled...");
            }
            Thread.Sleep(10);
            Console.WriteLine("\r\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public static string CheckGoBack()
        {
            string usrinput = Console.ReadLine();

            if (new HashSet<string> { "back", "exit", "return", "goback", }.Contains(usrinput.ToLower().Trim()))
                throw new GoBackException();
            return usrinput;
        }

        /// <summary>
        /// We raise this exception when the user indicate that they wish to return to a previous menu.
        /// </summary>
        [Serializable]
        public class GoBackException : Exception
        {
            public GoBackException() { }

            public GoBackException(string message) : base(message) { }

            public GoBackException(string message, Exception innerException) : base(message, innerException) { }
        }
    }
}
