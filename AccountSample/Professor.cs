using System;
using System.Collections.Generic;
using System.Text;

namespace AccountSample
{
    class Professor
    {
        public string Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        private string Password { get; set; }

        public Professor()
        {

        }
    }
}
