using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sln2NMake.VisualStudioAutomation.Interfaces;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Reflection;

namespace Sln2NMake.VisualStudio2010Automation
{
  public class ProjectItem : IProjectItem
  {

    private CompositionContainer _container;

    [ImportMany("CreateProject", typeof(Func<EnvDTE.Project, IProject>))]
    public IEnumerable<Lazy<Func<EnvDTE.Project, IProject>,IProjectMetaInfoView>> ProjectCreationFunctions { get; set; }

    internal ProjectItem(EnvDTE.ProjectItem projectItem)
    {
      this._projectItem = projectItem;
      Compose();
    }

    private void Compose()
    {
      var catalog = new AggregateCatalog();
      catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
      _container = new CompositionContainer(catalog);
      _container.ComposeParts(this);

    }


    public string Name
    {
      get
      {
        return _projectItem.Name;
      }
    }

    public string Kind
    {
      get
      {
        return _projectItem.Kind;
      }
    }

    public IEnumerable<IProjectItem> ProjectItems
    {
      get
      {
        if (_projectItem.ProjectItems == null)
        {
          yield break;
        }

        foreach (var projectItemObject in _projectItem.ProjectItems)
        {
          yield return new ProjectItem(projectItemObject as EnvDTE.ProjectItem);
        }
      }
    }

    public IProject SubProject
    {
      get
      {
        if (_projectItem.SubProject!=null)
        {
          // Find the appropriate Creation function and execute it. 
          var lazyCreationFunction =
            ProjectCreationFunctions
              .SingleOrDefault(lazyCreator =>
                                 (lazyCreator.Metadata.Kind == _projectItem.SubProject.Kind &&
                                    lazyCreator.Metadata.Version == _projectItem.SubProject.DTE.Version) 
                                    ? true
                                    : false);
          if (lazyCreationFunction != null)
          {
            return lazyCreationFunction.Value(_projectItem.SubProject);
          }

          return null;
        }
        return null;
      }
    }
    

    private EnvDTE.ProjectItem _projectItem;
  }
}
