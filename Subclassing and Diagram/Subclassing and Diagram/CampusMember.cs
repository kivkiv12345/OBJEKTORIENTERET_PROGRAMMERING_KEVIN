using System;
using System.Collections.Generic;
using System.Text;

namespace Subclassing_and_Diagram
{
    /// <summary>
    /// The Login class is used to accept user input, and find the corresponding campus member in the users dictionary.
    /// </summary>
    public class Login
    {
        string name, password;  // The name and password strings are what will be used to find the corresponding user in the dictionary.

        public Login(CampusMember member)
        {
            this.name = member.name;
            this.password = member.password;
        }

        public Login(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        public override int GetHashCode() => (name + password).GetHashCode();

        public override bool Equals(object obj) => Equals(obj as Login);
        public bool Equals(Login obj) => obj != null && obj.GetHashCode() == this.GetHashCode();

        public override string ToString() => $"Login for {name}";
    }

    public abstract class CampusMember
    {
        #region Actions
        public void PrintName()
        {
            Console.WriteLine(this.name);
        }
        public void LogOut()
        {
            Program.CurrentUser = null;
        }
        #endregion

        public string ID, name, password;
        public List<ActionWrapper> actions = new List<ActionWrapper>();

        private static uint IDcounter = 0;
        private static string NextID()
        {
            IDcounter++;
            return (IDcounter - 1).ToString();
        }

        public class ActionWrapper
        {
            public Action action;
            public string name;

            public ActionWrapper(Action action, string name)
            {
                this.action = action;
                this.name = name;
            }
        }

        public CampusMember(string name, string password)
        {
            this.name = name;
            this.password = password;
            this.ID = NextID();

            actions.Add(new ActionWrapper(PrintName, "print the name of this member"));
            actions.Add(new ActionWrapper(LogOut, "log out"));
        }

        public void PrintActions()
        {
            Console.WriteLine("=================================");
            for (int i = 0; i < actions.Count; i++)
            {
                Console.WriteLine($"Type {i} to {actions[i].name}.");
            }
            Console.WriteLine("=================================");

            actions[Convert.ToInt32(Console.ReadLine())].action();
        }

        /// <summary>
        /// Useful when the user itself needs to be paired with matching login credentials.
        /// </summary>
        /// <returns>A KeyValuePair which may be added 'directly' to the users dictionary.</returns>
        public KeyValuePair<Login, CampusMember> Login() => new KeyValuePair<Login, CampusMember>(new Login(this), this);

        public override string ToString() => $"[{this.name}, {this.GetType().Name}]";
    }
}