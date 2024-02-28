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
            this.CantidadTiras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KgXTira = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.textBoxKg = new System.Windows.Forms.TextBox();
            this.textBox1Tira = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgXPaqueteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perfilBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.perfilBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.perfilBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxTiras = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource1)).BeginInit();
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
            this.CantidadTiras,
            this.KgXTira});
            this.dataGridViewStock.DataSource = this.perfilBindingSource2;
            this.dataGridViewStock.Location = new System.Drawing.Point(51, 57);
            this.dataGridViewStock.Name = "dataGridViewStock";
            this.dataGridViewStock.ReadOnly = true;
            this.dataGridViewStock.RowHeadersWidth = 51;
            this.dataGridViewStock.RowTemplate.Height = 24;
            this.dataGridViewStock.Size = new System.Drawing.Size(972, 301);
            this.dataGridViewStock.TabIndex = 1;
            this.dataGridViewStock.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewStock_RowHeaderMouseDoubleClick);
            // 
            // CantidadTiras
            // 
            this.CantidadTiras.DataPropertyName = "CantidadTiras";
            this.CantidadTiras.HeaderText = "CantidadTiras";
            this.CantidadTiras.MinimumWidth = 6;
            this.CantidadTiras.Name = "CantidadTiras";
            this.CantidadTiras.ReadOnly = true;
            // 
            // KgXTira
            // 
            this.KgXTira.DataPropertyName = "KgXTira";
            this.KgXTira.HeaderText = "KgXTira";
            this.KgXTira.MinimumWidth = 6;
            this.KgXTira.Name = "KgXTira";
            this.KgXTira.ReadOnly = true;
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
            this.textBoxBuscar.TextChanged += new System.EventHandler(this.textBoxBuscar_TextChanged);
            this.textBoxBuscar.Enter += new System.EventHandler(this.textBoxBuscar_Enter);
            this.textBoxBuscar.Leave += new System.EventHandler(this.textBoxBuscar_Leave);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(48, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(713, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Kg x paquete";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label3.Location = new System.Drawing.Point(900, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cantidad tiras";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label5.Location = new System.Drawing.Point(48, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 19);
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
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(761, 209);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(128, 50);
            this.btnAgregar.TabIndex = 7;
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
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // textBoxKg
            // 
            this.textBoxKg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxKg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxKg.Location = new System.Drawing.Point(717, 42);
            this.textBoxKg.Name = "textBoxKg";
            this.textBoxKg.Size = new System.Drawing.Size(121, 34);
            this.textBoxKg.TabIndex = 4;
            this.textBoxKg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxKg_KeyPress);
            // 
            // textBox1Tira
            // 
            this.textBox1Tira.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1Tira.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1Tira.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBox1Tira.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1Tira.Location = new System.Drawing.Point(903, 106);
            this.textBox1Tira.Name = "textBox1Tira";
            this.textBox1Tira.Size = new System.Drawing.Size(121, 34);
            this.textBox1Tira.TabIndex = 6;
            this.textBox1Tira.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxKg_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label6.Location = new System.Drawing.Point(899, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "Kg x tira";
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
            // perfilBindingSource2
            // 
            this.perfilBindingSource2.DataSource = typeof(AluminiosRuta5.Objects.Perfil);
            // 
            // perfilBindingSource
            // 
            this.perfilBindingSource.DataSource = typeof(AluminiosRuta5.Objects.Perfil);
            // 
            // perfilBindingSource1
            // 
            this.perfilBindingSource1.DataSource = typeof(AluminiosRuta5.Objects.Perfil);
            // 
            // textBoxTiras
            // 
            this.textBoxTiras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTiras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTiras.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxTiras.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxTiras.Location = new System.Drawing.Point(904, 41);
            this.textBoxTiras.Name = "textBoxTiras";
            this.textBoxTiras.Size = new System.Drawing.Size(121, 34);
            this.textBoxTiras.TabIndex = 17;
            this.textBoxTiras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxKg_KeyPress);
            // 
            // FormPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1082, 673);
            this.Controls.Add(this.textBoxTiras);
            this.Controls.Add(this.textBox1Tira);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxKg);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewStock;
        private System.Windows.Forms.TextBox textBoxBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantTirasDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource perfilBindingSource;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox textBoxKg;
        private System.Windows.Forms.BindingSource perfilBindingSource1;
        private System.Windows.Forms.TextBox textBox1Tira;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgXPaqueteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadTiras;
        private System.Windows.Forms.DataGridViewTextBoxColumn KgXTira;
        private System.Windows.Forms.BindingSource perfilBindingSource2;
        private System.Windows.Forms.TextBox textBoxTiras;
    }
}