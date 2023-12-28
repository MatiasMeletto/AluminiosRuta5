namespace AluminiosRuta5.Forms
{
    partial class FormPerfil
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewStock = new System.Windows.Forms.DataGridView();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgXPaqueteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantTirasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perfilBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.numericUpDownKg = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTiras = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownImporte = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTiras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImporte)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridViewStock);
            this.panel1.Controls.Add(this.textBoxBuscar);
            this.panel1.Location = new System.Drawing.Point(0, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 408);
            this.panel1.TabIndex = 1;
            // 
            // dataGridViewStock
            // 
            this.dataGridViewStock.AllowUserToAddRows = false;
            this.dataGridViewStock.AllowUserToDeleteRows = false;
            this.dataGridViewStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStock.AutoGenerateColumns = false;
            this.dataGridViewStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStock.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.kgXPaqueteDataGridViewTextBoxColumn,
            this.cantTirasDataGridViewTextBoxColumn,
            this.importeDataGridViewTextBoxColumn});
            this.dataGridViewStock.DataSource = this.perfilBindingSource;
            this.dataGridViewStock.Location = new System.Drawing.Point(51, 57);
            this.dataGridViewStock.Name = "dataGridViewStock";
            this.dataGridViewStock.ReadOnly = true;
            this.dataGridViewStock.RowHeadersWidth = 51;
            this.dataGridViewStock.RowTemplate.Height = 24;
            this.dataGridViewStock.Size = new System.Drawing.Size(972, 301);
            this.dataGridViewStock.TabIndex = 1;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.codigoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kgXPaqueteDataGridViewTextBoxColumn
            // 
            this.kgXPaqueteDataGridViewTextBoxColumn.DataPropertyName = "KgXPaquete";
            this.kgXPaqueteDataGridViewTextBoxColumn.HeaderText = "KgXPaquete";
            this.kgXPaqueteDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.kgXPaqueteDataGridViewTextBoxColumn.Name = "kgXPaqueteDataGridViewTextBoxColumn";
            this.kgXPaqueteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantTirasDataGridViewTextBoxColumn
            // 
            this.cantTirasDataGridViewTextBoxColumn.DataPropertyName = "CantTiras";
            this.cantTirasDataGridViewTextBoxColumn.HeaderText = "CantTiras";
            this.cantTirasDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cantTirasDataGridViewTextBoxColumn.Name = "cantTirasDataGridViewTextBoxColumn";
            this.cantTirasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // importeDataGridViewTextBoxColumn
            // 
            this.importeDataGridViewTextBoxColumn.DataPropertyName = "Importe";
            this.importeDataGridViewTextBoxColumn.HeaderText = "Importe";
            this.importeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.importeDataGridViewTextBoxColumn.Name = "importeDataGridViewTextBoxColumn";
            this.importeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // perfilBindingSource
            // 
            this.perfilBindingSource.DataSource = typeof(AluminiosRuta5.Objects.Perfil);
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxBuscar.ForeColor = System.Drawing.Color.Silver;
            this.textBoxBuscar.Location = new System.Drawing.Point(51, 17);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(248, 34);
            this.textBoxBuscar.TabIndex = 0;
            this.textBoxBuscar.Text = "Buscar...";
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxCodigo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxCodigo.Location = new System.Drawing.Point(51, 41);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(403, 34);
            this.textBoxCodigo.TabIndex = 2;
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxDescripcion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxDescripcion.Location = new System.Drawing.Point(51, 105);
            this.textBoxDescripcion.Multiline = true;
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(403, 75);
            this.textBoxDescripcion.TabIndex = 3;
            // 
            // numericUpDownKg
            // 
            this.numericUpDownKg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownKg.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13F);
            this.numericUpDownKg.Location = new System.Drawing.Point(716, 40);
            this.numericUpDownKg.Name = "numericUpDownKg";
            this.numericUpDownKg.Size = new System.Drawing.Size(120, 35);
            this.numericUpDownKg.TabIndex = 4;
            // 
            // numericUpDownTiras
            // 
            this.numericUpDownTiras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownTiras.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13F);
            this.numericUpDownTiras.Location = new System.Drawing.Point(903, 41);
            this.numericUpDownTiras.Name = "numericUpDownTiras";
            this.numericUpDownTiras.Size = new System.Drawing.Size(120, 35);
            this.numericUpDownTiras.TabIndex = 5;
            // 
            // numericUpDownImporte
            // 
            this.numericUpDownImporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownImporte.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13F);
            this.numericUpDownImporte.Location = new System.Drawing.Point(903, 105);
            this.numericUpDownImporte.Name = "numericUpDownImporte";
            this.numericUpDownImporte.Size = new System.Drawing.Size(120, 35);
            this.numericUpDownImporte.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(48, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(713, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Kg x paquete";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(900, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cantidad tiras";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(900, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Importe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(48, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Descripcion";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(51, 209);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(128, 50);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(761, 209);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(128, 50);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Location = new System.Drawing.Point(895, 209);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(128, 50);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // FormPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1082, 673);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownImporte);
            this.Controls.Add(this.numericUpDownTiras);
            this.Controls.Add(this.numericUpDownKg);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPerfil";
            this.Text = "FormPerfil";
            this.Load += new System.EventHandler(this.FormPerfil_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTiras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewStock;
        private System.Windows.Forms.TextBox textBoxBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgXPaqueteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantTirasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource perfilBindingSource;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.NumericUpDown numericUpDownKg;
        private System.Windows.Forms.NumericUpDown numericUpDownTiras;
        private System.Windows.Forms.NumericUpDown numericUpDownImporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
    }
}