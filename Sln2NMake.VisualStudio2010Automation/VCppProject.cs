using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sln2NMake.VisualStudioAutomation.Interfaces;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.VCProjectEngine;


namespace Sln2NMake.VisualStudio2010Automation
{
  public class VCppProject : IProject, IVCppProject
  {

    [Export("CreateProject", typeof(Func<EnvDTE.Project, IProject>))]
    [ExportMetadata("Kind", "{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}")]
    [ExportMetadata("Version", "10.0")]
    public static IProject CreateVCppProject(EnvDTE.Project project)
    {
      return new VCppProject(project);
    }


    public string Name
    {
      get
      {
        return _project.Name;
      }
    }

    public string Kind
    {
      get
      {
        return _project.Kind;
      }
    }

    public string FullName
    {
      get
      {
        return _project.FullName;
      }
    }

    public IEnumerable<IProjectItem> ProjectItems
    {
      get
      {
        if (null == _project.ProjectItems)
        {
          yield break;
        }
        foreach (var projectItemObject in this._project.ProjectItems)
        {
          // Cast the project to 
          var projectItem = projectItemObject as EnvDTE.ProjectItem;
          yield return new ProjectItem(projectItem) as IProjectItem;
        }
      }
    }

    internal VCppProject(EnvDTE.Project project)
    {
      _project = project;
    }

    private EnvDTE.Project _project;

    #region IVCppProject Members

    string IVCppProject.Name
    {
      get 
      {
        var vcppComObject = _project.Object;
        return vcppComObject.Name;
      }
    }
    

    string IVCppProject.Kind
    {
      get
      {
        return _project.Object.Kind;
      }
    }

    #endregion

    #region IVCppProject Members

    #region IVCppProject Members



    #endregion


#endregion

    #region IVCppProject Members


    public string AssemblyReferencePath
    {
      get { throw new NotImplementedException(); }
    }

    public IEnumerable<IVCFile> Files
    {
      get 
      { 
        /* Get the number of files */
        if (null == this._project.Object.Files)
        {
          yield break;
        }

        foreach (var vcFile in _project.Object.Files) 
        {
          yield return new VCFile(vcFile);
        }
      }
    }


public    string ProjectDirectory
    {
      get { throw new NotImplementedException(); }
    }

public    string ProjectFile
    {
      get { throw new NotImplementedException(); }
    }

    #endregion

    #region IVCppProject Members


public    dynamic Object
    {
      get { return _project.Object; }
    }

    #endregion

#region IVCppProject Members


public IEnumerable<IVCConfiguration> Configurations
{
  get { throw new NotImplementedException(); }
}

#endregion
  }
}
