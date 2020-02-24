using System;
using System.Collections.Generic;
using System.Text;

namespace AccountSample
{
    public class Person
    {
        public string Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Pw {get; set;}

        public Person(string id, string fName, string lName, string email, string pw)
        {

            Id = id;
            FName = fName;
            LName = lName;
            Email = email;
            Pw = pw;
        }
    }
}
