using System;
using System.Collections.Generic;
using System.Text;

namespace Subclassing_and_Diagram
{
    public class Teacher : CampusMember
    {
        public HashSet<Student> students;
        public Teacher(string name, string password) : base(name, password)
        {
        }
    }
}