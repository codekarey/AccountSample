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
                allStudents.Add(new Student(stds[0], stds[1], stds[2], stds[3], stds[4], int.Parse(stds[5]), stds[6], stds[7], bool.Parse(stds[8])));
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
        //register for class and save changes when classCheck==true
        public static void StudentClasses(Student student, List<Class> allClasses)
        {
            //if date/time, prereq, maxstudent all checkout: can add student id to class list and maxstudent-1 (in ClassMenu)
            //list of student classes for account and detailed information
            bool another = true;
            while (another)
            {

                Console.WriteLine("Enter the class name or Id to add to your account.");
                string find = Console.ReadLine().ToLower();

                bool match = false;
                    //update tuition and tuitionStatus
                    foreach(Class c in allClasses)
                    {
                        if ((find == c.Id)||find==c.Name.ToLower())
                        {
                            student.Tuition =+ c.Tuition;
                            
                            student.Transcript=student.Transcript+"&\n"+(c.Id.ToString());
                        }
                    }
                
                if (!match)
                {
                    Console.WriteLine("Sorry, there is not a class with that ID");
                }
            }

            
        }
        //student tuition and store payments
        public static bool Payments(string option, Student thisStudent)
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
                }
            }
            if (option == "store")
            {
                //saves to student account (rent/buy books and materials saved to account)
                paid = true;
            }
            return paid;
        }

        public static void Update(List<Student> students)
        {
            using (StreamWriter writer = new StreamWriter("../../../Students.txt", true))
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
