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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizCompetition.Forms.Question
{
    public partial class QuestionListForm : Form
    {
        private readonly IQuizQuestionService _quizQuestionService;
        private readonly IQuizLevelService _quizLevelService;
        private readonly IQuizRoundService _quizRoundService;

        public QuestionListForm()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();

            this._quizQuestionService = new QuizQuestionService(new QuizQuestionRepository<QuizCompetitionDbContext>());
            this._quizLevelService = new QuizLevelService(new QuizLevelRepository<QuizCompetitionDbContext>());
            this._quizRoundService = new QuizRoundService(new QuizRoundRepository<QuizCompetitionDbContext>());
        }

        private void QuestionListForm_Load(object sender, EventArgs e)
        {
            GetQuestions();
        }

        public  void GetQuestions()
        {
            DataTable dt = null;

            var questions = (from qq in _quizQuestionService.GetAll().ToList()
                             join ql in _quizLevelService.GetAll().ToList() on qq.LevelId equals ql.Id
                             join qr in _quizRoundService.GetAll().ToList() on qq.RoundId equals qr.Id
                             select new QuizQuestions
                             {
                                 Id = qq.Id,
                                 AcademicYear = qq.AcademicYear,
                                 Level = ql.Name,
                                 Round = qr.Name,
                                 QuestionText = qq.Question,
                                 QuestionType = qq.QuestionType,
                                 DocUrl = qq.DocUrl,
                                 IsMCQ = qq.IsMCQ,
                                 CorrectAnswer = qq.CorrectAnswer,
                                 Option1 = qq.Option1,
                                 Option2 = qq.Option2,
                                 Option3 = qq.Option3,
                                 Option4 = qq.Option4,
                                 Time = qq.Time + " Sec."
                             }).ToList();

            if (questions != null && questions.Count() != 0)
            {
                if (questions.Count() > 0)
                {
                    dt = ExportExcelhelper.ListToDataTable(questions);
                }
            }
            else
            {
                List<QuizQuestions> list = new List<QuizQuestions>();

                QuizQuestions quizQuestion = new QuizQuestions();
                list.Add(quizQuestion);

                dt = ExportExcelhelper.ListToDataTable(list);
                dt.Rows.RemoveAt(0);
            }

            QuestiondataGridView.AutoGenerateColumns = true;
            QuestiondataGridView.DataSource = dt;
            QuestiondataGridView.Columns["Id"].Visible = false;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Createbtn_Click(object sender, EventArgs e)
        {
            AddQuestionForm addQuestions = new AddQuestionForm(0);
            addQuestions.Text = "Add Question";
            addQuestions.ShowDialog();
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            int selectRow = QuestiondataGridView.SelectedRows.Count;
            if (selectRow > 0)
            {
                if (QuestiondataGridView.CurrentCell != null)
                {
                    int selectedRowIndex = QuestiondataGridView.CurrentCell.RowIndex;

                    DataGridViewRow row = QuestiondataGridView.Rows[selectedRowIndex];

                    int Id = Convert.ToInt32(row.Cells["Id"].Value);

                    AddQuestionForm addQuestions = new AddQuestionForm(Id);
                    addQuestions.Text = "Add Question";
                    addQuestions.ShowDialog();

                    GetQuestions();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectRow = QuestiondataGridView.SelectedRows.Count;

            if (selectRow > 0)
            {
                if (QuestiondataGridView.CurrentCell != null)
                {
                    int selectedRowIndex = QuestiondataGridView.CurrentCell.RowIndex;

                    DataGridViewRow row = QuestiondataGridView.Rows[selectedRowIndex];

                    int Id = Convert.ToInt32(row.Cells["Id"].Value);

                    DialogResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        var question = _quizQuestionService.FindBy(x => x.Id == Id).FirstOrDefault();
                        question.DeletedBy = "Admin";
                        question.DeletedDate = DateTime.Now;

                        _quizQuestionService.Delete(question);
                        _quizQuestionService.Save();
                    }
                    else if (dr == DialogResult.No)
                    {
                        //Nothing to do
                    }

                    GetQuestions();
                }
            }
        }
    }
}
