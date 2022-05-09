using Microsoft.EntityFrameworkCore;
using MilanEducationEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanEducationEF.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
    }
}
