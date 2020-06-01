namespace QuizCompetition.Repository.Migrations
{
    using QuizCompetition.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<QuizCompetition.Repository.Common.QuizCompetitionDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(QuizCompetition.Repository.Common.QuizCompetitionDbContext context)
        {
            User user = new User();
            user.UserName = "Admin";
            user.Password = "Admin";
            user.CreatedBy = "Admin";
            user.IsActive = true;
            user.CreatedDate = DateTime.Now;

            context.User.AddOrUpdate(user);

            for (int i = 1; i <= 3; i++)
            {
                QuizLevel quizLevel = new QuizLevel();
                quizLevel.Name = "Level" + i;
                quizLevel.Description = "Level" + i;
                quizLevel.CreatedBy = "Admin";
                quizLevel.IsActive = true;
                quizLevel.CreatedDate = DateTime.Now;

                if (context.QuizLevel.Where(x => x.Name == quizLevel.Name).Count() == 0)
                    context.QuizLevel.AddOrUpdate(quizLevel);
            }

            QuizRound quizRound = new QuizRound();
            quizRound.Name = "Round1";
            quizRound.Description = "Round1";
            quizRound.CreatedBy = "Admin";
            quizRound.IsActive = true;
            quizRound.CreatedDate = DateTime.Now;
            quizRound.NoOfQuestions = 4;

            if (context.QuizRound.Where(x => x.Name == quizRound.Name).Count() == 0)
                context.QuizRound.AddOrUpdate(quizRound);

            QuizRound quizRound1 = new QuizRound();
            quizRound1.Name = "Round2";
            quizRound1.Description = "Round2";
            quizRound1.CreatedBy = "Admin";
            quizRound1.IsActive = true;
            quizRound1.CreatedDate = DateTime.Now;
            quizRound1.NoOfQuestions = 4;

            if (context.QuizRound.Where(x => x.Name == quizRound1.Name).Count() == 0)
                context.QuizRound.AddOrUpdate(quizRound1);

            QuizRound quizRound2 = new QuizRound();
            quizRound2.Name = "Round3";
            quizRound2.Description = "Round3";
            quizRound2.CreatedBy = "Admin";
            quizRound2.IsActive = true;
            quizRound2.CreatedDate = DateTime.Now;
            quizRound2.NoOfQuestions = 4;

            if (context.QuizRound.Where(x => x.Name == quizRound2.Name).Count() == 0)
                context.QuizRound.AddOrUpdate(quizRound2);

            QuizRound quizRound3 = new QuizRound();
            quizRound3.Name = "Round4";
            quizRound3.Description = "Round4";
            quizRound3.CreatedBy = "Admin";
            quizRound3.IsActive = true;
            quizRound3.CreatedDate = DateTime.Now;
            quizRound3.NoOfQuestions = 4;

            if (context.QuizRound.Where(x => x.Name == quizRound3.Name).Count() == 0)
                context.QuizRound.AddOrUpdate(quizRound3);

            QuizRound quizRoundtieBreaker = new QuizRound();
            quizRoundtieBreaker.Name = "tie Breaker";
            quizRoundtieBreaker.Description = "tie Breaker";
            quizRoundtieBreaker.CreatedBy = "Admin";
            quizRoundtieBreaker.IsActive = true;
            quizRoundtieBreaker.CreatedDate = DateTime.Now;
            quizRoundtieBreaker.NoOfQuestions = 4;

            if (context.QuizRound.Where(x => x.Name == quizRoundtieBreaker.Name).Count() == 0)
                context.QuizRound.AddOrUpdate(quizRoundtieBreaker);

            QuizTeam quizTeam = new QuizTeam();
            quizTeam.Name = "Team1";
            quizTeam.Schoolname = "Team1";
            quizTeam.Marks = 0;
            quizTeam.CreatedBy = "Admin";
            quizTeam.IsActive = true;
            quizTeam.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam);

            QuizTeam quizTeam1 = new QuizTeam();
            quizTeam1.Name = "Team2";
            quizTeam1.Schoolname = "Team2";
            quizTeam1.Marks = 0;
            quizTeam1.CreatedBy = "Admin";
            quizTeam1.IsActive = true;
            quizTeam1.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam1.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam1);

            QuizTeam quizTeam2 = new QuizTeam();
            quizTeam2.Name = "Team3";
            quizTeam2.Schoolname = "Team3";
            quizTeam2.Marks = 0;
            quizTeam2.CreatedBy = "Admin";
            quizTeam2.IsActive = true;
            quizTeam2.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam2.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam2);

            QuizTeam quizTeam3 = new QuizTeam();
            quizTeam3.Name = "Team4";
            quizTeam3.Schoolname = "Team4";
            quizTeam3.Marks = 0;
            quizTeam3.CreatedBy = "Admin";
            quizTeam3.IsActive = true;
            quizTeam3.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam3.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam3);

            QuizTeam quizTeam4 = new QuizTeam();
            quizTeam4.Name = "Team5";
            quizTeam4.Schoolname = "Team5";
            quizTeam4.Marks = 0;
            quizTeam4.CreatedBy = "Admin";
            quizTeam4.IsActive = true;
            quizTeam4.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam4.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam4);

            QuizTeam quizTeam5 = new QuizTeam();
            quizTeam5.Name = "Team6";
            quizTeam5.Schoolname = "Team6";
            quizTeam5.Marks = 0;
            quizTeam5.CreatedBy = "Admin";
            quizTeam5.IsActive = true;
            quizTeam5.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam5.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam5);


            QuizTeam quizTeam6 = new QuizTeam();
            quizTeam6.Name = "Team7";
            quizTeam6.Schoolname = "Team7";
            quizTeam6.Marks = 0;
            quizTeam6.CreatedBy = "Admin";
            quizTeam6.IsActive = true;
            quizTeam6.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam6.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam6);


            QuizTeam quizTeam7 = new QuizTeam();
            quizTeam7.Name = "Team8";
            quizTeam7.Schoolname = "Team8";
            quizTeam7.Marks = 0;
            quizTeam7.CreatedBy = "Admin";
            quizTeam7.IsActive = true;
            quizTeam7.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam7.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam7);


            QuizTeam quizTeam8 = new QuizTeam();
            quizTeam8.Name = "Team9";
            quizTeam8.Schoolname = "Team9";
            quizTeam8.Marks = 0;
            quizTeam8.CreatedBy = "Admin";
            quizTeam8.IsActive = true;
            quizTeam8.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam8.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam8);


            QuizTeam quizTeam9 = new QuizTeam();
            quizTeam9.Name = "Team10";
            quizTeam9.Schoolname = "Team10";
            quizTeam9.Marks = 0;
            quizTeam9.CreatedBy = "Admin";
            quizTeam9.IsActive = true;
            quizTeam9.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam9.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam9);

            QuizTeam quizTeam10 = new QuizTeam();
            quizTeam10.Name = "Team11";
            quizTeam10.Schoolname = "Team11";
            quizTeam10.Marks = 0;
            quizTeam10.CreatedBy = "Admin";
            quizTeam10.IsActive = true;
            quizTeam10.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam10.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam10);

            QuizTeam quizTeam11 = new QuizTeam();
            quizTeam11.Name = "Team12";
            quizTeam11.Schoolname = "Team12";
            quizTeam11.Marks = 0;
            quizTeam11.CreatedBy = "Admin";
            quizTeam11.IsActive = true;
            quizTeam11.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam11.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam11);

            QuizTeam quizTeam12 = new QuizTeam();
            quizTeam12.Name = "Team13";
            quizTeam12.Schoolname = "Team13";
            quizTeam12.Marks = 0;
            quizTeam12.CreatedBy = "Admin";
            quizTeam12.IsActive = true;
            quizTeam12.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam12.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam12);


            QuizTeam quizTeam13 = new QuizTeam();
            quizTeam13.Name = "Team14";
            quizTeam13.Schoolname = "Team14";
            quizTeam13.Marks = 0;
            quizTeam13.CreatedBy = "Admin";
            quizTeam13.IsActive = true;
            quizTeam13.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam13.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam13);

            QuizTeam quizTeam14 = new QuizTeam();
            quizTeam14.Name = "Team15";
            quizTeam14.Schoolname = "Team15";
            quizTeam14.Marks = 0;
            quizTeam14.CreatedBy = "Admin";
            quizTeam14.IsActive = true;
            quizTeam14.CreatedDate = DateTime.Now;

            if (context.QuizTeams.Where(x => x.Name == quizTeam14.Name).Count() == 0)
                context.QuizTeams.AddOrUpdate(quizTeam14);

            NoQuesPerLeavelRound noQuesPerLeavelRound = new NoQuesPerLeavelRound();
            noQuesPerLeavelRound.LevelId = context.QuizLevel.Where(x => x.Name == "Level1").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound.RoundId = context.QuizRound.Where(x => x.Name == "Round1").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound.NoOfQuestion = 5;
            noQuesPerLeavelRound.CreatedBy = "Admin";
            noQuesPerLeavelRound.IsActive = true;
            noQuesPerLeavelRound.CreatedDate = DateTime.Now;

            if (context.NoQuesPerLeavelRounds.Where(x => x.LevelId == noQuesPerLeavelRound.LevelId && x.RoundId == noQuesPerLeavelRound.RoundId).Count() == 0)
                context.NoQuesPerLeavelRounds.AddOrUpdate(noQuesPerLeavelRound);

            NoQuesPerLeavelRound noQuesPerLeavelRound1 = new NoQuesPerLeavelRound();
            noQuesPerLeavelRound1.LevelId = context.QuizLevel.Where(x => x.Name == "Level1").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound1.RoundId = context.QuizRound.Where(x => x.Name == "Round2").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound1.NoOfQuestion = 1;
            noQuesPerLeavelRound1.CreatedBy = "Admin";
            noQuesPerLeavelRound1.IsActive = true;
            noQuesPerLeavelRound1.CreatedDate = DateTime.Now;

            if (context.NoQuesPerLeavelRounds.Where(x => x.LevelId == noQuesPerLeavelRound1.LevelId && x.RoundId == noQuesPerLeavelRound1.RoundId).Count() == 0)
                context.NoQuesPerLeavelRounds.AddOrUpdate(noQuesPerLeavelRound1);

            NoQuesPerLeavelRound noQuesPerLeavelRound3 = new NoQuesPerLeavelRound();
            noQuesPerLeavelRound3.LevelId = context.QuizLevel.Where(x => x.Name == "Level1").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound3.RoundId = context.QuizRound.Where(x => x.Name == "Round3").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound3.NoOfQuestion = 1;
            noQuesPerLeavelRound3.CreatedBy = "Admin";
            noQuesPerLeavelRound3.IsActive = true;
            noQuesPerLeavelRound3.CreatedDate = DateTime.Now;

            if (context.NoQuesPerLeavelRounds.Where(x => x.LevelId == noQuesPerLeavelRound3.LevelId && x.RoundId == noQuesPerLeavelRound3.RoundId).Count() == 0)
                context.NoQuesPerLeavelRounds.AddOrUpdate(noQuesPerLeavelRound3);

            NoQuesPerLeavelRound noQuesPerLeavelRound2 = new NoQuesPerLeavelRound();
            noQuesPerLeavelRound2.LevelId = context.QuizLevel.Where(x => x.Name == "Level1").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound2.RoundId = context.QuizRound.Where(x => x.Name == "Round4").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound2.NoOfQuestion = 4;
            noQuesPerLeavelRound2.CreatedBy = "Admin";
            noQuesPerLeavelRound2.IsActive = true;
            noQuesPerLeavelRound2.CreatedDate = DateTime.Now;

            if (context.NoQuesPerLeavelRounds.Where(x => x.LevelId == noQuesPerLeavelRound2.LevelId && x.RoundId == noQuesPerLeavelRound2.RoundId).Count() == 0)
                context.NoQuesPerLeavelRounds.AddOrUpdate(noQuesPerLeavelRound2);

            NoQuesPerLeavelRound noQuesPerLeavelRound4 = new NoQuesPerLeavelRound();
            noQuesPerLeavelRound4.LevelId = context.QuizLevel.Where(x => x.Name == "Level2").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound4.RoundId = context.QuizRound.Where(x => x.Name == "Round1").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound4.NoOfQuestion = 1;
            noQuesPerLeavelRound4.CreatedBy = "Admin";
            noQuesPerLeavelRound4.IsActive = true;
            noQuesPerLeavelRound4.CreatedDate = DateTime.Now;

            if (context.NoQuesPerLeavelRounds.Where(x => x.LevelId == noQuesPerLeavelRound4.LevelId && x.RoundId == noQuesPerLeavelRound4.RoundId).Count() == 0)
                context.NoQuesPerLeavelRounds.AddOrUpdate(noQuesPerLeavelRound4);


            NoQuesPerLeavelRound noQuesPerLeavelRound5 = new NoQuesPerLeavelRound();
            noQuesPerLeavelRound5.LevelId = context.QuizLevel.Where(x => x.Name == "Level2").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound5.RoundId = context.QuizRound.Where(x => x.Name == "Round2").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound5.NoOfQuestion = 1;
            noQuesPerLeavelRound5.CreatedBy = "Admin";
            noQuesPerLeavelRound5.IsActive = true;
            noQuesPerLeavelRound5.CreatedDate = DateTime.Now;

            if (context.NoQuesPerLeavelRounds.Where(x => x.LevelId == noQuesPerLeavelRound5.LevelId && x.RoundId == noQuesPerLeavelRound5.RoundId).Count() == 0)
                context.NoQuesPerLeavelRounds.AddOrUpdate(noQuesPerLeavelRound5);

            NoQuesPerLeavelRound noQuesPerLeavelRound6 = new NoQuesPerLeavelRound();
            noQuesPerLeavelRound6.LevelId = context.QuizLevel.Where(x => x.Name == "Level2").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound6.RoundId = context.QuizRound.Where(x => x.Name == "Round3").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound6.NoOfQuestion = 4;
            noQuesPerLeavelRound6.CreatedBy = "Admin";
            noQuesPerLeavelRound6.IsActive = true;
            noQuesPerLeavelRound6.CreatedDate = DateTime.Now;

            if (context.NoQuesPerLeavelRounds.Where(x => x.LevelId == noQuesPerLeavelRound6.LevelId && x.RoundId == noQuesPerLeavelRound6.RoundId).Count() == 0)
                context.NoQuesPerLeavelRounds.AddOrUpdate(noQuesPerLeavelRound6);


            NoQuesPerLeavelRound noQuesPerLeavelRound7 = new NoQuesPerLeavelRound();
            noQuesPerLeavelRound7.LevelId = context.QuizLevel.Where(x => x.Name == "Level2").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound7.RoundId = context.QuizRound.Where(x => x.Name == "Round4").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound7.NoOfQuestion = 4;
            noQuesPerLeavelRound7.CreatedBy = "Admin";
            noQuesPerLeavelRound7.IsActive = true;
            noQuesPerLeavelRound7.CreatedDate = DateTime.Now;

            if (context.NoQuesPerLeavelRounds.Where(x => x.LevelId == noQuesPerLeavelRound7.LevelId && x.RoundId == noQuesPerLeavelRound7.RoundId).Count() == 0)
                context.NoQuesPerLeavelRounds.AddOrUpdate(noQuesPerLeavelRound7);

            NoQuesPerLeavelRound noQuesPerLeavelRound8 = new NoQuesPerLeavelRound();
            noQuesPerLeavelRound8.LevelId = context.QuizLevel.Where(x => x.Name == "Level3").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound8.RoundId = context.QuizRound.Where(x => x.Name == "Round1").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound8.NoOfQuestion = 5;
            noQuesPerLeavelRound8.CreatedBy = "Admin";
            noQuesPerLeavelRound8.IsActive = true;
            noQuesPerLeavelRound8.CreatedDate = DateTime.Now;

            if (context.NoQuesPerLeavelRounds.Where(x => x.LevelId == noQuesPerLeavelRound8.LevelId && x.RoundId == noQuesPerLeavelRound8.RoundId).Count() == 0)
                context.NoQuesPerLeavelRounds.AddOrUpdate(noQuesPerLeavelRound8);

            NoQuesPerLeavelRound noQuesPerLeavelRound9 = new NoQuesPerLeavelRound();
            noQuesPerLeavelRound9.LevelId = context.QuizLevel.Where(x => x.Name == "Level3").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound9.RoundId = context.QuizRound.Where(x => x.Name == "Round2").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound9.NoOfQuestion = 1;
            noQuesPerLeavelRound9.CreatedBy = "Admin";
            noQuesPerLeavelRound9.IsActive = true;
            noQuesPerLeavelRound9.CreatedDate = DateTime.Now;

            if (context.NoQuesPerLeavelRounds.Where(x => x.LevelId == noQuesPerLeavelRound9.LevelId && x.RoundId == noQuesPerLeavelRound9.RoundId).Count() == 0)
                context.NoQuesPerLeavelRounds.AddOrUpdate(noQuesPerLeavelRound9);

            NoQuesPerLeavelRound noQuesPerLeavelRound10 = new NoQuesPerLeavelRound();
            noQuesPerLeavelRound10.LevelId = context.QuizLevel.Where(x => x.Name == "Level3").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound10.RoundId = context.QuizRound.Where(x => x.Name == "Round3").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound10.NoOfQuestion = 1;
            noQuesPerLeavelRound10.CreatedBy = "Admin";
            noQuesPerLeavelRound10.IsActive = true;
            noQuesPerLeavelRound10.CreatedDate = DateTime.Now;

            if (context.NoQuesPerLeavelRounds.Where(x => x.LevelId == noQuesPerLeavelRound10.LevelId && x.RoundId == noQuesPerLeavelRound10.RoundId).Count() == 0)
                context.NoQuesPerLeavelRounds.AddOrUpdate(noQuesPerLeavelRound10);

            NoQuesPerLeavelRound noQuesPerLeavelRound11 = new NoQuesPerLeavelRound();
            noQuesPerLeavelRound11.LevelId = context.QuizLevel.Where(x => x.Name == "Level3").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound11.RoundId = context.QuizRound.Where(x => x.Name == "Round4").Select(x => x.Id).FirstOrDefault();
            noQuesPerLeavelRound11.NoOfQuestion = 4;
            noQuesPerLeavelRound11.CreatedBy = "Admin";
            noQuesPerLeavelRound11.IsActive = true;
            noQuesPerLeavelRound11.CreatedDate = DateTime.Now;

            if (context.NoQuesPerLeavelRounds.Where(x => x.LevelId == noQuesPerLeavelRound11.LevelId && x.RoundId == noQuesPerLeavelRound11.RoundId).Count() == 0)
                context.NoQuesPerLeavelRounds.AddOrUpdate(noQuesPerLeavelRound11);


            context.SaveChanges();
        }
    }
}
