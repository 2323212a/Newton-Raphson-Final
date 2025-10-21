using System;

namespace Newton_Raphson
{
    partial class Tabla
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
        /// Método requerido para el diseñador. No modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridNewton = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNewton)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridNewton
            // 
            this.dataGridNewton.AllowUserToAddRows = false;
            this.dataGridNewton.AllowUserToDeleteRows = false;
            this.dataGridNewton.AllowUserToResizeRows = false;
            this.dataGridNewton.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridNewton.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridNewton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNewton.Location = new System.Drawing.Point(37, 66);
            this.dataGridNewton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridNewton.Name = "dataGridNewton";
            this.dataGridNewton.ReadOnly = true;
            this.dataGridNewton.RowHeadersVisible = false;
            this.dataGridNewton.RowHeadersWidth = 51;
            this.dataGridNewton.RowTemplate.Height = 28;
            this.dataGridNewton.Size = new System.Drawing.Size(832, 400);
            this.dataGridNewton.TabIndex = 0;
            this.dataGridNewton.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridNewton_CellContentClick);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(496, 484);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(138, 63);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Firebrick;
            this.btnRegresar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Location = new System.Drawing.Point(261, 484);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(141, 63);
            this.btnRegresar.TabIndex = 2;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // Tabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 560);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dataGridNewton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tabla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Método de Newton-Raphson - Iteraciones";
            this.Load += new System.EventHandler(this.Tabla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNewton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridNewton;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnRegresar;
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            var formPrincipal = new Form1();
            formPrincipal.Show();
            this.Close();
        }
    }

}

