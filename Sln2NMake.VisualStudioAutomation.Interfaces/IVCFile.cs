using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sln2NMake.VisualStudioAutomation.Interfaces
{
  public interface IVCFile
  {
    string FullPath { get; }
    IEnumerable<IVCFileConfiguration> FileConfigurations { get; }
  }
}
