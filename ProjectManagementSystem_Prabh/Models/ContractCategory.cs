using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem_Prabh.Models
{
    public class ContractCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ContractID { get; set; }
        public Contract Contract { get; set; }
    }
}