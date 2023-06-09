﻿using CrazyPetals.Entities.Database;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface IVersionControlRepository : IRepository<VersionControl>
    {
        VersionControl CurrentVersion(string AppId);
    }
}
