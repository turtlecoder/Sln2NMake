using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sln2NMake.VisualStudioAutomation.Interfaces;

namespace Sln2NMake.VisualStudio2010Automation
{
  public class DTE : IDTE
  {
    internal DTE(EnvDTE.DTE dte)
    {
      _dte = dte;
    }

    public ISolution Solution
    {
      get
      {
        return new Solution(_dte.Solution);
      }
    }

    public void Quit()
    {
      _dte.Quit();
    }

    private EnvDTE.DTE _dte;

    #region IDTE Members


    public string Version
    {
      get { return _dte.Version; }
    }

    #endregion
  }
}
