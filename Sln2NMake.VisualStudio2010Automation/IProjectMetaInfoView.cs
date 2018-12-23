using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sln2NMake.VisualStudio2010Automation
{
  public interface IProjectMetaInfoView
  {
    string Kind { get; }
    string Version{get;}
  }
}
