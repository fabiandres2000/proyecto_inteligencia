using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerceptronMulticapa
{
    public class Funcionderivada
    {
        double res;
        string funcion;
        float salidaCapa;
        public Funcionderivada(string funcion, float salidaCapa)
        {
            this.funcion = funcion;
            this.salidaCapa = salidaCapa;
        }
        public float getfunDerivada()
        {
            switch (funcion)
            {
                case "Sigmoidal.":
                    this.res = Math.Exp(-salidaCapa) / Math.Pow(1+Math.Exp(-salidaCapa), 2);
                    break;
                case "Tangente hiperbólica.":
                    this.res = 1 / Math.Pow(Math.Cosh(salidaCapa), 2);
                    break;
                case "Seno.":
                    this.res = Math.Cos(salidaCapa);
                    break;
                case "Coseno.":
                    this.res = -Math.Sin(salidaCapa);
                    break;
                case "Gausiana.":
                    this.res = -Math.Sin(salidaCapa);//float.Parse(((-2) * Math.Pow(Math.E, -Math.Pow(salidaCapa, 2)) * salidaCapa).ToString());
                    break;
            }
            return (float.Parse(this.res.ToString()));
        }
    }
}
