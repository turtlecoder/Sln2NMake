using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sln2NMake.VisualStudioAutomation.Interfaces;

namespace Sln2NMake.VisualStudio2010Automation
{
  public class VCCustomBuildRule : IVCTool
  {
    private dynamic _vcCustomBuildRule;
    public VCCustomBuildRule(dynamic vcCustomBuildRule)
    {
      this._vcCustomBuildRule = vcCustomBuildRule;
    }

    #region IVCTool Members

    public string Name
    {
      get
      {
        return _vcCustomBuildRule.Name;
      }
    }

    public string CommandLine
    {
      get
      {
        return _vcCustomBuildRule.CommandLine;
      }
    }

    public string Outputs
    {
      get
      {
        return _vcCustomBuildRule.Outputs;
      }
    }

    public IEnumerable<IVCRuntimeProperty> Properties
    {
      get
      {
        if (null == this._vcCustomBuildRule.Properties)
        {
          yield return null;
        }
        foreach (var prop in this._vcCustomBuildRule.Properties)
        {
          yield return new VCRuntimeProperty(prop);
        }
      }
    }

    #endregion
  }
}
