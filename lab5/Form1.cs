using Microsoft.AspNetCore.Components;
using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Timer = System.Windows.Forms.Timer;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;
using ExtentionMethodsForListBox;
using System.Text.Json;
using System.Text;

namespace lab5
{
    public partial class Form1 : Form
    {
        object locker = new object();
        private bool exec = true;
        private bool stopping = false;

        private const string filePath = "SerializationFile.json";
        private long students = default;
        private long projects = default;
        private University university = new University();

        private List<Thread> threads = new List<Thread>();
        private List<Task> tasks = new List<Task>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TeachersListBox.DataSource = university.getTeachers().ToList();
            TeachersListBox.DisplayMember = "Name";
            Thread StudentsStudingThread = new Thread(ExecutingProjects);
            StudentsStudingThread.Name = "StudSt";
            threads.Add(StudentsStudingThread);
            StudentsStudingThread.IsBackground = true;
            StudentsStudingThread.Start();
        }

        private void StudentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StudentsListBox.SelectedItems.Count == 0)
                return;
            try
            {
                Student selected = (Student)StudentsListBox.SelectedItem;
                MessageBox.Show(selected.ToString());
            }
            catch { }
        }
        private void TeachersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeachersListBox.SelectedItems.Count == 0)
                return;
            try
            {
                Teacher selected = (Teacher)TeachersListBox.SelectedItem;
                MessageBox.Show(selected.ToString());
            }
            catch { }
        }

        private void UpdateForm()
        {
            Invoke(new Action(() => StudentsListBox.SelectionMode = SelectionMode.None));
            Invoke(new Action(() => TeachersListBox.SelectionMode = SelectionMode.None));
            Invoke(new Action(() => StudentsListBox.DataSource = university.getStudents().ToList()));
            Invoke(new Action(() => StudentsListBox.DisplayMember = "Name"));
            Invoke(new Action(() => TeachersListBox.DisplayMember = "Name"));
            Invoke(new Action(() => StudentsListBox.SelectionMode = SelectionMode.One));
            Invoke(new Action(() => TeachersListBox.SelectionMode = SelectionMode.One));
        }
        private void ExecutingProjects()
        {
            while (exec)
            {
                lock (locker)
                {
                    List<Student> students = new List<Student>();
                    if (university.getStudents() != null)
                        students = university.getStudents().Where(x => x.status == "WAITING").ToList();
                    List<Teacher> teachers = university.getTeachers().ToList();
                    Subject stSubject;
                    foreach (Teacher t in teachers.Where(a => a.isWorking == true))
                    {
                        foreach (Student s in students.Where(x => x.teacher == null))
                        {
                            stSubject = s.GetRandomSubject();
                            if (stSubject == t.GetRandomSubject())
                            {
                                s.teacher = t;
                                tasks.Add(Task.Run(() =>
                                {
                                    int progress;
                                    LOGs.Invoke(new Action(() => LOGs.Items.Add($"Log INFO: студент {s.Name} почав навчання у {t.Name} з предмета {stSubject}")));
                                    LOGs.Invoke(LOGs.SelectBottomIndex);
                                    s.status = Status.STUDING.ToString();
                                    LOGs.Invoke(new Action(() => LOGs.Items.Add($"Log INFO: Статус студента {s.Name} змінено на STUDING")));
                                    LOGs.Invoke(LOGs.SelectBottomIndex);
                                    for (int i = 1; i < t.CountOfIteration; i += 5)
                                    {
                                        progress = i * 100 / t.CountOfIteration;
                                        LOGs.Invoke(new Action(() => LOGs.Items.Add($"Log INFO: {s.Name} вивчився на {progress}%")));
                                        LOGs.Invoke(LOGs.SelectBottomIndex);
                                        Thread.Sleep(2000);
                                    }
                                    LOGs.Invoke(new Action(() => LOGs.Items.Add($"Log INFO: {s.Name} закіечив навчання у {t.Name}")));
                                    LOGs.Invoke(LOGs.SelectBottomIndex);
                                    s.completeSubject(stSubject);
                                    LOGs.Invoke(new Action(() => LOGs.Items.Add($"Log INFO: Викладач {t.Name} випустив студента {s.Name}")));
                                    LOGs.Invoke(LOGs.SelectBottomIndex);
                                    LOGs.Invoke(new Action(() => LOGs.Items.Add($"Log INFO: Статус студента {s.Name} змінено на {s.status}")));
                                    LOGs.Invoke(LOGs.SelectBottomIndex);
                                    if (s.status == "COMPLETED")
                                    {
                                        university.totalGraduatedStudents++;
                                    }
                                    LOGs.Invoke(new Action(() => textBox1.Text = university.totalGraduatedStudents.ToString()));
                                    if (s.status == "FALT")
                                    {
                                        university.totalFaltStudents++;
                                    }
                                    LOGs.Invoke(new Action(() => textBox2.Text = university.totalFaltStudents.ToString()));
                                }));
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void RemovingFaltAndCompletedStudents()
        {
            lock (locker)
            {
                threads.RemoveAll(x => x.ThreadState.Equals(ThreadState.Stopped));
                tasks.RemoveAll(x => x.Status.Equals(TaskStatus.RanToCompletion));
                university.removeCompletedAndFaltStudents();
                UpdateForm();
                LOGs.Invoke(new Action(() => LOGs.Items.Add($"STUDENTS LISTS UPDATED!")));
                LOGs.Invoke(LOGs.SelectBottomIndex);
            }
        }
        private void ClearStudentsTimer_Tick(object sender, EventArgs e)
        {
            if (!exec)
            {
                ClearStudentsTimer.Stop();
                return;
            }
            Thread ClearStudents = new Thread(RemovingFaltAndCompletedStudents);

            ClearStudents.Name = "StClear";
            threads.Add(ClearStudents);
            ClearStudents.IsBackground = true;
            ClearStudents.Start();
        }
        private void AdditingStudents()
        {
            lock (locker)
            {
                int chance = Random.Shared.Next(1, 8);
                Student s;
                for (int i = 0; i < chance; i++)
                {
                    s = Student.CreateRandomStudent();
                    students++;
                    university.newStudent(s);
                }
                UpdateForm();
            }
        }
        private void AddStudentsTimer_Tick(object sender, EventArgs e)
        {
            if (!exec)
            {
                AddStudentsTimer.Stop();
                return;
            }
            Thread AddStudents = new Thread(AdditingStudents);
            AddStudents.Name = "AddSt";
            threads.Add(AddStudents);
            AddStudents.IsBackground = true;
            AddStudents.Start();
        }



        private async void StopAndSerialize_Click(object sender, EventArgs e)
        {
            if (!exec)
                return;

            stopping = true;
            LOGs.Items.Add($"LOG INFO: PROGRAM STOPING");
            LOGs.SelectBottomIndex();
            exec = false;
            List<Thread> thr = threads.Where(x => !x.ThreadState.Equals(ThreadState.Stopped)).ToList();
            foreach (Thread th in thr)
            {
                th.Join();
            }
            List<Task> tsk = tasks.Where(x => x.Status.Equals(TaskStatus.Running)).ToList();
            foreach (Task task in tsk)
            {
                await task;
            }

            LOGs.Items.Add($"LOG INFO: PROGRAM STOPPED!");
            LOGs.SelectBottomIndex();
            LOGs.Items.Add($"LOG INFO: випущено студентів: {university.totalGraduatedStudents}");
            LOGs.SelectBottomIndex();
            LOGs.Items.Add($"LOG INFO: завалено студентів: {university.totalFaltStudents}");
            LOGs.SelectBottomIndex();

            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            using (var fStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                var items = LOGs.Items.Cast<object>().ToArray();
                var jsonString = JsonSerializer.Serialize(items, jsonOptions);
                var jsonBytes = Encoding.UTF8.GetBytes(jsonString);
                fStream.Write(jsonBytes, 0, jsonBytes.Length);
            }
            stopping = false;
            MessageBox.Show("\n\nLOG INFO: дані збережено можете відновляти роботу", "Повідомлення!", MessageBoxButtons.OK);
        }



        private void continueExecuting_Click(object sender, EventArgs e)
        {
            if (stopping | exec)
                return;
            exec = true;
            LOGs.Items.Add($"РОБОТУ ПОНОВЛЕНО!");
            LOGs.SelectBottomIndex();
            ClearStudentsTimer.Start();
            AddStudentsTimer.Start();
            TeacherVacation.Start();
            Thread ExecutingProjectsThread = new Thread(ExecutingProjects);
            ExecutingProjectsThread.Name = "ExecPR";
            threads.Add(ExecutingProjectsThread);
            ExecutingProjectsThread.IsBackground = true;
            ExecutingProjectsThread.Start();
        }

        private void vacationPeriod()
        {
            lock (locker)
            {
                Teacher teacher = university.GetRandomTeacher();
                teacher.vacationON();
                Thread.Sleep(3000);
                teacher.vacationOFF();
            }
        }
        private void TeacherVacation_Tick(object sender, EventArgs e)
        {
            if (!exec)
            {
                TeacherVacation.Stop();
                return;
            }
            Thread teacherVacation = new Thread(vacationPeriod);
            teacherVacation.Name = "TVac";
            threads.Add(teacherVacation);
            teacherVacation.IsBackground = true;
            teacherVacation.Start();
        }
    }
}