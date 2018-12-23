using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sln2NMake.VisualStudioAutomation.Interfaces;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace Sln2NMake.VisualStudio2010Automation
{
  public class Solution : ISolution
  {
    private EnvDTE.Solution _solution;
    private CompositionContainer _container;

    [ImportMany("CreateProject", typeof(Func<EnvDTE.Project, IProject>))]
    public IEnumerable<Lazy<Func<EnvDTE.Project, IProject>,IProjectMetaInfoView>> ProjectCreationFunctions { get; set; }

    public Solution(EnvDTE.Solution solution)
    {
      this._solution = solution;
      // Compose the creation functions
      Compose();
    }

    private void Compose()
    {
      var catalog = new AggregateCatalog();
      catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
      _container = new CompositionContainer(catalog);
      _container.ComposeParts(this);
    }

    public void Open(string solutionPath)
    {
      _solution.Open(solutionPath);
    }

    public void Close()
    {
      _solution.Close();
    }

    public IEnumerable<IProject> Projects
    {
      get
      {
        if (null ==_solution.Projects)
        {
          yield break;
        }
        foreach (var projectObject in _solution.Projects)
        {
          var projectComObject = projectObject as EnvDTE.Project;
          // Find the correct Creation method for the project we want
          var lazyCreationFunction = 
            ProjectCreationFunctions.SingleOrDefault(lazyCreator => 
                                                 (lazyCreator.Metadata.Kind == projectComObject.Kind &&
                                                    lazyCreator.Metadata.Version == projectComObject.DTE.Version) ? true : false);
          if (lazyCreationFunction != null)
          {
            yield return lazyCreationFunction.Value(projectComObject);
          }
        }
      }
    }
  }
}
