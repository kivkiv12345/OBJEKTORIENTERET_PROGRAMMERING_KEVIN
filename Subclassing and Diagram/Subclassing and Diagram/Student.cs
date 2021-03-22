using System;
using System.Collections.Generic;
using System.Text;

namespace Subclassing_and_Diagram
{
    public class Student : CampusMember
    {
        public Student(string name, string password) : base(name, password){ }

        public Student(string name, string password, Teacher teacher) : base(name, password)
        {
            this.Teacher = teacher;
            this.Teacher.students.Add(this);
        }

        public Teacher Teacher
        {
            get => default;
            // TODO Kevin: Not sure if Teacher represents the old or new value in this context.
            // The setter may therefore need to be changed.
            set{  Teacher.students.Remove(this); }
        }
    }
}