using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDT1
{
    internal class Subject
    {
        public string code;
        public string type;
        public int creditHour;
        public int subjectFee;
        public Subject(string code,string type,int creditHour,int subjectFee)
        {
            this.code = code;
            this.type = type;
            this.creditHour = creditHour;
            this.subjectFee = subjectFee;
        }
    }
}
