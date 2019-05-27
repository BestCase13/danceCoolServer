﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DanceCoolDataAccessLogic.EfStructures.Context;
using DanceCoolDataAccessLogic.EfStructures.Entities;

namespace DanceCoolDataAccessLogic.Repositories.Interfaces
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        IEnumerable<Attendance> GetAllAttendances();
        Attendance GetAttendanceById(int id);
    }
}
