namespace AluminiosRuta5.Forms
{
    partial class FormPresupuesto
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
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTotalKg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTotalTiras = new System.Windows.Forms.Label();
            this.labelTotalImporte = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownImporte = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImporte)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxCodigo.Location = new System.Drawing.Point(40, 55);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(128, 34);
            this.textBoxCodigo.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(40, 124);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(128, 50);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(36, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Codigo";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(616, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 599);
            this.panel1.TabIndex = 16;
            // 
            // labelTotalKg
            // 
            this.labelTotalKg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotalKg.AutoSize = true;
            this.labelTotalKg.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTotalKg.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalKg.Location = new System.Drawing.Point(34, 399);
            this.labelTotalKg.Name = "labelTotalKg";
            this.labelTotalKg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTotalKg.Size = new System.Drawing.Size(154, 36);
            this.labelTotalKg.TabIndex = 17;
            this.labelTotalKg.Text = "Total KG =";
            this.labelTotalKg.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(178, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "Cantidad tiras";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13F);
            this.numericUpDown1.Location = new System.Drawing.Point(182, 56);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 35);
            this.numericUpDown1.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(0, 624);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 50);
            this.button1.TabIndex = 21;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelTotalTiras
            // 
            this.labelTotalTiras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotalTiras.AutoSize = true;
            this.labelTotalTiras.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTotalTiras.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalTiras.Location = new System.Drawing.Point(34, 352);
            this.labelTotalTiras.Name = "labelTotalTiras";
            this.labelTotalTiras.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTotalTiras.Size = new System.Drawing.Size(171, 36);
            this.labelTotalTiras.TabIndex = 23;
            this.labelTotalTiras.Text = "Total tiras =";
            this.labelTotalTiras.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTotalImporte
            // 
            this.labelTotalImporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotalImporte.AutoSize = true;
            this.labelTotalImporte.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTotalImporte.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalImporte.Location = new System.Drawing.Point(34, 445);
            this.labelTotalImporte.Name = "labelTotalImporte";
            this.labelTotalImporte.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTotalImporte.Size = new System.Drawing.Size(221, 36);
            this.labelTotalImporte.TabIndex = 24;
            this.labelTotalImporte.Text = "Total importe =";
            this.labelTotalImporte.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label3.Location = new System.Drawing.Point(308, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 19);
            this.label3.TabIndex = 40;
            this.label3.Text = "Importe por kilo";
            // 
            // numericUpDownImporte
            // 
            this.numericUpDownImporte.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13F);
            this.numericUpDownImporte.Location = new System.Drawing.Point(312, 56);
            this.numericUpDownImporte.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownImporte.Name = "numericUpDownImporte";
            this.numericUpDownImporte.Size = new System.Drawing.Size(120, 35);
            this.numericUpDownImporte.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Location = new System.Drawing.Point(22, 342);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 157);
            this.panel2.TabIndex = 41;
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReset.Location = new System.Drawing.Point(22, 505);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(128, 50);
            this.buttonReset.TabIndex = 42;
            this.buttonReset.Text = "Reiniciar lista";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // FormPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownImporte);
            this.Controls.Add(this.labelTotalImporte);
            this.Controls.Add(this.labelTotalTiras);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelTotalKg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPresupuesto";
            this.Text = "FormPresupuesto";
            this.Load += new System.EventHandler(this.FormPresupuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTotalKg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelTotalTiras;
        private System.Windows.Forms.Label labelTotalImporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownImporte;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonReset;
    }
}