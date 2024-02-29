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
            this.lTiras = new System.Windows.Forms.Label();
            this.labelTotalKg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lImporte = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTiras = new System.Windows.Forms.TextBox();
            this.textBoxImporte = new System.Windows.Forms.TextBox();
            this.textBoxKilos = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
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
            // lTiras
            // 
            this.lTiras.AutoSize = true;
            this.lTiras.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lTiras.Location = new System.Drawing.Point(172, 34);
            this.lTiras.Name = "lTiras";
            this.lTiras.Size = new System.Drawing.Size(107, 19);
            this.lTiras.TabIndex = 30;
            this.lTiras.Text = "Cantidad tiras";
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
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxCodigo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxCodigo.Location = new System.Drawing.Point(42, 54);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(128, 34);
            this.textBoxCodigo.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirmar.Location = new System.Drawing.Point(42, 542);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(135, 51);
            this.btnConfirmar.TabIndex = 35;
            this.btnConfirmar.Text = "Confirmar remito";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lImporte
            // 
            this.lImporte.AutoSize = true;
            this.lImporte.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lImporte.Location = new System.Drawing.Point(310, 34);
            this.lImporte.Name = "lImporte";
            this.lImporte.Size = new System.Drawing.Size(121, 19);
            this.lImporte.TabIndex = 38;
            this.lImporte.Text = "Importe por kilo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label4.Location = new System.Drawing.Point(444, 34);
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
            // textBoxNombre
            // 
            this.textBoxNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxNombre.Location = new System.Drawing.Point(310, 559);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(246, 34);
            this.textBoxNombre.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label5.Location = new System.Drawing.Point(306, 537);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 19);
            this.label5.TabIndex = 42;
            this.label5.Text = "Nombre del remito";
            // 
            // textBoxTiras
            // 
            this.textBoxTiras.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxTiras.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxTiras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTiras.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxTiras.Location = new System.Drawing.Point(176, 54);
            this.textBoxTiras.Name = "textBoxTiras";
            this.textBoxTiras.Size = new System.Drawing.Size(128, 34);
            this.textBoxTiras.TabIndex = 1;
            this.textBoxTiras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxImporte_KeyPress);
            // 
            // textBoxImporte
            // 
            this.textBoxImporte.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxImporte.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxImporte.Location = new System.Drawing.Point(310, 54);
            this.textBoxImporte.Name = "textBoxImporte";
            this.textBoxImporte.Size = new System.Drawing.Size(128, 34);
            this.textBoxImporte.TabIndex = 2;
            this.textBoxImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxImporte_KeyPress);
            // 
            // textBoxKilos
            // 
            this.textBoxKilos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxKilos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxKilos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxKilos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxKilos.Location = new System.Drawing.Point(444, 54);
            this.textBoxKilos.Name = "textBoxKilos";
            this.textBoxKilos.Size = new System.Drawing.Size(128, 34);
            this.textBoxKilos.TabIndex = 3;
            this.textBoxKilos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxImporte_KeyPress);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.checkBox1.Location = new System.Drawing.Point(468, 137);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 23);
            this.checkBox1.TabIndex = 47;
            this.checkBox1.Text = "Accesorio";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FormRemito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBoxKilos);
            this.Controls.Add(this.textBoxImporte);
            this.Controls.Add(this.textBoxTiras);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lImporte);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.labelTotalImporte);
            this.Controls.Add(this.labelTotalTiras);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lTiras);
            this.Controls.Add(this.labelTotalKg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRemito";
            this.Text = "FormRemito";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotalImporte;
        private System.Windows.Forms.Label labelTotalTiras;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lTiras;
        private System.Windows.Forms.Label labelTotalKg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lImporte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTiras;
        private System.Windows.Forms.TextBox textBoxImporte;
        private System.Windows.Forms.TextBox textBoxKilos;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}