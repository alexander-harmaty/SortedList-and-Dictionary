using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCS_426_Mod_9
{
    class Program
    {
        static void Main(string[] args)
        {
            bool programRunning = true;
            int option;
            Console.WriteLine("Welcome to Module 9!");
            
            while (programRunning)
            {
                Console.WriteLine("MENU\n____\n" +
                    "1) Student data with List<T>\n" +
                    "2) Student data with SortedList<TKey,TValue>\n" +
                    "3) Student data with Dictionary<TKey,TValue>\n" +
                    "4) END PROGRAM!\n");
                Console.WriteLine("Please select and option to continue...");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        //initialize students list and fill with data
                        List<Student> students = new List<Student>();
                        students.Add(new Student(2000, "Mike Smith", "Freshman", "NY"));
                        students.Add(new Student(4444, "Alice Smith", "Sophomore", "NC"));
                        students.Add(new Student(2002, "Tom Brown", "Freshman", "NY"));
                        students.Add(new Student(3000, "Sarah Smith", "Senior", "NY"));
                        students.Add(new Student(1001, "Samantha Green", "Junior", "MD"));
                        students.Add(new Student(4004, "NO_NAME", "Junior", "NJ"));
                        students.Add(new Student(1000, "NO_NAME", "Freshman", "NJ"));
                        students.Add(new Student(1000, "NO_NAME", "Freshman", "NJ"));

                        //first search by status
                        List<Student> studentsFreshmen = (List<Student>)students.ToLookup(s => s._Status == "Freshman");
                        
                        //second search by state
                        List<Student> studentsNY = (List<Student>)students.ToLookup(s => s._State == "NY");

                        //print lists
                        foreach (Student s in students)
                        {
                            Console.WriteLine(s);
                        }
                        foreach (Student s in studentsFreshmen)
                        {
                            Console.WriteLine(s);
                        }
                        foreach (Student s in studentsNY)
                        {
                            Console.WriteLine(s);
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        programRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public class Student : IEnumerable<Student>
        {
            public int _ID;
            public string _Name;
            public string _Status;
            public string _State;

            public Student(int id, string name, string status, string state)
            {
                _ID = id;
                _Name = name;
                _Status = status;
                _State = state;
            }

            public IEnumerator<Student> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}
