using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace VP_Refactoring1
{
    public class Exec
	{
	    public readonly CarConfig _carConfig;
	    private readonly MotoConfig _motoConfig;
	    private readonly TruckConfig _truckConfig;
	    private readonly ResultExec _resultExec;

	    public Exec()
	    {
	        _carConfig = new CarConfig(this);
	        _motoConfig = new MotoConfig(this);
	        _truckConfig = new TruckConfig(this);
	        _resultExec = new ResultExec(this);
	    }

	    public class CommandManager : ICommandManager   
		{
			public string Name
			{
				get;
				set;
			}

			public IDictionary<string, string> ParametersDictionary
			{
				get;
				set;
			}

			public CommandManager(string str)
			{
				this.Name = str.Substring(0, str.IndexOf(' '));
				this.ParametersDictionary = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(str.Substring(str.IndexOf(' ') + 1));
			}
		}

	    public VehicleSystem VehiclePark
		{
			get;
			set;
		}

	    public MotoConfig MotoConfig
	    {
	        get { return _motoConfig; }
	    }

	    public TruckConfig TruckConfig
	    {
	        get { return _truckConfig; }
	    }

	    public string Execute(ICommandManager commandManager)
		{
			bool flag = commandManager.Name != "SetupPark" && this.VehiclePark == null; 

			return _resultExec.Result(commandManager, flag);
		}
	}
}
