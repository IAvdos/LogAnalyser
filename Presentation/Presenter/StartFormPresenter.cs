using DomainModel;

public class StartFormPresenter : IPresenter
{
	readonly IStartView _startForm;
	readonly StartFormModel _startFormModel;

	public StartFormPresenter(StartFormModel model, IStartView startView)
	{
		_startForm = startView;
		_startFormModel = model;

		_startForm.ReadLogs += (f) => ReadLogFiles(f);
	}

	public void ReadLogFiles(string[] logFiles)
	{
		string[] statusReadFiles;

		var statusFiles = _startFormModel.OperateLogs(logFiles).Select(s =>  s.FileName + " - " + s.Status).ToArray();
		_startForm.ShowReport(statusFiles);
	}

	public void Run()
	{
		_startForm.Show();
	}

	public void ShowDiagramForm(DiagramModel model, IDiagramView view)
	{
		//var diagramFormPres = new DiagramFormPresenter(new DiagramModel(), new Diagram);

		//diagramFormPres.Run();
	}
}