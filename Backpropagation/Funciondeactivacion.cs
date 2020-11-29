using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptronmulticapas
{
    class Funciondeactivacion
    {
        double res;
        string funcion;
        float salidaCapa;
        public Funciondeactivacion(string funcion, float salidaCapa)
        {
            this.funcion = funcion;
            this.salidaCapa = salidaCapa;
        }
        public float getfunActivacion()
        {
            switch (funcion)
            {
                case "Lineal.":
                    this.res = salidaCapa;
                    break;
                case "Sigmoidal.":
                    this.res = (1 / (1 + Math.Exp(-salidaCapa)));
                    break;
                case "Tangente hiperbólica.":
                    this.res = Math.Tanh(salidaCapa);
                    break;
                case "Seno.":
                    this.res = Math.Sin(salidaCapa);
                    break;
                case "Coseno.":
                    this.res = Math.Cos(salidaCapa);
                    break;
                case "Gausiana.":
                    this.res =  Math.Pow(Math.Exp(-Math.Pow(salidaCapa, 2)), 1);
                    break;
            }
            return (float.Parse(this.res.ToString()));
        }
    }
}
