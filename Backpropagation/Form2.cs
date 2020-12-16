using Backpropagation;
using NAudio.Wave;
using NUnit.Framework;
using Perceptronmulticapas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Perceptronsimple
{
    public partial class Form2 : Form
    {
        int patrones;
        int entradas;
        int capasocultas;
        Dictionary<int, float[,]> diccionariodearraydematrizdepesos;
        Dictionary<int, float[]> diccionariodearraydeumbrales;
        DataGridView grilladecapasocultas;
        string comboBox1;
        float[,] arraydeentradas;
        float[] arraydenumerosmayoresporcolumnasdeentradas;
        float[] arraydenumerosmenoresporcolumnasdeentradas;
        public Form2(int entradas, int patrones, Dictionary<int, float[,]> diccionariodearraydematrizdepesos,
                     Dictionary<int, float[]> diccionariodearraydeumbrales, int capasocultas, DataGridView grilladecapasocultas,
                     string combobox1, float[] arraydenumerosmayoresporcolumnasdeentradas, float[] arraydenumerosmenoresporcolumnasdeentradas)
        {
            InitializeComponent();
            this.entradas = entradas;
            this.patrones = patrones;
            this.capasocultas = capasocultas;
            this.diccionariodearraydematrizdepesos = diccionariodearraydematrizdepesos;
            this.diccionariodearraydeumbrales = diccionariodearraydeumbrales;
            this.grilladecapasocultas = grilladecapasocultas;
            this.comboBox1 = combobox1;
            this.arraydenumerosmayoresporcolumnasdeentradas = arraydenumerosmayoresporcolumnasdeentradas;
            this.arraydenumerosmenoresporcolumnasdeentradas = arraydenumerosmenoresporcolumnasdeentradas;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Title = "SELECCIONE SOPLO PARA OBTENER EL DIAGNOSTICO.";
            dlg.CheckFileExists = true;
            dlg.Filter = "WAV files (*.wav)|*.wav";
            dlg.DefaultExt = ".wav";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                label4.Text = "";
                label3.Text = dlg.FileName;
                arraydeentradas = new float[1, entradas];
                WaveFileReader reader = new WaveFileReader(dlg.FileName);
                Assert.AreEqual(16, reader.WaveFormat.BitsPerSample, "Only works with 16 bit audio");
                byte[] buffer = new byte[reader.Length];
                int read = reader.Read(buffer, 0, buffer.Length);
                short[] sampleBuffer = new short[read / 2];
                Buffer.BlockCopy(buffer, 0, sampleBuffer, 0, read);
                for (int i = 0; i < 100; i++)
                    arraydeentradas[0, i] = float.Parse(sampleBuffer[i].ToString());
                NormalizarEntradasDeLaRed();
                button2.Enabled = true;
            }
        }
        private void NormalizarEntradasDeLaRed()
        {
            for (int j = 0; j < arraydeentradas.GetLength(1); j++)
            {
                 arraydeentradas[0, j] = ((arraydeentradas[0, j] - arraydenumerosmenoresporcolumnasdeentradas[j]) * (1 - 0) / (arraydenumerosmayoresporcolumnasdeentradas[j] - arraydenumerosmenoresporcolumnasdeentradas[j])) + 0;
                 arraydeentradas[0, j] = float.Parse(Math.Round(arraydeentradas[0, j]).ToString());
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Simular(arraydeentradas);    
        }
        private void Simular(float[,] arraydeentradas)
        {
            string binariodesalida = "";
            Dictionary<int, float[,]> diccionariodelassalidasdecapa = new Dictionary<int, float[,]>();
            int pt = 0;
            float[,] arraydematrizdepesos;
            float[] arraydeumbrales;
            float[,] arraydesalidadelacapaanterior = null;
            float[,] arraydesalidadelacapaactual = null;
            for (int cp = 0; cp <= capasocultas; cp++)
            {
                arraydematrizdepesos = diccionariodearraydematrizdepesos[cp];
                arraydeumbrales = diccionariodearraydeumbrales[cp];
                arraydesalidadelacapaactual = new float[patrones, arraydematrizdepesos.GetLength(0)];
                if (cp > 0)
                    arraydesalidadelacapaanterior = diccionariodelassalidasdecapa[cp - 1];
                for (int i = 0; i < arraydematrizdepesos.GetLength(0); i++)
                {
                    arraydesalidadelacapaactual[pt, i] = 0;
                    if (cp == 0)
                    {
                        for (int j = 0; j < entradas; j++)
                            arraydesalidadelacapaactual[pt, i] += arraydeentradas[pt, j] * arraydematrizdepesos[i, j];
                    }
                    else if (cp > 0 && cp < capasocultas)
                    {
                        for (int j = 0; j < arraydematrizdepesos.GetLength(1); j++)
                            arraydesalidadelacapaactual[pt, i] += arraydesalidadelacapaanterior[pt, j] * arraydematrizdepesos[i, j];
                    }
                    else if (cp == capasocultas)
                    {
                        for (int j = 0; j < arraydematrizdepesos.GetLength(1); j++)
                            arraydesalidadelacapaactual[pt, i] += arraydesalidadelacapaanterior[pt, j] * arraydematrizdepesos[i, j];
                    }
                    arraydesalidadelacapaactual[pt, i] -= arraydeumbrales[i];
                    if (cp != capasocultas)
                    {
                        arraydesalidadelacapaactual[pt, i] = new Funciondeactivacion(grilladecapasocultas.Rows[cp].Cells[2].Value.ToString(), arraydesalidadelacapaactual[pt, i]).getfunActivacion();
                    }
                    else
                    {
                        arraydesalidadelacapaactual[pt, i] = new Funciondeactivacion(comboBox1, arraydesalidadelacapaactual[pt, i]).getfunActivacion();
                        binariodesalida += Math.Round(double.Parse(arraydesalidadelacapaactual[pt, i].ToString())).ToString();
                    }
                }
                diccionariodelassalidasdecapa.Add(cp, arraydesalidadelacapaactual);
            }
            string resultadodediagnostico = new Binarioacaracteres(binariodesalida).ConvertirDeBinarioACadenaDeCaracteres().ToUpper();
            Packages pack = new Packages();
            
            if (pack.verify(resultadodediagnostico)==true)
            {
                MessageBox.Show("El diagnostico obtenido mediante la tecnología es que usted padece de: " + resultadodediagnostico, "Diagnostico inteligente.");
                label4.Text = resultadodediagnostico;
            }
            else
            {
                MessageBox.Show("No coincide con ninguno de los patrones presentados para el entrenamiento");
                label4.Text = binariodesalida;
            }
           
        }
    }
}
