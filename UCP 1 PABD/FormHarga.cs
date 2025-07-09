using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UCP_1_PABD
{
    public partial class FormHarga : Form
    {
        public FormHarga()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            cmbJenis.Items.AddRange(new string[] { "Semua", "SUV", "Sedan", "Hatchback", "MPV" }); // Bisa sesuaikan dengan jenis asli
            cmbJenis.SelectedIndex = 0;

            LoadChartData("Semua");

            cmbJenis.SelectedIndexChanged += cmbJenis_SelectedIndexChanged;
        }

        private void cmbJenis_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbJenis.SelectedItem.ToString();
            LoadChartData(selected);
        }

        private void FormHarga_Load(object sender, EventArgs e)
        {
            // Contoh isi: inisialisasi combo box dan load chart
            cmbJenis.Items.AddRange(new string[] { "Semua", "SUV", "Sedan", "Hatchback", "MPV" });
            cmbJenis.SelectedIndex = 0;

            LoadChartData("Semua");

            cmbJenis.SelectedIndexChanged += cmbJenis_SelectedIndexChanged;
        }

        private void LoadChartData(string filter)
        {
            chartHarga.Series.Clear();
            chartHarga.Titles.Clear();
            chartHarga.Legends.Clear();
            chartHarga.ChartAreas.Clear();

            ChartArea ca = new ChartArea("AreaUtama");
            ca.AxisX.Title = "Merek Mobil";
            ca.AxisY.Title = "Harga Total (Rp)";
            ca.AxisX.LabelStyle.Angle = -45;
            ca.BackColor = Color.LightCyan;
            chartHarga.ChartAreas.Add(ca);

            string connStr = "Data Source= LAPTOP-872LO0G1\\RINAKIT;Initial Catalog=SowroomMobil;Integrated Security=True";


            string query = @"
                SELECT 
                    Merek,
                    SUM(Harga) AS TotalHarga
                FROM Mobil
                {0}
                GROUP BY Merek";

            string whereClause = "";
            if (filter != "Semua")
            {
                whereClause = "WHERE Jenis_Mobil = @Jenis";
            }

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(string.Format(query, whereClause), conn);
                if (filter != "Semua")
                {
                    cmd.Parameters.AddWithValue("@Jenis", filter);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            Series sHarga = new Series("Total Harga Mobil")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.DodgerBlue,
                IsValueShownAsLabel = true
            };

            foreach (DataRow row in dt.Rows)
            {
                decimal harga = Convert.ToDecimal(row["TotalHarga"]);
                sHarga.Points.AddXY(row["Merek"].ToString(), harga);
            }

            chartHarga.Series.Add(sHarga);
            chartHarga.Titles.Add("Grafik Total Harga Mobil per Merek");
            chartHarga.Legends.Add(new Legend("Legenda"));
        }
    }
}
