using System;
using System.Collections.Generic;
using System.Text;

namespace AccountSample
{
    class Student
    {
        public string Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        private string Password { get; set; }
        public string Gpa { get; set; }
        public int Tuition {get; set;}
        public bool TuitionStatus { get; set; }
        public string StudentStore { get; set; }
        public bool StudentStoreStatus { get; set; }

        
        public Student()
        {
            Gpa = "";
            Tuition = 0;
            StudentStore = "";
            StudentStoreStatus = true;

        }

        public Student(string id, string fname, string lname, string email, string password, string gpa, int tuition, bool tuitionStatus, string studentStore, bool studentStorestatus)
        {
            Id = id;
            Fname = fname;
            Lname = lname;
            Email = email;
            Password = password;
            Gpa = gpa;
            Tuition = tuition;
            TuitionStatus = tuitionStatus;
            StudentStore = studentStore;
            StudentStoreStatus = studentStorestatus;
        }

        public override string ToString()
        {
            return $"{Id}|{Fname} {Lname}|{Email}|{Gpa}|{Tuition}|{TuitionStatus}|{StudentStore}|{StudentStoreStatus}";
        }
    }
}
