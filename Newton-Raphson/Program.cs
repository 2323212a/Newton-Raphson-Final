using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Newton_Raphson
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Creamos una instancia de nuestra pantalla de presentación.
            Form2 formPresentacion = new Form2();
            formPresentacion.ShowDialog();
            if (formPresentacion.DialogResult == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
            
        }
    }
}
