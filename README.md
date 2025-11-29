MeshAligner — Parametric Mesh Alignment & Fusion System

MeshAligner is a modular software solution for aligning, merging, and optimizing polygonal meshes.
The project is engineered as a scalable .NET-based platform and is suitable for 3D processing, geometry research, scanning workflows, model post-processing, and automated mesh manipulation pipelines.


Key Features

Mesh Alignment — automatic and manual registration of meshes
Mesh Fusion — point-based and topology-aware merging
Format Support — OBJ, PLY, STL and extendable serializer layer
Modular Architecture — clean separation into API, Core, Infrastructure
Extensible — plugin-ready, service-based interaction
Cross-platform Backend (.NET 8)


Technology Stack

Backend: ASP.NET Core, C#, Entity Framework Core
Database: PostgreSQL (default), configurable via app settings
CI/CD: GitHub Actions example included
Containerization: Docker & Docker Compose ready


Repository Structure

src/MeshAligner.Core — business logic, mesh operations, alignment algorithms
src/MeshAligner.API — .NET Web API interface
src/MeshAligner.Infrastructure — data access, EF migrations, repositories
tests/ — unit and integration tests
docker/ — environment configs
README.md — documentation for setup and usage


Getting Started

Clone the repository
Configure database credentials in appsettings.json
Run docker-compose up or launch API manually
Use HTTP endpoints or integrate the processing module into your own system


Goals and Roadmap

integration with Open3D / CGAL
GPU-accelerated alignment
UI front-end for interactive mesh comparison
web-based mesh preview and annotation tools
