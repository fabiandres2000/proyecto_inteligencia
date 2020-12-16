namespace pruebaRed
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.graficaErroriteracion = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnCargarmatriz = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grilladedatos = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPatrones = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSalidas = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEntradas = new System.Windows.Forms.Label();
            this.btnSimular = new System.Windows.Forms.Button();
            this.btnInicializarred = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nudIteraciones = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.nudErrormaximopermitido = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.nudRataaprendizaje = new System.Windows.Forms.NumericUpDown();
            this.btnEntrenarlared = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grilladecapasocultas = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.nudCapasocultas = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.graficaErroriteracion)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilladedatos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIteraciones)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudErrormaximopermitido)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRataaprendizaje)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilladecapasocultas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapasocultas)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // graficaErroriteracion
            // 
            this.graficaErroriteracion.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.Name = "ChartArea1";
            this.graficaErroriteracion.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.graficaErroriteracion.Legends.Add(legend1);
            this.graficaErroriteracion.Location = new System.Drawing.Point(1054, 343);
            this.graficaErroriteracion.Name = "graficaErroriteracion";
            this.graficaErroriteracion.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.Name = "Error por Iteracion";
            this.graficaErroriteracion.Series.Add(series1);
            this.graficaErroriteracion.Size = new System.Drawing.Size(268, 276);
            this.graficaErroriteracion.TabIndex = 10;
            this.graficaErroriteracion.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            title1.Name = "Title1";
            title1.Text = "Grafico RMS vs Iteracion";
            this.graficaErroriteracion.Titles.Add(title1);
            // 
            // btnCargarmatriz
            // 
            this.btnCargarmatriz.BackgroundImage = global::Backpropagation.Properties.Resources.subir1;
            this.btnCargarmatriz.Location = new System.Drawing.Point(44, 16);
            this.btnCargarmatriz.Name = "btnCargarmatriz";
            this.btnCargarmatriz.Size = new System.Drawing.Size(178, 38);
            this.btnCargarmatriz.TabIndex = 25;
            this.btnCargarmatriz.UseVisualStyleBackColor = true;
            this.btnCargarmatriz.Click += new System.EventHandler(this.btnCargarmatriz_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.groupBox1.Controls.Add(this.grilladedatos);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnCargarmatriz);
            this.groupBox1.Controls.Add(this.btnSimular);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(255, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1073, 238);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // grilladedatos
            // 
            this.grilladedatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilladedatos.Location = new System.Drawing.Point(263, 14);
            this.grilladedatos.Name = "grilladedatos";
            this.grilladedatos.Size = new System.Drawing.Size(793, 218);
            this.grilladedatos.TabIndex = 38;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblPatrones);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblSalidas);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblEntradas);
            this.groupBox2.Location = new System.Drawing.Point(11, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 120);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informacion del DataSet";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "Salidas:";
            // 
            // lblPatrones
            // 
            this.lblPatrones.AutoSize = true;
            this.lblPatrones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatrones.Location = new System.Drawing.Point(85, 98);
            this.lblPatrones.Name = "lblPatrones";
            this.lblPatrones.Size = new System.Drawing.Size(0, 16);
            this.lblPatrones.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Entradas:";
            // 
            // lblSalidas
            // 
            this.lblSalidas.AutoSize = true;
            this.lblSalidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalidas.Location = new System.Drawing.Point(85, 73);
            this.lblSalidas.Name = "lblSalidas";
            this.lblSalidas.Size = new System.Drawing.Size(0, 16);
            this.lblSalidas.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "Patrones:";
            // 
            // lblEntradas
            // 
            this.lblEntradas.AutoSize = true;
            this.lblEntradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntradas.Location = new System.Drawing.Point(85, 47);
            this.lblEntradas.Name = "lblEntradas";
            this.lblEntradas.Size = new System.Drawing.Size(0, 16);
            this.lblEntradas.TabIndex = 29;
            // 
            // btnSimular
            // 
            this.btnSimular.BackgroundImage = global::Backpropagation.Properties.Resources.simular;
            this.btnSimular.Enabled = false;
            this.btnSimular.Location = new System.Drawing.Point(44, 187);
            this.btnSimular.Name = "btnSimular";
            this.btnSimular.Size = new System.Drawing.Size(178, 43);
            this.btnSimular.TabIndex = 31;
            this.btnSimular.UseVisualStyleBackColor = true;
            this.btnSimular.Click += new System.EventHandler(this.btnSimular_Click);
            // 
            // btnInicializarred
            // 
            this.btnInicializarred.BackgroundImage = global::Backpropagation.Properties.Resources.inicializar;
            this.btnInicializarred.Enabled = false;
            this.btnInicializarred.Location = new System.Drawing.Point(592, 292);
            this.btnInicializarred.Name = "btnInicializarred";
            this.btnInicializarred.Size = new System.Drawing.Size(221, 40);
            this.btnInicializarred.TabIndex = 27;
            this.btnInicializarred.UseVisualStyleBackColor = true;
            this.btnInicializarred.Click += new System.EventHandler(this.btnInicializarred_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Heavy", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(384, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(834, 47);
            this.label3.TabIndex = 37;
            this.label3.Text = "APLICANDO LA (RNA) BACKPROPAGATION";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Backpropagation.Properties.Resources.creditos;
            this.button1.Location = new System.Drawing.Point(46, 524);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 122);
            this.button1.TabIndex = 38;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(11, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "label4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(11, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 20);
            this.label8.TabIndex = 40;
            this.label8.Text = "label8";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nudIteraciones);
            this.groupBox4.Location = new System.Drawing.Point(28, 47);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(240, 57);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Numero de iteraciones";
            // 
            // nudIteraciones
            // 
            this.nudIteraciones.Enabled = false;
            this.nudIteraciones.Location = new System.Drawing.Point(21, 22);
            this.nudIteraciones.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudIteraciones.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIteraciones.Name = "nudIteraciones";
            this.nudIteraciones.Size = new System.Drawing.Size(98, 26);
            this.nudIteraciones.TabIndex = 0;
            this.nudIteraciones.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nudErrormaximopermitido);
            this.groupBox5.Location = new System.Drawing.Point(28, 112);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(240, 60);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Error maximo permitido";
            // 
            // nudErrormaximopermitido
            // 
            this.nudErrormaximopermitido.DecimalPlaces = 3;
            this.nudErrormaximopermitido.Enabled = false;
            this.nudErrormaximopermitido.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudErrormaximopermitido.Location = new System.Drawing.Point(21, 23);
            this.nudErrormaximopermitido.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.nudErrormaximopermitido.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudErrormaximopermitido.Name = "nudErrormaximopermitido";
            this.nudErrormaximopermitido.Size = new System.Drawing.Size(98, 26);
            this.nudErrormaximopermitido.TabIndex = 0;
            this.nudErrormaximopermitido.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.nudRataaprendizaje);
            this.groupBox6.Location = new System.Drawing.Point(28, 182);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(240, 56);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Rata de aprendizaje";
            // 
            // nudRataaprendizaje
            // 
            this.nudRataaprendizaje.DecimalPlaces = 1;
            this.nudRataaprendizaje.Enabled = false;
            this.nudRataaprendizaje.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRataaprendizaje.Location = new System.Drawing.Point(22, 21);
            this.nudRataaprendizaje.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudRataaprendizaje.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRataaprendizaje.Name = "nudRataaprendizaje";
            this.nudRataaprendizaje.Size = new System.Drawing.Size(98, 26);
            this.nudRataaprendizaje.TabIndex = 6;
            this.nudRataaprendizaje.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // btnEntrenarlared
            // 
            this.btnEntrenarlared.BackgroundImage = global::Backpropagation.Properties.Resources.entrenar;
            this.btnEntrenarlared.Enabled = false;
            this.btnEntrenarlared.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrenarlared.Location = new System.Drawing.Point(82, 243);
            this.btnEntrenarlared.Name = "btnEntrenarlared";
            this.btnEntrenarlared.Size = new System.Drawing.Size(133, 98);
            this.btnEntrenarlared.TabIndex = 4;
            this.btnEntrenarlared.UseVisualStyleBackColor = true;
            this.btnEntrenarlared.Click += new System.EventHandler(this.btnEntrenarlared_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Controls.Add(this.btnEntrenarlared);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.grilladecapasocultas);
            this.groupBox3.Controls.Add(this.btnInicializarred);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.nudCapasocultas);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(227, 343);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(821, 348);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parametros de entrenamiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Función en salida:";
            // 
            // grilladecapasocultas
            // 
            this.grilladecapasocultas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grilladecapasocultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilladecapasocultas.Location = new System.Drawing.Point(313, 77);
            this.grilladecapasocultas.Name = "grilladecapasocultas";
            this.grilladecapasocultas.Size = new System.Drawing.Size(486, 201);
            this.grilladecapasocultas.TabIndex = 32;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Lineal.",
            "Coseno.",
            "Seno.",
            "Gausiana.",
            "Sigmoidal.",
            "Tangente hiperbólica."});
            this.comboBox1.Location = new System.Drawing.Point(465, 296);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 35;
            // 
            // nudCapasocultas
            // 
            this.nudCapasocultas.Enabled = false;
            this.nudCapasocultas.Location = new System.Drawing.Point(619, 36);
            this.nudCapasocultas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCapasocultas.Name = "nudCapasocultas";
            this.nudCapasocultas.Size = new System.Drawing.Size(180, 26);
            this.nudCapasocultas.TabIndex = 33;
            this.nudCapasocultas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCapasocultas.ValueChanged += new System.EventHandler(this.nudCapasocultas_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Numero de capas ocultas que desea: ";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(1054, 625);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(268, 66);
            this.groupBox7.TabIndex = 41;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Resultado Dinamico X Iteracion";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::Backpropagation.Properties.Resources.FONDO_FORM13;
            this.ClientSize = new System.Drawing.Size(1345, 703);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.graficaErroriteracion);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backpropagation";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graficaErroriteracion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grilladedatos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudIteraciones)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudErrormaximopermitido)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRataaprendizaje)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilladecapasocultas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapasocultas)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graficaErroriteracion;
        private System.Windows.Forms.Button btnCargarmatriz;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPatrones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSalidas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEntradas;
        private System.Windows.Forms.Button btnInicializarred;
        private System.Windows.Forms.Button btnSimular;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grilladedatos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown nudIteraciones;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown nudErrormaximopermitido;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown nudRataaprendizaje;
        private System.Windows.Forms.Button btnEntrenarlared;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grilladecapasocultas;
        private System.Windows.Forms.NumericUpDown nudCapasocultas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox7;
    }
}

