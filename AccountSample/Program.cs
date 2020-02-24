using System;
using System.Collections.Generic;

namespace AccountSample
{
    class Program
    {
            //list of all students and accounts
            static List<Student> studentList = new List<Student>();
            static List<Class> classList = new List<Class>();
        static List<Professor> professorList = new List<Professor>();
        static void Main(string[] args)
        {
            //read/write txt lists
            
            
            ClassMenu.AllClasses(classList);

            bool main = true;
            while (main)
            {
                Console.WriteLine("Enter one of the following to start exploring: ");
                string menu = Get("[ Professor ] [ Student ] [ Store ]").ToLower();
                switch (menu)
                {
                    //main//
                    case "professor": //Create new, add class, update grades, user account(show current students and classes)
                        Professor newProfessor = NewProfessor();
                        MenuProf.AddProf(newProfessor);
                        MenuProf.Update(professorList);
                        break;
                    //main//
                    case "student": //Create new, search classes, add classes, pay tuition, get materials, user account(show current classes, gpa, rented books? and grades)
                        bool sMenu = true;
                        bool paid;
                        //student menu
                        Student newStudent = NewStudent();
                        StudentMenu.AddStudent(newStudent);
                        StudentMenu.Update(studentList);
                        switch (Get("[ Classes ]  [ Account ]  [ Materials ]").ToLower())
                        {
                            case "classes":
                                //if classCheck=true:add to StudentMenu(save updates to list to show in account details)
                                break;
                            case "account":
                                StudentMenu.ViewStudents();
                                break;
                            case "materials":

                                break;
                            default:
                                string again = Get("Sorry, please try again or enter X to return to the main menu.").ToLower();
                                if (again=="x")
                                {
                                    sMenu = false;
                                }
                                break;
                        }
                            
                        break;
                   //main//
                   case "store": 

                        break;
                    default:
                        menu = Get("Sorry, please try one again: Professor, Student, or Store.");
                        break;
                }
            }

        }

        public static string Get(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        public static Student NewStudent()
        {
            string fName=Get("First Name:");
            string lName= Get("Last Name:");
            string id = fName+"."+ lName;
            string email = lName + "@student.com";
            Student person = new Student(id,fName, lName, email, Get("Password"), 0, "No History", "No History", false);
            return person;
        }
        public static Professor NewProfessor()
        {
            string fName = Get("First Name:");
            string lName = Get("Last Name:");
            string id = fName + "." + lName;
            string email = lName + "@professor.com";
            string classes = "Classes: ";
            Professor person = new Professor(id, fName, lName, email, Get("Password"), classes);
            return person;
        }



    }
}
