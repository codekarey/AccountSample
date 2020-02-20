using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AccountSample
{
    class StudentMenu
    {
        //save all students to student file from main
        public static List<Student> AllStudents(List<Student> allStudents)
        {
            //reads from file and splits information by format below
            StreamReader reader = new StreamReader("../../../Students.txt");
            string split = reader.ReadLine();
            while (split != null)
            {
                string[] stds = split.Split('|');
                allStudents.Add(new Student(stds[0], stds[1], stds[2], stds[3], stds[4], stds[5], int.Parse(stds[6]), bool.Parse(stds[7]), stds[8], bool.Parse(stds[9])));
                split = reader.ReadLine();
            }
            reader.Close();
            return allStudents;
        }
        //update student changes to file
        
        //add a new student to file

        //register for class and save changes

        //student tuition and store payments

    }
}
