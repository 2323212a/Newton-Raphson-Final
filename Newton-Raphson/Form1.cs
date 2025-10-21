using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Newton_Raphson
{
    public partial class Form1 : Form
    {
        private string funcionPotenciaCuarta = null;   // Para evaluar "3*x^4 - 2*x^3 + 1"
        private string funcionParaMostrar = null;      // Para mostrar con potencias unicode "3x⁴ - 2x³ + 1"

        public Form1()
        {
            InitializeComponent();
            Panelpreedicion.Visible = false;
            btnEditar.Enabled = false;
            btnsiguiente.Enabled = false;
        }

        private void btninsertar_Click_1(object sender, EventArgs e)
        {
            var coeficientes = new Dictionary<int, string>
            {
                { 4, textBox1.Text.Trim() },
                { 3, textBox2.Text.Trim() },
                { 2, textBox3.Text.Trim() },
                { 1, textBox4.Text.Trim() },
                { 0, textBox5.Text.Trim() }
            };

            bool hayAlMenosUnCoeficiente = false;
            List<string> partesFuncionMostrar = new List<string>();
            List<string> partesFuncionEvaluar = new List<string>();

            foreach (var kvp in coeficientes)
            {
                int grado = kvp.Key;
                string coef = kvp.Value;

                if (!string.IsNullOrWhiteSpace(coef))
                {
                    hayAlMenosUnCoeficiente = true;

                    if (!double.TryParse(coef, out double valorNumerico))
                    {
                        MessageBox.Show($"Coeficiente inválido en x^{grado}. Asegúrate de ingresar números válidos.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string terminoMostrar = ConstruirTerminoParaMostrar(valorNumerico, grado, partesFuncionMostrar.Count == 0);
                    if (!string.IsNullOrEmpty(terminoMostrar))
                        partesFuncionMostrar.Add(terminoMostrar);

                    string terminoEvaluar = ConstruirTerminoParaEvaluar(valorNumerico, grado, partesFuncionEvaluar.Count == 0);
                    if (!string.IsNullOrEmpty(terminoEvaluar))
                        partesFuncionEvaluar.Add(terminoEvaluar);
                }
            }

            if (!hayAlMenosUnCoeficiente)
            {
                MessageBox.Show("Ingrese al menos un coeficiente válido para la función de potencia cuarta.");
                return;
            }

            funcionParaMostrar = string.Join(" ", partesFuncionMostrar);
            funcionPotenciaCuarta = string.Join(" ", partesFuncionEvaluar);

       
            Panelpreedicion.Controls.Clear();
            var lblFuncion = new Label
            {
                Text = funcionParaMostrar,
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 12)
            };
            Panelpreedicion.Controls.Add(lblFuncion);
            Panelpreedicion.Visible = true;

            // Bloquear textboxes
            BloquearTextBoxes();

            // Activar botones
            btnEditar.Enabled = true;
            btnsiguiente.Enabled = true;
        }

        private string ConstruirTerminoParaMostrar(double coef, int grado, bool esPrimerTermino)
        {
            if (coef == 0) return string.Empty;

            string signo = coef > 0 ? (esPrimerTermino ? "" : "+") : "-";
            double valorAbs = Math.Abs(coef);

            string coefStr = (valorAbs == 1 && grado != 0) ? "" : valorAbs.ToString();

            string potenciaUnicode = "";
            if (grado == 4)
                potenciaUnicode = "x⁴";
            else if (grado == 3)
                potenciaUnicode = "x³";
            else if (grado == 2)
                potenciaUnicode = "x²";
            else if (grado == 1)
                potenciaUnicode = "x";
            else if (grado == 0)
                potenciaUnicode = "";
            else
                potenciaUnicode = "x^" + grado;

            return (signo + " " + coefStr + potenciaUnicode).Trim();
        }

        private string ConstruirTerminoParaEvaluar(double coef, int grado, bool esPrimerTermino)
        {
            if (coef == 0) return string.Empty;

            string signo = coef > 0 ? (esPrimerTermino ? "" : "+") : "-";
            double valorAbs = Math.Abs(coef);

            string coefStr = (valorAbs == 1 && grado != 0) ? "" : valorAbs.ToString();

            string potencia = "";
            if (grado == 0)
                potencia = "";
            else if (grado == 1)
                potencia = "x";
            else
                potencia = "x^" + grado;

            return (signo + " " + coefStr + potencia).Trim();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DesbloquearTextBoxes();
            textBox1.Focus();
        }

        private void btnborrar_Click_1(object sender, EventArgs e)
        {
            funcionPotenciaCuarta = null;
            funcionParaMostrar = null;
            Panelpreedicion.Controls.Clear();
            Panelpreedicion.Visible = false;

           
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

           
            DesbloquearTextBoxes();

            btnEditar.Enabled = false;
            btnsiguiente.Enabled = false;
        }

        private void btnsalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(funcionPotenciaCuarta))
            {
                MessageBox.Show("Debe ingresar una función válida antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Datos_extra siguiente = new Datos_extra(funcionPotenciaCuarta);
            siguiente.Show();
            this.Hide();  
        }

        private void BloquearTextBoxes()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }

        private void DesbloquearTextBoxes()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
