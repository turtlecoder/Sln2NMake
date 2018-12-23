using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sln2NMake.VisualStudioAutomation.Interfaces;
using ImpromptuInterface;

namespace Sln2NMake.VisualStudio2010Automation
{
  public class VCRuntimeProperty : IVCRuntimeProperty
  {
    private dynamic _vcRuntimeProperty;

    public VCRuntimeProperty(dynamic vcRuntimeProperty)
    {
      // TODO: Complete member initialization
      this._vcRuntimeProperty = vcRuntimeProperty;
    }

    #region IVCRuntimeProperty Members

    string IVCRuntimeProperty.Name
    {
      get 
      {
        return _vcRuntimeProperty.Name;
      }
    }

    string IVCRuntimeProperty.Value
    {
      get 
      {
        return Impromptu.InvokeGet(this._vcRuntimeProperty, (this as IVCRuntimeProperty).Name);
      }
    }

    #endregion
  }

  
}
