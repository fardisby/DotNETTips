using First.After;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        var students = new List<Student>
        {
            new Student{ Name = "Alice", AssignmentScore = 90, ExamScore = 90},
            new Student{ Name = "Bob", AssignmentScore = 80, ExamScore = 80},
            new Student{Name = "Diana", AssignmentScore = 70, ExamScore = 75 }

        };

        int passingStudents = 0;

        Console.WriteLine("Processing students sequentially:");

        /* //Sequentially process each student
         foreach (var student in students) 
         {
             student.CalculateFinalGrade();
         }*/

       System.Threading.Tasks.Parallel.ForEach(students, student =>
        {
            student.CalculateFinalGrade();
            Console.WriteLine($"{student.Name}'s Final Garde:{student.FinalGrade}");

            //Thread-safe increment of the passing count
            if (student.FinalGrade >= 60)
            {
                Interlocked.Increment(ref passingStudents);
            }

        });
    }
}
