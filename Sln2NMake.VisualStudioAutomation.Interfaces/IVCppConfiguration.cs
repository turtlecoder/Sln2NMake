
using System.Collections.Generic;
namespace Sln2NMake.VisualStudioAutomation.Interfaces
{
   public enum VCppConfigurationType
    {
      typeUnknown = 0,
      typeApplication = 1,
      typeDyamicLibrary = 4,
      typeStaticLibrary = 10
    }

  public interface IVCppConfiguration
  {
    dynamic Object { get;}
    string BuildLogFile { get; }
    string Name { get; }
    VCppConfigurationType Type { get; }

  }
}
