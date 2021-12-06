using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesConsoleApp
{

    public class Professor
    {
        public string professorName;
       public string studentName;
       public string  studentId;
       public List<int> grades;
        public Professor(string _professorName, string student, string studentId, List<int> _grades)
        {
            this.professorName = _professorName;
            this.studentName = student;
            this.studentId = studentId;
            this.grades = _grades;
      }
    }
}
