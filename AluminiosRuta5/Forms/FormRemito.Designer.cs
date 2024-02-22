namespace AluminiosRuta5.Forms
{
    partial class FormRemito
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
            this.labelTotalImporte = new System.Windows.Forms.Label();
            this.labelTotalTiras = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDownCantTiras = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTotalKg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.numericUpDownImporte = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownKilos = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantTiras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKilos)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTotalImporte
            // 
            this.labelTotalImporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotalImporte.AutoSize = true;
            this.labelTotalImporte.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTotalImporte.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalImporte.Location = new System.Drawing.Point(36, 350);
            this.labelTotalImporte.Name = "labelTotalImporte";
            this.labelTotalImporte.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTotalImporte.Size = new System.Drawing.Size(221, 36);
            this.labelTotalImporte.TabIndex = 34;
            this.labelTotalImporte.Text = "Total importe =";
            this.labelTotalImporte.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTotalTiras
            // 
            this.labelTotalTiras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotalTiras.AutoSize = true;
            this.labelTotalTiras.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTotalTiras.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalTiras.Location = new System.Drawing.Point(36, 257);
            this.labelTotalTiras.Name = "labelTotalTiras";
            this.labelTotalTiras.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTotalTiras.Size = new System.Drawing.Size(171, 36);
            this.labelTotalTiras.TabIndex = 33;
            this.labelTotalTiras.Text = "Total tiras =";
            this.labelTotalTiras.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(0, 623);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 50);
            this.button1.TabIndex = 32;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDownCantTiras
            // 
            this.numericUpDownCantTiras.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13F);
            this.numericUpDownCantTiras.Location = new System.Drawing.Point(184, 55);
            this.numericUpDownCantTiras.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownCantTiras.Name = "numericUpDownCantTiras";
            this.numericUpDownCantTiras.Size = new System.Drawing.Size(120, 35);
            this.numericUpDownCantTiras.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(180, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 19);
            this.label2.TabIndex = 30;
            this.label2.Text = "Cantidad tiras";
            // 
            // labelTotalKg
            // 
            this.labelTotalKg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotalKg.AutoSize = true;
            this.labelTotalKg.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTotalKg.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalKg.Location = new System.Drawing.Point(36, 304);
            this.labelTotalKg.Name = "labelTotalKg";
            this.labelTotalKg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTotalKg.Size = new System.Drawing.Size(154, 36);
            this.labelTotalKg.TabIndex = 29;
            this.labelTotalKg.Text = "Total KG =";
            this.labelTotalKg.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(618, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 561);
            this.panel1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(38, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 27;
            this.label1.Text = "Codigo";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(42, 123);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(128, 50);
            this.btnAgregar.TabIndex = 26;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxCodigo.Location = new System.Drawing.Point(42, 54);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(128, 34);
            this.textBoxCodigo.TabIndex = 25;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirmar.Location = new System.Drawing.Point(42, 542);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(128, 51);
            this.btnConfirmar.TabIndex = 35;
            this.btnConfirmar.Text = "Confirmar remito";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // numericUpDownImporte
            // 
            this.numericUpDownImporte.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13F);
            this.numericUpDownImporte.Location = new System.Drawing.Point(310, 55);
            this.numericUpDownImporte.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownImporte.Name = "numericUpDownImporte";
            this.numericUpDownImporte.Size = new System.Drawing.Size(120, 35);
            this.numericUpDownImporte.TabIndex = 36;
            // 
            // numericUpDownKilos
            // 
            this.numericUpDownKilos.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13F);
            this.numericUpDownKilos.Location = new System.Drawing.Point(436, 55);
            this.numericUpDownKilos.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownKilos.Name = "numericUpDownKilos";
            this.numericUpDownKilos.Size = new System.Drawing.Size(120, 35);
            this.numericUpDownKilos.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label3.Location = new System.Drawing.Point(306, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 38;
            this.label3.Text = "Importe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label4.Location = new System.Drawing.Point(432, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 19);
            this.label4.TabIndex = 39;
            this.label4.Text = "Kilos";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Location = new System.Drawing.Point(31, 247);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 157);
            this.panel2.TabIndex = 40;
            // 
            // FormRemito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownKilos);
            this.Controls.Add(this.numericUpDownImporte);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.labelTotalImporte);
            this.Controls.Add(this.labelTotalTiras);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDownCantTiras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelTotalKg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRemito";
            this.Text = "FormRemito";
            this.Load += new System.EventHandler(this.FormRemito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantTiras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKilos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotalImporte;
        private System.Windows.Forms.Label labelTotalTiras;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDownCantTiras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTotalKg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.NumericUpDown numericUpDownImporte;
        private System.Windows.Forms.NumericUpDown numericUpDownKilos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
    }
}