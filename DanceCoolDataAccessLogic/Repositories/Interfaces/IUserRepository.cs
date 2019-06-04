﻿using System.Collections.Generic;
using DanceCoolDataAccessLogic.EfStructures.Entities;

namespace DanceCoolDataAccessLogic.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
        IEnumerable<User> GetStudentsByGroupId(int groupId);
        IEnumerable<User> GetStudents();
        void AddUserRange(IEnumerable<User> users);
        IEnumerable<User> Search(string key);
        IEnumerable<User> GetStudentsNotInGroup(int groupId);
        User GetUserByPhoneNumber(string phoneNumber);
        User GetUserByEmail(string email);
    }
}
