﻿using Microsoft.IdentityModel.Tokens;
using System.Collections;

public partial class ReportForm : Form, IReportView
{
	public ReportForm()
	{
		InitializeComponent();

	}

	private void showResultButton_Click(object sender, EventArgs e)
	{ 		PrepareReportGrid();
		ReadControlsData();
		reportGrid.ClearSelection();
		List<StatisticReport> report = null;

		if(forAllDayButton.Checked)
		{
			report = GetStatisticReport.Invoke(_startPeriodDate, _endPeriodDate, new int[0], _instrumentNumber);
		}
		if(forWorkShiftButton.Checked)
		{
			report = GetStatisticReport.Invoke(_startPeriodDate, _endPeriodDate, _checkedWorkShifts, _instrumentNumber);
		}

		ShowReport(report);
	}

	private void ShowReport(List<StatisticReport> reports)
	{
		reportGrid.DataSource = reports;
	}

	private void ReadControlsData()
	{
		_instrumentNumber = instrumentNumberBox.SelectedItem.ToString();
		_startPeriodDate = (DateTime)startPeriodBox.SelectedItem;
		_endPeriodDate = (DateTime)endPeriodBox.SelectedItem;

		if(dayStatisticButton.Checked)
			_endPeriodDate = (DateTime)startPeriodBox.SelectedItem;

		if (forWorkShiftButton.Checked)
		{
			_checkedWorkShifts = workShiftNumberBox.CheckedIndices.ToArray();
		}
	}

	private void PrepareReportGrid()
	{
		reportGrid.Columns.AddRange(
			new DataGridViewCheckBoxColumn { DataPropertyName = "NumberOfWorkShift", HeaderText = "Смена" },
			new DataGridViewCheckBoxColumn { DataPropertyName = "SampleCount", HeaderText = "Количество проб" },
			new DataGridViewCheckBoxColumn { DataPropertyName = "AnalysisOkCount", HeaderText = "Успешный анализ" },
			new DataGridViewCheckBoxColumn { DataPropertyName = "PreparetionCount", HeaderText = "Количество обработок" },
			new DataGridViewCheckBoxColumn { DataPropertyName = "ErrorCount", HeaderText = "Количество ошибок" },
			new DataGridViewCheckBoxColumn { DataPropertyName = "SummTestModeTime", HeaderText = "Время Test mode" },
			new DataGridViewCheckBoxColumn { DataPropertyName = "AverageAnalysisTime", HeaderText = "Ср. время анализа" },
			new DataGridViewCheckBoxColumn { DataPropertyName = "AverageOneSideRuns", HeaderText = "Ср. кол-во прожигов на стороне" },
			new DataGridViewCheckBoxColumn { DataPropertyName = "AverageBadSurfaceRate", HeaderText = "Ср. процент плохой поверхности" },
			new DataGridViewCheckBoxColumn { DataPropertyName = "AverageSamplePreparation", HeaderText = "Ср. кол-во обработок" },
			new DataGridViewCheckBoxColumn { DataPropertyName = "PercentBadSample", HeaderText = "Процент брака" });
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
	}

	private void periodStatisticButton_CheckedChanged(object sender, EventArgs e)
	{
		endPeriodBox.Enabled = true;
	}

	private void forWorkShiftButton_CheckedChanged(object sender, EventArgs e)
	{
		workShiftNumberBox.Enabled = true;
	}

	private void forAllDayButton_CheckedChanged(object sender, EventArgs e)
	{
		workShiftNumberBox.Enabled = false;
	}

	string _instrumentNumber;
	DateTime _startPeriodDate;
	DateTime _endPeriodDate;
	int[] _checkedWorkShifts;

	public event Func<string, DateTime[]> GetStatisticDatesForInstrument;
	public event Func<DateTime, DateTime, int[], string, List<StatisticReport>> GetStatisticReport;
}