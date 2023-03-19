using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console; 

namespace HW_CollectionsSort
{
    internal class Program
    {
        class Student : IComparable
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public DateTime Birthday { get; set; }
            public string DiplomaTheme { get; set; }
            public bool Tails { get; set; }=false;
            public override string ToString()
            {
                return $" Last name: {LastName}\tFirst name: {FirstName}\t" +
                    $"Birthday: {Birthday.ToShortDateString()}\nDiploma theme: {DiplomaTheme}\tStuding debt: {Tails}\n";
            }
            public int CompareTo(object obj)
            {
                if (obj is Student)
                {
                    if(this.LastName!=(obj as Student).LastName) return this.LastName.CompareTo((obj as Student).LastName);
                    else return this.FirstName.CompareTo((obj as Student).FirstName);                
                }
                else throw new NotImplementedException();
            }
        }
        class NameComparer : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                
                if (obj1 is Student && obj2 is Student)
                {
                    if ((obj1 as Student).FirstName != (obj2 as Student).FirstName)
                    return String.Compare((obj1 as Student).FirstName, (obj2 as Student).FirstName); 
                    else return String.Compare((obj1 as Student).LastName, (obj2 as Student).LastName);
                }
                throw new NotImplementedException();
            }
        }
        class DateComparer: IComparer
        {
            public int Compare (object x, object y)
            {
                if (x is Student && y is Student)
                    return DateTime.Compare((x as Student).Birthday, (y as Student).Birthday); 
                throw new NotImplementedException();  
            }
        }
        class DiplomaThemeComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                if(x is Student && y is Student)
                        return String.Compare((x as Student).DiplomaTheme, (y as Student).DiplomaTheme);
                throw new NotImplementedException();
            }
        }
        class TailComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x is Student && y is Student)
                {
                    if ((x as Student).Tails == true && (y as Student).Tails == false) return 1; 
                    if ((x as Student).Tails == (y as Student).Tails) return 0; 
                    else return -1;
                }
                throw new NotImplementedException();
            }
        }

        static void Main(string[] args)
        {
            ArrayList auditory = new ArrayList()
            {
                new Student {
                    FirstName ="Jessey", LastName = "Pinkman",
                    Birthday = new DateTime(1988, 12, 10),
                    DiplomaTheme ="MethLab", Tails = true },
                new Student
                {
                    FirstName = "Walter", LastName = "White",
                    Birthday = new DateTime (1950, 01,01),
                    DiplomaTheme ="How to get money if u r a chemTeacher"
                },
                new Student
                {
                    FirstName = "Scyler", LastName="White",
                    Birthday  =new DateTime(1955, 11, 30),
                    DiplomaTheme ="Washing money", Tails=true
                },
                new Student
                {
                    FirstName="Hank", LastName="Schraider",
                    Birthday = new DateTime(1953, 09,20),
                    DiplomaTheme ="How to catch Hizenberg"
                },
                new Student
                {
                    FirstName= "Soul", LastName = "Goodman",
                    Birthday = new DateTime(1960, 03,24),
                    DiplomaTheme = "Justice agains drugs", Tails=true
                },
                new Student
                {
                    FirstName = "Mike", LastName = "Ehrmantraut",
                    Birthday = new DateTime(1941, 05,02),
                    DiplomaTheme = "Poiceman after get retire"
                },
                new Student
                {
                    FirstName = "Pete", LastName="Skinny",
                    Birthday = new DateTime(1984,04,20),
                    DiplomaTheme = "Drag dealing", Tails = true
                },
                new Student
                {
                    FirstName = "Steven", LastName="Gomez",
                    Birthday = new DateTime(1963,11,24),
                    DiplomaTheme = "Chasing"
                },
                new Student
                {
                    FirstName ="Badger", LastName = "None",
                    Birthday = new DateTime(1990,06,11),
                    DiplomaTheme = "Space invaders among us", Tails=true
                }
            };
            WriteLine("List of students:");
            //foreach (Student student in auditory) WriteLine(student);
            //auditory.Sort(); 
            //foreach (Student student in auditory) WriteLine(student);
            //auditory.Sort(new NameComparer());
            //foreach (Student student in auditory) WriteLine(student);
            //auditory.Sort(new DiplomaThemeComparer());
            //foreach (Student student in auditory) WriteLine(student);
            auditory.Sort(new TailComparer());
            foreach (Student student in auditory) WriteLine(student);

        }
    }
}
