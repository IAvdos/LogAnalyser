﻿using Microsoft.IdentityModel.Tokens;
using System.Collections;

namespace Views
{
	public partial class DiagramForm : Form, IDiagramView
	{
		public DiagramForm()
		{
			InitializeComponent();
		}

		private void axicXWorkShift_CheckedChanged(object sender, EventArgs e)
		{
			numberWorkShiftBox.Enabled = true;
		}

		private void axisXDate_CheckedChanged(object sender, EventArgs e)
		{
			numberWorkShiftBox.Enabled = false;
		}

		private void instrumentNumberBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			_instrumentNumber = instrumentNumberBox.SelectedItem.ToString();

			var statisticDates = GetStatisticDatesForInstrument.Invoke(_instrumentNumber);

			if (statisticDates.IsNullOrEmpty())
			{
				MessageBox.Show("К сожалению по данному прибору нет данных.");
				startPeriodDatePicker.DataSource = null;
				endPeriodDatePicker.DataSource = null;
			}
			else
			{
				startPeriodDatePicker.DataSource = new List<DateTime>(statisticDates);
				endPeriodDatePicker.DataSource = new List<DateTime>(statisticDates);
				startPeriodDatePicker.Enabled = true;
				endPeriodDatePicker.Enabled = true;
			}
		}

		private void buildDiagramButton_Click(object sender, EventArgs e)
		{
			if (!GetControlsData())
			{
				MessageBox.Show("Заполните все элементы.");
			}
			else
			{
				PrepareChart();

				if (_statisticForDay)
				{
					var statisticPoints = GetStatisticReport.Invoke(_startPeriodDate, _endPeriodDate, 0, _statisticElement, _instrumentNumber);
					ShowDiagram(statisticPoints, 0);
				}

				if (!_statisticForDay)
				{
					foreach (var workShift in _checkedWorkShifts)
					{
						var statisticPoints = GetStatisticReport.Invoke(_startPeriodDate, _endPeriodDate
							,(int)workShift + 1, _statisticElement, _instrumentNumber);

						ShowDiagram(statisticPoints, (int)workShift + 1);
					}
				}
			}
		}

		private bool GetControlsData()
		{
			if (instrumentNumberBox.SelectedIndex == -1) return false;
			if (axisYParameterBox.SelectedIndex == -1) return false;

			_startPeriodDate = (DateTime)startPeriodDatePicker.SelectedItem;
			_endPeriodDate = (DateTime)endPeriodDatePicker.SelectedItem;

			_statisticElement = axisYParameterBox.SelectedItem.ToString();

			if (axisXDate.Checked) _statisticForDay = true;
			if (axisXWorkShift.Checked)
			{
				_statisticForDay = false;
				_checkedWorkShifts = numberWorkShiftBox.CheckedIndices;
			}

			return true;
		}

		private void PrepareChart()
		{
			foreach (var series in chart1.Series)
			{
				series.Enabled = false;
				series.Points.Clear();
			}
		}

		private void ShowDiagram(List<DiagramPoint> points, int seriesNumber)
		{
			chart1.Series[seriesNumber].Enabled = true;
			chart1.Legends[0].Enabled = true;

			foreach (var p in points)
			{
				chart1.Series[seriesNumber].Points.AddXY(p.xAxis, p.yAxis);
			}
		}

		private void startPeriodDatePicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(startPeriodDatePicker.DataSource != null)
			{
				//TODO: Павел. Можно ли делать даункаст без проверки на его возможность? Ведь я знаю какой тип нaходится в DataSource.
				//Полагаю что нет.
				var dates = (List<DateTime>)startPeriodDatePicker.DataSource;
				var index = startPeriodDatePicker.SelectedIndex;
				var forvardDates = new DateTime[dates.Count - index];
				dates.CopyTo(index, forvardDates, 0, forvardDates.Length);

				endPeriodDatePicker.DataSource = forvardDates;
			}
		}

		string _instrumentNumber;
		DateTime _startPeriodDate;
		DateTime _endPeriodDate;
		string _statisticElement;
		bool _statisticForDay = true;
		IList _checkedWorkShifts;

		//TODO: Павел. Меня беспокоит большое количество параметров для событий и как следствие методов. Это норм?
		public event Func<DateTime, DateTime, int, string, string, List<DiagramPoint>> GetStatisticReport;
		public event Func<string, DateTime[]> GetStatisticDatesForInstrument;
	}
}