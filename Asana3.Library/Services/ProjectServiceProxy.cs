using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asana3.Maui.Util;
using Newtonsoft.Json;
using Asana3.Library.Models;

namespace Asana3.Library.Services
{
    public class ProjectServiceProxy
    {
        private List<Project> projects;

        public List<Project> Projects
        {
            get { return projects; }
        }

        private ProjectServiceProxy()
        {
            var projectData = new WebRequestHandler().Get("/Project/Expand").Result;
            // projects = JsonConvert.DeserializeObject<List<Project>>(projectData) ?? new List<Project>();
            if (string.IsNullOrWhiteSpace(projectData))
            {
                projects = new List<Project>();
            }
            else
            {
                projects = JsonConvert.DeserializeObject<List<Project>>(projectData) ?? new List<Project>();
            }
        }

        private static object _lock = new object();
        private static ProjectServiceProxy? instance;

        public static ProjectServiceProxy Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ProjectServiceProxy();
                    }
                }

                return instance;
            }
        }

        public Project? AddOrUpdate(Project? project)
        {
            if (project == null) return null;

            var existing = projects.FirstOrDefault(p => p.Id == project.Id);

            if (existing != null)
            {
                existing.Name = project.Name;
                existing.Description = project.Description;
                existing.CompletePercent = project.CompletePercent;
            }
            else
            {
                project.Id = projects.Any() ? projects.Max(p => p.Id) + 1 : 1;
                projects.Add(project);
            }

            return project;
        }

        public void DisplayProjects()
        {
            projects.ForEach(Console.WriteLine);
        }

        public Project? GetById(int id)
        {
            return projects.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteProject(Project? project)
        {
            if (project != null)
            {
                projects.Remove(project);
            }
        }

        public void ToDosInProject(Project? project)
        {
            if (project == null) return;

            project.ToDos.ForEach(Console.WriteLine);
        }
    }
}