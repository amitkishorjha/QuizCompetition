using QuizCompetition.App.Common;
using QuizCompetition.BusinessLogic.Impl;
using QuizCompetition.BusinessLogic.Interface;
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

namespace QuizCompetition.Forms.QuizLevel
{
    public partial class QuizLevelList : Form
    {
        private readonly IQuizLevelService _quizLevelService;

        public QuizLevelList()
        {
            InitializeComponent();
            this._quizLevelService = new QuizLevelService(new QuizLevelRepository<QuizCompetitionDbContext>());
        }

        private void QuizLevelList_Load(object sender, EventArgs e)
        {
            quizLeveldataGridView.AutoGenerateColumns = true;
            DataSet ds = GetLevelListData();
            quizLeveldataGridView.DataSource = ds.Tables[0];
        }

        public DataSet GetLevelListData()
        {
            DataSet ds = new DataSet();
            try
            {
                var quizLevels = _quizLevelService.GetAll().Select(x => new { x.Name, x.Description}).ToList();

                DataTable dt = ExportExcelhelper.ListToDataTable(quizLevels);

                ds.Tables.Add(dt);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void quizLeveldataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
