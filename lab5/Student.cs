using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Student
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string status { get; set; } = Status.WAITING.ToString();
        public Teacher? teacher { get; set; }

        private List<Subject>? subjects = new List<Subject>();
        public int studingProgres { get; set; } = 0;
        private List<int>? marks = new List<int>();
        public IEnumerable<Subject> getSubjects()
        {
            foreach (Subject s in subjects)
            {
                yield return s;
            }
        }
        public IEnumerable<int> getMarks()
        {
            foreach (int m in marks)
            {
                yield return m;
            }
        }
///////////////////////////////////////////////////////////////////////////////////////////////////
        public void completeSubject(Subject subjectToRemove)
        {
            if (subjects.Any())
            {
                int mark;
                int chance = Random.Shared.Next(1, 20);
                if (chance<2)
                {
                    mark = Random.Shared.Next(0, 60);
                }
                else
                {
                    mark = Random.Shared.Next(60, 100);
                }
                marks.Add(mark);
                subjects.Remove(subjectToRemove);
                completeTeacher();
                if (subjects.Count == 0 && mark >= 60) status = Status.COMPLETED.ToString();
                else if (mark < 60) status = Status.FALT.ToString();
                else status = Status.WAITING.ToString();
            }
            else
            {
            MessageBox.Show("Студент вивчив усі предмети", "Повідомлення!", MessageBoxButtons.OK);
            }
        }
///////////////////////////////////////////////////////////////////////////////////////////////////
        public static Student CreateRandomStudent()
        {
            Student student = new Student();
            student.Name = GenerateRandomName();

            Array values = Enum.GetValues(typeof(Subject));
            List<Subject> randomSubjects = new List<Subject>();
           
            for (int i = Random.Shared.Next(2, 6); i > 0; i--)
            {
                Subject randomSubject = (Subject)values.GetValue(Random.Shared.Next(values.Length));
                if (!randomSubjects.Contains(randomSubject))
                {
                    randomSubjects.Add(randomSubject);
                }
                else
                {
                    i++;
                }
            }
            if (randomSubjects.Contains(Subject.NONE))
            {
                randomSubjects.Remove(Subject.NONE);
            }
            student.subjects = randomSubjects;
            return student;
        }
///////////////////////////////////////////////////////////////////////////////////////////////////
        public Subject GetRandomSubject()
        {
            if (subjects.Any() && status == "WAITING")
            {
                Random random = new Random();
                int index = random.Next(0, subjects.Count);
                return subjects[index];
            }
            else
            {
                return Subject.NONE;
            }
        }
///////////////////////////////////////////////////////////////////////////////////////////////////
        public static string GenerateRandomName()
        {
            string[] names = { "Adam", "Bob", "Charlie", "David", "Emily", "Frank", "George", "Hannah", "Isabella", "John", "Kate", "Liam", "Mason", "Natalie", "Olivia", "Patrick", "Quinn", "Rachel", "Sarah", "Thomas", "Ursula", "Victoria", "William", "Xavier", "Yvonne", "Zachary" };

            Random random = new Random();

            int index = random.Next(0, names.Length);

            return names[index];
        }
///////////////////////////////////////////////////////////////////////////////////////////////////
        public void completeTeacher()
        {
            teacher = null;
        }
///////////////////////////////////////////////////////////////////////////////////////////////////
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"ID: {ID}\n");
            sb.Append($"Name: {Name}\n");
            sb.Append($"Status: {status}\n");
            sb.Append($"Teacher: {teacher}\n");
            sb.Append("Subjects:\n");
            foreach (Subject subject in getSubjects())
            {
                sb.Append($"- {subject}\n");
            }
            sb.Append("Marks:\n");
            foreach (int mark in getMarks())
            {
                sb.Append($"- {mark}\n");
            }
            return sb.ToString();
        }
///////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
