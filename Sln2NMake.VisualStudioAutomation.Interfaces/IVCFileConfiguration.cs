using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sln2NMake.VisualStudioAutomation.Interfaces
{
  public interface IVCFileConfiguration
  {
    IVCTool Tool { get; }
    bool ExcludedFromBuild { get; }
    string Name { get; }
    IVCConfiguration ProjectConfiguration { get; }
  }
}
