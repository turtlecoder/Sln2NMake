using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sln2NMake.VisualStudioAutomation.Interfaces
{
  public interface IVCTool
  {
    string Name { get; }
    string CommandLine { get; }
    string Outputs { get; }
    // this needs to be readony
    IEnumerable<IVCRuntimeProperty> Properties { get; }
    
  }
}
