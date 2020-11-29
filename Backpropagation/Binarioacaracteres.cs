
using System.Windows.Forms;

namespace Backpropagation
{
    public class Binarioacaracteres
    {
        string Resultado;
        string Cadenabinaria;
        public Binarioacaracteres(string cadenabinaria)
        {
            this.Resultado = "";
            this.Cadenabinaria = cadenabinaria;
        }
        public string ConvertirDeBinarioACadenaDeCaracteres()
        {
            Resultado = "";
            ConversionOrdenada(Cadenabinaria);
            return Resultado;
        }
        public void ConversionOrdenada(string cadenabinaria)
        {
            int i = 0;
            while (i++ <= cadenabinaria.Length)
            {
                string bits = "";
                if (i % 5 == 0)
                {
                    bits = bits + cadenabinaria[i - 5];
                    bits = bits + cadenabinaria[i - 4];
                    bits = bits + cadenabinaria[i - 3];
                    bits = bits + cadenabinaria[i - 2];
                    bits = bits + cadenabinaria[i - 1];
                    ValoresBinarios(bits);
                }
            }
        }
        public void ValoresBinarios(string cadena)
        {
            switch (cadena)
            {
                case "00001":
                    Resultado += "a";
                    break;
                case "00010":
                    Resultado += "b";
                    break;
                case "00011":
                    Resultado += "c";
                    break;
                case "00100":
                    Resultado += "d";
                    break;
                case "00101":
                    Resultado += "e";
                    break;
                case "00110":
                    Resultado += "f";
                    break;
                case "00111":
                    Resultado += "g";
                    break;
                case "01000":
                    Resultado += "h";
                    break;
                case "01001":
                    Resultado += "i";
                    break;
                case "01010":
                    Resultado += "j";
                    break;
                case "01011":
                    Resultado += "k";
                    break;
                case "01100":
                    Resultado += "l";
                    break;
                case "01101":
                    Resultado += "m";
                    break;
                case "01110":
                    Resultado += "n";
                    break;
                case "01111":
                    Resultado += "ñ";
                    break;
                case "10000":
                    Resultado += "o";
                    break;
                case "10001":
                    Resultado += "p";
                    break;
                case "10010":
                    Resultado += "q";
                    break;
                case "10011":
                    Resultado += "r";
                    break;
                case "10100":
                    Resultado += "s";
                    break;
                case "10101":
                    Resultado += "t";
                    break;
                case "10110":
                    Resultado += "u";
                    break;
                case "10111":
                    Resultado += "v";
                    break;
                case "11000":
                    Resultado += "w";
                    break;
                case "11001":
                    Resultado += "x";
                    break;
                case "11010":
                    Resultado += "y";
                    break;
                case "11011":
                    Resultado += "z";
                    break;
                case "00000":
                    Resultado += " ";
                    break;
            }
        }
    }
}
