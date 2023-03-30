using GradeBook.Enums;
using System.Linq;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBook.Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            int numHigherGrades = Students.Count(s => s.AverageGrade > averageGrade);
            int numStudentsInTwentyPercent = (int)Math.Ceiling(Students.Count * 0.2);

            if (numHigherGrades < numStudentsInTwentyPercent)
            {
                return 'A';
            }
            else if (numHigherGrades < numStudentsInTwentyPercent * 2)
            {
                return 'B';
            }
            else if (numHigherGrades < numStudentsInTwentyPercent * 3)
            {
                return 'C';
            }
            else if (numHigherGrades < numStudentsInTwentyPercent * 4)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}