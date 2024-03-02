using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDT1
{
    internal class Program
    {
        static List<Student> StudentList = new List<Student>();
        static List<DegreeProgram> programList = new List<DegreeProgram>();
        static void Main(string[] args)
        {
            int opt=0;
            while(opt!=8)
            {
                Console.Clear();
                header();
                opt = Menu();
                if(opt==1)
                {
                    Console.Clear();
                    header();
                    if (programList.Count>0)
                    {
                        Student s = takeInputForStudent();
                        AddInto_studentList(s);
                    }
                }
                if(opt==2)
                {
                    Console.Clear();
                    header();
                    DegreeProgram d = takeInput_Degree();
                    Add_Into_DegreeList(d);
                }
                if(opt==3)
                {
                    Console.Clear();
                    header();
                    List<Student> SortedStudentList = new List<Student>();
                    SortedStudentList = sortStudentsByMerit();
                    giveAdmission(SortedStudentList);
                    printStudent();
                }
                if(opt==4)
                {
                    Console.Clear();
                    header();
                    ViewRegStudent();
                }
                if(opt==5)
                {
                    Console.Clear();
                    header();
                    string dName;
                    Console.WriteLine("Enter Degree Name: ");
                    dName = Console.ReadLine();
                    ViewStudent_inDegree(dName);
                }
                if(opt==6)
                {
                    Console.Clear();
                    header();
                    Console.WriteLine("Enter Student name: ");
                    string name = Console.ReadLine();
                    Student s = StudentPresent(name);
                    if(s!=null)
                    {
                        viewSubjects(s);
                        registerSubject(s);
                    }
                }
                if(opt==7)
                {
                    Console.Clear();
                    header();
                    CalculateFee();
                }
                if(opt==8)
                {
                    Console.Clear();
                    header();
                    Console.WriteLine("Exiting the Program.");
                    
                }
                Console.ReadKey();
            }
           
        }
        static Student StudentPresent(string name)
        {
            foreach (Student std in StudentList)
            {
                if (name == std.name && std.regProgram != null)
                {
                    return std;
                }
            }
            return null;
        }
        static void CalculateFee()
        {
            foreach (Student std in StudentList)
            {
                if (std.regProgram != null)
                {
                    Console.WriteLine(std.name + " has " + std.CalculateFee() + " Fee ");
                }

            }
        }
        static void registerSubject(Student s)
        {
            Console.WriteLine("Enter how many subjects you want to register");
            int subCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < subCount; i++)
            {
                Console.WriteLine("Enter the subject count: ");
                string code = Console.ReadLine();
                bool Flag = false;
                foreach (Subject sub in s.regProgram.subjects)
                {
                    if (code == sub.code && !(s.regSubjects.Contains(sub))) ;
                    {
                        s.regStudentSubject(sub);
                        Flag = true;
                        break;
                    }
                }
                if (Flag == false)
                {
                    Console.WriteLine("Enter Invalid Course:(");
                    i--;
                }
            }
        }
        static List<Student> sortStudentsByMerit()
        {
            List<Student> SortedList = new List<Student>();
            foreach (Student std in StudentList)
            {
                std.CalculateMerit();
            }
            SortedList = StudentList.OrderByDescending(o => o.merit).ToList();
            return SortedList;
        }
        static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach (Student std in sortedStudentList)
            {
                foreach (DegreeProgram d in std.preferences)
                {
                    if (d.seats > 0 && std.regProgram == null)
                    {
                        std.regProgram = d;
                        d.seats--;
                        break;
                    }
                }
            }
        }
        static void printStudent()
        {
            foreach (Student std in StudentList)
            {
                if (std.regProgram != null)
                {
                    Console.WriteLine(std.name + " got admission in " + std.regProgram.degreeName);
                }
                else
                {
                    Console.WriteLine(std.name + " didn't got admission:(");
                }
            }
        }
        static void ClearScreen()
        {
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
            Console.Clear();
        }
        static void ViewStudent_inDegree(string degName)
        {
            Console.WriteLine("Name\tFSC Marks\tECAT Marks\tAge");
            foreach (Student s in StudentList)
            {
                if (s.regProgram != null)
                {
                    if (degName == s.regProgram.degreeName)
                    {
                        Console.WriteLine(s.name + "\tt" + s.fscMarks + "\t\t" + s.ecatMarks + "\t\t" + s.age);
                    }
                }
            }
        }
        static void ViewRegStudent()
        {
            Console.WriteLine("Name\tFSC Marks\tECAT Marks\tAge");
            foreach (Student s in StudentList)
            {
                if (s.regProgram != null)
                {
                    Console.WriteLine(s.name + "\t\t" + s.fscMarks + "\t\t" + s.ecatMarks + "\t\t" + s.age);
                }
            }

        }
        static void Add_Into_DegreeList(DegreeProgram d)
        {
            programList.Add(d);
        }
        static DegreeProgram takeInput_Degree()
        {
            string degreeName;
            float degreeDuration;
            int seats;
            Console.WriteLine("Enter your degree name: ");
            degreeName = Console.ReadLine();
            Console.WriteLine("Enter your degree duration: ");
            degreeDuration = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the available seats");
            seats = int.Parse(Console.ReadLine());
            DegreeProgram d = new DegreeProgram(degreeName, degreeDuration, seats);
            Console.WriteLine("How many subjects you want to enter: ");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                d.AddSubject(takeInput_Subject());
            }
            return d;
        }
        static Subject takeInput_Subject()
        {
            string code, type;
            int creditHour, subjectFee;
            Console.WriteLine("Enter Subject Code: ");
            code = Console.ReadLine();
            Console.WriteLine("Enter Subject Type: ");
            type = Console.ReadLine();
            Console.WriteLine("Enter Subject Credit Hours: ");
            creditHour = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Subject Fee: ");
            subjectFee = int.Parse(Console.ReadLine());
            Subject s = new Subject(code, type, creditHour, subjectFee);
            return s;
        }
        static void AddInto_studentList(Student s)
        {
            StudentList.Add(s);
        }
        static Student takeInputForStudent()
        {
            string name;
            int age;
            double fscMarks;
            double ecatMarks;
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            Console.Write("Enter Student Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Student Age: ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Enter Student FSc Marks: ");
            fscMarks = double.Parse(Console.ReadLine());
            Console.Write("Enter Student Ecat Marks: ");
            ecatMarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Programs");
            viewDegreePrograms();
            Console.Write("Enter how many preferences to Enter: ");
            int Count = int.Parse(Console.ReadLine());
            for (int x = 0; x < Count; x++)
            {
                string degName = Console.ReadLine();
                bool flag = false;
                foreach (DegreeProgram dp in programList)
                {
                    if (degName == dp.degreeName && !(preferences.Contains(dp)))
                    {
                        preferences.Add(dp);
                    }
                    flag = true;
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter Valid Degree Program Name");
                    x = -1;
                }
            }
            Student s = new Student(name, age, fscMarks, ecatMarks, preferences);
            return s;
        }
        static void viewDegreePrograms()
        {
            foreach (DegreeProgram dp in programList)
            {
                Console.WriteLine(dp.degreeName);
            }
        }

        static void header()
        {
            Console.WriteLine("*****************************************************");
            Console.WriteLine("                       UAMS                          ");
            Console.WriteLine("*****************************************************");
        }

        static void viewSubjects(Student s)
        {
            if (s.regProgram!= null)
            {
                Console.WriteLine("Subject Code\t\tSubject Type");
                foreach (Subject sub in s.regProgram.subjects)
                {
                    Console.WriteLine(sub.code + "\t\t" + sub.type);
                }
            }
        }
        static int Menu()
        {
            int option ;
            Console.WriteLine("Welcome to University Admissions Management System:)");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate MAC");
            Console.WriteLine("4. View Students of a Specific Program");
            Console.WriteLine("5. View Registered Students");
            Console.WriteLine("6. Calculate Fees for all Registered Students");
            Console.WriteLine("7. Register Subject for a Specific Student");
            Console.WriteLine("8. Exit");
        again:
            Console.WriteLine("Enter your option: ");
            option = int.Parse(Console.ReadLine());
            if(option<=0||option>8)
            {
                Console.WriteLine("Invalid Option! Try Again..");
                goto again;
            }
            return option;
        }
    }
}
