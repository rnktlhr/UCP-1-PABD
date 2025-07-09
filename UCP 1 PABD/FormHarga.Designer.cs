namespace UCP_1_PABD
{
    partial class FormHarga
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

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label1 = new System.Windows.Forms.Label();
            this.chartHarga = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbJenis = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartHarga)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(160, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dashboard Harga Mobil";
            // 
            // chartKeuangan
            // 
            this.chartHarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.LabelStyle.Angle = -45;
            chartArea2.AxisX.Title = "Organisasi";
            chartArea2.AxisY.LabelStyle.Format = "Rp#,0";
            chartArea2.AxisY.Title = "Jumlah (Rp)";
            chartArea2.Name = "ChartArea1";
            this.chartHarga .ChartAreas.Add(chartArea2);
            legend2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chartHarga.Legends.Add(legend2);
            this.chartHarga .Location = new System.Drawing.Point(43, 125);
            this.chartHarga .Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartHarga .Name = "chartHarga";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.ForestGreen;
            series3.Legend = "Legend1";
            series3.Name = "Harga Mobil Tersedia";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.Firebrick;
            series4.Legend = "Legend1";
            series4.Name = "Harga Mobil Terjual";
            this.chartHarga .Series.Add(series3);
            this.chartHarga .Series.Add(series4);
            this.chartHarga .Size = new System.Drawing.Size(786, 363);
            this.chartHarga.TabIndex = 2;
            this.chartHarga.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "Grafik Harga Mobil";
            this.chartHarga.Titles.Add(title2);
            // 
            // cmbJenis
            // 
            this.cmbJenis.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbJenis.FormattingEnabled = true;
            this.cmbJenis.Location = new System.Drawing.Point(249, 80);
            this.cmbJenis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbJenis.Name = "cmbJenis";
            this.cmbJenis.Size = new System.Drawing.Size(267, 24);
            this.cmbJenis.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(160, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filter Jenis :";
            // 
            // FormKeuangan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(867, 515);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartHarga);
            this.Controls.Add(this.cmbJenis);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormHarga";
            this.Text = "Dashboard Harga Mbil";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormHarga_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartHarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataVisualization.Charting.Chart chartHarga;
        private System.Windows.Forms.ComboBox cmbJenis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}