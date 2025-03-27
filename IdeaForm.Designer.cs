using IdeaManager.Models;

namespace IdeaManager
{

    partial class IdeaForm
    {
        private TextBox txtTitle;
        private TextBox txtDescription;
        private ComboBox cbPriority;
        private ComboBox cbStatus;
        private TextBox txtTags;
        private Button btnSave;

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
            txtTitle = new TextBox();
            txtDescription = new TextBox();
            cbPriority = new ComboBox();
            cbStatus = new ComboBox();
            txtTags = new TextBox();
            btnSave = new Button();
            lblTitle = new Label();
            lblDescription = new Label();
            lblPriority = new Label();
            lblStatus = new Label();
            lblTags = new Label();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(124, 10);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(226, 31);
            txtTitle.TabIndex = 5;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(124, 40);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(226, 80);
            txtDescription.TabIndex = 6;
            // 
            // cbPriority
            // 
            cbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPriority.Location = new Point(124, 130);
            cbPriority.Name = "cbPriority";
            cbPriority.Size = new Size(126, 33);
            cbPriority.TabIndex = 7;
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Location = new Point(124, 160);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(126, 33);
            cbStatus.TabIndex = 8;
            // 
            // txtTags
            // 
            txtTags.Location = new Point(124, 192);
            txtTags.Name = "txtTags";
            txtTags.Size = new Size(226, 31);
            txtTags.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(251, 230);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(99, 30);
            btnSave.TabIndex = 10;
            btnSave.Text = "Guardar";
            btnSave.Click += btnSave_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(10, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(60, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Título:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(10, 40);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(108, 25);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Descripción:";
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Location = new Point(10, 130);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(88, 25);
            lblPriority.TabIndex = 7;
            lblPriority.Text = "Prioridad:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(10, 160);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(70, 25);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Estado:";
            // 
            // lblTags
            // 
            lblTags.AutoSize = true;
            lblTags.Location = new Point(10, 190);
            lblTags.Name = "lblTags";
            lblTags.Size = new Size(51, 25);
            lblTags.TabIndex = 9;
            lblTags.Text = "Tags:";
            // 
            // IdeaForm
            // 
            ClientSize = new Size(400, 280);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblPriority);
            Controls.Add(cbPriority);
            Controls.Add(lblStatus);
            Controls.Add(cbStatus);
            Controls.Add(lblTags);
            Controls.Add(txtTags);
            Controls.Add(btnSave);
            Name = "IdeaForm";
            Text = "Idea";
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label lblTitle;
        private Label lblDescription;
        private Label lblPriority;
        private Label lblStatus;
        private Label lblTags;
    }
}