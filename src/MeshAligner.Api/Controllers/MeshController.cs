using Microsoft.AspNetCore.Mvc;
using MeshAligner.Core;
using MeshAligner.Infrastructure;
using System.Linq;

namespace MeshAligner.Api.Controllers {
    [ApiController]
    [Route(""api/[controller]"")]
    public class MeshController : ControllerBase {
        private readonly MeshDbContext _context;

        public MeshController(MeshDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMeshes() => Ok(_context.Meshes.ToList());

        [HttpPost]
        public IActionResult CreateMesh([FromBody] Mesh mesh) {
            _context.Meshes.Add(mesh);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMeshes), new { id = mesh.Id }, mesh);
        }

        [HttpPut(""{id}"")]
        public IActionResult UpdateMesh(int id, [FromBody] Mesh mesh) {
            var existing = _context.Meshes.Find(id);
            if (existing == null) return NotFound();
            existing.Name = mesh.Name;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete(""{id}"")]
        public IActionResult DeleteMesh(int id) {
            var mesh = _context.Meshes.Find(id);
            if (mesh == null) return NotFound();
            _context.Meshes.Remove(mesh);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
