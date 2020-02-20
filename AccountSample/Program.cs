﻿using System;
using System.Collections.Generic;

namespace AccountSample
{
    class Program
    {
            //list of all students and accounts
            static List<Student> studentList = new List<Student>();

        static void Main(string[] args)
        {
            //read/write txt lists
            StudentMenu.AllStudents(studentList);


            bool main = true;
            while (main)
            {
                Console.WriteLine("Enter one of the following to start exploring: ");
                string menu = Get("[ Professor ] [ Student ] [ Store ]").ToLower();
                switch (menu)
                {
                    //main//
                    case "professor": //Create new, add class, update grades, user account(show current students and classes)

                        break;
                    //main//
                    case "student": //Create new, search classes, add classes, pay tuition, get materials, user account(show current classes, gpa, rented books? and grades)

                        //student menu
                        Console.WriteLine("");
                        switch (Get(""))
                        {

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
    }
}
