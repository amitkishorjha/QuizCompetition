namespace QuizCompetition.Forms.Team
{
    partial class TemListForm
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
            this.QuestiondataGridView = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.Editbtn = new System.Windows.Forms.Button();
            this.Createbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QuestiondataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // QuestiondataGridView
            // 
            this.QuestiondataGridView.AllowUserToAddRows = false;
            this.QuestiondataGridView.AllowUserToDeleteRows = false;
            this.QuestiondataGridView.AllowUserToResizeRows = false;
            this.QuestiondataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QuestiondataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.QuestiondataGridView.Location = new System.Drawing.Point(0, 94);
            this.QuestiondataGridView.MultiSelect = false;
            this.QuestiondataGridView.Name = "QuestiondataGridView";
            this.QuestiondataGridView.ReadOnly = true;
            this.QuestiondataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.QuestiondataGridView.ShowCellErrors = false;
            this.QuestiondataGridView.ShowCellToolTips = false;
            this.QuestiondataGridView.ShowEditingIcon = false;
            this.QuestiondataGridView.ShowRowErrors = false;
            this.QuestiondataGridView.Size = new System.Drawing.Size(1373, 492);
            this.QuestiondataGridView.TabIndex = 1;
            this.QuestiondataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.QuestiondataGridView_CellContentClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(447, 33);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Editbtn
            // 
            this.Editbtn.Location = new System.Drawing.Point(335, 33);
            this.Editbtn.Name = "Editbtn";
            this.Editbtn.Size = new System.Drawing.Size(75, 23);
            this.Editbtn.TabIndex = 5;
            this.Editbtn.Text = "Edit";
            this.Editbtn.UseVisualStyleBackColor = true;
            this.Editbtn.Click += new System.EventHandler(this.Editbtn_Click);
            // 
            // Createbtn
            // 
            this.Createbtn.Location = new System.Drawing.Point(222, 33);
            this.Createbtn.Name = "Createbtn";
            this.Createbtn.Size = new System.Drawing.Size(75, 23);
            this.Createbtn.TabIndex = 4;
            this.Createbtn.Text = "Create";
            this.Createbtn.UseVisualStyleBackColor = true;
            this.Createbtn.Click += new System.EventHandler(this.Createbtn_Click);
            // 
            // TemListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 558);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.Editbtn);
            this.Controls.Add(this.Createbtn);
            this.Controls.Add(this.QuestiondataGridView);
            this.Name = "TemListForm";
            this.Text = "TemListForm";
            this.Load += new System.EventHandler(this.TemListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuestiondataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView QuestiondataGridView;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button Editbtn;
        private System.Windows.Forms.Button Createbtn;
    }
}