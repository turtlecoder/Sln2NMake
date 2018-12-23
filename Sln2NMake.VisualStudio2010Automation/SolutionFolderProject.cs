using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sln2NMake.VisualStudioAutomation.Interfaces;
using System.ComponentModel.Composition;

namespace Sln2NMake.VisualStudio2010Automation
{
  public class SolutionFolderProject : IProject
  {
    [Export("CreateProject", typeof(Func<EnvDTE.Project, IProject>))]
    [ExportMetadata("Kind", "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}")]
    [ExportMetadata("Version","10.0")]
    public static IProject CreateSolutionFolderProject(EnvDTE.Project _project)
    {
      return new SolutionFolderProject(_project);
    }

    #region IProject Members

    public string FullName
    {
      get
      {
        return _project.FullName;
      }
    }

    public string Kind
    {
      get
      {
        return _project.Kind;
      }
    }

    public string Name
    {
      get
      {
        return _project.Name;
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
    #endregion


    public SolutionFolderProject(EnvDTE.Project _project)
    {
      this._project = _project;
    }

    #region SolutionFolderProject Fields

    EnvDTE.Project _project;
    
    #endregion
  }
}
