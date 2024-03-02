using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDT1
{
    internal class DegreeProgram
    {
        public string degreeName;
        public float duration;
        public List<Subject> subjects;
        public int seats;
        public DegreeProgram(string degreeName,float duration,int seats)
        {
            this.degreeName = degreeName;
            this.duration = duration;
            this.seats = seats;
            subjects=new List<Subject>();
        }
        public int CalculateCreditHour()
        {
            int count = 0;
            for (int i = 0; i < subjects.Count; i++)
            {
                count += subjects[i].creditHour;
            }
            return count;
        }
        public bool AddSubject(Subject s)
        {
            int CreditHours = CalculateCreditHour();
            if(CreditHours+s.creditHour<=20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isSubject(Subject sub)
        {
          foreach(Subject s in subjects)
            {
                if(s.code==sub.code)
                {
                    return true;
                }
            }
            return false;
        }
    }
    
}
