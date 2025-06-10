using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UCP_1_PABD
{
    public partial class FormMobil : Form
    {
        private string connectionString = "Data Source= LAPTOP-872LO0G1\\RINAKIT;Initial Catalog=SowroomMobil;Integrated Security=True";

        private string selectedIDMobil = "";

        public FormMobil()
        {
            InitializeComponent();
        }

        private void LoadJoinedData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        Mobil.ID_Mobil, Mobil.Merek AS [Nama Mobil], Mobil.Tahun_Produksi, Mobil.Type_Mobil AS [Tipe Mobil],
                        Mobil.Deskripsi, Mobil.Harga AS [Harga Mobil], Karyawan.Nama_Kar AS [Nama Karyawan]
                    FROM Mobil
                    INNER JOIN Karyawan ON Mobil.NIKar = Karyawan.NIKar";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                try
                {
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    selectedIDMobil = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }



        private void btn_tambah(object sender, EventArgs e)
        {
            string idMobil = txtIDMobil.Text.Trim();
            string merek = txtMerek.Text.Trim();
            string tipe = txtTipe.Text.Trim();
            string deskripsi = txtDeskripsi.Text.Trim();
            string namaKar = txtNamaKar.Text.Trim();
            decimal harga;
            int tahun;

            if (string.IsNullOrEmpty(idMobil) || string.IsNullOrEmpty(merek) ||
                string.IsNullOrEmpty(tipe) || string.IsNullOrEmpty(namaKar) ||
                !decimal.TryParse(txtHarga.Text, out harga) ||
                !int.TryParse(textTahun.Text, out tahun))
            {
                MessageBox.Show("Harap lengkapi semua data dengan format yang benar.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // Cek ID duplikat
                    using (SqlCommand checkID = new SqlCommand("SELECT COUNT(*) FROM Mobil WHERE ID_Mobil = @IDMobil", conn, trans))
                    {
                        checkID.Parameters.AddWithValue("@IDMobil", idMobil);
                        if ((int)checkID.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("ID Mobil sudah digunakan.", "Duplikasi ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            trans.Rollback();
                            return;
                        }
                    }

                    // Ambil NIK dari nama karyawan
                    object nikar;
                    using (SqlCommand getNIK = new SqlCommand("SELECT NIKar FROM Karyawan WHERE Nama_Kar = @NamaKar", conn, trans))
                    {
                        getNIK.Parameters.AddWithValue("@NamaKar", namaKar);
                        nikar = getNIK.ExecuteScalar();
                        if (nikar == null)
                        {
                            MessageBox.Show("Nama karyawan tidak ditemukan.", "Data Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            trans.Rollback();
                            return;
                        }
                    }

                    // Insert data mobil
                    using (SqlCommand insert = new SqlCommand(@"
                        INSERT INTO Mobil (ID_Mobil, Merek, Tahun_Produksi, Type_Mobil, Deskripsi, Harga, NIKar)
                        VALUES (@ID, @Merek, @Tahun, @Tipe, @Deskripsi, @Harga, @NIK)", conn, trans))
                    {
                        insert.Parameters.AddWithValue("@ID", idMobil);
                        insert.Parameters.AddWithValue("@Merek", merek);
                        insert.Parameters.AddWithValue("@Tahun", tahun);
                        insert.Parameters.AddWithValue("@Tipe", tipe);
                        insert.Parameters.AddWithValue("@Deskripsi", deskripsi);
                        insert.Parameters.AddWithValue("@Harga", harga);
                        insert.Parameters.AddWithValue("@NIK", nikar);

                        insert.ExecuteNonQuery();
                    }

                    trans.Commit();
                    lblMessage.Text = "Data berhasil ditambahkan.";
                    LoadJoinedData();
                }
                catch (Exception ex)
                {
                    trans?.Rollback();
                    MessageBox.Show("Gagal menambah data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btn_update(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIDMobil))
            {
                MessageBox.Show("Silakan pilih data yang ingin diubah.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string merek = txtMerek.Text.Trim();
            string tipe = txtTipe.Text.Trim();
            string deskripsi = txtDeskripsi.Text.Trim();
            decimal harga;
            int tahun;

            if (string.IsNullOrEmpty(merek) || string.IsNullOrEmpty(tipe) ||
                !decimal.TryParse(txtHarga.Text, out harga) ||
                !int.TryParse(textTahun.Text, out tahun))
            {
                MessageBox.Show("Format input salah. Tahun dan harga harus angka.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Yakin ingin mengubah data ini?", "Konfirmasi Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(@"
                UPDATE Mobil
                SET Merek = @Merek, Tahun_Produksi = @Tahun, Type_Mobil = @Tipe, Deskripsi = @Deskripsi, Harga = @Harga
                WHERE ID_Mobil = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@Merek", merek);
                        cmd.Parameters.AddWithValue("@Tahun", tahun);
                        cmd.Parameters.AddWithValue("@Tipe", tipe);
                        cmd.Parameters.AddWithValue("@Deskripsi", deskripsi);
                        cmd.Parameters.AddWithValue("@Harga", harga);
                        cmd.Parameters.AddWithValue("@ID", selectedIDMobil);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            lblMessage.Text = "Data berhasil diperbarui.";
                            LoadJoinedData();
                        }
                        else
                        {
                            lblMessage.Text = "Data tidak ditemukan.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal update: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_hapus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIDMobil))
            {
                MessageBox.Show("Pilih data mobil yang ingin dihapus.");
                return;
            }

            var confirm = MessageBox.Show("Yakin ingin menghapus data mobil ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Mobil WHERE ID_Mobil = @ID", conn, transaction);
                    cmd.Parameters.AddWithValue("@ID", selectedIDMobil);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        transaction.Commit();
                        MessageBox.Show("Data berhasil dihapus.");
                        LoadJoinedData();
                        selectedIDMobil = "";
                    }
                    else
                    {
                        transaction.Rollback();
                        MessageBox.Show("Data tidak ditemukan.");
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Gagal hapus: " + ex.Message);
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedIDMobil = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtIDMobil.Text = selectedIDMobil;
                txtMerek.Text = dataGridView1.Rows[e.RowIndex].Cells["Nama Mobil"].Value.ToString();
                textTahun.Text = dataGridView1.Rows[e.RowIndex].Cells["Tahun_Produksi"].Value.ToString();
                txtTipe.Text = dataGridView1.Rows[e.RowIndex].Cells["Tipe Mobil"].Value.ToString();
                txtDeskripsi.Text = dataGridView1.Rows[e.RowIndex].Cells["Deskripsi"].Value.ToString();
                txtHarga.Text = dataGridView1.Rows[e.RowIndex].Cells["Harga Mobil"].Value.ToString();
                txtNamaKar.Text = dataGridView1.Rows[e.RowIndex].Cells["Nama Karyawan"].Value.ToString();
            }
        }


        private void btn_refresh(object sender, EventArgs e)
        {
            txtIDMobil.Clear();
            txtMerek.Clear();
            txtTipe.Clear();
            textTahun.Clear();
            txtDeskripsi.Clear();
            txtHarga.Clear();
            txtNamaKar.Clear();
            lblMessage.Text = "";
            selectedIDMobil = "";
            dataGridView1.ClearSelection();
            LoadJoinedData();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadJoinedData();
        }

        private void btn_mobil(object sender, EventArgs e)
        {
            Mobil Mobil = new Mobil();
            Mobil.Show();
            this.Hide();
        }
    }
}
