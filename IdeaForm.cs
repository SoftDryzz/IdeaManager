using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IdeaManager.Models;

namespace IdeaManager
{
    public partial class IdeaForm : Form
    {
        public Idea CurrentIdea { get; private set; }

        public IdeaForm(Idea idea = null)
        {
            InitializeComponent();
            cbPriority.DataSource = Enum.GetValues(typeof(Priority));
            cbStatus.DataSource = Enum.GetValues(typeof(IdeaStatus));

            if (idea != null)
            {
                CurrentIdea = idea;
                txtTitle.Text = idea.Title;
                txtDescription.Text = idea.Description;
                cbPriority.SelectedItem = idea.Priority;
                cbStatus.SelectedItem = idea.Status;
                txtTags.Text = string.Join(", ", idea.Tags);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("El título es obligatorio.");
                return;
            }

            var tags = txtTags.Text.Split(',')
                        .Select(t => t.Trim())
                        .Where(t => !string.IsNullOrWhiteSpace(t))
                        .ToList();

            if (CurrentIdea == null)
            {
                CurrentIdea = new Idea();
            }

            CurrentIdea.Title = txtTitle.Text;
            CurrentIdea.Description = txtDescription.Text;
            CurrentIdea.Priority = (Priority)cbPriority.SelectedItem;
            CurrentIdea.Status = (IdeaStatus)cbStatus.SelectedItem;
            CurrentIdea.Tags = tags;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
