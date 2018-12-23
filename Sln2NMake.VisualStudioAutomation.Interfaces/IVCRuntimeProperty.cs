using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sln2NMake.VisualStudioAutomation.Interfaces
{
  public interface IVCRuntimeProperty
  {
    string Name { get; }
    string Value { get; }
  }
}
