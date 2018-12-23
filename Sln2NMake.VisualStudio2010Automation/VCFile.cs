using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sln2NMake.VisualStudioAutomation.Interfaces;
using System.Diagnostics;
using System.Reflection;
using Microsoft.VisualStudio.VCProjectEngine;

namespace Sln2NMake.VisualStudio2010Automation
{
  public class VCFile : IVCFile
  {

    #region IVCFile Members

    public string FullPath
    {
      get
      {
        return _vcFile.FullPath;
      }
    }

    public IEnumerable<IVCFileConfiguration> FileConfigurations
    {
      get
      {
        Debug.WriteLine(String.Format("{0}.{1}", MethodInfo.GetCurrentMethod().DeclaringType, MethodInfo.GetCurrentMethod().Name));
        Debug.Indent();
        /* Check if there is a vc file configuration */
        if (null == _vcFile.FileConfigurations)
        {
          yield return null;
        }
        foreach (var fileConfiguration in _vcFile.FileConfigurations)
        {
          yield return new VCFileConfiguration(fileConfiguration);
        }
        Debug.Unindent();
      }
    }

    #endregion

    public VCFile(dynamic vcFile)
    {
      _vcFile = vcFile;
    }

    //private dynamic _vcFile;
    private dynamic _vcFile;
  }
}
