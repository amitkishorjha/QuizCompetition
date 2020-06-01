using QuizCompetition.App;
using QuizCompetition.App.Common;
using QuizCompetition.BusinessLogic.Impl;
using QuizCompetition.BusinessLogic.Interface;
using QuizCompetition.Models;
using QuizCompetition.Repository.Common;
using QuizCompetition.Repository.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizCompetition.Forms.Question
{
    public partial class AddQuestionForm : Form
    {
        private readonly IQuizQuestionService _quizQuestionService;
        private readonly IQuizLevelService _quizLevelService;
        private readonly IQuizRoundService _quizRoundService;

        OpenFileDialog op1 = new OpenFileDialog();
        OpenFileDialog op2 = new OpenFileDialog();
        OpenFileDialog op3 = new OpenFileDialog();
        OpenFileDialog op4 = new OpenFileDialog();
        OpenFileDialog op5 = new OpenFileDialog();

        readonly int quesionId = 0;

        public AddQuestionForm(int id)
        {
            quesionId = id;

            InitializeComponent();

            this._quizQuestionService = new QuizQuestionService(new QuizQuestionRepository<QuizCompetitionDbContext>());
            this._quizLevelService = new QuizLevelService(new QuizLevelRepository<QuizCompetitionDbContext>());
            this._quizRoundService = new QuizRoundService(new QuizRoundRepository<QuizCompetitionDbContext>());
        }

        private void AddQuestionForm_Load(object sender, EventArgs e)
        {

            FillAcademiyears();

            FillLevels();

            FillRounds();

            FillFileTypes();

            if (quesionId > 0)
            {
                FillQuestionForm();
            }
        }

        private void FillQuestionForm()
        {
            var question = _quizQuestionService.FindBy(x => x.Id == quesionId).FirstOrDefault();

            AcademiccomboBox.SelectedValue = question.AcademicYear;
            LevelcomboBox.SelectedValue = question.LevelId;
            RoundcomboBox.SelectedValue = question.RoundId;
            QuestiontextBox.Text = question.Question;

            if (question.QuestionType != "Text")
            {
                QuestionTypecomboBox.SelectedValue = question.QuestionType;
                AppfilegroupBox.Visible = true; 

                if (question.QuestionType == "Image")
                    FileUrltextBox2.Text = @"QuesImages\" + question.DocUrl;
                else if (question.QuestionType == "Audio")
                    FileUrltextBox2.Text = @"Audios\" + question.DocUrl;
                else if (question.QuestionType == "Video")
                    FileUrltextBox2.Text = @"Videos\" + question.DocUrl;
            }
            else
            {
                QuestionTypecomboBox.SelectedValue = "";
                AppfilegroupBox.Visible = false;
            }

            if (question.IsMCQ == true)
            {
                OptionsgroupBox.Visible = true;
                CorrectAnsgroupBox.Visible = false;

                IsMCQcheckBox.Checked = true;
                Option1textBox.Text = question.Option1;
                Option2textBox.Text = question.Option2;
                Option3textBox.Text = question.Option3;
                Option4textBox.Text = question.Option4;

                if (question.CorrectAnswer.Contains("1"))
                    option1checkBox.Checked = true;
                else if (question.CorrectAnswer.Contains("2"))
                    option2checkBox.Checked = true;
                else if (question.CorrectAnswer.Contains("3"))
                    option3checkBox.Checked = true;
                else if (question.CorrectAnswer.Contains("4"))
                    option4checkBox.Checked = true;
            }
            else
            {
                OptionsgroupBox.Visible = false;
                CorrectAnsgroupBox.Visible = true;

                CorrectAnstextBox.Text = question.CorrectAnswer;
            }

            questionTime.Text = question.Time.ToString();

            FormTitel.Text = "Edit Question";
        }

        private void FillFileTypes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Key");
            dt.Columns.Add("Value");
            DataRow dr1 = dt.NewRow();

            dr1["Key"] = "";
            dr1["Value"] = "-- Select File Type --";
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["Key"] = "Image";
            dr2["Value"] = "Image";
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["Key"] = "Audio";
            dr3["Value"] = "Audio";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["Key"] = "Video";
            dr4["Value"] = "Video";
            dt.Rows.Add(dr4);

            QuestionTypecomboBox.ValueMember = "Key";
            QuestionTypecomboBox.DisplayMember = "Value";

            QuestionTypecomboBox.DataSource = dt;
        }

        private void FillAcademiyears()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Key");
            dt.Columns.Add("Value");
            DataRow dr1 = dt.NewRow();

            dr1["Key"] = "";
            dr1["Value"] = "--Select Academic Year--";
            dt.Rows.Add(dr1);
            for (int i = -1; i <= 10; i++)
            {
                DataRow dr = dt.NewRow();

                dr["Key"] = DateTime.Now.Year + i + " - " + (DateTime.Now.Year + i + 1);
                dr["Value"] = DateTime.Now.Year + i + " - " + (DateTime.Now.Year + i + 1);

                dt.Rows.Add(dr);
            }

            AcademiccomboBox.ValueMember = "Key";
            AcademiccomboBox.DisplayMember = "Value";

            AcademiccomboBox.DataSource = dt;
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

        private void QuestionTypecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (QuestionTypecomboBox.SelectedValue != null)
            {
                if (QuestionTypecomboBox.SelectedValue.ToString() != "")
                {
                    AppfilegroupBox.Visible = true;
                }
                else
                    AppfilegroupBox.Visible = false;
            }
            else
                AppfilegroupBox.Visible = false;
        }

        private void IsMCQcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsMCQcheckBox.Checked == true)
            {
                OptionsgroupBox.Visible = true;
                CorrectAnsgroupBox.Visible = false;
            }
            else
            {
                OptionsgroupBox.Visible = false;
                CorrectAnsgroupBox.Visible = true;
            }
        }

        private void Filebtn_Click(object sender, EventArgs e)
        {

            DialogResult result = op1.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                FileUrltextBox2.Text = op1.FileName;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                FormValidate();
                QuizQuestion quizQuestion = GetQuestionObject(quesionId);

                if (quesionId == 0)
                {
                    quizQuestion.Id = 0;
                    quizQuestion.CreatedBy = "Admin";
                    quizQuestion.CreatedDate = DateTime.Now;
                    _quizQuestionService.Add(quizQuestion);
                }
                else
                {
                    quizQuestion.UpdatedBy = "Admin";
                    quizQuestion.UpdatedDate = DateTime.Now;
                    _quizQuestionService.Edit(quizQuestion);
                }

                _quizQuestionService.Save();
                this.Close();
                Program.Questions.GetQuestions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private QuizQuestion GetQuestionObject(int id)
        {
            string docUrl = string.Empty;

            QuizQuestion quizQuestion = null;

            if (id == 0)
                quizQuestion = new QuizQuestion();
            else
            {
                quizQuestion = _quizQuestionService.FindBy(x => x.Id == quesionId).FirstOrDefault();
                docUrl = quizQuestion.DocUrl;
            }

            quizQuestion.AcademicYear = AcademiccomboBox.SelectedValue.ToString();
            quizQuestion.LevelId = Convert.ToInt32(LevelcomboBox.SelectedValue);
            quizQuestion.RoundId = Convert.ToInt32(RoundcomboBox.SelectedValue);
            quizQuestion.Question = QuestiontextBox.Text;

            if (QuestionTypecomboBox.SelectedValue.ToString() == "")
            {
                quizQuestion.QuestionType = "Text";
                quizQuestion.DocUrl = "";
            }
            else
            {
                quizQuestion.QuestionType = QuestionTypecomboBox.SelectedValue.ToString();
            }

            if (LevelcomboBox.Text == "Level2" && RoundcomboBox.Text == "Round2")
            {
                if (!File.Exists(@"QuesImages\"))
                {
                    Directory.CreateDirectory(@"QuesImages\");
                }

                if (op2.SafeFileName != "" && op3.SafeFileName != "" && op4.SafeFileName != "" && op5.SafeFileName != "")
                {
                    string ImagePath1 = @"QuesImages\" + Guid.NewGuid().ToString().Split('-')[0] + "_" + op2.SafeFileName;
                    string ImagePath2 = @"QuesImages\" + Guid.NewGuid().ToString().Split('-')[0] + "_" + op3.SafeFileName;
                    string ImagePath3 = @"QuesImages\" + Guid.NewGuid().ToString().Split('-')[0] + "_" + op4.SafeFileName;
                    string ImagePath4 = @"QuesImages\" + Guid.NewGuid().ToString().Split('-')[0] + "_" + op5.SafeFileName;

                    File.Copy(op2.FileName, ImagePath1);
                    File.Copy(op3.FileName, ImagePath2);
                    File.Copy(op4.FileName, ImagePath3);
                    File.Copy(op5.FileName, ImagePath4);

                    quizQuestion.DocUrl = ImagePath1 + "," + ImagePath2 + "," + ImagePath3 + "," + ImagePath4;
                }
            }

            if (quizQuestion.QuestionType == "Image")
            {
                if (!File.Exists(@"QuesImages\"))
                {
                    Directory.CreateDirectory(@"QuesImages\");
                }

                if (op1.SafeFileName != "")
                {
                    string ImagePath = @"QuesImages\" + Guid.NewGuid().ToString().Split('-')[0] + "_" + op1.SafeFileName;

                    File.Copy(op1.FileName, ImagePath);
                    quizQuestion.DocUrl = ImagePath;
                }
            }
            else if (quizQuestion.QuestionType == "Audio")
            {
                if (!File.Exists(@"Audios\"))
                {
                    Directory.CreateDirectory(@"Audios\");
                }

                if (op1.SafeFileName != "")
                {
                    string ImagePath = @"Audios\" + Guid.NewGuid().ToString().Split('-')[0] + "_" + op1.SafeFileName;

                    File.Copy(op1.FileName, ImagePath);
                    quizQuestion.DocUrl = ImagePath;
                }

            }
            else if (quizQuestion.QuestionType == "Video")
            {
                if (!File.Exists(@"Videos\"))
                {
                    Directory.CreateDirectory(@"Videos\");
                }

                if (op1.SafeFileName != "")
                {
                    string ImagePath = @"Videos\" + Guid.NewGuid().ToString().Split('-')[0] + "_" + op1.SafeFileName;

                    File.Copy(op1.FileName, ImagePath);
                    quizQuestion.DocUrl = ImagePath;
                }
            }

            if (op1.SafeFileName != "" && id != 0)
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "" + docUrl);
            }

            quizQuestion.IsMCQ = IsMCQcheckBox.Checked;

            if (IsMCQcheckBox.Checked == true)
            {
                quizQuestion.Option1 = Option1textBox.Text;
                quizQuestion.Option2 = Option2textBox.Text;
                quizQuestion.Option3 = Option3textBox.Text;
                quizQuestion.Option4 = Option4textBox.Text;

                if (option1checkBox.Checked == true)
                    quizQuestion.CorrectAnswer = Option1textBox.Text;
                else if (option2checkBox.Checked == true)
                    quizQuestion.CorrectAnswer = Option2textBox.Text;
                else if (option3checkBox.Checked == true)
                    quizQuestion.CorrectAnswer = Option3textBox.Text;
                else if (option4checkBox.Checked == true)
                    quizQuestion.CorrectAnswer = Option4textBox.Text;

            }
            else
            {
                quizQuestion.CorrectAnswer = CorrectAnstextBox.Text;
                quizQuestion.Option1 = "";
                quizQuestion.Option2 = "";
                quizQuestion.Option3 = "";
                quizQuestion.Option4 = "";
            }

            quizQuestion.Time = Convert.ToDecimal(questionTime.Text);
            return quizQuestion;
        }

        private void FormValidate()
        {
            if (AcademiccomboBox.SelectedValue.ToString() == "")
            {
                throw new Exception("Please select academic year");
            }
            if (LevelcomboBox.SelectedValue.ToString() == "0")
            {
                throw new Exception("Please select question level");
            }
            if (RoundcomboBox.SelectedValue.ToString() == "0")
            {
                throw new Exception("Please select question round");
            }

            if (QuestiontextBox.Text == "")
            {
                throw new Exception("Please enter question text");
            }

            if (QuestionTypecomboBox.SelectedValue.ToString() != "")
            {
                if (FileUrltextBox2.Text == "")
                    throw new Exception("Please select file");
            }

            if (LevelcomboBox.Text == "Level2" && RoundcomboBox.Text == "Round3")
            {
                CorrectAnstextBox.Text = "Rapid fire round";
            }
            else
            {
                if (IsMCQcheckBox.Checked == true)
                {
                    if (Option1textBox.Text == "")
                        throw new Exception("Please enter value for option 1");
                    else if (Option2textBox.Text == "")
                        throw new Exception("Please enter value for option 2");
                    else if (Option3textBox.Text == "")
                        throw new Exception("Please enter value for option 3");
                    else if (Option4textBox.Text == "")
                        throw new Exception("Please enter value for option 4");

                    if (option1checkBox.Checked == false && option2checkBox.Checked == false && option3checkBox.Checked == false
                        && option4checkBox.Checked == false)
                    {
                        throw new Exception("Please check at least one check box for correct answer");
                    }
                }
                else
                {
                    if (CorrectAnstextBox.Text == "")
                        throw new Exception("Please enter value for correct answer");
                }
            }

            if (questionTime.Text == "")
            {
                throw new Exception("Please enter question time in seconds");
            }
        }

        private void LevelcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LevelcomboBox.Text == "Level2" && RoundcomboBox.Text == "Round2")
            {
                groupFourImage.Visible = true;
                AppfilegroupBox.Visible = false;
            }
            else
            {
                groupFourImage.Visible = false;
                AppfilegroupBox.Visible = true;
            }
        }

        private void RoundcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (LevelcomboBox.Text == "Level2" && RoundcomboBox.Text == "Round2")
            {
                groupFourImage.Visible = true;
                AppfilegroupBox.Visible = false;
            }
            else
            {
                groupFourImage.Visible = false;
                AppfilegroupBox.Visible = true;
            }
        }

        private void btnBrow1_Click(object sender, EventArgs e)
        {
            DialogResult result = op2.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                textBoxImg1.Text = op2.FileName;
            }
        }

        private void btnBrow2_Click(object sender, EventArgs e)
        {
            DialogResult result = op3.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                textBoxImg2.Text = op3.FileName;
            }
        }

        private void btnBrow3_Click(object sender, EventArgs e)
        {
            DialogResult result = op4.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                textBoxImg3.Text = op4.FileName;
            }
        }

        private void btnBrow4_Click(object sender, EventArgs e)
        {
            DialogResult result = op5.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                textBoxImg4.Text = op5.FileName;
            }

        }
    }
}
