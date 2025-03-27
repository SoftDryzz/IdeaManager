namespace IdeaManager
{
    using System.Text;
    using IdeaManager.Models;
    using IdeaManager.Services;

    public partial class MainForm : Form
    {
        private List<Idea> ideas = new();

        public MainForm()
        {

            InitializeComponent();
            LoadIdeas();
            SetupUI();
        }

        private void LoadIdeas()
        {
            ideas = IdeaService.LoadIdeas();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvIdeas.DataSource = null;

            // Hacemos una copia ordenada por defecto si querés (por fecha o por título)
            var sortedIdeas = ideas.OrderBy(i => i.CreatedAt).ToList();

            dgvIdeas.DataSource = sortedIdeas;

            // Opcional: ajustar nombres de columnas
            dgvIdeas.Columns["Title"].HeaderText = "Título";
            dgvIdeas.Columns["Description"].HeaderText = "Descripción";
            dgvIdeas.Columns["Priority"].HeaderText = "Prioridad";
            dgvIdeas.Columns["Status"].HeaderText = "Estado";
            dgvIdeas.Columns["CreatedAt"].HeaderText = "Fecha";
        }
        private void DgvIdeas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvIdeas.Rows[e.RowIndex].DataBoundItem is Idea selectedIdea)
            {
                ShowIdeaDetails(selectedIdea);
            }
        }
        private void ShowIdeaDetails(Idea idea)
        {
            string mensaje = $"📌 Título: {idea.Title}\n\n" +
                             $"📝 Descripción:\n{idea.Description}\n\n" +
                             $"🎯 Prioridad: {idea.Priority}\n" +
                             $"📊 Estado: {idea.Status}\n" +
                             $"🏷️ Tags: {string.Join(", ", idea.Tags)}\n" +
                             $"📅 Creado el: {idea.CreatedAt:dd/MM/yyyy HH:mm}";

            MessageBox.Show(mensaje, "Detalles de la Idea", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DgvIdeas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvIdeas.Rows[e.RowIndex].DataBoundItem is Idea idea)
            {
                // 🎨 Colores por estado
                if (dgvIdeas.Columns[e.ColumnIndex].Name == "Status")
                {
                    switch (idea.Status)
                    {
                        case IdeaStatus.Pending:
                            e.CellStyle.BackColor = Color.LightYellow;
                            break;
                        case IdeaStatus.InProgress:
                            e.CellStyle.BackColor = Color.LightBlue;
                            break;
                        case IdeaStatus.Completed:
                            e.CellStyle.BackColor = Color.LightGreen;
                            break;
                    }
                }

                // 🔥 Colores por prioridad (aplica a toda la fila)
                if (dgvIdeas.Columns[e.ColumnIndex].Name == "Priority")
                {
                    switch (idea.Priority)
                    {
                        case Priority.High:
                            e.Value = "🔥 Alta";
                            break;
                        case Priority.Medium:
                            e.Value = "⚠️ Media";
                            break;
                        case Priority.Low:
                            e.Value = "🟢 Baja";
                            break;
                    }
                    e.FormattingApplied = true;
                }

            }
        }

