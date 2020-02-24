using System;
using System.Collections.Generic;
using System.Text;

namespace AccountSample
{
    class Class : Person
    {
        public string ClassId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public int Tuition { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public TimeSpan DateSpan { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public string CrecId { get; set; }
        public int Grade { get; set; }
        public int Max { get; set; }
     

        public Class(string classId, string id, string name, string description, int credits, string fName, string lName, string email, string pw,
            DateTime dateStart, DateTime dateEnd, TimeSpan dateSpan, DateTime time, DateTime officeHours, string location, string crecId, int grade, int max)
            : base(id, fName, lName, email, pw)
        {
            ClassId = Name +id;
            Name = name;
            Description = description;
            Credits = credits;
            Tuition = 1200 * credits;
            Email = email;
            Pw = pw;
            DateStart = dateStart;
            DateEnd = dateEnd;
            DateSpan = dateSpan;
            Time = time;
            Location = location;
            CrecId = crecId;
            Grade = grade;
            Max = max;
        }

        public override string ToString()
        {
            return $"{Id}|{Name}|{Description}|{Credits}|{FName}|{LName}|{Email}|{Pw}|{DateStart}|{DateEnd}|{DateSpan}|{Time}|{Location}|{CrecId}|{Grade}|{Max}";
        }
    }
}
