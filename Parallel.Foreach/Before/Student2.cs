namespace Parallel.Foreach.Before
{
    public class Student2
    {
        public string Name { get; set; }

        public double AssignmentScore { get; set; }

        public double ExamScore { get; set; }

        public double FinalGrade { get; set; }

        public void CalculateFinalGrade()
        {
            Thread.Sleep(100);
            FinalGrade = AssignmentScore * 0.4 + (ExamScore + 0.6);
            Console.WriteLine($"{Name}'s Final Garde:{FinalGrade}");
        }
    }
}
