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
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source= LAPTOP-872LO0G1\\RINAKIT;Initial Catalog=SowroomMobil;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ClearForm()
        {
            txtIDMobil.Clear();
            txtMerekMobil.Clear();
            txtTahunProduksi.Clear();
            txtTypeMobil.Clear();
            txtPemilik.Clear();
            txtJenisMobil.Clear();
            txtHarga.Clear();
            txtStatus.Clear();
            txtDeskripsi.Clear();
            txtNIKar.Clear();
        }

  
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Mobil";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvMobil.AutoGenerateColumns = true;
                    dgvMobil.DataSource = dt;

                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void B1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try 
                { 
                    if (txtIDMobil.Text == "" ||txtMerekMobil.Text== "" || txtTahunProduksi.Text=="" || txtTypeMobil.Text=="" || txtPemilik.Text=="" || txtJenisMobil.Text=="" || txtStatus.Text== "" || txtDeskripsi.Text == ""|| txtNIKar.Text =="")
                    {
                        MessageBox.Show("Harap isi semua data wajib!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    conn.Open();
                    string query = "INSERT INTO Mobil (ID_Mobil, Merek, Tahun_Produksi, Type_Mobil, Pemilik, Jenis_Mobil, Harga, Status, Deskripsi, NIKar) " +
                                  "VALUES (@ID_Mobil, @Merek, @Tahun_Produksi, @Type_Mobil, @Pemilik, @Jenis_Mobil, @Harga, @Status, @Deskripsi, @NIKar)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_Mobil", txtIDMobil.Text.Trim());
                        cmd.Parameters.AddWithValue("@Merek", txtMerekMobil.Text.Trim());
                        cmd.Parameters.AddWithValue("@Tahun_Produksi", int.Parse(txtTahunProduksi.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Type_Mobil", txtTypeMobil.Text.Trim());
                        cmd.Parameters.AddWithValue("@Pemilik", txtPemilik.Text.Trim());
                        cmd.Parameters.AddWithValue("@Jenis_Mobil", txtJenisMobil.Text.Trim());
                        cmd.Parameters.AddWithValue("@Harga", decimal.Parse(txtHarga.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Status", txtStatus.Text.Trim());
                        cmd.Parameters.AddWithValue("@Deskripsi", txtDeskripsi.Text.Trim());
                        cmd.Parameters.AddWithValue("@NIKar", txtNIKar.Text.Trim());



                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Data tidak berhasil ditambahkan!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void B2(object sender, EventArgs e)
        {
            if (txtIDMobil.Text == "" ||txtMerekMobil.Text == "" || txtTahunProduksi.Text == "" || txtTypeMobil.Text == "" || txtPemilik.Text == "" || txtJenisMobil.Text == "" || txtStatus.Text == "" || txtDeskripsi.Text == "" || txtNIKar.Text=="")

            {
                MessageBox.Show("Harap isi semua data sebelum memperbarui!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Mobil SET Merek = @Merek, Tahun_Produksi = @Tahun_Produksi, Type_Mobil = @Type_Mobil, " +
                                   "Pemilik = @Pemilik, Jenis_Mobil = @Jenis_Mobil, Harga = @Harga, Status = @Status, Deskripsi = @Deskripsi, NIKar = @NIKar " +
                                   "WHERE ID_Mobil = @ID_Mobil";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_Mobil", txtIDMobil.Text.Trim());
                        cmd.Parameters.AddWithValue("@Merek", txtMerekMobil.Text.Trim());
                        cmd.Parameters.AddWithValue("@Tahun_Produksi", int.Parse(txtTahunProduksi.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Type_Mobil", txtTypeMobil.Text.Trim());
                        cmd.Parameters.AddWithValue("@Pemilik", txtPemilik.Text.Trim());
                        cmd.Parameters.AddWithValue("@Jenis_Mobil", txtJenisMobil.Text.Trim());
                        cmd.Parameters.AddWithValue("@Harga", decimal.Parse(txtHarga.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Status", txtStatus.Text.Trim());
                        cmd.Parameters.AddWithValue("@Deskripsi", txtDeskripsi.Text.Trim());
                        cmd.Parameters.AddWithValue("@NIKar", txtNIKar.Text.Trim());



                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ditemukan atau gagal diperbarui!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void B3(object sender, EventArgs e)
        {
            if (dgvMobil.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string idMobil = dgvMobil.SelectedRows[0].Cells["ID_Mobil"].Value.ToString();
                            conn.Open();
                            string query = "DELETE FROM Mobil WHERE ID_Mobil = @ID_Mobil";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@ID_Mobil", idMobil);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData();
                                }
                                else
                                {
                                    MessageBox.Show("Data tidak ditemukan atau gagal dihapus!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void B4(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show($"Jumlah Kolom: {dgvMobil.ColumnCount}\nJumlah Baris: {dgvMobil.RowCount}",
                "Debugging DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       

        private void dgvMobil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMobil.Rows[e.RowIndex];

                txtIDMobil.Text = row.Cells["ID_Mobil"].Value.ToString();
                txtMerekMobil.Text = row.Cells["Merek"].Value.ToString();
                txtTahunProduksi.Text = row.Cells["Tahun_Produksi"].Value.ToString();
                txtTypeMobil.Text = row.Cells["Type_Mobil"].Value.ToString();
                txtPemilik.Text = row.Cells["Pemilik"].Value.ToString();
                txtJenisMobil.Text = row.Cells["Jenis_Mobil"].Value.ToString();
                txtHarga.Text = row.Cells["Harga"].Value.ToString();
                txtStatus.Text = row.Cells["Status"].Value.ToString();
                txtDeskripsi.Text = row.Cells["Deskripsi"].Value.ToString();
                txtNIKar.Text = row.Cells["NIKar"].Value.ToString();


            }
        }
    }
}
