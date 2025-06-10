using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UCP_1_PABD
{
    public partial class Preview_Data : Form
    {
        private string connectionString = "Data Source= LAPTOP-872LO0G1\\RINAKIT;Initial Catalog=SowroomMobil;Integrated Security=True";

        public Preview_Data(DataTable data)
        {
            InitializeComponent();
            dataGridView.DataSource = data;
        }

        private void Btn_Ok(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin mengimpor data ini ke database?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Mengimpor data dari DataGridView ke database
                ImportDataToDatabase();
            }
        }

        private void Preview_Data_Load(object sender, EventArgs e)
        {
            dataGridView.AutoResizeColumns();
        }

        private bool ValidateMobilRow(DataRow row)
        {
            string idMobil = row["ID_Mobil"].ToString();
            string status = row["Status"].ToString();
            string nikar = row["NIKar"].ToString();

            if (idMobil.Length == 0 || nikar.Length != 5)
            {
                MessageBox.Show("ID Mobil atau NIKar tidak valid.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (status != "Tersedia" && status != "Terjual")
            {
                MessageBox.Show("Status harus 'Tersedia' atau 'Terjual'.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ImportDataToDatabase()
        {
            try
            {
                DataTable dt = (DataTable)dataGridView.DataSource;

                foreach (DataRow row in dt.Rows)
                {
                    // Validasi dapat ditambahkan di sini jika perlu, misalnya cek panjang ID_Mobil atau NIKar

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand("TambahMobil", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID_Mobil", row["ID_Mobil"]);
                        cmd.Parameters.AddWithValue("@Merek", row["Merek"]);
                        cmd.Parameters.AddWithValue("@Tahun_Produksi", Convert.ToInt32(row["Tahun_Produksi"]));
                        cmd.Parameters.AddWithValue("@Type_Mobil", row["Type_Mobil"]);
                        cmd.Parameters.AddWithValue("@Pemilik", row["Pemilik"]);
                        cmd.Parameters.AddWithValue("@Jenis_Mobil", row["Jenis_Mobil"]);
                        cmd.Parameters.AddWithValue("@Harga", Convert.ToDecimal(row["Harga"]));
                        cmd.Parameters.AddWithValue("@Status", row["Status"]);
                        cmd.Parameters.AddWithValue("@Deskripsi", row["Deskripsi"]);
                        cmd.Parameters.AddWithValue("@NIKar", row["NIKar"]);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data mobil berhasil diimpor ke database.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengimpor data mobil: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
