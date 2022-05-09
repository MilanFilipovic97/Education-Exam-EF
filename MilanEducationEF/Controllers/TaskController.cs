using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilanEducationEF.Data;
using MilanEducationEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanEducationEF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly DataContext _context;
        public TaskController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskEntity>>> GetProjects()
        {
            return await _context.Tasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskEntity>> GetTask(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult<TaskEntity>> CreateTask(TaskEntity pe)
        {
            TaskEntity TaskEntity = new()
            {
                Name = pe.Name,
                Description = pe.Description,
                Id = pe.Id,
                ProjectId = pe.ProjectId
            };

            _context.Tasks.Add(TaskEntity);
            await _context.SaveChangesAsync();
            return await _context.Tasks.FindAsync(pe.Id);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id, TaskEntity pe)
        {
            var existingProject = await _context.Tasks.FindAsync(id);
            TaskEntity TaskEntity = new TaskEntity();
            TaskEntity.Name = pe.Name;
            TaskEntity.Description = pe.Description;
            TaskEntity.ProjectId = existingProject.Id;

            _context.Entry(TaskEntity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTaskAsync(int id)
        {
            var existingProject = await _context.Tasks.FindAsync(id);

            _context.Tasks.Remove(existingProject);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
