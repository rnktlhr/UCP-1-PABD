using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Runtime.Caching;





namespace UCP_1_PABD
{
    public partial class Mobil : Form
    {
        private string connectionString = "Data Source= LAPTOP-872LO0G1\\RINAKIT;Initial Catalog=SowroomMobil;Integrated Security=True";

        // Inisialisasi cache dan kebijakan kadaluarsa untuk data Mobil
        private readonly MemoryCache _cache = MemoryCache.Default;

        private readonly CacheItemPolicy _policy = new CacheItemPolicy
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
        };

        private const string CacheKey = "MobilData";

        public Mobil()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            EnsureIndexes();
            LoadData();
        }

        private void EnsureIndexes()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var indexScript = @"
                    IF OBJECT_ID('dbo.Mobil', 'U') IS NOT NULL
                    BEGIN
                        IF NOT EXISTS (
                            SELECT 1 
                            FROM sys.indexes 
                            WHERE name = 'idx_Mobil_Merek' AND object_id = OBJECT_ID('dbo.Mobil')
                        )
                            CREATE NONCLUSTERED INDEX idx_Mobil_Merek ON dbo.Mobil(Merek);

                        IF NOT EXISTS (
                            SELECT 1 
                            FROM sys.indexes 
                            WHERE name = 'idx_Mobil_Tahun' AND object_id = OBJECT_ID('dbo.Mobil')
                        )
                            CREATE NONCLUSTERED INDEX idx_Mobil_Tahun ON dbo.Mobil(Tahun_Produksi);

                        IF NOT EXISTS (
                            SELECT 1 
                            FROM sys.indexes 
                            WHERE name = 'idx_Mobil_Status' AND object_id = OBJECT_ID('dbo.Mobil')
                        )
                            CREATE NONCLUSTERED INDEX idx_Mobil_Status ON dbo.Mobil(Status);

                        IF NOT EXISTS (
                            SELECT 1 
                            FROM sys.indexes 
                            WHERE name = 'idx_Mobil_Harga' AND object_id = OBJECT_ID('dbo.Mobil')
                        )
                            CREATE NONCLUSTERED INDEX idx_Mobil_Harga ON dbo.Mobil(Harga);
                    END
                    ";

                using (var cmd = new SqlCommand(indexScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
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
            dgvMobil.ClearSelection();
        }

  
        private void LoadData()
        {
            DataTable dt;
            if (_cache.Contains(CacheKey))
            {
                dt = _cache.Get(CacheKey) as DataTable;
            }
            else
            {
                dt = new DataTable();
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var query = @"SELECT 
                            ID_Mobil AS [ID], 
                            Merek, 
                            Tahun_Produksi AS [Tahun], 
                            Type_Mobil AS [Tipe], 
                            Pemilik, 
                            Jenis_Mobil AS [Jenis], 
                            Harga, 
                            Status, 
                            Deskripsi, 
                            NIKar 
                            FROM dbo.Mobil";

                    var da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
                _cache.Add(CacheKey, dt, _policy);
            }

            dgvMobil.AutoGenerateColumns = true;
            dgvMobil.DataSource = dt;
        }

        private void AnalyzeQuery(string sqlQuery)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.InfoMessage += (s, e) => MessageBox.Show(e.Message, "STATISTICS INFO");
                conn.Open();
                var wrapped = $@"
                SET STATISTICS IO ON;
                SET STATISTICS TIME ON;
                {sqlQuery};
                SET STATISTICS IO OFF;
                SET STATISTICS TIME OFF;";
                using (var cmd = new SqlCommand(wrapped, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private void B1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (txtIDMobil.Text == "" || txtMerekMobil.Text == "" || txtTahunProduksi.Text == "" ||
                        txtTypeMobil.Text == "" || txtPemilik.Text == "" || txtJenisMobil.Text == "" ||
                        txtHarga.Text == "" || txtStatus.Text == "" || txtDeskripsi.Text == "" || txtNIKar.Text == "")
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
                            _cache.Remove(CacheKey); // Hapus cache
                            LoadData();              // Perbarui DGV
                            ClearForm();             // Bersihkan form input
                        }
                        else
                        {
                            MessageBox.Show("Data tidak berhasil ditambahkan!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void B2(object sender, EventArgs e)
        {
            if (txtIDMobil.Text == "" || txtMerekMobil.Text == "" || txtTahunProduksi.Text == "" ||
                txtTypeMobil.Text == "" || txtPemilik.Text == "" || txtJenisMobil.Text == "" ||
                txtStatus.Text == "" || txtDeskripsi.Text == "" || txtNIKar.Text == "")
            {
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
                            _cache.Remove(CacheKey); // 🧼 Clear cache
                            LoadData();              // 🔄 Refresh DGV
                            ClearForm();             // optional: bersihkan input
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
                            // Ambil ID dari kolom yang dipakai di DataGridView (lihat LoadData)
                            string idMobil = dgvMobil.SelectedRows[0].Cells["ID"].Value?.ToString();
                            if (string.IsNullOrEmpty(idMobil))
                            {
                                MessageBox.Show("ID Mobil tidak valid.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            conn.Open();
                            string query = "DELETE FROM Mobil WHERE ID_Mobil = @ID_Mobil";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@ID_Mobil", idMobil);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    _cache.Remove(CacheKey); // Penting: hapus cache
                                    LoadData();              // Perbarui DGV
                                    ClearForm();             // Opsional: bersihkan form
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
            
            _cache.Remove(CacheKey);
            LoadData();

           
            int jumlahKolom = dgvMobil.ColumnCount;
            int jumlahBaris = dgvMobil.RowCount;

            MessageBox.Show(
                $"Jumlah Kolom: {jumlahKolom}\nJumlah Baris: {jumlahBaris}",
                "Informasi DataGridView",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }



        private void dgvMobil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMobil.Rows[e.RowIndex];

                txtIDMobil.Text = row.Cells[0].Value.ToString();
                txtMerekMobil.Text = row.Cells[1].Value.ToString();
                txtTahunProduksi.Text = row.Cells[2].Value.ToString();
                txtTypeMobil.Text = row.Cells[3].Value.ToString();
                txtPemilik.Text = row.Cells[4].Value.ToString();
                txtJenisMobil.Text = row.Cells[5].Value.ToString();
                txtHarga.Text = row.Cells[6].Value.ToString();
                txtStatus.Text = row.Cells[7].Value.ToString();
                txtDeskripsi.Text = row.Cells[8].Value.ToString();
                txtNIKar.Text = row.Cells[9].Value.ToString();

            }
        }

        private void btn_import(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Preview_Data(filePath);  // Display preview before importing
            }
        }

        private void Preview_Data(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(fs); // Membuka workbook Excel
                    ISheet sheet = workbook.GetSheetAt(0);     // Mendapatkan worksheet pertama
                    DataTable dt = new DataTable();

                    // Membaca header kolom
                    IRow headerRow = sheet.GetRow(0);
                    foreach (var cell in headerRow.Cells)
                    {
                        dt.Columns.Add(cell.ToString());
                    }

                    // Membaca sisa data
                    for (int i = 1; i <= sheet.LastRowNum; i++)  // Lewati baris header
                    {
                        IRow dataRow = sheet.GetRow(i);
                        DataRow newRow = dt.NewRow();
                        int cellIndex = 0;
                        foreach (var cell in dataRow.Cells)
                        {
                            newRow[cellIndex] = cell.ToString();
                            cellIndex++;
                        }
                        dt.Rows.Add(newRow);
                    }

                    // Membuka PreviewForm dan mengirimkan DataTable ke form tersebut
                    Preview_Data previewForm = new Preview_Data(dt);
                    previewForm.ShowDialog(); // Tampilkan PreviewForm
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_analisis(object sender, EventArgs e)
        {
            {
                string queryToAnalyze = @"
                SELECT
                    t.index_id,
                    t.name AS index_name
                FROM sys.indexes AS t
                WHERE t.object_id = OBJECT_ID('dbo.Mobil');";
                AnalyzeQuery(queryToAnalyze);
            }
        }

        private void btn_form(object sender, EventArgs e)
        {
            FormMobil formMobil = new FormMobil();
            formMobil.Show();
            this.Hide();
        }

        private void Btn_export(object sender, EventArgs e)
        {
            FormShowroom formShowroom = new FormShowroom();
            formShowroom.Show();
            this.Hide();
        }
    }
}
