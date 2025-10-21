using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NCalc;

namespace Newton_Raphson
{
    public class ResultadoNewtonRaphson
    {
        public int Iteracion { get; set; }
        public double Xi { get; set; }
        public double Fxi { get; set; }
        public double Fpxi { get; set; }
        public double Xi1 { get; set; }
        public double Fx1 { get; set; }
        public double Error { get; set; }
    }

    public class NewtonRaphsonSolver
    {
        public static List<ResultadoNewtonRaphson> Ejecutar(string funcion, double x0, double errorTolerado)
        {
            var resultados = new List<ResultadoNewtonRaphson>();
            double xi = x0;
            double error = 100;
            int iteracion = 0;

            while (error > errorTolerado && iteracion < 1000)
            {
                double fxi = EvaluarFuncion(funcion, xi);
                double fpxi = DerivarFuncion(funcion, xi);

                if (fpxi == 0)
                    throw new Exception("La derivada es cero. No se puede continuar.");

                double xi1 = xi - (fxi / fpxi);
                double fx1 = EvaluarFuncion(funcion, xi1);
                error = Math.Abs((xi1 - xi) / xi1);

                resultados.Add(new ResultadoNewtonRaphson
                {
                    Iteracion = iteracion + 1,
                    Xi = xi,
                    Fxi = fxi,
                    Fpxi = fpxi,
                    Xi1 = xi1,
                    Fx1 = fx1,
                    Error = error
                });

                xi = xi1;
                iteracion++;
            }

            return resultados;
        }

   
        public static double EvaluarFuncion(string funcion, double x)
        {
            try
            {
                // Preprocesamiento de la función
                string corregida = PrepararFuncion(funcion);

                var expr = new Expression(corregida);
                expr.Parameters["x"] = x;

                return Convert.ToDouble(expr.Evaluate());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al evaluar la función '{funcion}' en x={x}: {ex.Message}");
            }
        }

       
        public static double DerivarFuncion(string funcion, double x)
        {
            try
            {
                // Derivada numérica: f'(x) ≈ (f(x+h) - f(x-h)) / (2h)
                //funcion de diferencia centrada
                double h = 1e-6;

                // Preparamos la función solo una vez
                string corregida = PrepararFuncion(funcion);

                double fxh = EvaluarFuncion(corregida, x + h);
                double fx_h = EvaluarFuncion(corregida, x - h);

                return (fxh - fx_h) / (2 * h);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al derivar la función '{funcion}' en x={x}: {ex.Message}");
            }
        }

        private static string PrepararFuncion(string funcion)
        {
            string corregida = funcion;

          
            corregida = Regex.Replace(corregida, @"(\d)(x)", "$1*$2");

         
            corregida = Regex.Replace(corregida, @"(\))(\s*\*?\s*x)", "$1*$2");

            
            corregida = Regex.Replace(corregida, @"x\^(\d+)", "Pow(x,$1)");

            
            corregida = corregida.Replace(" ", "");

            return corregida;
        }
    }
}
