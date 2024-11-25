using Cafe.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public partial class Reporting : Form
    {
        public Reporting()
        {
            InitializeComponent();
        }

        Cafe_DatabaseDataContext db = new Cafe_DatabaseDataContext();


        private void Reporting_Load(object sender, EventArgs e)
        {
            LoadReports();

            var kantumruyFont = new Font("Kantumruy Pro", 10, FontStyle.Bold);
            DgvReport.ColumnHeadersDefaultCellStyle.Font = kantumruyFont; // Font for header
            DgvReport.DefaultCellStyle.Font = kantumruyFont; // Font for rows
        }

        private void LoadReports()
        {
            try
            {
                DgvReport.DataSource = db.V_Reports.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reports: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (ValidateDateRange(out DateTime startDate, out DateTime endDate))
            {
                try
                {
                    var reports = db.V_Reports
                        .Where(x => x.Print_Date >= startDate && x.Print_Date <= endDate)
                        .ToList();

                    DgvReport.DataSource = reports;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error searching reports: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            UpdateDataGridView(searchText);
        }
        private void UpdateDataGridView(string searchText)
        {
            try
            {
                var reports = string.IsNullOrEmpty(searchText)
                    ? db.V_Reports.ToList()
                    : db.V_Reports.Where(x => x.Inv_No.Contains(searchText)).ToList();

                DgvReport.DataSource = reports;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating report data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateDateRange(out DateTime startDate, out DateTime endDate)
        {
            startDate = DateTime.MinValue;
            endDate = DateTime.MaxValue;

            if (DateTime.TryParse(dtFrom.Text, out DateTime fromDate) && DateTime.TryParse(dtTo.Text, out DateTime toDate))
            {
                if (fromDate <= toDate)
                {
                    startDate = fromDate;
                    endDate = toDate;
                    return true;
                }
                MessageBox.Show("Start date must be earlier than or equal to end date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Please enter valid dates.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }




        private void BtnExport_Click(object sender, EventArgs e)
        {
            ExportToCsv();
        }

        private void ExportToCsv()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.Title = "Save an Exported File";
                saveFileDialog.FileName = "ExportedData.csv"; // Default file name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile()))
                        {
                            // Write the header
                            var columnNames = DgvReport.Columns.Cast<DataGridViewColumn>().Select(column => EscapeCsvValue(column.HeaderText));
                            writer.WriteLine(string.Join(",", columnNames));

                            // Write the rows
                            foreach (DataGridViewRow row in DgvReport.Rows)
                            {
                                var cellValues = row.Cells.Cast<DataGridViewCell>().Select(cell => EscapeCsvValue(cell.Value?.ToString()));
                                writer.WriteLine(string.Join(",", cellValues));
                            }
                        }

                        MessageBox.Show("Data exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private string EscapeCsvValue(string value)
        {
            // Escape quotes and enclose in quotes
            return $"\"{value?.Replace("\"", "\"\"")}\"";
        }
    }
}
