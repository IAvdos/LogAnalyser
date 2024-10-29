using Microsoft.IdentityModel.Tokens;

public partial class ReportForm : Form, IReportView
{
	public ReportForm()
	{
		InitializeComponent();
		PrepareReportGrid();
	}

	private void showResultButton_Click(object sender, EventArgs e)
	{
		if (!ReadControlsData())
		{
			MessageBox.Show("Заполните все поля.");
		}
		else
		{
			List<StatisticReport> report = null;

			if (forAllDayButton.Checked)
			{
				report = GetStatisticReport.Invoke(_startPeriodDate, _endPeriodDate, new int[0], _instrumentNumber);
			}
			if (forWorkShiftButton.Checked)
			{
				report = GetStatisticReport.Invoke(_startPeriodDate, _endPeriodDate, _checkedWorkShifts, _instrumentNumber);
			}

			ShowReport(report);
		}
	}

	private void ShowReport(List<StatisticReport> reports)
	{
		reportGrid.DataSource = reports;
	}

	private bool ReadControlsData()
	{
		if (instrumentNumberBox.SelectedIndex == -1)
			return false;

		_instrumentNumber = instrumentNumberBox.SelectedItem.ToString();
		_startPeriodDate = (DateTime)startPeriodBox.SelectedItem;
		_endPeriodDate = (DateTime)endPeriodBox.SelectedItem;

		if (dayStatisticButton.Checked)
			_endPeriodDate = (DateTime)startPeriodBox.SelectedItem;

		if (forWorkShiftButton.Checked)
		{
			_checkedWorkShifts = workShiftNumberBox.CheckedIndices.ToArray();
			if (_checkedWorkShifts.Length == 0)
				return false;
		}

		return true;
	}

	private void PrepareReportGrid()
	{
		reportGrid.AutoGenerateColumns = false;

		reportGrid.Columns.AddRange(
			new DataGridViewTextBoxColumn { DataPropertyName = "NumberOfWorkShift", HeaderText = "Смена" },
			new DataGridViewTextBoxColumn { DataPropertyName = "SampleCount", HeaderText = "Количество проб" },
			new DataGridViewTextBoxColumn { DataPropertyName = "AnalysisOkCount", HeaderText = "Успешный анализ" },
			new DataGridViewTextBoxColumn { DataPropertyName = "PreparetionCount", HeaderText = "Количество обработок" },
			new DataGridViewTextBoxColumn { DataPropertyName = "ErrorCount", HeaderText = "Количество ошибок" },
			new DataGridViewTextBoxColumn { DataPropertyName = "SummTestModeTime", HeaderText = "Время Test mode" },
			new DataGridViewTextBoxColumn { DataPropertyName = "AverageAnalysisTime", HeaderText = "Ср. время анализа" },
			new DataGridViewTextBoxColumn { DataPropertyName = "AverageOneSideRuns", HeaderText = "Ср. кол-во прожигов на стороне" },
			new DataGridViewTextBoxColumn { DataPropertyName = "AverageBadSurfaceRate", HeaderText = "Ср. процент плохой поверхности" },
			new DataGridViewTextBoxColumn { DataPropertyName = "AverageSamplePreparation", HeaderText = "Ср. кол-во обработок" },
			new DataGridViewTextBoxColumn { DataPropertyName = "PercentBadSample", HeaderText = "Процент брака" });

		reportGrid.Columns[6].DefaultCellStyle.Format = "mm\\:ss";
	}

	private void instrumentNumberBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		var statisticDates = GetStatisticDatesForInstrument.Invoke(instrumentNumberBox.SelectedItem.ToString());

		if (statisticDates.IsNullOrEmpty())
		{
			MessageBox.Show("К сожалению по данному прибору нет данных.");
			startPeriodBox.DataSource = null;
			endPeriodBox.DataSource = null;
		}
		else
		{
			startPeriodBox.DataSource = new List<DateTime>(statisticDates);
			endPeriodBox.DataSource = new List<DateTime>(statisticDates);
			startPeriodBox.Enabled = true;
			endPeriodBox.Enabled = true;
		}
	}

	private void dayStatisticButton_CheckedChanged(object sender, EventArgs e)
	{
		endPeriodBox.Enabled = false;
		label4.Enabled = false;
	}

	private void periodStatisticButton_CheckedChanged(object sender, EventArgs e)
	{
		endPeriodBox.Enabled = true;
		label4.Enabled = true;
	}

	private void forWorkShiftButton_CheckedChanged(object sender, EventArgs e)
	{
		workShiftNumberBox.Enabled = true;
	}

	private void forAllDayButton_CheckedChanged(object sender, EventArgs e)
	{
		workShiftNumberBox.Enabled = false;
	}

	private void saveButton_Click(object sender, EventArgs e)
	{
		if (areaNameBox.Text.IsNullOrEmpty())
		{
			MessageBox.Show("Укажите участок.");
		}
		if (reportGrid.DataSource == null)
		{
			MessageBox.Show("Необходимо расчитать данные отчета.");
		}
		else
		{
			saveFileDialog1.ShowDialog();
			var filePath = saveFileDialog1.FileName;

			if (reportGrid.DataSource != null || !filePath.IsNullOrEmpty())
			{
				SaveReport.Invoke(_instrumentNumber, _startPeriodDate, _endPeriodDate, filePath, areaNameBox.Text);
			}
		}
	}

	string _instrumentNumber;
	DateTime _startPeriodDate;
	DateTime _endPeriodDate;
	int[] _checkedWorkShifts;

	private void startPeriodBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (startPeriodBox.DataSource != null)
		{
			var dates = (List<DateTime>)startPeriodBox.DataSource;
			var index = startPeriodBox.SelectedIndex;
			var forvardDates = new DateTime[dates.Count - index];
			dates.CopyTo(index, forvardDates, 0, forvardDates.Length);

			endPeriodBox.DataSource = forvardDates;
		}
	}

	public event Func<string, DateTime[]> GetStatisticDatesForInstrument;

	//TODO: Павел. Меня беспокоит большое количество параметров для событий и как следствие методов. Это норм?
	public event Func<DateTime, DateTime, int[], string, List<StatisticReport>> GetStatisticReport;
	public event Action<string, DateTime, DateTime, string, string> SaveReport;
}