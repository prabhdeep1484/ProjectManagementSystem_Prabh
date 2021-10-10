using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem_Prabh.Models
{
    public class Contract
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int OptionYears { get; set; }

        public List<TaskOrder> TaskOrders { get; set; }
        public List<ContractCategory> ContractCategories { get; set; }
    }
}