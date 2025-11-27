using Microsoft.AspNetCore.Mvc;
using MeshAligner.Core;
using MeshAligner.Infrastructure;
using System.Threading.Tasks;

namespace MeshAligner.Api.Controllers
{
    [ApiController]
    [Route(""api/[controller]"")]
    public class MeshController : ControllerBase
    {
        private readonly Repository _repo;
        public MeshController(Repository repo) { _repo = repo; }

        [HttpPost]
        public async Task<IActionResult> Create(Mesh mesh)
        {
            var created = await _repo.AddMeshAsync(mesh);
            return CreatedAtAction(nameof(Create), new { id = created.Id }, created);
        }
    }
}
