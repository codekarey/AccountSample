using System;
using System.Collections.Generic;

namespace AccountSample
{
    class Program
    {
        //list of all accounts and classes
        static List<Student> studentList = new List<Student>();
        static List<Class> classList = new List<Class>();
        static List<Professor> professorList = new List<Professor>();
        static Professor thisProf;
        static Student thisStudent;

        static void Main(string[] args)
        {

            StudentMenu.StudentStream(studentList);
            MenuProf.ProfStream(professorList);
            ClassMenu.ClassStream(classList);
            bool loop = true;
            while (loop)
            {

                StudentMenu.Update(studentList);
                MenuProf.Update(professorList);
                ClassMenu.Update(classList);

                Console.WriteLine("Enter one of the following to start exploring: ");
                string create = Get("[ New Account ]  [ Log In ]").ToLower();
                switch (create)
                {
                    case "new account":
                    case "new":
                        Create();
                        loop = false;
                        break;
                    case "log in":
                    case "login":
                        string user = Get("User Id (Firstname.Lastname):");
                        string uId;
                        foreach (Student s in studentList)
                        {
                            if (user == s.Id)
                            {
                                thisStudent = s;
                                uId = s.Id;
                            }
                        }
                        foreach (Professor p in professorList)
                        {
                            if (user == p.Id)
                            {
                                thisProf = p;
                                uId = p.Id;
                            }
                        }
                        break;
                    default: break;
                }
                //profmenu
                if (thisProf != null)
                {
                    bool pMenu = true;
                    while (pMenu)
                    {
                        //Create new, add class, update grades, user account(show current students and classes)
                        ClassMenu.Update(classList);
                        string pick = Get("[ Create Class ]  [ My Classes ]  [ My Students ]   [ Exit ]").ToLower();
                        switch (pick)
                        {
                            case "create class":
                                Class newClass = NewClass(thisProf);
                                ClassMenu.AddClass(newClass);
                                
                                break;

                            case "my classes":
                                ClassMenu.ClassStream(classList);
                                foreach (Class c in classList)
                                {
                                    Console.WriteLine("-");
                                    if (c.ProfId == thisProf.Id)
                                    {
                                        Console.WriteLine(c.Name + " ] ID: " + c.ClassId + " |  Description: " + c.Description + " |\n" +
                                        "Date: " + c.DateStart.ToShortDateString() + " - " + c.DateEnd.ToShortDateString() + " | " +
                                        "Time: " + c.Time.ToShortTimeString() + " - " + c.Time.Subtract(c.DateSpan).ToShortTimeString() + " | Location: " + c.Location + " |\n" +
                                        "Prerequisites: " + c.CrecId + "  | Credits: " + c.Credits + " | Tuition: " + c.Tuition + "\n-");
                                    }
                                }
                                break;
                            case "my students":

                                break;
                            case "exit":
                                pMenu = false;
                                break;
                            default:
                                break;
                        }
                    }
                }
                //student menu
                else if (thisStudent != null)
                {
                    //Create new, search classes, add classes, pay tuition, get materials, user account(show current classes, gpa, rented books? and grades)
                    bool sMenu = true;
                    bool paid;
                    while (sMenu)
                    {
                        //StudentMenu.Update(studentList);
                        //ClassMenu.Update(classList);
                        switch (Get("[ Classes ]  [ Account ]").ToLower())
                        {
                            case "classes":
                                //if classCheck=true:add to StudentMenu(save updates to list to show in account details)
                                ClassMenu.ViewClasses();
                                //ClassMenu.ClassStream(classList);
                                string addClass = Get("Enter the Class Id you want to add to your account.");
                                foreach (Class c in classList)
                                {
                                    if (addClass == c.ClassId)
                                    {
                                        StudentMenu.StudentClass(classList, studentList, thisStudent, addClass);

                                        Console.WriteLine("You have added this class to your account\nBefore it is added to your transcript you need to pay your tuition.");
                                    }
                                }
                                break;
                            case "account":
                                StudentMenu.StudentStream(studentList);
                                string pass = Get("Enter your password");
                                foreach (Student s in studentList)
                                {
                                    if (pass == s.Pw)
                                    {
                                        Console.WriteLine("\nWelcome to your account " + s.FName + "\n" +
                                        "Transcript: " + s.Transcript + "\t GPA: " + s.Gpa);
                                        //Payments
                                        StudentMenu.Payments(Get("\n[ Tuition ]").ToLower(), thisStudent, studentList);
                                    }
                                }
                                break;
                            default:
                                string again = Get("Sorry, please try again or enter X to return to the main menu.").ToLower();
                                if (again == "x")
                                {
                                    sMenu = false;
                                }
                                break;
                        }
                    }
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
            string fName = Get("First Name:");
            string lName = Get("Last Name:");
            string id = StudentMenu.StudentID(fName, lName);
            string email = lName + "@student.com";
            string pw = Get("Password");
            Student person = new Student(id, fName, lName, email, pw, 0, 0, "No History", "No History", false);
            Console.WriteLine("Please save the following information for your records:\nID: " + id + "\tEmail: " + email);
            return person;
        }
        public static Professor NewProfessor()
        {
            string fName = Get("First Name:");
            string lName = Get("Last Name:");
            string id = new string(fName + "." + lName);
            string email = lName + "@professor.com";
            string classes = "Classes: ";
            Professor person = new Professor(id, fName, lName, email, Get("Password"), classes);
            return person;
        }

        public static Class NewClass(Professor creator)
        {

            string profId = creator.Id;
            string profEmail = creator.Email;
            string profPw = creator.Pw;
            string name = Get("Class name:");
            string classId = name + creator.LName;
            string description = Get("Describe the class.");
            int credits = int.Parse(Get("# of credits:"));
            int tuition = credits * 300;
            DateTime dateStart = DateTime.Parse(Get("Start Date (in format)"));
            DateTime dateEnd = DateTime.Parse(Get("End Date (int format"));
            DateTime time = DateTime.Parse(Get("Time class starts:"));
            double min = double.Parse(Get("Length of class in # of minutes:"));
            TimeSpan dateSpan = time - time.AddMinutes(min);
            string location = Get("Location");
            string crecId = Get("Prerequisite [ Yes : ClassID ] or [ No : X ])");
            int grade = 0;
            int max = int.Parse(Get("The max # of students for this class"));
            Class newClass = new Class(classId, profId, profEmail, profPw, name, description, credits, tuition, dateStart, dateEnd, dateSpan, time, location, crecId, grade, max,"");
            return newClass;
        }
        public static string Create()
        {
            string type = Get("[ Professor ] [ Student ]");
            switch (type)
            {
                case "professor":
                    thisProf = MenuProf.AddProf(NewProfessor());
                    MenuProf.Update(professorList);
                    return "p";
                case "student":
                    StudentMenu.AddStudent(NewStudent());
                    StudentMenu.Update(studentList);
                    return "s";
            }
            return "";
        }
    }
}

