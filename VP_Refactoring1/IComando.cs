using System;
using System.Collections.Generic;

public interface IComando
{
	string nome
	{
		get;
	}

	IDictionary<string, string> parâmetros
	{
		get;
	}
}
