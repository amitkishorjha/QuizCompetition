using QuizCompetition.Forms.Question;
using QuizCompetition.Forms.Quiz;
using QuizCompetition.Forms.Team;
using QuizCompetition.Repository.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizCompetition.App
{
    static class Program
    {

        public static int NoOfQuestion = 0 , AttemtNoOfQuestion=0;
        public static string Level = string.Empty;
        public static string Round = string.Empty;

        public static string TeamA = string.Empty;
        public static string TeamB = string.Empty;
        public static string TeamC = string.Empty;
        public static string TeamD = string.Empty;

        public static string CurrAcademicYear = string.Empty;

        public static Form2 form2;
        public static QuestionListForm Questions;
        public static ChooseLevelForm chooseLevelForm;
        public static TemListForm teamListForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var configuration = new QuizCompetition.Repository.Migrations.Configuration();
            //configuration.ContextKey = "QuizCompetitionDbContext";
            //var migrator = new System.Data.Entity.Migrations.DbMigrator(configuration);
            //migrator.Update();

            form2 = new Form2();
            Questions = new QuestionListForm();
            chooseLevelForm = new ChooseLevelForm();
            teamListForm = new TemListForm();

            if (System.DateTime.Now.Month < 5)
            {
                CurrAcademicYear = (DateTime.Now.Year - 1).ToString() + " - " + DateTime.Now.Year;
            }
            else
                CurrAcademicYear = (DateTime.Now.Year).ToString() + " - " + (DateTime.Now.Year + 1);

            Application.Run(new MDIParentForm());
        }
    }
}
