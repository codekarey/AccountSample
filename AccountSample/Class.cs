using System;
using System.Collections.Generic;
using System.Text;

namespace AccountSample
{
    class Class
    {
        public string ClassId { get; set; }
        public string ProfId { get; set; }
        public string ProfEmail { get; set; }
        public string ProfPw { get; set; }
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
        public string Students { get; set; }
     

        public Class(string classId, string profId, string profEmail, string profPw, string name, string description, int credits, int tuition,
            DateTime dateStart, DateTime dateEnd, TimeSpan dateSpan, DateTime time, string location, string crecId, int grade, int max, string students)
        {
            ClassId = classId;
            ProfId = profId;
            ProfEmail = profEmail;
            ProfPw = profPw;
            Name = name;
            Description = description;
            Credits = credits;
            Tuition = tuition;
            DateStart = dateStart;
            DateEnd = dateEnd;
            DateSpan = dateSpan;
            Time = time;
            Location = location;
            CrecId = crecId;
            Grade = grade;
            Max = max;
            Students = students;
        }

        public override string ToString()
        {
            return $"{ClassId}|{ProfId}|{ProfEmail}|{ProfPw}|{Name}|{Description}|{Credits}|{Tuition}|{DateStart}|{DateEnd}|{DateSpan}|{Time}|{Location}|{CrecId}|{Max}|{Grade}|{Students}";
        }
    }
}
