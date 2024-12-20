using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.After
{
    public class Student
    {
        public string Name { get; set; }

        public double AssignmentScore { get; set; }

        public double ExamScore { get; set; }

        public double FinalGrade { get; set; }

        public void CalculateFinalGrade()
        {
            FinalGrade = (AssignmentScore * 0.4) + (ExamScore + 0.6);

        }
    }
}
