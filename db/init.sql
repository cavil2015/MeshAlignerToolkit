CREATE TABLE IF NOT EXISTS ""Meshes"" (
    ""Id"" UUID PRIMARY KEY,
    ""Name"" TEXT NOT NULL,
    ""VerticesJson"" TEXT NOT NULL,
    ""TrianglesJson"" TEXT NOT NULL
);
