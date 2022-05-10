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
                        Console.WriteLine("User selected option 2: Student data with List<T>!\n");

                        //initialize students list, fill with data
                        List<Student> students = new List<Student>();
                        List<Student> studentsCopy1 = new List<Student>();
                        List<Student> studentsCopy2 = new List<Student>();
                        students.Add(new Student(2000, "Mike Smith", "Freshman", "NY"));
                        students.Add(new Student(4444, "Alice Smith", "Sophomore", "NC"));
                        students.Add(new Student(2002, "Tom Brown", "Freshman", "NY"));
                        students.Add(new Student(3000, "Sarah Smith", "Senior", "NY"));
                        students.Add(new Student(1001, "Samantha Green", "Junior", "MD"));
                        students.Add(new Student(4004, "NO_NAME", "Junior", "NJ"));
                        students.Add(new Student(1000, "NO_NAME", "Freshman", "NJ"));
                        students.Add(new Student(1000, "NO_NAME", "Freshman", "NJ"));
                        Console.WriteLine("List of students...");
                        foreach (Student s in students)
                        {
                            //print list
                            Console.WriteLine(s);
                            //copy list
                            studentsCopy1.Add(new Student(s));
                            studentsCopy2.Add(new Student(s));
                        }
                        Console.WriteLine("\n");

                        //first search by status
                            //List<Student> studentsFreshmen = (List<Student>)students.ToLookup(s => s._Status == "Freshman");
                        int indexFreshmanStudent;
                        int studentsCapacity = students.Count;
                        List<Student> studentsFreshmen = new List<Student>();

                        for (int i = 0; i < studentsCapacity-1; i++)
                        {
                            indexFreshmanStudent = studentsCopy1.FindIndex(new FindStudentStatus("Freshman").FindStudentStatusPredicate);
                            studentsFreshmen.Add(new Student(students[indexFreshmanStudent]));
                            studentsCopy1.RemoveAt(indexFreshmanStudent);
                        }
                        
                        Console.WriteLine("List of freshmen students...");
                        foreach (Student s in studentsFreshmen) Console.WriteLine(s);
                        Console.WriteLine("\n");

                        //second search by state
                            //List<Student> studentsNY = (List<Student>)students.ToLookup(s => s._State == "NY");
                        int indexNYStudent;
                        List<Student> studentsNY = new List<Student>();
                        for (int i = 0; i < studentsCapacity; i++)
                        {
                            indexNYStudent = studentsCopy2.FindIndex(new FindStudentState("NY").FindStudentStatePredicate);
                            studentsFreshmen.Add(new Student(students[indexNYStudent]));
                            studentsCopy2.RemoveAt(indexNYStudent);
                        }
                        Console.WriteLine("List of NY students...");
                        foreach (Student s in studentsNY) Console.WriteLine(s);
                        Console.WriteLine("\n");

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

            public Student(Student newStudent)
            {
                _ID = newStudent._ID;
                _Name = newStudent._Name;
                _Status = newStudent._Status;
                _State = newStudent._State;
            }

            public override string ToString()
            {
                return _ID + " " + _Name + " " + _Status + " " + _State;
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

        public class FindStudentStatus
        {
            private string _Status;

            public FindStudentStatus(string status) => _Status = status;

            public bool FindStudentStatusPredicate(Student student) => student?._Status == _Status;
        }

        public class FindStudentState
        {
            private string _State;

            public FindStudentState(string state) => _State = state;

            public bool FindStudentStatePredicate(Student student) => student?._Status == _State;
        }
    }
}
