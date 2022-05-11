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
                Console.WriteLine("______________________________________________");
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

                        Console.WriteLine("User selected option 1: Student data with List<T>!\n");

                        //initialize students list, fill with data
                        List<Student> studentsList = new List<Student>();
                        studentsList.Add(new Student(2000, "Mike Smith", "Freshman", "NY"));
                        studentsList.Add(new Student(4444, "Alice Smith", "Sophomore", "NC"));
                        studentsList.Add(new Student(2002, "Tom Brown", "Freshman", "NY"));
                        studentsList.Add(new Student(3000, "Sarah Smith", "Senior", "NY"));
                        studentsList.Add(new Student(1001, "Samantha Green", "Junior", "MD"));
                        studentsList.Add(new Student(4004, "NO_NAME", "Junior", "NJ"));
                        studentsList.Add(new Student(1000, "NO_NAME", "Freshman", "NJ"));

                        //list all student data
                        Console.WriteLine("List of unsorted students...");
                        foreach (Student s in studentsList) Console.WriteLine(s);
                        Console.WriteLine("\n");

                        //first search by status
                        Console.WriteLine("List of freshmen students...");
                        var lookupStatus = studentsList.ToLookup(s => s._Status);
                        foreach (Student s in lookupStatus["Freshman"]) Console.WriteLine(s);

                        //second search by state
                        Console.WriteLine("\nList of NY students...");
                        var lookupState = studentsList.ToLookup(s => s._State);
                        foreach (Student s in lookupState["NY"]) Console.WriteLine(s);

                        break;

                    case 2:

                        Console.WriteLine("User selected option 2: Student data with SortedList<TKey,TValue>!\n");

                        //initialize students list, fill with data
                        SortedList<int, Student> studentsSortedList = new SortedList<int, Student>();
                        studentsSortedList.Add(2000, new Student(2000, "Mike Smith", "Freshman", "NY"));
                        studentsSortedList.Add(4444, new Student(4444, "Alice Smith", "Sophomore", "NC"));
                        studentsSortedList.Add(2002, new Student(2002, "Tom Brown", "Freshman", "NY"));
                        studentsSortedList.Add(3000, new Student(3000, "Sarah Smith", "Senior", "NY"));
                        studentsSortedList.Add(1001, new Student(1001, "Samantha Green", "Junior", "MD"));
                        studentsSortedList.Add(4004, new Student(4004, "NO_NAME", "Junior", "NJ"));
                        studentsSortedList.Add(1000, new Student(1000, "NO_NAME", "Freshman", "NJ"));

                        //list all student data sorted by ID
                        Console.WriteLine("List of students sorted by ID...");
                        foreach (Student s in studentsSortedList.Values) Console.WriteLine(s);
                        Console.WriteLine("\n");

                        //search for user entered ID
                        Console.WriteLine("Please enter an ID to search for...");
                        int searchSortedID = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nResults of ID search: " + searchSortedID);

                        try
                        {
                            Student searchSortedValue = (Student)studentsSortedList[searchSortedID];
                            Console.WriteLine(searchSortedValue + "\n");
                        }
                        catch (KeyNotFoundException e)
                        {
                            Console.WriteLine("No results found! Please try again.");
                        }

                        break;

                    case 3:

                        Console.WriteLine("User selected option 3: Student data with Dictionary<TKey,TValue>!\n");

                        //initialize students list, fill with data
                        Dictionary<int, Student> studentsDictionary = new Dictionary<int, Student>();
                        studentsDictionary.Add(2000, new Student(2000, "Mike Smith", "Freshman", "NY"));
                        studentsDictionary.Add(4444, new Student(4444, "Alice Smith", "Sophomore", "NC"));
                        studentsDictionary.Add(2002, new Student(2002, "Tom Brown", "Freshman", "NY"));
                        studentsDictionary.Add(3000, new Student(3000, "Sarah Smith", "Senior", "NY"));
                        studentsDictionary.Add(1001, new Student(1001, "Samantha Green", "Junior", "MD"));
                        studentsDictionary.Add(4004, new Student(4004, "NO_NAME", "Junior", "NJ"));
                        studentsDictionary.Add(1000, new Student(1000, "NO_NAME", "Freshman", "NJ"));

                        //list all student data
                        Console.WriteLine("List of students...");
                        foreach (Student s in studentsDictionary.Values) Console.WriteLine(s);
                        Console.WriteLine("\n");

                        //list all student data sorted by ID
                        Console.WriteLine("List of students sorted by ID...");
                        var studentsSortedID = from data in studentsDictionary orderby data.Key ascending select data;
                        foreach (KeyValuePair<int, Student> kvp in studentsSortedID) Console.WriteLine(kvp.Value);
                        Console.WriteLine("\n");

                        //search for user entered ID
                        Console.WriteLine("Please enter an ID to search for...");
                        int searchDictionaryID = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nResults of ID search: " + searchDictionaryID);
                        
                        try
                        {
                            Console.WriteLine(studentsDictionary[searchDictionaryID] + "\n");
                        }
                        catch (KeyNotFoundException e)
                        {
                            Console.WriteLine("No results found! Please try again.");
                        }

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
    }
}
