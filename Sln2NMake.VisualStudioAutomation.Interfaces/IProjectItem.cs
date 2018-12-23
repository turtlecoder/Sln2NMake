using System;
using System.Collections.Generic;
namespace Sln2NMake.VisualStudioAutomation.Interfaces
{
  public interface IProjectItem
  {
    string Kind { get; }
    string Name { get; }
    IEnumerable<IProjectItem> ProjectItems { get; }
    IProject SubProject { get; }
  }
}
