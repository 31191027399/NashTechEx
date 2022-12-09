using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMSSpecFlow.Models
{
    public class SearchProjectInfoDto
    {
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string ProjectType { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectManager { get; set; }
        public string Location { get; set; }

        public SearchProjectInfoDto(string projectName,string clientName, string projectType,
         string projectStatus,string projectManager, string location)
        {
            ProjectName = projectName;
            ClientName = clientName;
            ProjectType = projectType;
            ProjectStatus = projectStatus;
            ProjectManager = projectManager;
            Location = location;
        }
    }
}