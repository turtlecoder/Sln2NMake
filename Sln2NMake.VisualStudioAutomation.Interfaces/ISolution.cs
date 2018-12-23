using System;
namespace Sln2NMake.VisualStudioAutomation.Interfaces
{
  public interface ISolution
  {
    void Close();
    void Open(string solutionPath);
    System.Collections.Generic.IEnumerable<IProject> Projects { get; }
  }
}
