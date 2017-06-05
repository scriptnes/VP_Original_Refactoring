using System.Collections.Generic;

namespace VP_Refactoring1
{
    public interface ICommandManager    
    {
        string Name
        {
            get;
        }

        IDictionary<string, string> ParametersDictionary    
        {
            get;
        }
    }
}
