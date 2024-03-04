namespace AluminiosRuta5.Forms
{
    partial class FormEleccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEleccion));
            this.btnStock = new System.Windows.Forms.Button();
            this.btnRemitos = new System.Windows.Forms.Button();
            this.btnPresupuestos = new System.Windows.Forms.Button();
            this.buttonEstadisticas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStock
            // 
            this.btnStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(157)))), ((int)(((byte)(186)))));
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStock.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 21F);
            this.btnStock.Image = ((System.Drawing.Image)(resources.GetObject("btnStock.Image")));
            this.btnStock.Location = new System.Drawing.Point(93, 117);
            this.btnStock.Name = "btnStock";
            this.btnStock.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.btnStock.Size = new System.Drawing.Size(270, 400);
            this.btnStock.TabIndex = 0;
            this.btnStock.Text = "Stock";
            this.btnStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnRemitos
            // 
            this.btnRemitos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemitos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(157)))), ((int)(((byte)(186)))));
            this.btnRemitos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemitos.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 21F);
            this.btnRemitos.Image = ((System.Drawing.Image)(resources.GetObject("btnRemitos.Image")));
            this.btnRemitos.Location = new System.Drawing.Point(369, 117);
            this.btnRemitos.Name = "btnRemitos";
            this.btnRemitos.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.btnRemitos.Size = new System.Drawing.Size(270, 400);
            this.btnRemitos.TabIndex = 1;
            this.btnRemitos.Text = "Remitos";
            this.btnRemitos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemitos.UseVisualStyleBackColor = false;
            this.btnRemitos.Click += new System.EventHandler(this.btnRemitos_Click);
            // 
            // btnPresupuestos
            // 
            this.btnPresupuestos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPresupuestos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(157)))), ((int)(((byte)(186)))));
            this.btnPresupuestos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPresupuestos.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 21F);
            this.btnPresupuestos.Image = ((System.Drawing.Image)(resources.GetObject("btnPresupuestos.Image")));
            this.btnPresupuestos.Location = new System.Drawing.Point(645, 117);
            this.btnPresupuestos.Name = "btnPresupuestos";
            this.btnPresupuestos.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.btnPresupuestos.Size = new System.Drawing.Size(270, 400);
            this.btnPresupuestos.TabIndex = 2;
            this.btnPresupuestos.Text = "Presupuestos";
            this.btnPresupuestos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPresupuestos.UseVisualStyleBackColor = false;
            this.btnPresupuestos.Click += new System.EventHandler(this.btnPresupuestos_Click);
            // 
            // buttonEstadisticas
            // 
            this.buttonEstadisticas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonEstadisticas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(157)))), ((int)(((byte)(186)))));
            this.buttonEstadisticas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEstadisticas.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 21F);
            this.buttonEstadisticas.Image = global::AluminiosRuta5.Properties.Resources.investigacion_1_;
            this.buttonEstadisticas.Location = new System.Drawing.Point(921, 117);
            this.buttonEstadisticas.Name = "buttonEstadisticas";
            this.buttonEstadisticas.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.buttonEstadisticas.Size = new System.Drawing.Size(270, 400);
            this.buttonEstadisticas.TabIndex = 3;
            this.buttonEstadisticas.Text = "Estadisticas";
            this.buttonEstadisticas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonEstadisticas.UseVisualStyleBackColor = false;
            this.buttonEstadisticas.Click += new System.EventHandler(this.buttonEstadisticas_Click);
            // 
            // FormEleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.buttonEstadisticas);
            this.Controls.Add(this.btnPresupuestos);
            this.Controls.Add(this.btnRemitos);
            this.Controls.Add(this.btnStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEleccion";
            this.Text = "FormEleccion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnRemitos;
        private System.Windows.Forms.Button btnPresupuestos;
        private System.Windows.Forms.Button buttonEstadisticas;
    }
}