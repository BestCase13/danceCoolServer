﻿using System.Collections.Generic;
using DanceCoolDataAccessLogic.EfStructures.Entities;
using DanceCoolDTO;

namespace DanceCoolBusinessLogic.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO GetUserById(int userId);
        UserDTO GetUserByEmail(string email);
        UserDTO GetUserByPhoneNumber(string phoneNumber);
        IEnumerable<UserDTO> GetAllStudents();
        IEnumerable<UserDTO> GetUsersFromGroup(int groupId);
        IEnumerable<UserDTO> GetStudentsNotInCurrentGroup(int groupId);
        IEnumerable<UserDTO> GetMentors();
        IEnumerable<UserDTO> GetMentorsNotInGroup(int[] usedMentors);
        UserDTO AddUser(NewUserDTO userDTO);
        UserGroup AddNewUserToGroup(NewUserDTO newUserDTO, int groupId);
        UserGroup AddUserToGroup(int userId, int groupId);
        IEnumerable<UserDTO> Search(string key);
        IEnumerable<RoleDto> GetAllRoles();
        bool ChangeUserRole(int userId, int newRoleId);
    }
}