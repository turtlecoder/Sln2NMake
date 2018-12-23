using System;
using EnvDTE;
using MessageFilterImpl;
using Sln2NMake.VisualStudioAutomation.Interfaces;
using System.ComponentModel.Composition;

namespace Sln2NMake.VisualStudio2010Automation
{
  [Export(typeof(IDTEFactory))]
  public class DTEFactory : IDTEFactory
  {
    private static string VISUAL_STUDIO_2010_PROGID="VisualStudio.DTE.10.0";

    public static DTE InternalCreateDTE()
    {
      var dteType = System.Type.GetTypeFromProgID(VISUAL_STUDIO_2010_PROGID);
      var dteComObject = Activator.CreateInstance(dteType);
      var dte = dteComObject as EnvDTE.DTE;
      return new DTE(dte);
    }

    public IDTE CreateDTE()
    {
      return DTEFactory.InternalCreateDTE();
    }
  }
}
