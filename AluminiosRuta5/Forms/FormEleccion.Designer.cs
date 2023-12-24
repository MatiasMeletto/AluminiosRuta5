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
            this.btnStock = new System.Windows.Forms.Button();
            this.btnRemito = new System.Windows.Forms.Button();
            this.btnPresupuesto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStock
            // 
            this.btnStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(157)))), ((int)(((byte)(186)))));
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStock.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.Location = new System.Drawing.Point(75, 82);
            this.btnStock.Name = "btnStock";
            this.btnStock.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.btnStock.Size = new System.Drawing.Size(370, 500);
            this.btnStock.TabIndex = 0;
            this.btnStock.Text = "Stock";
            this.btnStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStock.UseVisualStyleBackColor = false;
            // 
            // btnRemito
            // 
            this.btnRemito.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemito.AutoSize = true;
            this.btnRemito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(157)))), ((int)(((byte)(186)))));
            this.btnRemito.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemito.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemito.Location = new System.Drawing.Point(451, 82);
            this.btnRemito.Name = "btnRemito";
            this.btnRemito.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.btnRemito.Size = new System.Drawing.Size(370, 500);
            this.btnRemito.TabIndex = 1;
            this.btnRemito.Text = "Remitos";
            this.btnRemito.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemito.UseVisualStyleBackColor = false;
            // 
            // btnPresupuesto
            // 
            this.btnPresupuesto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPresupuesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(157)))), ((int)(((byte)(186)))));
            this.btnPresupuesto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPresupuesto.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresupuesto.Location = new System.Drawing.Point(827, 82);
            this.btnPresupuesto.Name = "btnPresupuesto";
            this.btnPresupuesto.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.btnPresupuesto.Size = new System.Drawing.Size(370, 500);
            this.btnPresupuesto.TabIndex = 2;
            this.btnPresupuesto.Text = "Presupuestos";
            this.btnPresupuesto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPresupuesto.UseVisualStyleBackColor = false;
            // 
            // FormEleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.btnPresupuesto);
            this.Controls.Add(this.btnRemito);
            this.Controls.Add(this.btnStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEleccion";
            this.Text = "FormEleccion";
            this.Load += new System.EventHandler(this.FormEleccion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnRemito;
        private System.Windows.Forms.Button btnPresupuesto;
    }
}