using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace While_E.Models
{
    class Task
    {
        public int taskId { get; set; }
        public string taskName { get; set; }
        public string taskDesc { get; set; }
        public bool taskComplete { get; set; }
        public int userID { get; set; }
    }
}
