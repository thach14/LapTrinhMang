using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Student
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public string FullNameAndId { get { return ID + " - " + FullName; } }

        public Student()
        {

        }

        public Student(string iD, string full)
        {
            ID = iD;
            FullName = full;
        }
    }
}
