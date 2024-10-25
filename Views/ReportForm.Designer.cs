	partial class ReportForm
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
		label1 = new Label();
		label2 = new Label();
		instrumentNumberBox = new ComboBox();
		startPeriodBox = new ComboBox();
		label4 = new Label();
		endPeriodBox = new ComboBox();
		label3 = new Label();
		areaNameBox = new TextBox();
		periodStatisticButton = new RadioButton();
		dayStatisticButton = new RadioButton();
		groupBox1 = new GroupBox();
		groupBox2 = new GroupBox();
		forWorkShiftButton = new RadioButton();
		forAllDayButton = new RadioButton();
		workShiftNumberBox = new CheckedListBox();
		showResultButton = new Button();
		saveButton = new Button();
		saveFileDialog1 = new SaveFileDialog();
		reportGrid = new DataGridView();
		label5 = new Label();
		groupBox1.SuspendLayout();
		groupBox2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)reportGrid).BeginInit();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Font = new Font("Segoe UI", 14F);
		label1.Location = new Point(517, 9);
		label1.Name = "label1";
		label1.Size = new Size(63, 25);
		label1.TabIndex = 0;
		label1.Text = "Отчет";
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new Point(312, 44);
		label2.Name = "label2";
		label2.Size = new Size(184, 15);
		label2.TabIndex = 1;
		label2.Text = "По контейнерной лаборатории:";
		// 
		// instrumentNumberBox
		// 
		instrumentNumberBox.FormattingEnabled = true;
		instrumentNumberBox.Items.AddRange(new object[] { "4460-967", "4460-1165", "4460-953", "4460-1257" });
		instrumentNumberBox.Location = new Point(517, 41);
		instrumentNumberBox.Name = "instrumentNumberBox";
		instrumentNumberBox.Size = new Size(121, 23);
		instrumentNumberBox.TabIndex = 2;
		instrumentNumberBox.SelectedIndexChanged += instrumentNumberBox_SelectedIndexChanged;
		// 
		// startPeriodBox
		// 
		startPeriodBox.FormattingEnabled = true;
		startPeriodBox.Location = new Point(517, 85);
		startPeriodBox.Name = "startPeriodBox";
		startPeriodBox.Size = new Size(121, 23);
		startPeriodBox.TabIndex = 4;
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Location = new Point(653, 89);
		label4.Name = "label4";
		label4.Size = new Size(24, 15);
		label4.TabIndex = 5;
		label4.Text = "по:";
		// 
		// endPeriodBox
		// 
		endPeriodBox.FormattingEnabled = true;
		endPeriodBox.Location = new Point(716, 86);
		endPeriodBox.Name = "endPeriodBox";
		endPeriodBox.Size = new Size(121, 23);
		endPeriodBox.TabIndex = 6;
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new Point(662, 44);
		label3.Name = "label3";
		label3.Size = new Size(49, 15);
		label3.TabIndex = 9;
		label3.Text = "участка";
		// 
		// areaNameBox
		// 
		areaNameBox.Location = new Point(737, 41);
		areaNameBox.Name = "areaNameBox";
		areaNameBox.Size = new Size(100, 23);
		areaNameBox.TabIndex = 10;
		// 
		// periodStatisticButton
		// 
		periodStatisticButton.AutoSize = true;
		periodStatisticButton.Checked = true;
		periodStatisticButton.Location = new Point(10, 14);
		periodStatisticButton.Name = "periodStatisticButton";
		periodStatisticButton.Size = new Size(79, 19);
		periodStatisticButton.TabIndex = 11;
		periodStatisticButton.TabStop = true;
		periodStatisticButton.Text = "за период";
		periodStatisticButton.UseVisualStyleBackColor = true;
		periodStatisticButton.CheckedChanged += periodStatisticButton_CheckedChanged;
		// 
		// dayStatisticButton
		// 
		dayStatisticButton.AutoSize = true;
		dayStatisticButton.Location = new Point(112, 14);
		dayStatisticButton.Name = "dayStatisticButton";
		dayStatisticButton.Size = new Size(64, 19);
		dayStatisticButton.TabIndex = 12;
		dayStatisticButton.Text = "за день";
		dayStatisticButton.UseVisualStyleBackColor = true;
		dayStatisticButton.CheckedChanged += dayStatisticButton_CheckedChanged;
		// 
		// groupBox1
		// 
		groupBox1.Controls.Add(dayStatisticButton);
		groupBox1.Controls.Add(periodStatisticButton);
		groupBox1.Location = new Point(271, 71);
		groupBox1.Name = "groupBox1";
		groupBox1.Size = new Size(186, 46);
		groupBox1.TabIndex = 13;
		groupBox1.TabStop = false;
		// 
		// groupBox2
		// 
		groupBox2.Controls.Add(forWorkShiftButton);
		groupBox2.Controls.Add(forAllDayButton);
		groupBox2.Location = new Point(271, 132);
		groupBox2.Name = "groupBox2";
		groupBox2.Size = new Size(186, 46);
		groupBox2.TabIndex = 14;
		groupBox2.TabStop = false;
		// 
		// forWorkShiftButton
		// 
		forWorkShiftButton.AutoSize = true;
		forWorkShiftButton.Location = new Point(104, 14);
		forWorkShiftButton.Name = "forWorkShiftButton";
		forWorkShiftButton.Size = new Size(76, 19);
		forWorkShiftButton.TabIndex = 1;
		forWorkShiftButton.Text = "по смене";
		forWorkShiftButton.UseVisualStyleBackColor = true;
		forWorkShiftButton.CheckedChanged += forWorkShiftButton_CheckedChanged;
		// 
		// forAllDayButton
		// 
		forAllDayButton.AutoSize = true;
		forAllDayButton.Checked = true;
		forAllDayButton.Location = new Point(10, 14);
		forAllDayButton.Name = "forAllDayButton";
		forAllDayButton.Size = new Size(69, 19);
		forAllDayButton.TabIndex = 0;
		forAllDayButton.TabStop = true;
		forAllDayButton.Text = "за сутки";
		forAllDayButton.UseVisualStyleBackColor = true;
		forAllDayButton.CheckedChanged += forAllDayButton_CheckedChanged;
		// 
		// workShiftNumberBox
		// 
		workShiftNumberBox.CheckOnClick = true;
		workShiftNumberBox.Enabled = false;
		workShiftNumberBox.FormattingEnabled = true;
		workShiftNumberBox.Items.AddRange(new object[] { "Первая", "Вторая", "Третья", "Четвертая" });
		workShiftNumberBox.Location = new Point(498, 140);
		workShiftNumberBox.Name = "workShiftNumberBox";
		workShiftNumberBox.Size = new Size(120, 76);
		workShiftNumberBox.TabIndex = 15;
		// 
		// showResultButton
		// 
		showResultButton.Location = new Point(715, 146);
		showResultButton.Name = "showResultButton";
		showResultButton.Size = new Size(89, 33);
		showResultButton.TabIndex = 17;
		showResultButton.Text = "Расчитать";
		showResultButton.UseVisualStyleBackColor = true;
		showResultButton.Click += showResultButton_Click;
		// 
		// saveButton
		// 
		saveButton.Location = new Point(537, 396);
		saveButton.Name = "saveButton";
		saveButton.Size = new Size(75, 23);
		saveButton.TabIndex = 18;
		saveButton.Text = "Сохранить";
		saveButton.UseVisualStyleBackColor = true;
		// 
		// reportGrid
		// 
		reportGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		reportGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		reportGrid.Location = new Point(12, 234);
		reportGrid.Name = "reportGrid";
		reportGrid.Size = new Size(1144, 154);
		reportGrid.TabIndex = 19;
		// 
		// label5
		// 
		label5.AutoSize = true;
		label5.Location = new Point(480, 89);
		label5.Name = "label5";
		label5.Size = new Size(16, 15);
		label5.TabIndex = 20;
		label5.Text = "с:";
		// 
		// ReportForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(1184, 431);
		Controls.Add(label5);
		Controls.Add(reportGrid);
		Controls.Add(saveButton);
		Controls.Add(showResultButton);
		Controls.Add(workShiftNumberBox);
		Controls.Add(groupBox2);
		Controls.Add(groupBox1);
		Controls.Add(areaNameBox);
		Controls.Add(label3);
		Controls.Add(endPeriodBox);
		Controls.Add(label4);
		Controls.Add(startPeriodBox);
		Controls.Add(instrumentNumberBox);
		Controls.Add(label2);
		Controls.Add(label1);
		MaximumSize = new Size(1200, 470);
		Name = "ReportForm";
		Text = "ReportForm";
		groupBox1.ResumeLayout(false);
		groupBox1.PerformLayout();
		groupBox2.ResumeLayout(false);
		groupBox2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)reportGrid).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private Label label1;
		private Label label2;
		private ComboBox instrumentNumberBox;
		private ComboBox startPeriodBox;
		private Label label4;
		private ComboBox endPeriodBox;
		private Label label3;
		private TextBox areaNameBox;
		private RadioButton periodStatisticButton;
		private RadioButton dayStatisticButton;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private RadioButton forWorkShiftButton;
		private RadioButton forAllDayButton;
		private CheckedListBox workShiftNumberBox;
		private Button showResultButton;
		private Button saveButton;
		private SaveFileDialog saveFileDialog1;
	private DataGridView reportGrid;
	private Label label5;
}