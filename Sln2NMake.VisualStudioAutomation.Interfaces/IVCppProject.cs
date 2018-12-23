using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sln2NMake.VisualStudioAutomation.Interfaces
{
  public interface IVCppProject
  {
    string Name { get; }
    string Kind { get; }
    string AssemblyReferencePath { get; }
    IEnumerable<IVCFile> Files { get; }
    IEnumerable<IVCConfiguration> Configurations { get; }
    string ProjectDirectory { get; }
    string ProjectFile { get; }
    dynamic Object { get; }
  }
}
