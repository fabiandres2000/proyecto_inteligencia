namespace Backpropagation
{
    public class Caracteresabinario
    {
        float[] vectordesalidas;
        int salidas;
        public Caracteresabinario(int salidas)
        {
            this.salidas = salidas;
            vectordesalidas = new float[salidas];
        }
        public float[] ConvertirCadenaDeCaracteresABitsYAlmacenarloEnSalidas(string[] arraydecaracteres)
        {

            for (int i = 0; i < salidas/5; i++)
            {
                try
                {
                    switch (arraydecaracteres[i])
                    {
                        case "a":
                            AsignarValoresOrganizados(0,0,0,0,1,i);
                            break;
                        case "b":
                            AsignarValoresOrganizados(0,0,0,1,0,i);
                            break;
                        case "c":
                            AsignarValoresOrganizados(0,0,0,1,1,i);
                            break;
                        case "d":
                            AsignarValoresOrganizados(0,0,1,0,0,i);
                            break;
                        case "e":
                            AsignarValoresOrganizados(0,0,1,0,1,i);
                            break;
                        case "f":
                            AsignarValoresOrganizados(0,0,1,1,0,i);
                            break;
                        case "g":
                            AsignarValoresOrganizados(0,0,1,1,1,i);
                            break;
                        case "h":
                            AsignarValoresOrganizados(0,1,0,0,0,i);
                            break;
                        case "i":
                            AsignarValoresOrganizados(0,1,0,0,1,i);
                            break;
                        case "j":
                            AsignarValoresOrganizados(0,1,0,1,0,i);
                            break;
                        case "k":
                            AsignarValoresOrganizados(0,1,0,1,1,i);
                            break;
                        case "l":
                            AsignarValoresOrganizados(0,1,1,0,0,i);
                            break;
                        case "m":
                            AsignarValoresOrganizados(0,1,1,0,1,i);
                            break;
                        case "n":
                            AsignarValoresOrganizados(0,1,1,1,0,i);
                            break;
                        case "ñ":
                            AsignarValoresOrganizados(0,1,1,1,1,i);
                            break;
                        case "o":
                            AsignarValoresOrganizados(1,0,0,0,0,i);
                            break;
                        case "p":
                            AsignarValoresOrganizados(1,0,0,0,1,i);
                            break;
                        case "q":
                            AsignarValoresOrganizados(1,0,0,1,0,i);
                            break;
                        case "r":
                            AsignarValoresOrganizados(1,0,0,1,1,i);
                            break;
                        case "s":
                            AsignarValoresOrganizados(1,0,1,0,0,i);
                            break;
                        case "t":
                            AsignarValoresOrganizados(1,0,1,0,1,i);
                            break;
                        case "u":
                            AsignarValoresOrganizados(1,0,1,1,0,i);
                            break;
                        case "v":
                            AsignarValoresOrganizados(1,0,1,1,1,i);
                            break;
                        case "w":
                            AsignarValoresOrganizados(1,1,0,0,0,i);
                            break;
                        case "x":
                            AsignarValoresOrganizados(1,1,0,0,1,i);
                            break;
                        case "y":
                            AsignarValoresOrganizados(1,1,0,1,0,i);
                            break;
                        case "z":
                            AsignarValoresOrganizados(1,1,0,1,1,i);
                            break;
                        default:
                            AsignarValoresOrganizados(0,0,0,0,0,i);
                            break;
                    }
                }
                catch
                {
                    AsignarValoresOrganizados(0,0,0,0,0,i);
                }
            }
            return vectordesalidas;
        }
        private void AsignarValoresOrganizados(float val1, float val2, float val3, float val4, float val5, int posicion)
        {
            if (posicion == 0)
            {
                vectordesalidas[posicion] = val1;
                vectordesalidas[posicion + 1] = val2;
                vectordesalidas[posicion + 2] = val3;
                vectordesalidas[posicion + 3] = val4;
                vectordesalidas[posicion + 4] = val5;
            }
            else
            {
                posicion *= 5;
                vectordesalidas[posicion] = val1;
                vectordesalidas[posicion + 1] = val2;
                vectordesalidas[posicion + 2] = val3;
                vectordesalidas[posicion + 3] = val4;
                vectordesalidas[posicion + 4] = val5;
            }
        }
    }
}
