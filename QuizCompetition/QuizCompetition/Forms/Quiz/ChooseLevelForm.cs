using QuizCompetition.App;
using QuizCompetition.App.Common;
using QuizCompetition.BusinessLogic.Impl;
using QuizCompetition.BusinessLogic.Interface;
using QuizCompetition.Repository.Common;
using QuizCompetition.Repository.Impl;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuizCompetition.Forms.Quiz
{
    public partial class ChooseLevelForm : Form
    {
        private readonly IQuizLevelService _quizLevelService;
        private readonly IQuizRoundService _quizRoundService;
        private readonly IAttamtedQuestionsService _attamtedQuestionsService;
        private readonly IQuizTeamService _quizTeamService;

        public ChooseLevelForm()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();

            this._quizLevelService = new QuizLevelService(new QuizLevelRepository<QuizCompetitionDbContext>());
            this._quizRoundService = new QuizRoundService(new QuizRoundRepository<QuizCompetitionDbContext>());
            this._attamtedQuestionsService = new AttamtedQuestionsService(new AttamtedQuestionsRepository<QuizCompetitionDbContext>());
            this._quizTeamService = new QuizTeamService(new QuizTeamRepository<QuizCompetitionDbContext>());

            FillRounds();

            FillLevels();

            Program.AttemtNoOfQuestion = 0;
        }

        private void FillRounds()
        {
            var rounds = _quizRoundService.GetAll().Select(x => new { x.Id, x.Name }).ToList();

            DataTable dt = ExportExcelhelper.ListToDataTable(rounds);

            DataRow dr1 = dt.NewRow();

            dr1["Id"] = 0;
            dr1["Name"] = "--Select Round --";
            dt.Rows.InsertAt(dr1, 0);

            RoundcomboBox.ValueMember = "Id";
            RoundcomboBox.DisplayMember = "Name";

            RoundcomboBox.DataSource = dt;
        }

        private void FillLevels()
        {
            var levels = _quizLevelService.GetAll().Select(x => new { x.Id, x.Name }).ToList();

            DataTable dt = ExportExcelhelper.ListToDataTable(levels);

            DataRow dr1 = dt.NewRow();

            dr1["Id"] = 0;
            dr1["Name"] = "--Select Level --";
            dt.Rows.InsertAt(dr1, 0);

            LevelcomboBox.ValueMember = "Id";
            LevelcomboBox.DisplayMember = "Name";

            LevelcomboBox.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int Teamcount = 0;
                if (LevelcomboBox.SelectedValue.ToString() == "0")
                {
                    throw new Exception("Please select quiz level");
                }

                if (RoundcomboBox.SelectedValue.ToString() == "0")
                {
                    throw new Exception("Please select quiz level");
                }

                Program.Level = LevelcomboBox.Text + "," + LevelcomboBox.SelectedValue.ToString();
                Program.Round = RoundcomboBox.Text + "," + RoundcomboBox.SelectedValue.ToString();

                if (ChooseTeam1comboBox.SelectedValue.ToString() != "0")
                {
                    Teamcount = Teamcount + 1;
                }

                if (ChooseTeam2comboBox.SelectedValue.ToString() != "0")
                {
                    Teamcount = Teamcount + 1;
                }

                if (ChooseTeam3comboBox.SelectedValue.ToString() != "0")
                {
                    Teamcount = Teamcount + 1;
                }

                if (ChooseTeam4comboBox.SelectedValue.ToString() != "0")
                {
                    Teamcount = Teamcount + 1;
                }

                if (Teamcount < 2)
                {
                    throw new Exception("Please choose at least 2 teams to start quiz");
                }

                if ((ChooseTeam1comboBox.Text == ChooseTeam2comboBox.Text)
                    || (ChooseTeam1comboBox.Text == ChooseTeam3comboBox.Text)
                    || (ChooseTeam1comboBox.Text == ChooseTeam4comboBox.Text)
                    || (ChooseTeam2comboBox.Text == ChooseTeam3comboBox.Text)
                    || (ChooseTeam2comboBox.Text == ChooseTeam4comboBox.Text)
                    || (ChooseTeam3comboBox.Text == ChooseTeam2comboBox.Text)
                    || (ChooseTeam3comboBox.Text == ChooseTeam4comboBox.Text)
                    || (ChooseTeam4comboBox.Text == ChooseTeam3comboBox.Text)
                    || (ChooseTeam4comboBox.Text == ChooseTeam2comboBox.Text))
                {
                    throw new Exception("Please choose four different teams");
                }


                if (ChooseTeam1comboBox.SelectedValue.ToString() != "0")
                    Program.TeamA = ChooseTeam1comboBox.Text;
                else
                    Program.TeamA = string.Empty;

                if (ChooseTeam2comboBox.SelectedValue.ToString() != "0")
                    Program.TeamB = ChooseTeam2comboBox.Text;
                else
                    Program.TeamB = string.Empty;

                if (ChooseTeam3comboBox.SelectedValue.ToString() != "0")
                    Program.TeamC = ChooseTeam3comboBox.Text;
                else
                    Program.TeamC = string.Empty;

                if (ChooseTeam4comboBox.SelectedValue.ToString() != "0")
                    Program.TeamD = ChooseTeam4comboBox.Text;
                else
                    Program.TeamD = string.Empty;

                Program.NoOfQuestion = _quizRoundService.GetAll().Where(x => x.Name == RoundcomboBox.Text).Select(x => x.NoOfQuestions).FirstOrDefault();

                if (LevelcomboBox.Text == "Level1" && RoundcomboBox.Text == "Round1")
                {

                    Form2 Question = new Form2();
                    Question.Text = "Question";
                    Question.Show();
                }

                if (LevelcomboBox.Text == "Level1" && RoundcomboBox.Text == "Round2")
                {
                    Level1Round2Form Question = new Level1Round2Form();
                    Question.Text = "Question";
                    Question.Show();
                }

                if (LevelcomboBox.Text == "Level1" && RoundcomboBox.Text == "Round3")
                {
                    Level1Round3Form Question = new Level1Round3Form();
                    Question.Text = "Question";
                    Question.Show();
                }

                if (LevelcomboBox.Text == "Level1" && RoundcomboBox.Text == "Round4")
                {
                    Level1Round4Form Question = new Level1Round4Form();
                    Question.Text = "Question";
                    Question.Show();
                }

                if (LevelcomboBox.Text == "Level1" && RoundcomboBox.Text == "tie Breaker")
                {
                    Level1Round4Form Question = new Level1Round4Form();
                    Question.Text = "Question";
                    Question.Show();
                }

                if (LevelcomboBox.Text == "Level2" && RoundcomboBox.Text == "Round1")
                {
                    Form2 Question = new Form2();
                    Question.Text = "Question";
                    Question.Show();
                }

                if (LevelcomboBox.Text == "Level2" && RoundcomboBox.Text == "Round2")
                {
                    Level2Round2Form Question = new Level2Round2Form();
                    Question.Text = "Question";
                    Question.Show();
                }

                if (LevelcomboBox.Text == "Level2" && RoundcomboBox.Text == "Round3")
                {
                    Level2Round3Form Question = new Level2Round3Form();
                    Question.Text = "Question";
                    Question.Show();
                }

                if (LevelcomboBox.Text == "Level2" && RoundcomboBox.Text == "Round4")
                {
                    Level2Round4Form Question = new Level2Round4Form();
                    Question.Text = "Question";
                    Question.Show();
                }

                if (LevelcomboBox.Text == "Level2" && RoundcomboBox.Text == "tie Breaker")
                {
                    Level1Round4Form Question = new Level1Round4Form();
                    Question.Text = "Question";
                    Question.Show();
                }


                if (LevelcomboBox.Text == "Level3" && RoundcomboBox.Text == "Round1")
                {
                    Form2 Question = new Form2();
                    Question.Text = "Question";
                    Question.Show();
                }

                if (LevelcomboBox.Text == "Level3" && RoundcomboBox.Text == "Round2")
                {
                    Level3Round2Form Question = new Level3Round2Form();
                    Question.Text = "Question";
                    Question.Show();
                }

                if (LevelcomboBox.Text == "Level3" && RoundcomboBox.Text == "Round3")
                {
                    Level3Round3Form Question = new Level3Round3Form();
                    Question.Text = "Question";
                    Question.Show();
                }

                if (LevelcomboBox.Text == "Level3" && RoundcomboBox.Text == "Round4")
                {
                    Level2Round4Form Question = new Level2Round4Form();
                    Question.Text = "Question";
                    Question.Show();
                }

                if (LevelcomboBox.Text == "Level3" && RoundcomboBox.Text == "tie Breaker")
                {
                    Level1Round4Form Question = new Level1Round4Form();
                    Question.Text = "Question";
                    Question.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message");
            }
        }

        public void ChooseLevelForm_Load(object sender, EventArgs e)
        {
            LevelcomboBox.SelectedValue = "0";
            RoundcomboBox.SelectedValue = "0";

            FillTeamsOne();
            FillTeamsTwo();
            FillTeamsThree();
            FillTeamsFour();

            DScorelabel.Visible = false;
            BScorelabel.Visible = false;
            AScorelabel.Visible = false;
            CScorelabel.Visible = false;

        }

        private void FillTeamsFour()
        {
            var teams = _quizTeamService.GetAll().Select(x => new { x.Id, x.Name }).ToList();

            DataTable dt = ExportExcelhelper.ListToDataTable(teams);

            DataRow dr0 = dt.NewRow();

            dr0["Id"] = "0";
            dr0["Name"] = "-- Select Team 4 --";
            dt.Rows.InsertAt(dr0, 0);

            ChooseTeam4comboBox.ValueMember = "Id";
            ChooseTeam4comboBox.DisplayMember = "Name";

            ChooseTeam4comboBox.DataSource = dt;
        }

        private void FillTeamsThree()
        {
            var teams = _quizTeamService.GetAll().Select(x => new { x.Id, x.Name }).ToList();

            DataTable dt = ExportExcelhelper.ListToDataTable(teams);

            DataRow dr0 = dt.NewRow();

            dr0["Id"] = "0";
            dr0["Name"] = "-- Select Team 3 --";
            dt.Rows.InsertAt(dr0, 0);

            ChooseTeam3comboBox.ValueMember = "Id";
            ChooseTeam3comboBox.DisplayMember = "Name";

            ChooseTeam3comboBox.DataSource = dt;

        }

        private void FillTeamsTwo()
        {
            var teams = _quizTeamService.GetAll().Select(x => new { x.Id, x.Name }).ToList();

            DataTable dt = ExportExcelhelper.ListToDataTable(teams);

            DataRow dr0 = dt.NewRow();

            dr0["Id"] = "0";
            dr0["Name"] = "-- Select Team 2 --";
            dt.Rows.InsertAt(dr0, 0);

            ChooseTeam2comboBox.ValueMember = "Id";
            ChooseTeam2comboBox.DisplayMember = "Name";

            ChooseTeam2comboBox.DataSource = dt;
        }

        private void FillTeamsOne()
        {
            var teams = _quizTeamService.GetAll().Select(x => new { x.Id, x.Name }).ToList();

            DataTable dt = ExportExcelhelper.ListToDataTable(teams);

            DataRow dr0 = dt.NewRow();

            dr0["Id"] = "0";
            dr0["Name"] = "-- Select Team 1 --";
            dt.Rows.InsertAt(dr0, 0);

            ChooseTeam1comboBox.ValueMember = "Id";
            ChooseTeam1comboBox.DisplayMember = "Name";

            ChooseTeam1comboBox.DataSource = dt;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.Black);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.Black);
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.Black);
        }

        private void DrawGroupBox(Panel box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);

                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);

                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                //g.Clear(this.BackColor);

                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));

                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));

                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));

                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));

                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var attemptQuestions = _attamtedQuestionsService.GetAll().ToList();
            foreach (var item in attemptQuestions)
            {
                item.Marks = 0;
                _attamtedQuestionsService.Edit(item);
                _attamtedQuestionsService.Save();
            }

            ChooseTeam2comboBox.SelectedValue = 0;
            ChooseTeam1comboBox.SelectedValue = 0;
            ChooseTeam3comboBox.SelectedValue = 0;
            ChooseTeam4comboBox.SelectedValue = 0;

            DScorelabel.Visible = false;
            BScorelabel.Visible = false;
            AScorelabel.Visible = false;
            CScorelabel.Visible = false;
        }

        private void ChooseTeam1comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string AcademicYear = Program.CurrAcademicYear;
            var attempted = _attamtedQuestionsService.GetAll().Where(x => x.AcademicYear == AcademicYear).ToList();

            AScorelabel.Text = ChooseTeam1comboBox.Text + " : " + Convert.ToInt32(attempted.Where(x => x.TeamName == ChooseTeam1comboBox.Text & x.AcademicYear == AcademicYear).Sum(x => x.Marks)).ToString();
            AScorelabel.Visible = true;
        }

        private void ChooseTeam2comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string AcademicYear = Program.CurrAcademicYear;

            var attempted = _attamtedQuestionsService.GetAll().Where(x => x.AcademicYear == AcademicYear).ToList();

            BScorelabel.Text = ChooseTeam2comboBox.Text + " : " + Convert.ToInt32(attempted.Where(x => x.TeamName == ChooseTeam2comboBox.Text & x.AcademicYear == AcademicYear).Sum(x => x.Marks)).ToString();
            BScorelabel.Visible = true;
        }

        private void ChooseTeam3comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string AcademicYear = Program.CurrAcademicYear;
            var attempted = _attamtedQuestionsService.GetAll().Where(x => x.AcademicYear == AcademicYear).ToList();

            CScorelabel.Text = ChooseTeam3comboBox.Text + " : " + Convert.ToInt32(attempted.Where(x => x.TeamName == ChooseTeam3comboBox.Text & x.AcademicYear == AcademicYear).Sum(x => x.Marks)).ToString();
            CScorelabel.Visible = true;
        }

        private void ChooseTeam4comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string AcademicYear = Program.CurrAcademicYear;
            var attempted = _attamtedQuestionsService.GetAll().Where(x => x.AcademicYear == AcademicYear).ToList();

            DScorelabel.Text = ChooseTeam4comboBox.Text + " : " + Convert.ToInt32(attempted.Where(x => x.TeamName == ChooseTeam4comboBox.Text & x.AcademicYear == AcademicYear).Sum(x => x.Marks)).ToString();
            DScorelabel.Visible = true;
        }
    }
}
