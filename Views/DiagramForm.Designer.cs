namespace Views
{
	partial class DiagramForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
			chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			axisYParameterBox = new ComboBox();
			numberWorkShiftBox = new CheckedListBox();
			buildDiagramButton = new Button();
			panel1 = new Panel();
			axisXWorkShift = new RadioButton();
			axisXDate = new RadioButton();
			label1 = new Label();
			label2 = new Label();
			startPeriodDatePicker = new ComboBox();
			endPeriodDatePicker = new ComboBox();
			label4 = new Label();
			instrumentNumberBox = new ComboBox();
			((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// chart1
			// 
			chart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			chartArea1.AxisX.Interval = 1D;
			chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
			chartArea1.AxisX.LineWidth = 2;
			chartArea1.AxisY.LineWidth = 2;
			chartArea1.CursorX.IsUserEnabled = true;
			chartArea1.Name = "ChartArea1";
			chart1.ChartAreas.Add(chartArea1);
			legend1.Enabled = false;
			legend1.Name = "legend";
			chart1.Legends.Add(legend1);
			chart1.Location = new Point(316, 32);
			chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series1.Color = Color.Black;
			series1.Enabled = false;
			series1.IsValueShownAsLabel = true;
			series1.Legend = "legend";
			series1.LegendText = "День";
			series1.MarkerBorderColor = Color.Fuchsia;
			series1.MarkerColor = Color.FromArgb(0, 0, 192);
			series1.Name = "daySeries";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series2.Color = Color.Red;
			series2.Enabled = false;
			series2.IsValueShownAsLabel = true;
			series2.Legend = "legend";
			series2.Name = "Первая";
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series3.Color = Color.Green;
			series3.Enabled = false;
			series3.IsValueShownAsLabel = true;
			series3.Legend = "legend";
			series3.Name = "Вторая";
			series4.ChartArea = "ChartArea1";
			series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series4.Color = Color.Purple;
			series4.Enabled = false;
			series4.IsValueShownAsLabel = true;
			series4.Legend = "legend";
			series4.Name = "Третья";
			series5.ChartArea = "ChartArea1";
			series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series5.Color = Color.Brown;
			series5.Enabled = false;
			series5.IsValueShownAsLabel = true;
			series5.Legend = "legend";
			series5.Name = "Четвертая";
			chart1.Series.Add(series1);
			chart1.Series.Add(series2);
			chart1.Series.Add(series3);
			chart1.Series.Add(series4);
			chart1.Series.Add(series5);
			chart1.Size = new Size(670, 420);
			chart1.TabIndex = 0;
			chart1.Text = "chart1";
			// 
			// axisYParameterBox
			// 
			axisYParameterBox.FormattingEnabled = true;
			axisYParameterBox.Items.AddRange(new object[] { "Количество проб", "Количество \"заточек\"", "Количество ошибок", "Время Test mode", "Среднее количество \"заточек\"", "Среднее время анализа", "Средний процент плохой пов. пробы", "Среднее количество прожигов на стороне", "Процент брака" });
			axisYParameterBox.Location = new Point(100, 103);
			axisYParameterBox.Name = "axisYParameterBox";
			axisYParameterBox.Size = new Size(199, 23);
			axisYParameterBox.TabIndex = 3;
			// 
			// numberWorkShiftBox
			// 
			numberWorkShiftBox.CheckOnClick = true;
			numberWorkShiftBox.Enabled = false;
			numberWorkShiftBox.FormattingEnabled = true;
			numberWorkShiftBox.Items.AddRange(new object[] { "Первая", "Вторая", "Третья", "Четвертая" });
			numberWorkShiftBox.Location = new Point(179, 202);
			numberWorkShiftBox.Name = "numberWorkShiftBox";
			numberWorkShiftBox.Size = new Size(120, 76);
			numberWorkShiftBox.TabIndex = 5;
			// 
			// buildDiagramButton
			// 
			buildDiagramButton.Location = new Point(97, 297);
			buildDiagramButton.Name = "buildDiagramButton";
			buildDiagramButton.Size = new Size(139, 34);
			buildDiagramButton.TabIndex = 6;
			buildDiagramButton.Text = "Построить график";
			buildDiagramButton.UseVisualStyleBackColor = true;
			buildDiagramButton.Click += buildDiagramButton_Click;
			// 
			// panel1
			// 
			panel1.Controls.Add(axisXWorkShift);
			panel1.Controls.Add(axisXDate);
			panel1.Location = new Point(21, 145);
			panel1.Name = "panel1";
			panel1.Size = new Size(278, 41);
			panel1.TabIndex = 7;
			// 
			// axisXWorkShift
			// 
			axisXWorkShift.AutoSize = true;
			axisXWorkShift.Location = new Point(187, 12);
			axisXWorkShift.Name = "axisXWorkShift";
			axisXWorkShift.Size = new Size(61, 19);
			axisXWorkShift.TabIndex = 1;
			axisXWorkShift.Text = "Смена";
			axisXWorkShift.UseVisualStyleBackColor = true;
			axisXWorkShift.CheckedChanged += axicXWorkShift_CheckedChanged;
			// 
			// axisXDate
			// 
			axisXDate.AutoSize = true;
			axisXDate.Checked = true;
			axisXDate.Location = new Point(16, 12);
			axisXDate.Name = "axisXDate";
			axisXDate.Size = new Size(52, 19);
			axisXDate.TabIndex = 0;
			axisXDate.TabStop = true;
			axisXDate.Text = "День";
			axisXDate.UseVisualStyleBackColor = true;
			axisXDate.CheckedChanged += axisXDate_CheckedChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(24, 107);
			label1.Name = "label1";
			label1.Size = new Size(70, 15);
			label1.TabIndex = 8;
			label1.Text = "Показатель";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(21, 56);
			label2.Name = "label2";
			label2.Size = new Size(125, 15);
			label2.TabIndex = 9;
			label2.Text = "Статистика за период";
			// 
			// startPeriodDatePicker
			// 
			startPeriodDatePicker.Enabled = false;
			startPeriodDatePicker.FormattingEnabled = true;
			startPeriodDatePicker.Location = new Point(21, 74);
			startPeriodDatePicker.Name = "startPeriodDatePicker";
			startPeriodDatePicker.Size = new Size(121, 23);
			startPeriodDatePicker.TabIndex = 10;
			startPeriodDatePicker.SelectedIndexChanged += startPeriodDatePicker_SelectedIndexChanged;
			// 
			// endPeriodDatePicker
			// 
			endPeriodDatePicker.Enabled = false;
			endPeriodDatePicker.FormattingEnabled = true;
			endPeriodDatePicker.Location = new Point(178, 74);
			endPeriodDatePicker.Name = "endPeriodDatePicker";
			endPeriodDatePicker.Size = new Size(121, 23);
			endPeriodDatePicker.TabIndex = 11;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(20, 16);
			label4.Name = "label4";
			label4.Size = new Size(96, 15);
			label4.TabIndex = 14;
			label4.Text = "Номер прибора";
			// 
			// instrumentNumberBox
			// 
			instrumentNumberBox.FormattingEnabled = true;
			instrumentNumberBox.Items.AddRange(new object[] { "4460-967", "4460-1165", "4460-953", "4460-1257" });
			instrumentNumberBox.Location = new Point(134, 13);
			instrumentNumberBox.Name = "instrumentNumberBox";
			instrumentNumberBox.Size = new Size(121, 23);
			instrumentNumberBox.TabIndex = 15;
			instrumentNumberBox.SelectedIndexChanged += instrumentNumberBox_SelectedIndexChanged;
			// 
			// DiagramForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1002, 472);
			Controls.Add(instrumentNumberBox);
			Controls.Add(label4);
			Controls.Add(endPeriodDatePicker);
			Controls.Add(startPeriodDatePicker);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(panel1);
			Controls.Add(buildDiagramButton);
			Controls.Add(numberWorkShiftBox);
			Controls.Add(axisYParameterBox);
			Controls.Add(chart1);
			Name = "DiagramForm";
			Text = "DiagramForm";
			((System.ComponentModel.ISupportInitialize)chart1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private ComboBox axisYParameterBox;
		private GroupBox groupBox1;
		private RadioButton radioButton2;
		private RadioButton radioButton1;
		private CheckedListBox numberWorkShiftBox;
		private Button buildDiagramButton;
		private Panel panel1;
		private RadioButton axisXWorkShift;
		private RadioButton axisXDate;
		private Label label1;
		private Label label2;
		private ComboBox startPeriodDatePicker;
		private ComboBox endPeriodDatePicker;
		private MonthCalendar monthCalendar1;
		private Label label3;
		private Label label4;
		private ComboBox instrumentNumberBox;
	}
}