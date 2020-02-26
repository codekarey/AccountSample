using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AccountSample
{
    class StudentMenu
    {
        //save 
        public static List<Student> StudentStream(List<Student> allStudents)

        {
            //reads from file and splits information by format below
            StreamReader reader = new StreamReader("../../../Students.txt");
            string split = reader.ReadLine();
            while (split != null)
            {
                string[] stds = split.Split('|');
                allStudents.Add(new Student(stds[0], stds[1], stds[2], stds[3], stds[4], int.Parse(stds[5]), int.Parse(stds[6]), stds[7], stds[8], bool.Parse(stds[9])));
                split = reader.ReadLine();
            }
            reader.Close();
            return allStudents;
        }
        public static void ViewStudents()
        {
            List<Student> students = new List<Student>();
            StudentStream(students);
            int i = 1;
            foreach(Student s in students)
            {
                Console.WriteLine("Students\n"+i+" ] "+s.FName+" "+s.LName+"  ID: "+s.Id+"   Email: "+s.Email);
                i++;
            }
        }
        //add a new student to file
        public static Student AddStudent(Student newStudent)
        {
            using(StreamWriter writer = new StreamWriter("../../../Students.txt", true))
            {
                writer.WriteLine(newStudent);
            }
            return newStudent;
        }
        public static void StudentClass(List<Class> classList, List<Student> students, Student s, string cID)
        {
            //if date/time, prereq, maxstudent all checkout: can add student id to class list and maxstudent-1 (in ClassMenu)
            //list of student classes for account and detailed information
            foreach (Class c in classList)
            {
                if (cID == c.ClassId&& c.Max>=0)
                {
                    s.Tuition = +c.Tuition;
                    if(s.Transcript=="No History")
                    {
                        s.Transcript = "&" + c.ClassId;
                    }
                    else if (s.Transcript.StartsWith("&"))
                    {
                        s.Transcript += "&" + c.ClassId;
                    }
                    Update(students);
                    if (c.Students == "")
                    {
                        c.Students = "&" + s.Id;
                    }
                    else if (c.Students.StartsWith("&"))
                    {
                        c.Students += "&"+s.Id;
                    }
                    c.Max = c.Max-1;
                    ClassMenu.Update(classList);
                }
            }
        }
        //student tuition and store payments
        public static bool Payments(string option, Student thisStudent, List<Student> studentList)
        {
            bool paid=false;
            if (option == "tuition")
            {
                Console.WriteLine("Tuition Due: "+thisStudent.Tuition+"\nPay now? [ Y / N ]");
                if (Console.ReadLine().ToLower() == "y")
                {
                    thisStudent.Tuition = 0;
                    paid = true;
                    Console.WriteLine("Thank you.\nTuition Due: "+thisStudent.Tuition);
                    Update(studentList);
                }
            }
            if (option == "store")
            {
                //saves to student account (rent/buy books and materials saved to account)
                paid = true;
            }
            return paid;
        }
        public static string StudentID(string fName, string lName)
        {
            return (fName + "." + lName).ToString();
        }

        public static void Update(List<Student> students)
        {
            using (StreamWriter writer = new StreamWriter("../../../Students.txt", false))
            {
                foreach(Student s in students)
                {
                    writer.WriteLine(s);
                }
                writer.Close();
            }
        }

    }
}
