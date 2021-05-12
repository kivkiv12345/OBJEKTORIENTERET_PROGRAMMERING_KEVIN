using System;
using System.Collections.Generic;
using System.Text;
using static Subclassing_and_Diagram.utils;
using static Subclassing_and_Diagram.Program;

namespace Subclassing_and_Diagram
{
    public class Teacher : CampusMember
    {
        public HashSet<Student> students;
        public Teacher(string name, string password) : base(name, password)
        {
            void ManageStudents()
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("These are your students: ");
                    Console.WriteLine("=================================");
                    if (students != null)
                    {
                        foreach (Student student in students)
                            Console.WriteLine(student.name);

                    }
                    else { Console.WriteLine("NONE"); }

                    Console.WriteLine("=================================");

                    Console.WriteLine("\nThese are your options: \nType \"Add <STUDENT NAME>\" to assign a student to yourself.\nType \"Remove <STUDENT NAME>\" to unassign a student from yourself.");
                    string usrinput = CheckGoBack().ToLower();

                    if (usrinput.StartsWith("add"))
                    {
                        bool foundSome = false;
                        foreach(CampusMember member in users.Values)
                        {
                            if (member is Student && member.name.ToLower() == usrinput)  // TODO Kevin: This check fails
                            {
                                students.Add((Student)member);
                                foundSome = true;
                            }
                        }
                        if (!foundSome)
                        {
                            Console.WriteLine("Did not find any matching students!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    } else if (usrinput.StartsWith("remove"))
                    {
                        bool nameisinput(Student stud) => stud.name.ToLower() == usrinput;
                        students.RemoveWhere(nameisinput);
                    }
                }
            }

            // Define actions for teachers here.
            actions.AddRange(new List<ActionWrapper> 
            { 
                new ActionWrapper(ManageStudents, "manage your students"),
            });
        }
    }
}