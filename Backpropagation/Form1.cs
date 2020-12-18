using Backpropagation;
using NAudio.Wave;
using NUnit.Framework;
using PerceptronMulticapa;
using Perceptronmulticapas;
using Perceptronsimple;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace pruebaRed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int posiciongrafica = 1;
        int entrenando = 0;
        int entradas;
        int salidas;
        int patrones;
        int iteracion = 0;
        int conti = 1;
        float ratadeaprendizaje = 0;
        float errormaximopermitido = 0;
        float errordeiteracion = 0;
        float[] arraydenumerosmayoresporcolumnasdeentradas;
        float[] arraydenumerosmenoresporcolumnasdeentradas;
        float[] arraydeerrordelospatrones;
        float[] arraydeerroreslineales;
        float[] arraydeumbrales;
        float[] arraydeerrornolinealporneuronasdecapasocultas = null;
        float[,] arraydematrizdepesos;
        float[,] arraydeentradasdelared;
        float[,] arraydesalidasdeseadas;
        float[,] arraydesalidadelacapaactual;
        float[,] arraydesalidadelacapaanterior;
        List<string> registros = new List<string>();  
        List<float> listadeerroresdeiteracion = new List<float>();
        List<int> listadeiteraciones = new List<int>();
        Dictionary<int, float[,]> diccionariodearraydematrizdepesos = new Dictionary<int, float[,]>();
        Dictionary<int, float[]> diccionariodearraydeumbrales = new Dictionary<int, float[]>();
        Dictionary<int, float[,]> diccionariodelassalidasdecapa = new Dictionary<int, float[,]>();
        Dictionary<int, float[]> diccionariodeerrornolinealdeneuronasporcapaoscultas = new Dictionary<int, float[]>();
        List<float[]> Colecciondeentradas = new List<float[]>();
        List<float[]> Colecciondesalidas = new List<float[]>();
        float[] arraydeentradas;
        float[] arraydesalidas;
        private void btnCargarmatriz_Click(object sender, EventArgs e)
        {
            grilladedatos.Rows.Clear();
            grilladedatos.Columns.Clear();
            grilladecapasocultas.Rows.Clear();
            grilladecapasocultas.Columns.Clear();
            registros.Clear();
            patrones = 0;
            entradas = 100;
            salidas = 0;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Title = "SELECCIONE TODOS LOS AUDIOS CON DIAGNOSTICO";
            dlg.CheckFileExists = true;
            dlg.Filter = "WAV files (*.wav)|*.wav";
            dlg.DefaultExt = ".wav";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Colecciondeentradas.Clear();
                Colecciondesalidas.Clear();
                int dimensiondesalidas = 0;
                foreach (var file in dlg.FileNames)
                {
                    string[] cadenadestring = new string[2];
                    cadenadestring = new FileInfo(file).Name.Split('.');
                    if (dimensiondesalidas < cadenadestring[0].Length)
                        dimensiondesalidas = cadenadestring[0].Length;
                }
                salidas = dimensiondesalidas * 5;
                foreach (var file in dlg.FileNames)
                {
                    arraydeentradas = new float[entradas];
                    WaveFileReader reader = new WaveFileReader(file);
                    Assert.AreEqual(16, reader.WaveFormat.BitsPerSample, "Only works with 16 bit audio");
                    byte[] buffer = new byte[reader.Length];
                    int read = reader.Read(buffer, 0, buffer.Length);
                    short[] sampleBuffer = new short[read / 2];
                    Buffer.BlockCopy(buffer, 0, sampleBuffer, 0, read);
                    for (int i = 0; i < 100; i++)
                        arraydeentradas[i] = float.Parse(sampleBuffer[i].ToString());
                    Colecciondeentradas.Add(arraydeentradas);
                    ObbtenerSalidasPorArchivo(new FileInfo(file));
                }
                GuardarMatrizDeDatosEnArchivoPlano();
                TextReader leerdatos = new StreamReader("Carpeta de datos/Matriz de datos.txt");
                string fila;
                while ((fila = leerdatos.ReadLine()) != null)//Leemos línea por línea del archivo.
                {
                    patrones = patrones + 1;
                    registros.Add(fila);
                }
                leerdatos.Close();
                lblEntradas.Text = entradas.ToString();
                lblSalidas.Text = salidas.ToString();
                lblPatrones.Text = (patrones - 1).ToString(); //Se resta 1 porque la cabecera no se toma como patrón.
                patrones--;
                arraydeentradasdelared = new float[patrones, entradas];
                arraydesalidasdeseadas = new float[patrones, salidas];
                arraydeerrordelospatrones = new float[patrones];
                arraydeerroreslineales = new float[salidas];
                arraydenumerosmayoresporcolumnasdeentradas = new float[entradas];
                arraydenumerosmenoresporcolumnasdeentradas = new float[entradas];
                registros.RemoveAt(0);//Removemos el primer registro que vendría siendo la cabecera.
                //mostramos el mensaje de espera
                Barra_espera espera = new Barra_espera();
                espera.Show();
                int times = 400;
                while (times > 0)
                {
                    Application.DoEvents();
                    Thread.Sleep(1);
                    times--;
                }
                for (int i = 0; i < entradas; i++)//Creamos las columnas de entradas.
                {
                    string titulo = "Xr" + (i + 1);
                    grilladedatos.Columns.Add("Xr", titulo);
                }
                for (int i = 0; i < salidas; i++)//Creamos las columnas de las salidas.
                {
                    string titulo = "Yr" + (i + 1);
                    grilladedatos.Columns.Add("Yr", titulo);
                }
              
                int _i = 0;
                foreach (string registro in registros)//Lleno la grila de datos y las matrices de entradas y salidas.
                {
                    grilladedatos.Rows.Add(registro.Split(' '));
                    string[] reg = registro.Split(' ');
                    for (int j = 0; j < reg.Length; j++)
                    {
                        if (j < entradas)
                        {
                            arraydeentradasdelared[_i, j] = float.Parse(reg[j]);//Lleno la matriz de entradas de la red.
                        }
                        else
                            arraydesalidasdeseadas[_i, j - entradas] = float.Parse(reg[j]);//Lleno las salidas deseadas de la red.
                    }
                    _i++;
                }
                grilladedatos.AllowUserToAddRows = false;
                NormalizarEntradasDeLaRed();
                MessageBox.Show("Se han procesado los audios y se paso la señal a reales.", "Atencion!");
                nudCapasocultas.Enabled = true;
                nudCapasocultasactivado();
                comboBox1.Enabled = true;
            }
        }
        private void NormalizarEntradasDeLaRed()
        {
            for (int i = 0; i < arraydeentradasdelared.GetLength(1); i++)//Obtenemos el valor máximo y minimo para las columnas de entradas.
            {
                float Maximovalor = -1000000;
                float Minimovalor = 1000000;
                for (int j = 0; j < arraydeentradasdelared.GetLength(0); j++)
                {
                    if (Maximovalor < arraydeentradasdelared[j, i])
                        Maximovalor = arraydeentradasdelared[j, i];
                    if (Minimovalor > arraydeentradasdelared[j, i])
                        Minimovalor = arraydeentradasdelared[j, i];
                }
                arraydenumerosmayoresporcolumnasdeentradas[i] = Maximovalor;
                arraydenumerosmenoresporcolumnasdeentradas[i] = Minimovalor;
            }
            for (int i = 0; i < arraydeentradasdelared.GetLength(0); i++)//Normalizamos las entradas.
            {
                for (int j = 0; j < arraydeentradasdelared.GetLength(1); j++)
                {
                    arraydeentradasdelared[i, j] = ((arraydeentradasdelared[i, j] - arraydenumerosmenoresporcolumnasdeentradas[j]) * (1 - 0) / (arraydenumerosmayoresporcolumnasdeentradas[j] - arraydenumerosmenoresporcolumnasdeentradas[j])) + 0;
                }
            }
            for (int i = 0; i < patrones; i++)//Volvemos a llenar la tabla de datos con los datos normalizados.
            {
                for (int j = 0; j < entradas + salidas; j++)
                {
                    if (j < entradas)
                    {
                        grilladedatos.Rows[i].Cells[j].Value = arraydeentradasdelared[i, j].ToString();//Lleno las entradas.
                        arraydeentradasdelared[i, j] = float.Parse(Math.Round(arraydeentradasdelared[i, j]).ToString());
                    }
                }
            }
        }
        private void ObbtenerSalidasPorArchivo(FileInfo fileInfo)
        {
            string[] cadenadestring = new string[2];
            cadenadestring = fileInfo.Name.Split('.');
            string[] arraydecadena = new string[cadenadestring[0].Length];
            arraydesalidas = new float[salidas];
            cadenadestring[0] = cadenadestring[0].ToLower();
            char[] arraydecaracteres = new char[cadenadestring[0].Length - 1];
            arraydecaracteres = cadenadestring[0].ToCharArray();
            for (int i = 0; i < arraydecaracteres.Length; i++)
            {
                arraydecadena[i] = arraydecaracteres[i].ToString();
            }
            var resultado = new Caracteresabinario(salidas).ConvertirCadenaDeCaracteresABitsYAlmacenarloEnSalidas(arraydecadena);
            for (int j = 0; j < resultado.Length; j++)
            {
                arraydesalidas[j] = resultado[j];//Lleno la matriz de salidas deseadas de la red.
            }
            Colecciondesalidas.Add(arraydesalidas);
        }
        private void GuardarMatrizDeDatosEnArchivoPlano()
        {
            if (Directory.Exists("Carpeta de datos"))
            {
                if (Directory.GetFiles("Carpeta de datos").Length > 0)
                {
                    File.Delete("Carpeta de datos/Matriz de datos.txt");
                    Directory.Delete("Carpeta de datos");
                }
                else
                {
                    Directory.Delete("Carpeta de datos");
                }
            }
            string rutaFolderdatos = System.IO.Path.Combine("", "Carpeta de datos");
            System.IO.Directory.CreateDirectory(rutaFolderdatos);
            StreamWriter swd = new StreamWriter("Carpeta de datos/Matriz de datos.txt", true);
            string cabecera = "";
            for (int i = 0; i < entradas; i++)
                cabecera += "x ";
            for (int i = 0; i < salidas; i++)
            {
                if (i + 1 == salidas)
                    cabecera += "yd";
                else
                    cabecera += "yd ";
            }
            swd.WriteLine(cabecera);  
            for (int i = 0; i < Colecciondeentradas.Count; i++)
            {
                for (int j = 0; j < arraydeentradas.Length + Colecciondesalidas[i].Length; j++)
                {
                    if (j < arraydeentradas.Length)
                        swd.Write(Colecciondeentradas[i][j] + " ");
                    if (j >= arraydeentradas.Length && j + 1 < arraydeentradas.Length + Colecciondesalidas[i].Length)
                        swd.Write(Colecciondesalidas[i][j - arraydeentradas.Length] + " ");
                    if (j + 1 == arraydeentradas.Length + Colecciondesalidas[i].Length)
                        swd.WriteLine(Colecciondesalidas[i][j - arraydeentradas.Length]);
                }
            }
            swd.Close();
        }
        private void nudCapasocultasactivado()
        {
            grilladecapasocultas.Rows.Clear();
            grilladecapasocultas.Columns.Clear();

            DataGridViewComboBoxColumn Funciondeactivacion = new DataGridViewComboBoxColumn();
            Funciondeactivacion.HeaderText = "Funciones de activación.";
            Funciondeactivacion.Items.Add("Tangente hiperbólica.");
            Funciondeactivacion.Items.Add("Sigmoidal.");
            Funciondeactivacion.Items.Add("Seno.");
            Funciondeactivacion.Items.Add("Coseno.");
            Funciondeactivacion.Items.Add("Gausiana.");

            grilladecapasocultas.Columns.Add("Numerodecapaoculta", "# de capas ocultas.");
            grilladecapasocultas.Columns.Add("Numerodeneuronas", "# de neuronas en capa.");
            grilladecapasocultas.Columns.Add(Funciondeactivacion);
            grilladecapasocultas.AllowUserToAddRows = false;

            for (int i = 0; i < nudCapasocultas.Value; i++)
            {
                grilladecapasocultas.Rows.Add();
                grilladecapasocultas.Rows[i].Cells[0].Value = (i+1).ToString();
                grilladecapasocultas.Rows[i].Cells[1].Value = "1";
                grilladecapasocultas.Rows[i].Cells[2].Value = "Tangente hiperbólica.";
            }
            btnInicializarred.Enabled = true;
        }
        private void btnInicializarred_Click(object sender, EventArgs e)
        {
            conti = 1;
            graficaErroriteracion.Series[0].Points.Clear();
            listadeiteraciones.Clear();
            listadeerroresdeiteracion.Clear();
            
            iteracion = 0;
            diccionariodearraydematrizdepesos.Clear();
            diccionariodearraydeumbrales.Clear();
            for (int capa = 0; capa <= nudCapasocultas.Value; capa++) {//Inicializamos las dimensiondes de los pesos y umbrales.
                if (capa == 0) {
                    arraydeumbrales = new float[Convert.ToInt32(grilladecapasocultas.Rows[capa].Cells[1].Value.ToString())];
                    arraydematrizdepesos = new float[Convert.ToInt32(grilladecapasocultas.Rows[capa].Cells[1].Value.ToString()), entradas];
                }else if (capa > 0 && capa < nudCapasocultas.Value) {
                    arraydeumbrales = new float[Convert.ToInt32(grilladecapasocultas.Rows[capa].Cells[1].Value.ToString())];
                    arraydematrizdepesos = new float[Convert.ToInt32(grilladecapasocultas.Rows[capa].Cells[1].Value.ToString()), Convert.ToInt32(grilladecapasocultas.Rows[capa-1].Cells[1].Value.ToString())];
                }else if (capa == nudCapasocultas.Value) {
                    arraydeumbrales = new float[salidas];
                    arraydematrizdepesos = new float[salidas, Convert.ToInt32(grilladecapasocultas.Rows[capa-1].Cells[1].Value.ToString())];
                }
                diccionariodearraydeumbrales.Add(capa, arraydeumbrales);
                diccionariodearraydematrizdepesos.Add(capa, arraydematrizdepesos);
            }
            Random rnd = new Random();
            foreach (KeyValuePair<int, float[,]> Par in diccionariodearraydematrizdepesos)
            {
                for (int i = 0; i < Par.Value.GetLength(1); i++)
                {
                    for (int j = 0; j < Par.Value.GetLength(0); j++)
                    {
                        double val = rnd.NextDouble() * 1 - (-1) + (-1);
                        Par.Value[j, i] = float.Parse(val.ToString());
                    }
                }
            }
            foreach (KeyValuePair<int, float[]> Par in diccionariodearraydeumbrales)
            {
                for (int i = 0; i < Par.Value.GetLength(0); i++)
                {
                    double val = rnd.NextDouble() * 1 - (-1) + (-1);
                    Par.Value[i] = float.Parse(val.ToString());
                }
            }           
            MessageBox.Show("Pesos y umbrales inicializados con éxito", "Atencion!");
            nudIteraciones.Enabled = true;
            nudErrormaximopermitido.Enabled = true;
            nudRataaprendizaje.Enabled = true;
            btnEntrenarlared.Enabled = true;
            btnEntrenarlared.BackColor = Color.Cyan;
        }
        private void btnEntrenarlared_Click(object sender, EventArgs e)
        {
            if (entrenando == 0)
            {
                listadeerroresdeiteracion.Clear();
                entrenando = 1;
                Entrenamientodelared();
            }
            else if (entrenando == 1)
            {
                Entrenamientodelared();
            }                            
        }

        private void Entrenamientodelared()
        {
            iteracion = iteracion + Convert.ToInt32(nudIteraciones.Value);
            ratadeaprendizaje = float.Parse(nudRataaprendizaje.Value.ToString());
            errormaximopermitido = float.Parse(nudErrormaximopermitido.Value.ToString());
            //guardo error en archivo
            string path = @"c:\error_red.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(errormaximopermitido);
                }
            }
            ///////////////////////////////////////

            errordeiteracion = 1000;
            while (errormaximopermitido < errordeiteracion && conti <= iteracion)
            {
                List<string> listadesalidasdelared = new List<string>();
                List<int> numerodepatrones = new List<int>();
                arraydeerrordelospatrones = new float[patrones];
                for (int pt = 0; pt < patrones; pt++) {
                    float[] arraydeerroresdeneuronasendiccionario = null;
                    float[,] arraydesalidasdecapasocultasanterior = null;
                    diccionariodeerrornolinealdeneuronasporcapaoscultas.Clear();
                    numerodepatrones.Add(pt + 1);
                    diccionariodelassalidasdecapa.Clear();
                    for (int cp = 0; cp <= nudCapasocultas.Value; cp++) {
                        arraydematrizdepesos = diccionariodearraydematrizdepesos[cp];
                        arraydeumbrales = diccionariodearraydeumbrales[cp];
                        arraydesalidadelacapaactual = new float[patrones, arraydematrizdepesos.GetLength(0)];
                        if (cp > 0)
                            arraydesalidadelacapaanterior = diccionariodelassalidasdecapa[cp-1];
                        for (int i = 0; i < arraydematrizdepesos.GetLength(0); i++)
                        {
                            arraydesalidadelacapaactual[pt, i] = 0;
                            if (cp == 0) 
                            {
                                for (int j = 0; j < entradas; j++)
                                {
                                    arraydesalidadelacapaactual[pt, i] += arraydeentradasdelared[pt, j] * arraydematrizdepesos[i, j];
                                }                             
                            }else if (cp > 0 && cp < nudCapasocultas.Value) 
                            {
                                for (int j = 0; j < arraydematrizdepesos.GetLength(1); j++)
                                    arraydesalidadelacapaactual[pt, i] += arraydesalidadelacapaanterior[pt, j] * arraydematrizdepesos[i, j];
                            }else if (cp == nudCapasocultas.Value) 
                            {
                                for (int j = 0; j < arraydematrizdepesos.GetLength(1); j++)
                                    arraydesalidadelacapaactual[pt, i] += arraydesalidadelacapaanterior[pt, j] * arraydematrizdepesos[i, j];
                            }
                            arraydesalidadelacapaactual[pt, i] -= arraydeumbrales[i];
                            if (cp != nudCapasocultas.Value)
                                arraydesalidadelacapaactual[pt, i] = new Funciondeactivacion(grilladecapasocultas.Rows[cp].Cells[2].Value.ToString(), arraydesalidadelacapaactual[pt, i]).getfunActivacion();
                            else
                            {
                                arraydesalidadelacapaactual[pt, i] = new Funciondeactivacion(comboBox1.SelectedItem.ToString(), arraydesalidadelacapaactual[pt, i]).getfunActivacion();
                                listadesalidasdelared.Add(i.ToString() + " " + arraydesalidadelacapaactual[pt, i].ToString());
                            }
                        }
                        diccionariodelassalidasdecapa.Add(cp, arraydesalidadelacapaactual);
                    }
                    //Error lineal de las salidas de la red ....
                    arraydeerroreslineales = new float[salidas];
                    for (int i = 0; i < salidas; i++)
                        arraydeerroreslineales[i] = arraydesalidasdeseadas[pt, i] - arraydesalidadelacapaactual[pt, i];
                    //COMIENZA AQUÍ LA RETROPROPAGACIÓN, DE CADA NEURONA DESDE LA ÚLTIMA CAPA OCULTA HASTA LA PRIMERA...
                    //Error no lineal por neuronas de las capas ocultas....
                    for (int capOculta = Convert.ToInt32(nudCapasocultas.Value) - 1; capOculta >= 0; capOculta--)
                    {
                        //Última capa oculta con salida...
                        if (capOculta == Convert.ToInt32(nudCapasocultas.Value) -1)
                        {
                            arraydeerrornolinealporneuronasdecapasocultas = new float[Convert.ToInt32(grilladecapasocultas.Rows[capOculta].Cells[1].Value.ToString())];
                            arraydematrizdepesos = diccionariodearraydematrizdepesos[capOculta + 1];
                            for (int neucapActual = 0; neucapActual < arraydeerrornolinealporneuronasdecapasocultas.Length; neucapActual++)
                            {
                                float sumerr = 0;
                                for (int sal = 0; sal < salidas; sal++)
                                    sumerr = sumerr + (arraydeerroreslineales[sal] * arraydematrizdepesos[sal, neucapActual]);     
                                arraydeerrornolinealporneuronasdecapasocultas[neucapActual] = sumerr;
                            }
                            diccionariodeerrornolinealdeneuronasporcapaoscultas.Add(capOculta, arraydeerrornolinealporneuronasdecapasocultas);
                        }
                        else                       
                        //Entre capas ocultas....
                        {
                            float[] Errorneuronasiguiente = diccionariodeerrornolinealdeneuronasporcapaoscultas[capOculta + 1];
                            arraydeerrornolinealporneuronasdecapasocultas = new float[Convert.ToInt32(grilladecapasocultas.Rows[capOculta].Cells[1].Value.ToString())];
                            arraydematrizdepesos = diccionariodearraydematrizdepesos[capOculta + 1];
                            for (int neucapActual = 0; neucapActual < arraydeerrornolinealporneuronasdecapasocultas.Length; neucapActual++)
                            {
                                float sumerr = 0;
                                for (int neucapaSiguiente = 0; neucapaSiguiente < Errorneuronasiguiente.Length; neucapaSiguiente++)  
                                    sumerr = sumerr + (Errorneuronasiguiente[neucapaSiguiente] * arraydematrizdepesos[neucapaSiguiente, neucapActual]);                       
                                arraydeerrornolinealporneuronasdecapasocultas[neucapActual] = sumerr;
                            }
                            diccionariodeerrornolinealdeneuronasporcapaoscultas.Add(capOculta, arraydeerrornolinealporneuronasdecapasocultas);
                        }
                    }
                    //TERMINA LA RETROPROPAGACIÓN Y SE MODIFICAR PESOS Y UMBRALES CON LOS ERRORES NO LINEALES POR
                    //CADA NEURONA DE CADA CAPA OCULTA...
                    //Modificacion de pesos y umbrales...
                    for (int capOculta = 0; capOculta <= Convert.ToInt32(nudCapasocultas.Value); capOculta++)
                    {
                        //Desde la capa entrada hasta la última capa oculta....
                        arraydematrizdepesos = diccionariodearraydematrizdepesos[capOculta];
                        arraydeumbrales = diccionariodearraydeumbrales[capOculta];
                        if (capOculta < Convert.ToInt32(nudCapasocultas.Value))
                            arraydeerroresdeneuronasendiccionario = diccionariodeerrornolinealdeneuronasporcapaoscultas[capOculta];
                        arraydesalidadelacapaactual = diccionariodelassalidasdecapa[capOculta];
                        for (int sal = 0; sal < arraydematrizdepesos.GetLength(0); sal++)
                        {            
                            if (capOculta < Convert.ToInt32(nudCapasocultas.Value))
                                arraydeumbrales[sal] += 2 * ratadeaprendizaje * new Funcionderivada(grilladecapasocultas.Rows[capOculta].Cells[2].Value.ToString(), arraydesalidadelacapaactual[pt, sal]).getfunDerivada() * arraydeerroresdeneuronasendiccionario[sal];     
                            else
                                arraydeumbrales[sal] += 2 * ratadeaprendizaje * arraydeerroreslineales[sal];
                            for (int ent = 0; ent < arraydematrizdepesos.GetLength(1); ent++)
                            {
                                if (capOculta == 0)
                                {
                                    arraydematrizdepesos[sal, ent] += 2 * ratadeaprendizaje * new Funcionderivada(grilladecapasocultas.Rows[capOculta].Cells[2].Value.ToString(), arraydesalidadelacapaactual[pt, sal]).getfunDerivada() * arraydeerroresdeneuronasendiccionario[sal] * arraydeentradasdelared[pt, ent];
                                }
                                if (capOculta > 0 && capOculta < Convert.ToInt32(nudCapasocultas.Value))
                                {
                                    arraydesalidasdecapasocultasanterior = diccionariodelassalidasdecapa[capOculta - 1];
                                    arraydematrizdepesos[sal, ent] += 2 * ratadeaprendizaje * new Funcionderivada(grilladecapasocultas.Rows[capOculta].Cells[2].Value.ToString(), arraydesalidadelacapaactual[pt, sal]).getfunDerivada() * arraydeerroresdeneuronasendiccionario[sal] * arraydesalidasdecapasocultasanterior[pt, ent];
                                }
                                if (capOculta == Convert.ToInt32(nudCapasocultas.Value))
                                {
                                    arraydesalidasdecapasocultasanterior = diccionariodelassalidasdecapa[capOculta -1];
                                    arraydematrizdepesos[sal, ent] += 2 * ratadeaprendizaje * arraydeerroreslineales[sal] * arraydesalidasdecapasocultasanterior[pt, ent];
                                }
                            }
                        }
                        diccionariodearraydematrizdepesos[capOculta] = arraydematrizdepesos;
                        diccionariodearraydeumbrales[capOculta] = arraydeumbrales;
                    }                    
                    //Encontrando el error del patron...
                    float totalerrorlineal = 0;
                    for (int i = 0; i < salidas; i++)
                    {
                        totalerrorlineal = totalerrorlineal + Math.Abs(arraydeerroreslineales[i]);
                    }
                    arraydeerrordelospatrones[pt] = totalerrorlineal / salidas;
                }
                //Calculo del error por iteracion...
                errordeiteracion = 0;
                for (int i = 0; i < patrones; i++)
                {
                    errordeiteracion += arraydeerrordelospatrones[i];
                }
                errordeiteracion = errordeiteracion / patrones;
                listadeiteraciones.Add(conti);
                //Graficas generales...
               
                Graficarerror();
                int times = 3;
                while (times > 0)
                {
                    Application.DoEvents();
                    Thread.Sleep(1);
                    times--;
                }
                label4.Text = "Iteracion: "+conti.ToString();
                label8.Text = "Error RMS: " + errordeiteracion.ToString();
                conti++;
                posiciongrafica++;
            }
            if (errordeiteracion <= errormaximopermitido)
            {
                MessageBox.Show("La red entrenó correctamente y obtuvo su pesos y umbrales optimos en la iteración número " + (listadeiteraciones.Count) + ".", "Red entranada exitosamente.");
                guardarpesosyumbrales(diccionariodearraydematrizdepesos, diccionariodearraydeumbrales);
                btnSimular.Enabled = true;
                btnSimular.BackColor = Color.LimeGreen;
            }
            else
            {
                MessageBox.Show("La red no termina aún su proceso de aprendizaje. ¡Sigue iterando!", "Red aún sin aprender.");
                nudErrormaximopermitido.Enabled = false;
            }
        }
        private void Graficarerror()
        {
            if (posiciongrafica >= 5)
                graficaErroriteracion.ChartAreas["ChartArea1"].AxisX.Maximum = (graficaErroriteracion.ChartAreas["ChartArea1"].AxisX.Maximum + 1);
            listadeerroresdeiteracion.Add(errordeiteracion);
            graficaErroriteracion.Series[0].Points.DataBindXY(listadeiteraciones, listadeerroresdeiteracion);
            graficaErroriteracion.Update();
        }
        private void guardarpesosyumbrales(Dictionary<int, float[,]> Diccionariodepesos, Dictionary<int, float[]>Diccionariodeumbrales)
        {
            try
            {
                if (Directory.Exists("Carpeta de pesos"))
                {
                    if (Directory.GetFiles("Carpeta de pesos").Length > 0)
                    {
                        int numtxt = Directory.GetFiles("Carpeta de pesos").Length;
                        for (int i = 0; i < numtxt; i++)
                        {
                            File.Delete("Carpeta de pesos/Pesos" + (i + 1) + ".txt");
                            File.Delete("Carpeta de umbrales/Umbrales" + (i + 1) + ".txt");
                        }
                        Directory.Delete("Carpeta de pesos");
                        Directory.Delete("Carpeta de umbrales");
                    }
                    else
                    {
                        Directory.Delete("Carpeta de pesos");
                        Directory.Delete("Carpeta de umbrales");
                    }
                }
                string rutaFolderpesos = System.IO.Path.Combine("", "Carpeta de pesos");
                string rutaFolderumbrales = System.IO.Path.Combine("", "Carpeta de umbrales");
                System.IO.Directory.CreateDirectory(rutaFolderpesos);
                System.IO.Directory.CreateDirectory(rutaFolderumbrales);
                for (int i = 0; i < Diccionariodepesos.Count; i++)
                {
                    float[,] pesos = Diccionariodepesos[i];
                    float[] umbrales = Diccionariodeumbrales[i];
                    StreamWriter swp = new StreamWriter("Carpeta de pesos/Pesos"+(i + 1)+".txt", true);
                    StreamWriter swu = new StreamWriter("Carpeta de umbrales/Umbrales"+(i + 1)+".txt", true);
                    for (int ii = 0; ii < pesos.GetLength(0) ; ii++)
                    {
                        swu.WriteLine(umbrales[ii]);
                        for (int j = 0; j < pesos.GetLength(1); j++)
                        {
                            if ((j + 1 < pesos.GetLength(1)))
                                swp.Write(pesos[ii, j] + " ");
                            else
                                swp.WriteLine(pesos[ii, j]);
                        }
                    }
                    swp.Close();
                    swu.Close();
                }
            }
            catch (Exception) { MessageBox.Show(""); }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            graficaErroriteracion.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            graficaErroriteracion.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            graficaErroriteracion.ChartAreas["ChartArea1"].AxisX.Maximum = 5;
            graficaErroriteracion.ChartAreas[0].AxisY.Title = "Error.";
            graficaErroriteracion.ChartAreas[0].AxisX.Title = "Iteraciones.";
            comboBox1.SelectedIndex = 0;
            comboBox1.Enabled = false;
        }
       
        private void btnSimular_Click(object sender, EventArgs e)
        {
            new Form2(entradas, patrones, diccionariodearraydematrizdepesos, diccionariodearraydeumbrales,
                      Convert.ToInt32(nudCapasocultas.Value), grilladecapasocultas, comboBox1.SelectedItem.ToString(),
                      arraydenumerosmayoresporcolumnasdeentradas, arraydenumerosmenoresporcolumnasdeentradas).ShowDialog();
        }
        private void nudCapasocultas_ValueChanged(object sender, EventArgs e)
        {
            nudCapasocultasactivado();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
