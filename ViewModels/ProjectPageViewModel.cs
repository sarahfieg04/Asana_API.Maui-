using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asana3.Library.Models;
using Asana3.Library.Services;

namespace Asana3.Maui.ViewModels
{
    public class ProjectPageViewModel
    {
        public List<ProjectViewModel> Projects { get; set; }

        public ProjectViewModel?  SelectedProject {get; set; } 

        public ProjectPageViewModel()
        {
          
            Projects = ProjectServiceProxy.Current.Projects
                .Select(p => new ProjectViewModel(p))
                .ToList();
        }
    }
}
