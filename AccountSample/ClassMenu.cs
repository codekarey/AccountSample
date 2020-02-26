using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AccountSample
{
    class ClassMenu
    {
        //list of all classes
        public static List<Class> ClassStream(List<Class> allClasses)
        {
           //reads from file and splits information by format below
            StreamReader reader = new StreamReader("../../../Classes.txt");
            string split = reader.ReadLine();
            while (split != null)
            {
                string[] cls = split.Split('|');
                allClasses.Add(new Class(cls[0], cls[1], cls[2], cls[3], cls[4], cls[5], int.Parse(cls[6]), int.Parse(cls[7]), DateTime.Parse(cls[8]), DateTime.Parse(cls[9]), 
                    TimeSpan.Parse(cls[10]), DateTime.Parse(cls[11]), cls[12], cls[13], int.Parse(cls[14]), int.Parse(cls[15]), cls[16]));
                split = reader.ReadLine();
            }
            reader.Close();
            return allClasses;
        }
        public static void ViewClasses()
        {
            List<Class> classes = new List<Class>();
            ClassStream(classes);
            Console.WriteLine("-\t-\t-\t-\t-\t-\t-\t-\t-\t-");
            foreach (Class c in classes)
            {
                Console.WriteLine(c.Name+" ] ID: "+c.ClassId+" |  Description: "+c.Description+" |\n" +
                    "Date: "+c.DateStart.ToShortDateString()+" - "+c.DateEnd.ToShortDateString()+" | " +
                    "Time: "+c.Time.ToShortTimeString()+" - "+c.Time.Subtract(c.DateSpan).ToShortTimeString()+ " | Location: " + c.Location + " |\n" +
                    "Prerequisites: " + c.CrecId + "  | Credits: "+c.Credits+" | Tuition: "+c.Tuition+"\n-");
            } 
        }
        public static Class AddClass(Class newClass)
        {

            using (StreamWriter writer = new StreamWriter("../../../Classes.txt", true))
            {
                writer.WriteLine(newClass);
            }
            return newClass;
        }

        public static void Update(List<Class> classes)
        {
            using (StreamWriter writer = new StreamWriter("../../../Classes.txt", false))
            {
                foreach (Class c in classes)
                {
                    writer.WriteLine(c);
                }
                writer.Close();
            }
        }


        //check date/time

        //check tuition(credits) and tstatus

        //Prereqs(classids)

        //int maxstudent> List<Student> maxStudent.Count (and int-1 while list+1)

        //ClassCheck(bool all)

    }
}
