using System;
using System.Collections.Generic;
using System.Linq;

namespace Kattis_Problem_Roll_Call
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> listOfNames = new List<string>();

            for (int i = 0; i < 200; i++)
            {
                var name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    listOfNames.Add(name);
                }
                else
                {
                    break;
                }

            }


            string Names = null;

            for (int i = 0; i < listOfNames.Count; i++)
            {
                Names = Names + listOfNames[i] + " ";
            }


            string[] arryOfNames = Names.TrimEnd().Split(" ");

            List<string> FirstNames = new List<string>();
            List<string> LastNames = new List<string>();

            for (int i = 0; i < arryOfNames.Length; i++)
            {
                if (i % 2 == 0)
                {
                    FirstNames.Add(arryOfNames[i]);
                }
                else
                {
                    LastNames.Add(arryOfNames[i]);
                }
            }

            List<Studant> listOfStudants = new List<Studant>();

            for (int i = 0; i < listOfNames.Count; i++)
            {
                listOfStudants.Add(new Studant { FirstName = FirstNames[i], LastName = LastNames[i] });

            }
            var studnatsOnOrder = listOfStudants.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList();

            List<string> theSameFirstName = new List<string>();

            for (int i = 0; i < studnatsOnOrder.Count; i++)
            {
                for (int f = i + 1; f < studnatsOnOrder.Count; f++)
                {

                    if (studnatsOnOrder[i].FirstName == studnatsOnOrder[f].FirstName)
                    {


                        theSameFirstName.Add(studnatsOnOrder[i].FirstName);

                    }

                }

            }
            for (int i = 0; i < studnatsOnOrder.Count; i++)
            {
                for (int l = 0; l < theSameFirstName.Count; l++)
                {
                    if (studnatsOnOrder[i].FirstName.Contains(theSameFirstName[l]))
                    {
                        studnatsOnOrder[i].FirstName = studnatsOnOrder[i].FirstName + "*";

                    }

                }


            }
            for (int i = 0; i < studnatsOnOrder.Count; i++)
            {

                if (studnatsOnOrder[i].FirstName.Contains("*"))//

                {
                    var IndexOfStar = studnatsOnOrder[i].FirstName.IndexOf("*");
                    var nameWithoutStar = studnatsOnOrder[i].FirstName.Remove(IndexOfStar);
                    Console.WriteLine(nameWithoutStar + " " + studnatsOnOrder[i].LastName);

                }


                else
                {
                    Console.WriteLine(studnatsOnOrder[i].FirstName);
                }



            }



            Console.WriteLine();
        }
        public class Studant
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }


        }
    }
}