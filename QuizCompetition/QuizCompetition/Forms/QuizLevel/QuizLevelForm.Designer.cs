namespace QuizCompetition.Forms
{
    partial class QuizLevelForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.levelNameTxt = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.desctext = new System.Windows.Forms.TextBox();
            this.levelSavebut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // levelNameTxt
            // 
            this.levelNameTxt.Location = new System.Drawing.Point(219, 51);
            this.levelNameTxt.Name = "levelNameTxt";
            this.levelNameTxt.Size = new System.Drawing.Size(161, 20);
            this.levelNameTxt.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(113, 95);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description :";
            // 
            // desctext
            // 
            this.desctext.Location = new System.Drawing.Point(219, 95);
            this.desctext.Multiline = true;
            this.desctext.Name = "desctext";
            this.desctext.Size = new System.Drawing.Size(161, 54);
            this.desctext.TabIndex = 3;
            // 
            // levelSavebut
            // 
            this.levelSavebut.Location = new System.Drawing.Point(219, 184);
            this.levelSavebut.Name = "levelSavebut";
            this.levelSavebut.Size = new System.Drawing.Size(75, 23);
            this.levelSavebut.TabIndex = 4;
            this.levelSavebut.Text = "Save";
            this.levelSavebut.UseVisualStyleBackColor = true;
            this.levelSavebut.Click += new System.EventHandler(this.levelSavebut_Click);
            // 
            // QuizLevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 445);
            this.Controls.Add(this.levelSavebut);
            this.Controls.Add(this.desctext);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.levelNameTxt);
            this.Controls.Add(this.label1);
            this.Name = "QuizLevelForm";
            this.Text = "QuizLevelForm";
            this.Load += new System.EventHandler(this.QuizLevelForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox levelNameTxt;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox desctext;
        private System.Windows.Forms.Button levelSavebut;
    }
}