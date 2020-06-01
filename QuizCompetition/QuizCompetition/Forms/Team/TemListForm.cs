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

namespace QuizCompetition.Forms.Team
{
    public partial class TemListForm : Form
    {
        private readonly IQuizTeamService _quizTeamService;

        public TemListForm()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();

            this._quizTeamService = new QuizTeamService(new QuizTeamRepository<QuizCompetitionDbContext>());
        }

        private void Createbtn_Click(object sender, EventArgs e)
        {
            addTeam addTeam= new addTeam(0);
            addTeam.Text = "Add Team";
            addTeam.ShowDialog();
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

                    addTeam addTeam = new addTeam(Id);
                    addTeam.ShowDialog();

                    GetTeams();
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
                        var team = _quizTeamService.FindBy(x => x.Id == Id).FirstOrDefault();
                        team.DeletedBy = "Admin";
                        team.DeletedDate = DateTime.Now;

                        _quizTeamService.Delete(team);
                        _quizTeamService.Save();
                    }
                    else if (dr == DialogResult.No)
                    {
                        //Nothing to do
                    }

                    GetTeams();
                }
            }
        }

        private void TemListForm_Load(object sender, EventArgs e)
        {
            GetTeams();  
        }

        public void GetTeams()
        {
            DataTable dt = null;

            var teams = _quizTeamService.GetAll().Select(x=>new {x.Id,x.Name,x.Schoolname,x.Marks }).ToList();

            if (teams != null && teams.Count() != 0)
            {
                if (teams.Count() > 0)
                {
                    dt = ExportExcelhelper.ListToDataTable(teams);
                }
            }
            else
            {
                List<QuizTeam> list = new List<QuizTeam>();

                QuizTeam quizTeam = new QuizTeam();
                list.Add(quizTeam);

                dt = ExportExcelhelper.ListToDataTable(list);
                dt.Rows.RemoveAt(0);
            }

            QuestiondataGridView.AutoGenerateColumns = true;
            QuestiondataGridView.DataSource = dt;
            QuestiondataGridView.Columns["Id"].Visible = false;
        }

        private void QuestiondataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
