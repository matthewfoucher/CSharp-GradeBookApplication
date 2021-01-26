using System;
using System.Linq;

using GradeBook.Enums;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {

        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            var averageGrades = new List<double>();
            foreach (Student student in Students)
            {
                averageGrades.Add(student.AverageGrade);
            }
            int numLarger = 0;
            foreach (double grade in averageGrades)
            {
                if (grade > averageGrade)
                {
                    numLarger++;
                }
            }
            if ((double)(numLarger / Students.Count) <= 0.2)
            {
                return 'A';
            }
            else if ((double)(numLarger / Students.Count) <= 0.4)
            {
                return 'B';
            }
            else if ((double)(numLarger / Students.Count) <= 0.6)
            {
                return 'C';
            }
            else if ((double)(numLarger / Students.Count) <= 0.8)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
