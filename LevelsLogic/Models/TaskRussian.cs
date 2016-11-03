using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsLogic.Models
{
    public class TaskRussian
    {
        public String Text { get; set; }
        public String Description { get; set; }
        public TaskRussian() { }
        public TaskRussian(DataLevel1 data)
        {
            this.Description = data.Descriptions;
            this.Text = data.Text;
        }
    }
}
