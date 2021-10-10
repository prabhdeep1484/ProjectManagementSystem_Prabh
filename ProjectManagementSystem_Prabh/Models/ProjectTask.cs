using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem_Prabh.Models
{
    public class ProjectTask
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ProjectID { get; set; }

        public Project Project { get; set; }
    }
}