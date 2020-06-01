using QuizCompetition.BusinessLogic.Impl;
using QuizCompetition.BusinessLogic.Interface;
using QuizCompetition.Models;
using QuizCompetition.Repository.Common;
using QuizCompetition.Repository.Impl;
using System;
using System.Windows.Forms;
using QuizCompetition.Models;

namespace QuizCompetition.Forms
{
    public partial class QuizLevelForm : Form
    {
        private readonly IQuizLevelService _quizLevelService;

        public QuizLevelForm()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();

            this._quizLevelService = new QuizLevelService(new QuizLevelRepository<QuizCompetitionDbContext>());
        }

        private void QuizLevelForm_Load(object sender, EventArgs e)
        {

        }

        private void levelSavebut_Click(object sender, EventArgs e)
        {
            QuizCompetition.Models.QuizLevel quizLevel = new QuizCompetition.Models.QuizLevel();
            quizLevel.Name = levelNameTxt.Text;
            quizLevel.Description = lblDescription.Text;
            quizLevel.CreatedBy = "Admin";
            quizLevel.CreatedDate = DateTime.Now;

            _quizLevelService.Add(quizLevel);
            _quizLevelService.Save();

        }
    }
}
