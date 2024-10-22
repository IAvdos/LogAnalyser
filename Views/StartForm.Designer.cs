namespace Views
{
	partial class StartForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			openLogFileDialog = new OpenFileDialog();
			openReadLogFileButton = new Button();
			openDiagramFormButton = new Button();
			openReportFormButton = new Button();
			statusReportTextBox = new TextBox();
			SuspendLayout();
			// 
			// openLogFileDialog
			// 
			openLogFileDialog.FileName = "openFileDialog1";
			openLogFileDialog.Multiselect = true;
			// 
			// openReadLogFileButton
			// 
			openReadLogFileButton.Location = new Point(491, 12);
			openReadLogFileButton.Name = "openReadLogFileButton";
			openReadLogFileButton.Size = new Size(121, 43);
			openReadLogFileButton.TabIndex = 1;
			openReadLogFileButton.Text = "Обработать Log-файлы";
			openReadLogFileButton.UseVisualStyleBackColor = true;
			openReadLogFileButton.Click += openReadLogFileButton_Click;
			// 
			// openDiagramFormButton
			// 
			openDiagramFormButton.Location = new Point(502, 77);
			openDiagramFormButton.Name = "openDiagramFormButton";
			openDiagramFormButton.Size = new Size(99, 23);
			openDiagramFormButton.TabIndex = 2;
			openDiagramFormButton.Text = "Статистика";
			openDiagramFormButton.UseVisualStyleBackColor = true;
			openDiagramFormButton.Click += openDiagramFormButton_Click;
			// 
			// openReportFormButton
			// 
			openReportFormButton.Location = new Point(516, 125);
			openReportFormButton.Name = "openReportFormButton";
			openReportFormButton.Size = new Size(75, 23);
			openReportFormButton.TabIndex = 3;
			openReportFormButton.Text = "Отчет";
			openReportFormButton.UseVisualStyleBackColor = true;
			openReportFormButton.Click += openReportFormButton_Click;
			// 
			// statusReportTextBox
			// 
			statusReportTextBox.Location = new Point(12, 12);
			statusReportTextBox.Multiline = true;
			statusReportTextBox.Name = "statusReportTextBox";
			statusReportTextBox.ScrollBars = ScrollBars.Vertical;
			statusReportTextBox.Size = new Size(463, 254);
			statusReportTextBox.TabIndex = 4;
			// 
			// StartForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(622, 280);
			Controls.Add(statusReportTextBox);
			Controls.Add(openReportFormButton);
			Controls.Add(openDiagramFormButton);
			Controls.Add(openReadLogFileButton);
			MaximizeBox = false;
			MaximumSize = new Size(638, 319);
			MinimumSize = new Size(638, 319);
			Name = "StartForm";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private OpenFileDialog openLogFileDialog;
		private Button openReadLogFileButton;
		private Button openDiagramFormButton;
		private Button openReportFormButton;
		private TextBox statusReportTextBox;
	}
}
