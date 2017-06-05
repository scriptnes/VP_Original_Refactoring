using Comandos;
using System;

namespace VehicleParkSystem2
{
	internal class Mecanismo : IMecanismo
	{
		private exec ex;

		private Mecanismo(exec ex)
		{
			this.ex = ex;
		}

		public Mecanismo() : this(new exec())
		{
		}

		public void Runrunrunrunrun()
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
						exec.comando comando = new exec.comando(commandLine);
						string commandResult = this.ex.execução(comando);
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
