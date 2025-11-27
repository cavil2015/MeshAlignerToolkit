using MeshAligner.Core;

namespace MeshAligner.Core.Services
{
    public interface IMeshService
    {
        Task<Mesh> CreateMeshAsync(Mesh mesh);
        Task<Mesh?> GetMeshByIdAsync(int id);
        Task<List<Mesh>> GetAllMeshesAsync(int skip = 0, int take = 100);
        Task UpdateMeshAsync(Mesh mesh);
        Task DeleteMeshAsync(int id);
    }
}
