using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab5
{
    public class Teacher
    {
        public string ID { get; set; } = Guid.NewGuid().ToString(); 
        public string Name { get; set; }
        public bool isWorking { get; set; } = true;
        public int CountOfIteration { get; set; } = Random.Shared.Next(5, 20);

        private List<Subject> subjects = new List<Subject>();
        public Teacher(string name, List<Subject> subjects)
        {
            Name = name;
            this.subjects = subjects;
        }
        public IEnumerable<Subject> getSubjects()
        {
            foreach (Subject s in subjects)
            {
                yield return s;
            }
        }
///////////////////////////////////////////////////////////////////////////////////////////////////
        public void vacationON() 
        {
            isWorking = false;
            MessageBox.Show($"Викладач {Name} пішов у відпустку", "Повідомлення!", MessageBoxButtons.OK);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void vacationOFF() 
        {
            isWorking = true;
            MessageBox.Show($"Викладач {Name} повернувся з відпустки", "Повідомлення!", MessageBoxButtons.OK);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public Subject GetRandomSubject()
        {
            Random random = new Random();
            int index = random.Next(0, subjects.Count);
            return subjects[index];
        }
///////////////////////////////////////////////////////////////////////////////////////////////////
        public override string ToString()
        {
            string subjectsStr = string.Join(", ", getSubjects().Select(s => s.ToString()));
            return $"Teacher(ID: {ID}, Name: {Name}, isWorking: {isWorking}, Subjects: {subjectsStr})";
        }
///////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
