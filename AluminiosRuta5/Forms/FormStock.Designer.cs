namespace AluminiosRuta5.Forms
{
    partial class FormStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStock));
            this.panelSeleccion = new System.Windows.Forms.Panel();
            this.panelSalida = new System.Windows.Forms.Panel();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panelDefault = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panelDecorativo = new System.Windows.Forms.Panel();
            this.panelPerfiles = new System.Windows.Forms.Panel();
            this.panelSalida.SuspendLayout();
            this.panelDefault.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSeleccion
            // 
            resources.ApplyResources(this.panelSeleccion, "panelSeleccion");
            this.panelSeleccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
            this.panelSeleccion.Name = "panelSeleccion";
            // 
            // panelSalida
            // 
            resources.ApplyResources(this.panelSalida, "panelSalida");
            this.panelSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
            this.panelSalida.Controls.Add(this.btnCategorias);
            this.panelSalida.Controls.Add(this.btnVolver);
            this.panelSalida.Name = "panelSalida";
            // 
            // btnCategorias
            // 
            resources.ApplyResources(this.btnCategorias, "btnCategorias");
            this.btnCategorias.ForeColor = System.Drawing.Color.Aqua;
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnVolver
            // 
            resources.ApplyResources(this.btnVolver, "btnVolver");
            this.btnVolver.ForeColor = System.Drawing.Color.Aqua;
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // panelDefault
            // 
            this.panelDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
            this.panelDefault.Controls.Add(this.btnAgregar);
            resources.ApplyResources(this.panelDefault, "panelDefault");
            this.panelDefault.Name = "panelDefault";
            this.panelDefault.Click += new System.EventHandler(this.panelDefault_Click);
            // 
            // btnAgregar
            // 
            resources.ApplyResources(this.btnAgregar, "btnAgregar");
            this.btnAgregar.ForeColor = System.Drawing.Color.Aqua;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panelDecorativo
            // 
            this.panelDecorativo.BackColor = System.Drawing.Color.LightCyan;
            resources.ApplyResources(this.panelDecorativo, "panelDecorativo");
            this.panelDecorativo.Name = "panelDecorativo";
            // 
            // panelPerfiles
            // 
            resources.ApplyResources(this.panelPerfiles, "panelPerfiles");
            this.panelPerfiles.Name = "panelPerfiles";
            // 
            // FormStock
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panelPerfiles);
            this.Controls.Add(this.panelDecorativo);
            this.Controls.Add(this.panelDefault);
            this.Controls.Add(this.panelSalida);
            this.Controls.Add(this.panelSeleccion);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormStock";
            this.Load += new System.EventHandler(this.FormStock_Load);
            this.panelSalida.ResumeLayout(false);
            this.panelDefault.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSeleccion;
        private System.Windows.Forms.Panel panelSalida;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Panel panelDefault;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Panel panelDecorativo;
        private System.Windows.Forms.Panel panelPerfiles;
        private System.Windows.Forms.Button btnAgregar;
    }
}