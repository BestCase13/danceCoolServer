﻿using System.Collections.Generic;
using DanceCoolBusinessLogic.Interfaces;
using DanceCoolDataAccessLogic.EfStructures.Entities;
using DanceCoolDataAccessLogic.UnitOfWork;
using DanceCoolDTO;

namespace DanceCoolBusinessLogic.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork db) : base(db)
        {

        }

        public UserDTO AddUser(NewUserDTO userDTO)
        {
            var user = NewUserDTOToUserModel(userDTO);
            db.Users.AddEntity(user);
            db.Save();
            var newUserModel =  db.Users.GetUserByPhoneNumber(userDTO.PhoneNumber);
            return UserModelToUserDTO(newUserModel);
        }
       
        public void AddUserToGroup(int userId, int groupId)
        {
            db.UserGroups.AddUserToGroup(userId, groupId);
            db.Save();
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = db.Users.GetAllUsers();
            if (users == null)
            {
                return null;
            }

            var dtos = new List<UserDTO>();

            foreach (var user in users)
            {
                dtos.Add(UserModelToUserDTO(user));
            }

            return dtos;
        }

        public UserDTO GetUserById(int id)
        {
            var userModel = db.Users.GetUserById(id);
            return userModel == null ? null : UserModelToUserDTO(userModel);
        }

        public UserDTO GetUserByPhoneNumber(string phoneNumber)
        {
            var userModel = db.Users.GetUserByPhoneNumber(phoneNumber);
            return userModel == null ? null : UserModelToUserDTO(userModel);
        }

        public UserDTO GetUserByEmail(string email)
        {
            var user = db.Users.GetUserByEmail(email);
            return user == null ? null : UserModelToUserDTO(user);
        }

        public IEnumerable<UserDTO> GetUsersFromGroup(int groupId)
        {           
            var userModelsInGroup = db.Users.GetStudentsByGroupId(groupId);
            
            if (userModelsInGroup == null)
            {
                return null;
            }

            var usersInGroup = new List<UserDTO>();

            foreach (var item in userModelsInGroup)
            {
                usersInGroup.Add(UserModelToUserDTO(item));
            }

            return usersInGroup;
        }

        public IEnumerable<UserDTO> GetStudentsNotInCurrentGroup(int groupId)
        {
            var studentsNotInCurrentGroup = db.Users.GetStudentsNotInGroup(groupId);
            if (studentsNotInCurrentGroup == null)
            {
                return null;
            }
            var studentsDtos = new List<UserDTO>();

            foreach (var student in studentsNotInCurrentGroup)
            {
                studentsDtos.Add(UserModelToUserDTO(student));
            }

            return studentsDtos;
        }

        public IEnumerable<UserDTO> GetAllStudents()
        {
            var studentModels = db.Users.GetStudents();

            if (studentModels == null)
            {
                return null;
            }

            var studentsDtos = new List<UserDTO>();

            foreach (var item in studentModels)
            {
                studentsDtos.Add(UserModelToUserDTO(item));
            }
            return studentsDtos;

        }

        public IEnumerable<UserDTO> GetMentors()
        {
            var mentorModels = db.Users.GetMentors();

            if (mentorModels == null)
            {
                return null;
            }

            var mentorsDtos = new List<UserDTO>();

            foreach (var item in mentorModels)
            {
                mentorsDtos.Add(UserModelToUserDTO(item));
            }
            return mentorsDtos;
        }

        public IEnumerable<UserDTO> GetMentorsNotInGroup(int[] usedMentors)
        {
            var unUSedMentors = db.Users.GetMentorsNotInGroup(usedMentors);

            if (unUSedMentors == null)
                return null;

            var mentorDtos = new List<UserDTO>();

            foreach (var item in unUSedMentors)
                mentorDtos.Add(UserModelToUserDTO(item));

            return mentorDtos;
        }

        public IEnumerable<UserDTO> Search(string key)
        {
            var users = db.Users.Search(key);
            var dtos = new List<UserDTO>();

            foreach (var user in users)
            {
                dtos.Add(UserModelToUserDTO(user));
            }

            return dtos;
        }

        public IEnumerable<RoleDto> GetAllRoles()
        {
            var roles = db.Roles.GetAll();
            if (roles == null)
            {
                return null;
            }
            var roleDtos = new List<RoleDto>();
            foreach (var role in roles)
            {
                roleDtos.Add(new RoleDto(role.Id, role.RoleName));
            }

            return roleDtos;
        }

        public bool ChangeUserRole(int userId, int newRoleId)
        {
            return db.Users.ChangeUserRole(userId, newRoleId);
        }

        private UserDTO UserModelToUserDTO(User userModel) => 
            new UserDTO(userModel.Id,
                    userModel.FirstName,
                    userModel.LastName,
                    userModel.PhoneNumber,
                    userModel.RoleId,
                    userModel.Role.RoleName);

        private User NewUserDTOToUserModel(NewUserDTO userDto) =>
            new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber 
            };
    }
}
