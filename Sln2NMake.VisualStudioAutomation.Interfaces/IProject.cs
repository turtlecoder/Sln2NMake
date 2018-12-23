using System;
using System.Collections.Generic;
namespace Sln2NMake.VisualStudioAutomation.Interfaces
{
  public interface IProject
  {
    string FullName { get; }
    string Kind { get; }
    string Name { get; }
    IEnumerable<IProjectItem> ProjectItems { get; }
  }
}
