using Sln2NMake.VisualStudioAutomation.Interfaces;
using System.Diagnostics;
using System.Reflection;

namespace Sln2NMake.VisualStudio2010Automation
{
  public class VCFileConfiguration : IVCFileConfiguration
  {
    private dynamic  _fileConfiguration;

    public VCFileConfiguration(dynamic fileConfiguration)
    {
      Debug.WriteLine(string.Format("{0},{1}", MethodInfo.GetCurrentMethod().DeclaringType, MethodInfo.GetCurrentMethod().Name));
      Debug.Indent();

      this._fileConfiguration = fileConfiguration;

      Debug.Unindent();
    }

    #region IVCFileConfiguration Members

    public IVCTool Tool
    {
      get
      {
        return new VCCustomBuildRule(this._fileConfiguration.Tool);
      }
    }

    #endregion


    #region VCFileConfiguration members
    public dynamic DynamicObject
    {
      get
      {
        Debug.WriteLine(string.Format("{0}.{1}", MethodInfo.GetCurrentMethod().DeclaringType, MethodInfo.GetCurrentMethod().Name));
        Debug.Indent();
        try
        {
          return _fileConfiguration;
        }
        finally
        {
          Debug.Unindent();
        }
      }
    }
    #endregion

    #region IVCFileConfiguration Members


    public bool ExcludedFromBuild
    {
      get { throw new System.NotImplementedException(); }
    }

    public string Name
    {
      get { throw new System.NotImplementedException(); }
    }

    public IVCConfiguration ProjectConfiguration
    {
      get { throw new System.NotImplementedException(); }
    }

    #endregion
  }
}
