using System;
using System.Collections.Generic;
using System.Text;

namespace AccountSample
{
    class Professor: Person
    {
        public string Classes { get;set; }

        public Professor(string id, string fName, string lName, string email, string pw, string classes) 
            : base(id, fName, lName, email,  pw)
        {
            Id = id;
            FName = fName;
            LName = lName;
            Email = email;
            Pw = pw;
            Classes = classes;
        }

        public override string ToString()
        {
            return $"{Id}|{FName}|{LName}|{Email}|{Pw}|{Classes}";
        }

        //public List<Class> AdminClass(Professor newProf, List<Class> allClasses, List<Student> allStudents)
        //{
        //    List<Class> admin = new List<Class>();

        //    foreach(Class c in allClasses)
        //    {
        //        if (c.Id == newProf.Id)
        //        {
        //            Console.Write(c.Name+" "+c.ClassId+" ");
        //            admin.Add(c);
        //        }

        //    }
        //    return admin;
        //}
    }
}
