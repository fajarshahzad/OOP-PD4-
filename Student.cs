using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDT1
{
    internal class Student
    {
        public string name;
        public int age;
        public double fscMarks;
        public double merit;
        public double ecatMarks;
        public List<DegreeProgram> preferences;
        public List<Subject> regSubjects;
        public DegreeProgram regProgram;
        public Student(string name, int age, double fscMarks, double ecatMarks, List<DegreeProgram> preferences)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.preferences = preferences;
            regSubjects = new List<Subject>();
        }
        public void CalculateMerit()
        {
            this.merit = (((fscMarks / 1100) * 0.45F) + ((ecatMarks / 400) * 0.55F) * 100);
        }
        public bool regStudentSubject(Subject s)
        {
            int stCH = getCreditHour();
            if(regProgram!=null&& regProgram.isSubject(s)&&stCH+s.creditHour<=9)
            {
                regSubjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int getCreditHour()
        {
            int count = 0;
            foreach(Subject s in regSubjects)
            {
                count += s.creditHour;
            }
            return count;
        }
        public float CalculateFee()
        {
            float fee = 0;
            if(regSubjects!=null)
            {
                foreach(Subject s in regSubjects)
                {
                    fee += s.subjectFee;
                }
            }
            return fee;
        }
    }
}
