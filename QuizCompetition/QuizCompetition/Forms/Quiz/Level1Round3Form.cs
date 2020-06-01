using QuizCompetition.App;
using QuizCompetition.BusinessLogic.Impl;
using QuizCompetition.BusinessLogic.Interface;
using QuizCompetition.Forms.Message;
using QuizCompetition.Models;
using QuizCompetition.Repository.Common;
using QuizCompetition.Repository.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizCompetition.Forms.Quiz
{
    public partial class Level1Round3Form : Form
    {
        string Level = Program.Level;
        string Round = Program.Round;
        private int quick = 0;
        bool IsSkip = false;

        int Teamindex = 0;

        List<string> Teams = new List<string>();

        static string startupPath = AppDomain.CurrentDomain.BaseDirectory;

        static string path = System.Configuration.ConfigurationSettings.AppSettings["Audio"];

        System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(startupPath + "Audio\\Tick-DeepFrozenApps-397275646.wav");
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + "Audio\\Loud_Alarm_Clock_Buzzer-Muk1984-493547174.wav");

        private readonly IQuizRoundService _quizRoundService;
        private readonly IQuizQuestionService _quizQuestionService;
        private readonly IAttamtedQuestionsService _attamtedQuestionsService;
        private readonly IQuizTeamService _quizTeamService;
        private readonly INoQuesPerLeavelRoundService _noQuesPerLeavelRoundService;

        public Level1Round3Form()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();

            this._quizQuestionService = new QuizQuestionService(new QuizQuestionRepository<QuizCompetitionDbContext>());
            this._attamtedQuestionsService = new AttamtedQuestionsService(new AttamtedQuestionsRepository<QuizCompetitionDbContext>());
            this._quizTeamService = new QuizTeamService(new QuizTeamRepository<QuizCompetitionDbContext>());
            this._noQuesPerLeavelRoundService = new NoQuesPerLeavelRoundService(new NoQuesPerLeavelRoundRepository<QuizCompetitionDbContext>());
            this._quizRoundService = new QuizRoundService(new QuizRoundRepository<QuizCompetitionDbContext>());
        }

        private void Level1Round3Form_Load(object sender, EventArgs e)
        {
            Startbutton.Text = "Start Time";
            if (!String.IsNullOrEmpty(Program.TeamA))
            {
                Teams.Add(Program.TeamA);
            }

            if (!String.IsNullOrEmpty(Program.TeamB))
            {
                Teams.Add(Program.TeamB);
            }

            if (!String.IsNullOrEmpty(Program.TeamC))
            {
                Teams.Add(Program.TeamC);
            }

            if (!String.IsNullOrEmpty(Program.TeamD))
            {
                Teams.Add(Program.TeamD);
            }

            GetQuestion();
        }

        private void GetQuestion()
        {
            Timelabel.BackColor = Color.OrangeRed;
            List<QuizQuestion> unattemptQuestions = null;

            string AcademicYear = Program.CurrAcademicYear;
            int LevelId = Convert.ToInt32(Level.Split(',')[1]);
            int RoundId = Convert.ToInt32(Round.Split(',')[1]);

            var attempted = _attamtedQuestionsService.GetAll().Where(x => x.AcademicYear == AcademicYear).ToList();

            var questions = _quizQuestionService.GetAll().Where(x => x.LevelId == LevelId && x.RoundId == RoundId
                           && x.AcademicYear == AcademicYear).ToList();

            if (attempted.Count() > 0)
            {
                unattemptQuestions = (from qu in questions
                                      where !attempted.Any(x => x.QuestionId == qu.Id)
                                      select qu).ToList();
            }
            else
            {
                unattemptQuestions = questions;
            }

            if (unattemptQuestions.Count() > 0)
            {
                var question = unattemptQuestions.ElementAt(RandomNumber(0, unattemptQuestions.Count()));

                Questionlabel.Text = question.Question;

                questionidlabel.Text = question.Id.ToString();
                AcademicYearlabel.Text = question.AcademicYear;
                CorrectAnswerlabel.Text = question.CorrectAnswer;

                Timelabel.Text = question.Time.ToString().Split('.')[0];
                quick = Convert.ToInt32(question.Time);

                if (Convert.ToInt16(TeamIndexlabel.Text) >= Teams.Count())
                {
                    Teamindex = 0;
                }
                else
                    Teamindex = Convert.ToInt16(TeamIndexlabel.Text);

                QuizLevelandRoundlabel.Text = "Quiz " + Level.Split(',')[0] + " " + Round.Split(',')[0];

                if (IsSkip == false)
                {
                    QuestionForlabel.Text = "Question for Team " + Teams.ElementAt(Teamindex);
                    TeanNamelabel.Text = Teams.ElementAt(Teamindex);
                    TeamIndexlabel.Text = (Teamindex + 1).ToString();
                }

                pictureBox2.ImageLocation = startupPath + question.DocUrl;

                CalculateMarks();
            }
            else
            {
                MessageBox.Show(Level.Split(',')[0] + " " + Round.Split(',')[0] + " questions are finished", "Alert");
                button2.Enabled = false;
            }
        }

        public void CalculateMarks()
        {
            IsSkip = false;
            string AcademicYear = Program.CurrAcademicYear;
            var attempted = _attamtedQuestionsService.GetAll().Where(x => x.AcademicYear == AcademicYear).ToList();

            if (!String.IsNullOrEmpty(Program.TeamA))
            {
                AScorelabel.Text = Program.TeamA + " : " + Convert.ToInt32(attempted.Where(x => x.TeamName == Program.TeamA & x.AcademicYear == AcademicYear).Sum(x => x.Marks)).ToString();
            }
            else
                AScorelabel.Text = "";

            if (!String.IsNullOrEmpty(Program.TeamB))
            {
                BScorelabel.Text = Program.TeamB + " : " + Convert.ToInt32(attempted.Where(x => x.TeamName == Program.TeamB & x.AcademicYear == AcademicYear).Sum(x => x.Marks)).ToString();
            }
            else
                BScorelabel.Text = "";

            if (!String.IsNullOrEmpty(Program.TeamC))
            {
                CScorelabel.Text = Program.TeamC + " : " + Convert.ToInt32(attempted.Where(x => x.TeamName == Program.TeamC & x.AcademicYear == AcademicYear).Sum(x => x.Marks)).ToString();
            }
            else
                CScorelabel.Text = "";

            if (!String.IsNullOrEmpty(Program.TeamD))
            {
                DScorelabel.Text = Program.TeamD + " : " + Convert.ToInt32(attempted.Where(x => x.TeamName == Program.TeamD & x.AcademicYear == AcademicYear).Sum(x => x.Marks)).ToString();
            }
            else
                DScorelabel.Text = "";

        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private void ShowAnswerbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CorrectAnswerlabel.Text, "Correct answer");
        }

        private void Rightbtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            int questionnid = Convert.ToInt32(questionidlabel.Text);
            int LevelId = Convert.ToInt32(Level.Split(',')[1]);
            int RoundId = Convert.ToInt32(Round.Split(',')[1]);

            var checkforattamt = _attamtedQuestionsService.GetAll().Where(x => x.LevelId == LevelId && x.RoundId == RoundId
             && x.QuestionId == questionnid && x.AcademicYear == Program.CurrAcademicYear).ToList();

            if (checkforattamt.Count() == 0)
            {
                AttamtedQuestions attamtedQuestions = new AttamtedQuestions();
                attamtedQuestions.QuestionId = Convert.ToInt32(questionidlabel.Text);
                attamtedQuestions.LevelId = Convert.ToInt32(Level.Split(',')[1]);
                attamtedQuestions.RoundId = Convert.ToInt32(Round.Split(',')[1]);
                attamtedQuestions.Marks = 10;
                attamtedQuestions.TeamId = _quizTeamService.GetAll().Where(x => x.Name == TeanNamelabel.Text).Select(x => x.Id).FirstOrDefault();
                attamtedQuestions.TeamName = TeanNamelabel.Text;
                attamtedQuestions.AcademicYear = AcademicYearlabel.Text;
                attamtedQuestions.IsTrue = true;
                attamtedQuestions.CreatedBy = "Admin";
                attamtedQuestions.CreatedDate = DateTime.Now;

                _attamtedQuestionsService.Add(attamtedQuestions);
                _attamtedQuestionsService.Save();

                QuizTeam quizTeam = _quizTeamService.FindBy(x => x.Id == attamtedQuestions.TeamId).FirstOrDefault();
                quizTeam.Marks += attamtedQuestions.Marks;

                _quizTeamService.Edit(quizTeam);
                _quizTeamService.Save();

                SuccessForm success = new SuccessForm();
                success.Text = "Correct answer";
                success.ShowDialog();

                CalculateMarks();
            }
            else
            {
                MessageBox.Show("You have already attempted this question, please go to next question", "Alert");
            }
        }

        private void Wrongbutton_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            int questionnid = Convert.ToInt32(questionidlabel.Text);
            int LevelId = Convert.ToInt32(Level.Split(',')[1]);
            int RoundId = Convert.ToInt32(Round.Split(',')[1]);

            var checkforattamt = _attamtedQuestionsService.GetAll().Where(x => x.LevelId == LevelId && x.RoundId == RoundId
             && x.QuestionId == questionnid && x.AcademicYear == Program.CurrAcademicYear).ToList();

            if (checkforattamt.Count() == 0)
            {
                AttamtedQuestions attamtedQuestions = new AttamtedQuestions();
                attamtedQuestions.QuestionId = Convert.ToInt32(questionidlabel.Text);
                attamtedQuestions.LevelId = Convert.ToInt32(Level.Split(',')[1]);
                attamtedQuestions.RoundId = Convert.ToInt32(Round.Split(',')[1]);
                attamtedQuestions.Marks = 0;
                attamtedQuestions.TeamId = _quizTeamService.GetAll().Where(x => x.Name == TeanNamelabel.Text).Select(x => x.Id).FirstOrDefault();
                attamtedQuestions.TeamName = TeanNamelabel.Text;
                attamtedQuestions.AcademicYear = AcademicYearlabel.Text;
                attamtedQuestions.IsTrue = false;
                attamtedQuestions.CreatedBy = "Admin";
                attamtedQuestions.CreatedDate = DateTime.Now;

                _attamtedQuestionsService.Add(attamtedQuestions);
                _attamtedQuestionsService.Save();

                QuizTeam quizTeam = _quizTeamService.FindBy(x => x.Id == attamtedQuestions.TeamId).FirstOrDefault();
                quizTeam.Marks += attamtedQuestions.Marks;

                _quizTeamService.Edit(quizTeam);
                _quizTeamService.Save();

                WrongForm wrong = new WrongForm();
                wrong.Text = "Wrong answer";
                wrong.ShowDialog();

                CalculateMarks();
            }
            else
            {
                MessageBox.Show("You have already attempted this question, please go to next question", "Alert");
            }
        }

        private void Startbutton_Click(object sender, EventArgs e)
        {
            if (Startbutton.Text == "Start Time")
            {
                timer1.Enabled = true;
                timer1.Start();
                Startbutton.Text = "Stop Time";
            }
            else
            {
                Startbutton.Text = "Start Time";
                timer1.Stop();
                player1.Stop();
                player.Stop();
            }
        }

        private void Stopbutton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            player.Stop();
            player1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (quick >= 0)
            {
                quick--;
                if (quick >= 0)
                    Timelabel.Text = quick.ToString();
                player1.Play();
            }
            else
            {
                player1.Stop();
                player.Stop();
                timer1.Stop();
            }

            if ((quick) <= 6 && quick > 0)
            {
                player.Play();

                if (quick == 6)
                {
                    Timelabel.BackColor = Color.DarkRed;
                    Timelabel.ForeColor = Color.White;
                }
            }
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
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

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Black);
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Black);
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Black);
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
        }

        private void panel9_Paint_1(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
        }

        private void panel10_Paint_1(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
        }

        private void Timelabel_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            Program.chooseLevelForm.Text = "Choose quiz level and round";

            if (Program.chooseLevelForm.IsDisposed)
                Program.chooseLevelForm = new ChooseLevelForm();

            Program.chooseLevelForm.ChooseLevelForm_Load(sender, e);
            Program.chooseLevelForm.Activate();
            Program.chooseLevelForm.Show();
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            Panel box = sender as Panel;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.Black);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool IsDisable = false;
            string AcademicYear = Program.CurrAcademicYear;
            int LevelId = Convert.ToInt32(Level.Split(',')[1]);
            int RoundId = Convert.ToInt32(Round.Split(',')[1]);

            var NoOfQuestionPerTeam = _noQuesPerLeavelRoundService.GetAll().Where(x => x.LevelId == LevelId && x.RoundId == RoundId).Select(x => x.NoOfQuestion).FirstOrDefault();

            if (NoOfQuestionPerTeam != 0)
            {
                if (!String.IsNullOrEmpty(Program.TeamA))
                {
                    int TeamId = _quizTeamService.GetAll().Where(x => x.Name == Program.TeamA).Select(x => x.Id).FirstOrDefault();
                    var NoOfAttemptQues = _attamtedQuestionsService.GetAll().Where(x => x.LevelId == LevelId && x.RoundId == RoundId && x.TeamId == TeamId && x.AcademicYear == AcademicYear).ToList();

                    if (NoOfAttemptQues.Count() == NoOfQuestionPerTeam)
                        IsDisable = true;
                    else
                        IsDisable = false;
                }

                if (!String.IsNullOrEmpty(Program.TeamB))
                {
                    int TeamId = _quizTeamService.GetAll().Where(x => x.Name == Program.TeamB).Select(x => x.Id).FirstOrDefault();
                    var NoOfAttemptQues = _attamtedQuestionsService.GetAll().Where(x => x.LevelId == LevelId && x.RoundId == RoundId && x.TeamId == TeamId && x.AcademicYear == AcademicYear).ToList();

                    if (NoOfAttemptQues.Count() == NoOfQuestionPerTeam)
                        IsDisable = true;
                    else
                        IsDisable = false;
                }

                if (!String.IsNullOrEmpty(Program.TeamC))
                {
                    int TeamId = _quizTeamService.GetAll().Where(x => x.Name == Program.TeamC).Select(x => x.Id).FirstOrDefault();
                    var NoOfAttemptQues = _attamtedQuestionsService.GetAll().Where(x => x.LevelId == LevelId && x.RoundId == RoundId && x.TeamId == TeamId && x.AcademicYear == AcademicYear).ToList();

                    if (NoOfAttemptQues.Count() == NoOfQuestionPerTeam)
                        IsDisable = true;
                    else
                        IsDisable = false;
                }

                if (!String.IsNullOrEmpty(Program.TeamD))
                {
                    int TeamId = _quizTeamService.GetAll().Where(x => x.Name == Program.TeamD).Select(x => x.Id).FirstOrDefault();
                    var NoOfAttemptQues = _attamtedQuestionsService.GetAll().Where(x => x.LevelId == LevelId && x.RoundId == RoundId && x.TeamId == TeamId && x.AcademicYear == AcademicYear).ToList();

                    if (NoOfAttemptQues.Count() == NoOfQuestionPerTeam)
                        IsDisable = true;
                    else
                        IsDisable = false;
                }
            }

            if (IsDisable == true && Round.Split(',')[0] != "tie Breaker")
            {
                button2.Enabled = false;

                NexrRoundForm nextRoundForm = new NexrRoundForm();
                nextRoundForm.LevelROundLbl.Text = Level.Split(',')[0] + " " + Round.Split(',')[0] + " finished , Please click on next button";
                nextRoundForm.ShowDialog();
                this.Close();

                Program.Level = Level.Split(',')[0] + "," + LevelId.ToString();
                Program.Round = "Round4," + _quizRoundService.GetAll().Where(x => x.Name == "Round4").Select(x => x.Id).FirstOrDefault().ToString();

                Level1Round4Form Question = new Level1Round4Form();
                Question.Text = "Question";
                Question.Show();
            }
            else
            {
                GetQuestion();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            int questionnid = Convert.ToInt32(questionidlabel.Text);
            int LevelId = Convert.ToInt32(Level.Split(',')[1]);
            int RoundId = Convert.ToInt32(Round.Split(',')[1]);

            var checkforattamt = _attamtedQuestionsService.GetAll().Where(x => x.LevelId == LevelId && x.RoundId == RoundId
             && x.QuestionId == questionnid && x.AcademicYear == Program.CurrAcademicYear).ToList();

            if (checkforattamt.Count() == 0)
            {
                AttamtedQuestions attamtedQuestions = new AttamtedQuestions();
                attamtedQuestions.QuestionId = Convert.ToInt32(questionidlabel.Text);
                attamtedQuestions.Marks = 0;
                attamtedQuestions.LevelId = Convert.ToInt32(Level.Split(',')[1]);
                attamtedQuestions.RoundId = Convert.ToInt32(Round.Split(',')[1]);
                attamtedQuestions.TeamId = _quizTeamService.GetAll().Where(x => x.Name == TeanNamelabel.Text).Select(x => x.Id).FirstOrDefault();
                attamtedQuestions.TeamName = TeanNamelabel.Text;
                attamtedQuestions.AcademicYear = AcademicYearlabel.Text;
                attamtedQuestions.IsTrue = false;
                attamtedQuestions.IsSkip = true;
                attamtedQuestions.CreatedBy = "Admin";
                attamtedQuestions.CreatedDate = DateTime.Now;

                _attamtedQuestionsService.Add(attamtedQuestions);
                _attamtedQuestionsService.Save();
            }
            IsSkip = true;
            GetQuestion();
        }

        private void Level1Round3Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.chooseLevelForm.Text = "Choose quiz level and round";

            if (Program.chooseLevelForm.IsDisposed)
                Program.chooseLevelForm = new ChooseLevelForm();

            Program.chooseLevelForm.ChooseLevelForm_Load(sender, e);
            Program.chooseLevelForm.Activate();
            Program.chooseLevelForm.Show();
        }
    }
}
