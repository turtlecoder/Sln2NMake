using System;
namespace Sln2NMake.VisualStudioAutomation.Interfaces
{
  public interface IDTE
  {
    void Quit();
    ISolution Solution { get; }
    string Version { get; }
  }
}
