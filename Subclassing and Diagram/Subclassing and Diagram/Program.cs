using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Subclassing_and_Diagram.utils;

namespace Subclassing_and_Diagram
{
    class Program
    {
        public static CampusMember CurrentUser = null;

        public static IDictionary<Login, CampusMember> users = new KeyValuePair<Login, CampusMember>[]
        {
            // Initial members are added in this list.

            // Teachers:
            new Teacher("Egon", "IsNice").Login(),

            // Students:
            new Student("Kiv", "Test1234!").Login(),
            new Student("Dig", "qwerty").Login(),
            new Student("Mig", "password").Login(),
            new Student("Benny", "banan").Login(),

        }.ToDictionary(x => x.Key, x => x.Value);

        static void Main(string[] args)
        {
            while (true)
            {

                bool again = true;
                while (again)
                {
                    again = false;

                    Console.WriteLine("Please enter your username: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please enter your password: ");
                    string password = Console.ReadLine();
                    Console.Clear();
                    try
                    {
                        CurrentUser = users[new Login(name, password)];
                        Console.WriteLine($"Now logging in as {CurrentUser}.");
                    }
                    catch (KeyNotFoundException)
                    {
                        again = true;
                        Console.WriteLine("Incorrect username or password. Please try again.");
                    }
                }
                FakeLoading();

                while (CurrentUser != null)
                {
                    Console.Clear();

                    Console.WriteLine($"Welcome {CurrentUser.name}");

                    Console.WriteLine("These are your options: ");

                    try
                    {
                        CurrentUser.PrintActions();
                    } catch (GoBackException)
                    {
                        Console.WriteLine("Welcome back! TODO");
                    }

                    if (CurrentUser != null)
                        Console.ReadLine();
                    else
                        Console.Clear();
                }
            }
        }
    }
}
