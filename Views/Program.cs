using System.Configuration;

namespace Views
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{

			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			var path = ConfigurationManager.AppSettings["Excel_file_path"].ToString();
			var dataFilePath = new FileInfo(path).FullName;

			var startPresenter = new StartFormPresenter(new StartFormModel(dataFilePath), new StartForm(dataFilePath));
			startPresenter.Run();
		}
	}
}