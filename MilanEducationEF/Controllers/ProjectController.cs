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
    public class ProjectController : ControllerBase
    {
        private readonly DataContext _context;
        public ProjectController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectEntity>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectEntity>> GetProject(int id)
        {
            return await _context.Projects.FindAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult<ProjectEntity>> CreateProject(ProjectEntity pe)
        {
            ProjectEntity projectEntity = new()
            {
                Name = pe.Name,
                Code = pe.Code,
                Id = pe.Id
            };

            _context.Projects.Add(projectEntity);
            await _context.SaveChangesAsync();
            return await _context.Projects.FindAsync(pe.Id);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(int id, ProjectEntity pe)
        {
            var existingProject = await _context.Projects.FindAsync(id);
            ProjectEntity projectEntity = new ProjectEntity();
            projectEntity.Name = pe.Name;
            projectEntity.Code = pe.Code;

            _context.Entry(projectEntity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjectAsync(int id)
        {
            var existingProject = await _context.Projects.FindAsync(id);

            _context.Projects.Remove(existingProject);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
