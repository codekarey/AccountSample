using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AccountSample
{
    class ClassMenu
    {
        //new class

        //list of all classes
        public static List<Class> AllClasses(List<Class> allClasses)
        {
           //reads from file and splits information by format below
            StreamReader reader = new StreamReader("../../../Classes.txt");
            string split = reader.ReadLine();
            while (split != null)
            {
                string[] cls = split.Split('|');
                allClasses.Add(new Class(cls[0], cls[1], cls[2], cls[3], int.Parse(cls[4]), cls[5], cls[6], cls[7], cls[8], DateTime.Parse(cls[9]), DateTime.Parse(cls[10]), 
                    TimeSpan.Parse(cls[10]), DateTime.Parse(cls[11]), DateTime.Parse(cls[12]), cls[13], cls[14], int.Parse(cls[15]), int.Parse(cls[16])));
                split = reader.ReadLine();
            }
            reader.Close();
            return allClasses;
        }
        public static void ViewClasses()
        {
            List<Class> classes = new List<Class>();
            AllClasses(classes);
            int i = 1;
            Console.WriteLine("Class\t|\tClass ID\t|\t And more.....");
            foreach (Class c in classes)
            {
                Console.WriteLine(c.Name+"\t\t"+c.ClassId);
                i++;
            }
        }
        //check date/time

        //check tuition(credits) and tstatus

        //Prereqs(classids)

        //int maxstudent> List<Student> maxStudent.Count (and int-1 while list+1)

        //ClassCheck(bool all)

    }
}
