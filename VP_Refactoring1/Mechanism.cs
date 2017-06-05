using System;

namespace VP_Refactoring1
{
	class Mechanism : IMechanism
	{
		private readonly Exec _exec;

		private Mechanism(Exec exec)
		{
			this._exec = exec;
		}

		public Mechanism() : this(new Exec())   
		{
		}

		public void Run()
		{
			while (true)
			{
				string commandLine = Console.ReadLine();
				bool flag = commandLine == null;
				if (flag)
				{
					break;
				}
				commandLine.Trim();
				bool flag2 = string.IsNullOrEmpty(commandLine);
				if (flag2)
				{
					try
					{
						Exec.CommandManager commandManager = new Exec.CommandManager(commandLine);
						string commandResult = this._exec.Execute(commandManager);
						Console.WriteLine(commandResult);
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				}
			}
		}
	}
}