private void SetupUI()
{
    // 🎨 Estilo del DataGridView
    dgvIdeas.CellFormatting += DgvIdeas_CellFormatting;
    dgvIdeas.CellDoubleClick += DgvIdeas_CellDoubleClick;
    dgvIdeas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    dgvIdeas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
    //dgvIdeas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
    dgvIdeas.AllowUserToResizeRows = false;

    // 🧠 Filtro por estado con opción "Todos"
    cbFilterStatus.Items.Clear();
    cbFilterStatus.Items.Add("Todos"); // 👈 agregamos opción global
    cbFilterStatus.Items.AddRange(Enum.GetNames(typeof(IdeaStatus)));
    cbFilterStatus.SelectedIndex = 0; // por defecto "Todos"
    cbFilterStatus.SelectedIndexChanged += (s, e) => ApplyFilter();

    // 🔍 Filtro por búsqueda
    txtSearch.TextChanged += (s, e) => ApplyFilter();

    // 🧩 Botones
    btnAdd.Click += BtnAdd_Click;
    btnEdit.Click += BtnEdit_Click;       // <- ¡Esto faltaba!
    btnDelete.Click += BtnDelete_Click;
}

        private void ApplyFilter()
        {
            string selectedStatus = cbFilterStatus.SelectedItem?.ToString();
            var searchText = txtSearch.Text.ToLower();

            var filtered = ideas
                .Where(i =>
                    (selectedStatus == "Todos" || i.Status.ToString() == selectedStatus) &&
                    (i.Title.ToLower().Contains(searchText) || i.Description.ToLower().Contains(searchText))
                )
                .ToList();

            dgvIdeas.DataSource = null;
            dgvIdeas.DataSource = filtered;
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var form = new IdeaForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ideas.Add(form.CurrentIdea);
                IdeaService.SaveIdeas(ideas);
                RefreshGrid();
            }
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvIdeas.CurrentRow?.DataBoundItem is Idea selected)
            {
                var form = new IdeaForm(selected);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    IdeaService.SaveIdeas(ideas);
                    RefreshGrid();
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "Archivo de texto (*.txt)|*.txt|Archivo CSV (*.csv)|*.csv|Markdown (*.md)|*.md",
                Title = "Exportar Ideas",
                FileName = "ideas_export"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveDialog.FileName;

                try
                {
                    if (path.EndsWith(".txt"))
                        ExportAsTxt(path);
                    else if (path.EndsWith(".csv"))
                        ExportAsCsv(path);
                    else if (path.EndsWith(".md"))
                        ExportAsMarkdown(path);

                    MessageBox.Show("Exportación completada con éxito.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ExportAsTxt(string path)
        {
            var lines = ideas.Select(i =>
                $"Título: {i.Title}\n" +
                $"Descripción: {i.Description}\n" +
                $"Prioridad: {i.Priority}\n" +
                $"Estado: {i.Status}\n" +
                $"Tags: {string.Join(", ", i.Tags)}\n" +
                $"Creado: {i.CreatedAt:yyyy-MM-dd HH:mm}\n" +
                "----------------------------------------"
            );

            File.WriteAllLines(path, lines);
        }

        private void ExportAsCsv(string path)
        {
            var csv = new List<string>
    {
        "Título,Descripción,Prioridad,Estado,Tags,Creado"
    };

            csv.AddRange(ideas.Select(i =>
                $"\"{i.Title}\",\"{i.Description.Replace("\"", "\"\"")}\",{i.Priority},{i.Status},\"{string.Join(";", i.Tags)}\",{i.CreatedAt:yyyy-MM-dd HH:mm}"
            ));

            File.WriteAllLines(path, csv);
        }

        private void ExportAsMarkdown(string path)
        {
            var sb = new StringBuilder();
            sb.AppendLine("# 📌 Ideas Exportadas\n");

            foreach (var i in ideas)
            {
                sb.AppendLine($"## {i.Title}");
                sb.AppendLine($"**Descripción:** {i.Description}");
                sb.AppendLine($"- Prioridad: `{i.Priority}`");
                sb.AppendLine($"- Estado: `{i.Status}`");
                sb.AppendLine($"- Tags: {string.Join(", ", i.Tags)}");
                sb.AppendLine($"- Creado: {i.CreatedAt:yyyy-MM-dd HH:mm}");
                sb.AppendLine("---\n");
            }

            File.WriteAllText(path, sb.ToString());
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvIdeas.CurrentRow?.DataBoundItem is Idea selected)
            {
                ideas.Remove(selected);
                IdeaService.SaveIdeas(ideas);
                RefreshGrid();
            }
        }

        private void dgvIdeas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
