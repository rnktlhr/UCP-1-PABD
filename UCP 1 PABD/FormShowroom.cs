using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UCP_1_PABD
{
    public partial class FormShowroom : Form
    {
        public FormShowroom()
        {
            InitializeComponent();
        }

        private void FormShowroom_Load(object sender, EventArgs e)
        {
            SetupReportViewer();
            this.reportViewer1.RefreshReport();
        }

        private void SetupReportViewer()
        {
            string connectionString = "Data Source=LAPTOP-872LO0G1\\RINAKIT;Initial Catalog=SowroomMobil;Integrated Security=True";

            string query = @"
                SELECT
                    Mobil.ID_Mobil, 
                    Mobil.Merek, 
                    Mobil.Tahun_Produksi, 
                    Mobil.Type_Mobil, 
                    Mobil.Deskripsi,
                    Mobil.Harga, 
                    Karyawan.Nama_Kar
                FROM MOBIL
                INNER JOIN Karyawan ON Mobil.NIKar = Karyawan.NIKar";

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            ReportDataSource rds = new ReportDataSource("MobilDataSet", dt);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.ReportPath = @"D:\UCP 1 PABD\UCP 1 PABD\ReportMobil.rdlc";
            reportViewer1.RefreshReport();
        }

        private void btn_mobil(object sender, EventArgs e)
        {
            Mobil Mobil = new Mobil();
            Mobil.Show();
            this.Hide();
        }
    }
}
