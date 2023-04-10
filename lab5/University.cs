using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;

namespace lab5
{
    public class University
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public int totalGraduatedStudents { get; set; } = default;
        public int totalFaltStudents { get; set; } = default;
        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();
        public University()
        {
            teachers.Add(new Teacher("Tom", new List<Subject> { Subject.ENGLISH, Subject.MATH }));
            teachers.Add(new Teacher("Mikle", new List<Subject> { Subject.SPORT, Subject.ASTRONOMY }));
            teachers.Add(new Teacher("Lisa", new List<Subject> { Subject.PROGRAMMING, Subject.BIOLOGY }));
            teachers.Add(new Teacher("Olivia", new List<Subject> { Subject.LITHERATURE, Subject.CHEMISTRY }));
            teachers.Add(new Teacher("Denis", new List<Subject> { Subject.HISTORY, Subject.PHISICS }));
        }
        public IEnumerable<Student> getStudents()
        {
            foreach (Student s in students)
            {
                yield return s;
            }
        }
        public IEnumerable<Teacher> getTeachers()
        {
            foreach (Teacher t in teachers)
            {
                yield return t;
            }
        }
        public Teacher GetRandomTeacher()
        {
            Random random = new Random();
            int index = random.Next(teachers.Count);
            return teachers[index];
        }
        public void removeCompletedAndFaltStudents()
        {
            students.RemoveAll(s => s.status == "FALT" || s.status == "COMPLETED");
        }
        public void newStudent(Student student)
        {
            students.Add(student);
        }
    }
}
