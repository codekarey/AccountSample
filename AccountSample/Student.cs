using System;
using System.Collections.Generic;
using System.Text;

namespace AccountSample
{
    public class Student : Person
    {

        public int Gpa { get; set; }
        public int Tuition {get; set;}
        public string Transcript { get; set; }
        public string StudentStore { get; set; }
        public bool RentStatus { get; set; }

        public Student(string id, string fname, string lname, string email, string pw, int gpa, int tuition, string transcript, string studentStore, bool rentStatus)
            : base(id, fname, lname, email, pw)
        {
            Id = id;
            FName = fname;
            LName = lname;
            Email = email;
            Pw = pw;
            Gpa = gpa;
            Tuition = tuition;
            Transcript = transcript;
            StudentStore = studentStore;
            RentStatus = rentStatus;

        }

        public override string ToString()
        {
            return $"{Id}|{FName}|{LName}|{Email}|{Pw}|{Gpa}|{Tuition}|{Transcript}|{StudentStore}|{RentStatus}";
        }
    }
}
