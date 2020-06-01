using QuizCompetition.App;
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
    public partial class addTeam : Form
    {
        private readonly IQuizTeamService _quizTeamService;
        readonly int teamId;

        public addTeam(int id)
        {
            teamId = id;
            InitializeComponent();
            this._quizTeamService = new QuizTeamService(new QuizTeamRepository<QuizCompetitionDbContext>());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FormValidate();
                QuizTeam quizTeam = GetTeamObject(teamId);

                if (teamId == 0)
                {
                    quizTeam.Id = 0;
                    quizTeam.CreatedBy = "Admin";
                    quizTeam.CreatedDate = DateTime.Now;
                    _quizTeamService.Add(quizTeam);
                }
                else
                {
                    quizTeam.UpdatedBy = "Admin";
                    quizTeam.UpdatedDate = DateTime.Now;
                    _quizTeamService.Edit(quizTeam);
                }

                _quizTeamService.Save();
                this.Close();
                Program.teamListForm.GetTeams();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private QuizTeam GetTeamObject(int id)
        {
            QuizTeam quizTeam = null;

            if (id == 0)
                quizTeam = new QuizTeam();
            else
            {
                quizTeam = _quizTeamService.FindBy(x => x.Id == id).FirstOrDefault();
            }
            quizTeam.Name = textBox1.Text;
            quizTeam.Schoolname = textBox2.Text;
            return quizTeam;
        }


        private void FormValidate()
        {
            if (textBox1.Text == "")
            {
                throw new Exception("Please enter team name");
            }
            if (textBox2.Text == "")
            {
                throw new Exception("Please enter school name");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addTeam_Load(object sender, EventArgs e)
        {
            if (teamId > 0)
            {
                FillTeamForm();
            }
        }

        private void FillTeamForm()
        {
            var quizTeam = _quizTeamService.FindBy(x => x.Id == teamId).FirstOrDefault();
            textBox1.Text = quizTeam.Name;
            textBox2.Text = quizTeam.Schoolname;
        }
    }
}
