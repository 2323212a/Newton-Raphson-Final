using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Newton_Raphson
{
    public partial class Datos_extra : Form
    {
        private readonly string funcion;
        private Timer animacionEntrada;
        private int desplazamientoY = -30;

        public Datos_extra(string funcion)
        {
            InitializeComponent();
            this.funcion = funcion;

            AplicarEstilo();

            btnEditar.Enabled = false;
            btnSiguiente.Enabled = false;

            this.Opacity = 0;
            animacionEntrada = new Timer();
            animacionEntrada.Interval = 20;
            animacionEntrada.Tick += AnimarEntrada;
            animacionEntrada.Start();
        }

        private void AnimarEntrada(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            this.Top += desplazamientoY / 15;
            if (this.Opacity >= 1)
            {
                animacionEntrada.Stop();
            }
        }

        private void AplicarEstilo()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Font = new Font("Segoe UI", 10);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Datos Iniciales - Método de Newton-Raphson";

            foreach (Control c in this.Controls)
            {
                if (c is TextBox txt)
                {
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.BackColor = Color.WhiteSmoke;
                    txt.Font = new Font("Segoe UI", 10);

                    txt.Enter += (s, e) => txt.BackColor = Color.FromArgb(230, 240, 255);
                    txt.Leave += (s, e) => txt.BackColor = Color.WhiteSmoke;
                }
            }

      
            ConfigurarBoton(btnInsertarX0, Color.FromArgb(0, 120, 215), Color.White);
            ConfigurarBoton(btnEditar, Color.FromArgb(255, 193, 7), Color.Black);
            ConfigurarBoton(btnBorrar, Color.FromArgb(220, 53, 69), Color.White);
            ConfigurarBoton(btnSiguiente, Color.FromArgb(40, 167, 69), Color.White);
            ConfigurarBoton(btnRegresar, Color.FromArgb(108, 117, 125), Color.White);

            panelDatosExtra.BackColor = Color.White;
            panelDatosExtra.BorderStyle = BorderStyle.FixedSingle;
            panelDatosExtra.Padding = new Padding(10);

            this.Paint += (s, e) =>
            {
                using (Pen sombra = new Pen(Color.FromArgb(180, 200, 200, 200), 6))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawRectangle(sombra, 3, 3, this.Width - 8, this.Height - 8);
                }
            };
        }

        private void ConfigurarBoton(Button boton, Color colorFondo, Color colorTexto)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = colorFondo;
            boton.ForeColor = colorTexto;
            boton.Font = new Font("Segoe UI Semibold", 10);
            boton.Cursor = Cursors.Hand;

         
            boton.Paint += (s, e) =>
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    int r = 10;
                    Rectangle rect = boton.ClientRectangle;
                    path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                    path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                    path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                    path.CloseFigure();
                    boton.Region = new Region(path);
                }
            };

            boton.MouseEnter += (s, e) =>
            {
                boton.BackColor = ControlPaint.Light(colorFondo);
                boton.Font = new Font("Segoe UI Semibold", 10.2f);
                boton.Padding = new Padding(2, 1, 2, 1);
            };

            boton.MouseLeave += (s, e) =>
            {
                boton.BackColor = colorFondo;
                boton.Font = new Font("Segoe UI Semibold", 10);
                boton.Padding = new Padding(0);
            };
        }

        private void btninsertarxo_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtX0.Text.Trim(), out double x0))
            {
                MessageBox.Show("Ingrese un valor numérico válido para X₀.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtError.Text.Trim(), out double error) || error <= 0)
            {
                MessageBox.Show("Ingrese un valor positivo para el error tolerado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            panelDatosExtra.Controls.Clear();

            var lblX0 = new Label
            {
                Text = $"X₀ = {x0}",
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 10),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(10, 10)
            };

            var lblError = new Label
            {
                Text = $"Error tolerado = {error}",
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 10),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(10, 35)
            };

            panelDatosExtra.Controls.Add(lblX0);
            panelDatosExtra.Controls.Add(lblError);

            txtX0.Enabled = false;
            txtError.Enabled = false;
            btnInsertarX0.Enabled = false;
            btnEditar.Enabled = true;
            btnSiguiente.Enabled = true;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            txtX0.Enabled = true;
            txtError.Enabled = true;
            btnInsertarX0.Enabled = true;
            btnEditar.Enabled = false;
            btnSiguiente.Enabled = false;
        }

        private void btnerror_Click(object sender, EventArgs e)
        {
            txtX0.Clear();
            txtError.Clear();
            txtX0.Enabled = true;
            txtError.Enabled = true;
            btnInsertarX0.Enabled = true;
            btnEditar.Enabled = false;
            btnSiguiente.Enabled = false;
            panelDatosExtra.Controls.Clear();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtX0.Text.Trim(), out double x0))
            {
                MessageBox.Show("X₀ inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtError.Text.Trim(), out double error) || error <= 0)
            {
                MessageBox.Show("Error tolerado inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Tabla tablaForm = new Tabla(funcion, x0, error);
            tablaForm.Show();
            this.Hide();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void Datos_extra_Load(object sender, EventArgs e) { }
    }
}

