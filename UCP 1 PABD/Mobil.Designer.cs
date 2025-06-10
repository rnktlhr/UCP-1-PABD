namespace UCP_1_PABD
{
    partial class Mobil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Input = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtMerekMobil = new System.Windows.Forms.TextBox();
            this.txtTahunProduksi = new System.Windows.Forms.TextBox();
            this.txtTypeMobil = new System.Windows.Forms.TextBox();
            this.txtPemilik = new System.Windows.Forms.TextBox();
            this.txtJenisMobil = new System.Windows.Forms.TextBox();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvMobil = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.txtIDMobil = new System.Windows.Forms.TextBox();
            this.IDMobil = new System.Windows.Forms.Label();
            this.txtNIKar = new System.Windows.Forms.TextBox();
            this.NikKar = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobil)).BeginInit();
            this.SuspendLayout();
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(744, 39);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(75, 32);
            this.Input.TabIndex = 0;
            this.Input.Text = "Input";
            this.Input.UseVisualStyleBackColor = true;
            this.Input.Click += new System.EventHandler(this.B1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(744, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.B2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(744, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.B3);
            // 
            // txtMerekMobil
            // 
            this.txtMerekMobil.Location = new System.Drawing.Point(358, 36);
            this.txtMerekMobil.Name = "txtMerekMobil";
            this.txtMerekMobil.Size = new System.Drawing.Size(283, 22);
            this.txtMerekMobil.TabIndex = 3;
            // 
            // txtTahunProduksi
            // 
            this.txtTahunProduksi.Location = new System.Drawing.Point(358, 64);
            this.txtTahunProduksi.Name = "txtTahunProduksi";
            this.txtTahunProduksi.Size = new System.Drawing.Size(283, 22);
            this.txtTahunProduksi.TabIndex = 4;
            // 
            // txtTypeMobil
            // 
            this.txtTypeMobil.Location = new System.Drawing.Point(358, 92);
            this.txtTypeMobil.Name = "txtTypeMobil";
            this.txtTypeMobil.Size = new System.Drawing.Size(283, 22);
            this.txtTypeMobil.TabIndex = 5;
            // 
            // txtPemilik
            // 
            this.txtPemilik.Location = new System.Drawing.Point(358, 120);
            this.txtPemilik.Name = "txtPemilik";
            this.txtPemilik.Size = new System.Drawing.Size(283, 22);
            this.txtPemilik.TabIndex = 6;
            // 
            // txtJenisMobil
            // 
            this.txtJenisMobil.Location = new System.Drawing.Point(358, 148);
            this.txtJenisMobil.Name = "txtJenisMobil";
            this.txtJenisMobil.Size = new System.Drawing.Size(283, 22);
            this.txtJenisMobil.TabIndex = 7;
            // 
            // txtHarga
            // 
            this.txtHarga.Location = new System.Drawing.Point(358, 176);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(283, 22);
            this.txtHarga.TabIndex = 8;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(358, 204);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(283, 22);
            this.txtStatus.TabIndex = 9;
            // 
            // txtDeskripsi
            // 
            this.txtDeskripsi.Location = new System.Drawing.Point(358, 232);
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.Size = new System.Drawing.Size(283, 22);
            this.txtDeskripsi.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Merek";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tahun Produksi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Type Mobil";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Pemilik";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Jenis Mobil";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Harga";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Deskripsi";
            // 
            // dgvMobil
            // 
            this.dgvMobil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMobil.Location = new System.Drawing.Point(41, 333);
            this.dgvMobil.Name = "dgvMobil";
            this.dgvMobil.RowHeadersWidth = 51;
            this.dgvMobil.RowTemplate.Height = 24;
            this.dgvMobil.Size = new System.Drawing.Size(1027, 271);
            this.dgvMobil.TabIndex = 19;
            this.dgvMobil.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMobil_CellClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(744, 204);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 31);
            this.button3.TabIndex = 20;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.B4);
            // 
            // txtIDMobil
            // 
            this.txtIDMobil.Location = new System.Drawing.Point(358, 8);
            this.txtIDMobil.Name = "txtIDMobil";
            this.txtIDMobil.Size = new System.Drawing.Size(283, 22);
            this.txtIDMobil.TabIndex = 21;
            // 
            // IDMobil
            // 
            this.IDMobil.AutoSize = true;
            this.IDMobil.Location = new System.Drawing.Point(38, 14);
            this.IDMobil.Name = "IDMobil";
            this.IDMobil.Size = new System.Drawing.Size(53, 16);
            this.IDMobil.TabIndex = 22;
            this.IDMobil.Text = "IDMobil";
            // 
            // txtNIKar
            // 
            this.txtNIKar.Location = new System.Drawing.Point(358, 261);
            this.txtNIKar.Name = "txtNIKar";
            this.txtNIKar.Size = new System.Drawing.Size(283, 22);
            this.txtNIKar.TabIndex = 23;
            // 
            // NikKar
            // 
            this.NikKar.AutoSize = true;
            this.NikKar.Location = new System.Drawing.Point(38, 264);
            this.NikKar.Name = "NikKar";
            this.NikKar.Size = new System.Drawing.Size(47, 16);
            this.NikKar.TabIndex = 24;
            this.NikKar.Text = "NikKar";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(861, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 32);
            this.button4.TabIndex = 25;
            this.button4.Text = "Import";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btn_import);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(861, 91);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 30);
            this.button5.TabIndex = 26;
            this.button5.Text = "Analisis";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btn_analisis);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(861, 147);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 32);
            this.button6.TabIndex = 27;
            this.button6.Text = "Form Mobil";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btn_form);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(861, 204);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 31);
            this.button7.TabIndex = 28;
            this.button7.Text = "Export";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Btn_export);
            // 
            // Mobil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 643);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.NikKar);
            this.Controls.Add(this.txtNIKar);
            this.Controls.Add(this.IDMobil);
            this.Controls.Add(this.txtIDMobil);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dgvMobil);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDeskripsi);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.txtJenisMobil);
            this.Controls.Add(this.txtPemilik);
            this.Controls.Add(this.txtTypeMobil);
            this.Controls.Add(this.txtTahunProduksi);
            this.Controls.Add(this.txtMerekMobil);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Input);
            this.Name = "Mobil";
            this.Text = "FormMobil";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Input;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtMerekMobil;
        private System.Windows.Forms.TextBox txtTahunProduksi;
        private System.Windows.Forms.TextBox txtTypeMobil;
        private System.Windows.Forms.TextBox txtPemilik;
        private System.Windows.Forms.TextBox txtJenisMobil;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvMobil;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtIDMobil;
        private System.Windows.Forms.Label IDMobil;
        private System.Windows.Forms.TextBox txtNIKar;
        private System.Windows.Forms.Label NikKar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

