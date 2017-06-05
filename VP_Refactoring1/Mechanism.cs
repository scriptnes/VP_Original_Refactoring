using System;

namespace VP_Refactoring1
{
	class Mechanism : IMechanism
	{
		private Exec ex;

		private Mechanism(Exec ex)
		{
			this.ex = ex;
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
						Exec.CommandManager comando = new Exec.CommandManager(commandLine);
						string commandResult = this.ex.Execute(comando);
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
