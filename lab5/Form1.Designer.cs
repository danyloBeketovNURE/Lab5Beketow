namespace lab5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TeachersListBox = new ListBox();
            StudentsListBox = new ListBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            LOGs = new ListBox();
            textBox1 = new TextBox();
            totalCash = new Label();
            StopAndSerialize = new Button();
            ClearStudentsTimer = new System.Windows.Forms.Timer(components);
            AddStudentsTimer = new System.Windows.Forms.Timer(components);
            continueExecuting = new Button();
            label1 = new Label();
            textBox2 = new TextBox();
            TeacherVacation = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // TeachersListBox
            // 
            TeachersListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            TeachersListBox.FormattingEnabled = true;
            TeachersListBox.ItemHeight = 20;
            TeachersListBox.Location = new Point(287, 24);
            TeachersListBox.Margin = new Padding(2);
            TeachersListBox.Name = "TeachersListBox";
            TeachersListBox.SelectionMode = SelectionMode.None;
            TeachersListBox.Size = new Size(286, 424);
            TeachersListBox.TabIndex = 0;
            TeachersListBox.SelectedIndexChanged += TeachersListBox_SelectedIndexChanged;
            // 
            // StudentsListBox
            // 
            StudentsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            StudentsListBox.FormattingEnabled = true;
            StudentsListBox.ItemHeight = 20;
            StudentsListBox.Location = new Point(11, 25);
            StudentsListBox.Margin = new Padding(2);
            StudentsListBox.Name = "StudentsListBox";
            StudentsListBox.SelectionMode = SelectionMode.None;
            StudentsListBox.Size = new Size(272, 424);
            StudentsListBox.TabIndex = 0;
            StudentsListBox.SelectedIndexChanged += StudentsListBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 3);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 1;
            label2.Text = "Students:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(287, 2);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 1;
            label3.Text = "Teachers:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(577, 2);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 1;
            label4.Text = "Logs:";
            // 
            // LOGs
            // 
            LOGs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LOGs.FormattingEnabled = true;
            LOGs.ItemHeight = 20;
            LOGs.Location = new Point(577, 25);
            LOGs.Margin = new Padding(2);
            LOGs.Name = "LOGs";
            LOGs.ScrollAlwaysVisible = true;
            LOGs.Size = new Size(548, 424);
            LOGs.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox1.Location = new Point(731, 466);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(102, 27);
            textBox1.TabIndex = 6;
            // 
            // totalCash
            // 
            totalCash.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            totalCash.AutoSize = true;
            totalCash.Location = new Point(577, 469);
            totalCash.Margin = new Padding(2, 0, 2, 0);
            totalCash.Name = "totalCash";
            totalCash.Size = new Size(151, 20);
            totalCash.TabIndex = 7;
            totalCash.Text = "Випущено студентів:";
            // 
            // StopAndSerialize
            // 
            StopAndSerialize.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            StopAndSerialize.Location = new Point(9, 455);
            StopAndSerialize.Margin = new Padding(2);
            StopAndSerialize.Name = "StopAndSerialize";
            StopAndSerialize.Size = new Size(274, 49);
            StopAndSerialize.TabIndex = 8;
            StopAndSerialize.Text = "Зупинити та зберегти";
            StopAndSerialize.UseVisualStyleBackColor = true;
            StopAndSerialize.Click += StopAndSerialize_Click;
            // 
            // ClearStudentsTimer
            // 
            ClearStudentsTimer.Enabled = true;
            ClearStudentsTimer.Interval = 20000;
            ClearStudentsTimer.Tick += ClearStudentsTimer_Tick;
            // 
            // AddStudentsTimer
            // 
            AddStudentsTimer.Enabled = true;
            AddStudentsTimer.Interval = 8000;
            AddStudentsTimer.Tick += AddStudentsTimer_Tick;
            // 
            // continueExecuting
            // 
            continueExecuting.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            continueExecuting.Location = new Point(287, 455);
            continueExecuting.Margin = new Padding(2);
            continueExecuting.Name = "continueExecuting";
            continueExecuting.Size = new Size(286, 49);
            continueExecuting.TabIndex = 9;
            continueExecuting.Text = "Відновити роботу";
            continueExecuting.UseVisualStyleBackColor = true;
            continueExecuting.Click += continueExecuting_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(851, 469);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(145, 20);
            label1.TabIndex = 11;
            label1.Text = "Завалено студентів:";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox2.Location = new Point(1005, 466);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(102, 27);
            textBox2.TabIndex = 10;
            // 
            // TeacherVacation
            // 
            TeacherVacation.Enabled = true;
            TeacherVacation.Interval = 20000;
            TeacherVacation.Tick += TeacherVacation_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1137, 505);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(continueExecuting);
            Controls.Add(StopAndSerialize);
            Controls.Add(totalCash);
            Controls.Add(textBox1);
            Controls.Add(LOGs);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(StudentsListBox);
            Controls.Add(TeachersListBox);
            Margin = new Padding(2);
            MinimumSize = new Size(1155, 552);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Company Processing";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox TeachersListBox;
        private ListBox StudentsListBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListBox LOGs;
        private TextBox textBox1;
        private Label totalCash;
        private Button StopAndSerialize;
        private System.Windows.Forms.Timer ClearStudentsTimer;
        private System.Windows.Forms.Timer AddStudentsTimer;
        private Button continueExecuting;
        private Label label1;
        private TextBox textBox2;
        private System.Windows.Forms.Timer TeacherVacation;
    }
}