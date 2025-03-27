namespace IdeaManager
{
    partial class MainForm
    {private System.Windows.Forms.DataGridView dgvIdeas;
private System.Windows.Forms.TextBox txtSearch;
private System.Windows.Forms.ComboBox cbFilterStatus;
private System.Windows.Forms.Button btnAdd;
private System.Windows.Forms.Button btnEdit;
private System.Windows.Forms.Button btnDelete;
private System.Windows.Forms.Label lblSearch;
private System.Windows.Forms.Label lblFilter;

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvIdeas = new DataGridView();
            txtSearch = new TextBox();
            cbFilterStatus = new ComboBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            lblSearch = new Label();
            lblFilter = new Label();
            panelBottom = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvIdeas).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // dgvIdeas
            // 
            dgvIdeas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIdeas.Dock = DockStyle.Fill;
            dgvIdeas.Location = new Point(0, 0);
            dgvIdeas.Margin = new Padding(4, 5, 4, 5);
            dgvIdeas.Name = "dgvIdeas";
            dgvIdeas.ReadOnly = true;
            dgvIdeas.RowHeadersWidth = 62;
            dgvIdeas.RowTemplate.Height = 25;
            dgvIdeas.Size = new Size(1120, 602);
            dgvIdeas.TabIndex = 0;
            dgvIdeas.CellContentClick += dgvIdeas_CellContentClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(117, 18);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(284, 31);
            txtSearch.TabIndex = 2;
            // 
            // cbFilterStatus
            // 
            cbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterStatus.FormattingEnabled = true;
            cbFilterStatus.Location = new Point(496, 18);
            cbFilterStatus.Margin = new Padding(4, 5, 4, 5);
            cbFilterStatus.Name = "cbFilterStatus";
            cbFilterStatus.Size = new Size(171, 33);
            cbFilterStatus.TabIndex = 4;
            cbFilterStatus.SelectedIndexChanged += cbFilterStatus_SelectedIndexChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(709, 16);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(107, 42);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(824, 16);
            btnEdit.Margin = new Padding(4, 5, 4, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(107, 42);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Editar";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(940, 16);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(107, 42);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(40, 23);
            lblSearch.Margin = new Padding(4, 0, 4, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(67, 25);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Buscar:";
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(423, 23);
            lblFilter.Margin = new Padding(4, 0, 4, 0);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(70, 25);
            lblFilter.TabIndex = 3;
            lblFilter.Text = "Estado:";
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(cbFilterStatus);
            panelBottom.Controls.Add(btnDelete);
            panelBottom.Controls.Add(lblSearch);
            panelBottom.Controls.Add(btnEdit);
            panelBottom.Controls.Add(txtSearch);
            panelBottom.Controls.Add(btnAdd);
            panelBottom.Controls.Add(lblFilter);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 533);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1120, 69);
            panelBottom.TabIndex = 8;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 602);
            Controls.Add(panelBottom);
            Controls.Add(dgvIdeas);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            Text = "Gestor de Ideas Personales";
            ((System.ComponentModel.ISupportInitialize)dgvIdeas).EndInit();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }


        #endregion

        private Panel panelBottom;
    }
}
