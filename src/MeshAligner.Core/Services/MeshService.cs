using MeshAligner.Infrastructure;

namespace MeshAligner.Core.Services
{
    public class MeshService : IMeshService
    {
        private readonly IRepository<MeshEntity> _repository;
        public MeshService(IRepository<MeshEntity> repository) => _repository = repository;

        public async Task<Mesh> CreateMeshAsync(Mesh mesh)
        {
            var entity = MeshEntity.FromMesh(mesh);
            var added = await _repository.AddAsync(entity);
            return added.ToMesh();
        }

        public async Task<Mesh?> GetMeshByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity?.ToMesh();
        }

        public async Task<List<Mesh>> GetAllMeshesAsync(int skip = 0, int take = 100)
        {
            var entities = await _repository.GetAllAsync(skip, take);
            return entities.Select(e => e.ToMesh()).ToList();
        }

        public async Task UpdateMeshAsync(Mesh mesh)
        {
            var entity = MeshEntity.FromMesh(mesh);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteMeshAsync(int id) => await _repository.DeleteAsync(id);
    }
}
