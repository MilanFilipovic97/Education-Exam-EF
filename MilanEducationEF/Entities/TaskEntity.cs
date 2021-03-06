using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanEducationEF.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public ProjectEntity Project { get; set; }
    }
}
