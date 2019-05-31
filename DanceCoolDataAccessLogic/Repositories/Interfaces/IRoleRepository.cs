﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DanceCoolDataAccessLogic.EfStructures.Context;
using DanceCoolDataAccessLogic.EfStructures.Entities;

namespace DanceCoolDataAccessLogic.Repositories.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRoleById(int id);
        Role GetRoleByCredentails(string email);
    }
}
