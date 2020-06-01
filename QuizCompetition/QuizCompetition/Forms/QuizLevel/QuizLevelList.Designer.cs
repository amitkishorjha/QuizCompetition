namespace QuizCompetition.Forms.QuizLevel
{
    partial class QuizLevelList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.quizLeveldataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.quizLeveldataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // quizLeveldataGridView
            // 
            this.quizLeveldataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.quizLeveldataGridView.Location = new System.Drawing.Point(2, 52);
            this.quizLeveldataGridView.Name = "quizLeveldataGridView";
            this.quizLeveldataGridView.Size = new System.Drawing.Size(512, 360);
            this.quizLeveldataGridView.TabIndex = 0;
            this.quizLeveldataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.quizLeveldataGridView_CellContentClick);
            // 
            // QuizLevelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 416);
            this.Controls.Add(this.quizLeveldataGridView);
            this.Name = "QuizLevelList";
            this.Text = "QuizLevelList";
            this.Load += new System.EventHandler(this.QuizLevelList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quizLeveldataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView quizLeveldataGridView;
    }
}