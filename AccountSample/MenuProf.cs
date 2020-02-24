using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AccountSample
{
    class MenuProf
    {
        public static List<Professor> ProfStream(List<Professor> allProf)
        {
            //reads from file and splits information by format below
            StreamReader reader = new StreamReader("../../../Professors.txt");
            string split = reader.ReadLine();
            while (split != null)
            {
                string[] prof = split.Split('|');
                allProf.Add(new Professor(prof[0], prof[1], prof[2], prof[3], prof[4], prof[5]));
                split = reader.ReadLine();
            }
            reader.Close();
            return allProf;
        }

        public static Professor AddProf(Professor newProf)
        {
            using (StreamWriter writer = new StreamWriter("../../../Professors.txt", true))
            {
                writer.WriteLine(newProf);
            }
            return newProf;
        }

        public static void Update(List<Professor> allProf)
        {
            using (StreamWriter writer = new StreamWriter("../../../Professors.txt", true))
            {
                foreach (Professor p in allProf)
                {
                    writer.WriteLine(p);
                }
                writer.Close();
            }
        }
    }
}
