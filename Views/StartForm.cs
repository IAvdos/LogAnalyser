namespace Views
{
	public partial class StartForm : Form, IStartView
	{
		public StartForm(string dataFilePath)
		{
			InitializeComponent();
			_dataFilePath = dataFilePath;
		}

		public event Action<string[]> ReadLogs;

		private void openReadLogFileButton_Click(object sender, EventArgs e)
		{
			openLogFileDialog.ShowDialog();
			var files = openLogFileDialog.FileNames;

			ReadLogs.Invoke(files);
		}

		public void ShowReport(string[] status)
		{
			foreach (string s in status)
			{
				statusReportTextBox.AppendText(s + "\r\n");
			}
		}
		private void openDiagramFormButton_Click(object sender, EventArgs e)
		{
			new DiagramFormPresenter(new DiagramModel(_dataFilePath), new DiagramForm()).Run();
		}

		public new void Show()
		{
			Application.Run(this);
		}

		private void openReportFormButton_Click(object sender, EventArgs e)
		{
			new ReportFormPresenter(new ReportForm(), new ReportModel(_dataFilePath)).Run();
		}

		string _dataFilePath;
	}
}