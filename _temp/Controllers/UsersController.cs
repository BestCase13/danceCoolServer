﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceCoolBusinessLogic.Interfaces;
using DanceCoolDTO;
using DanceCoolWebApi.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DanceCoolWebApi.Controllers
{
    /// <summary>
    /// Controller for system users.
    /// </summary>
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHubContext<UsersHub, IHubContract> _context;

        public UsersController(IUserService userService, IHubContext<UsersHub, IHubContract> context)
        {
	        _context = context;
			_userService = userService;
        }

        /// <summary>Get all users in database.</summary>
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/users/fireSignalR")]
        public async Task Fire()
        {
	        await _context.Clients.All.UserAdded(_userService.GetAllUsers().First());
        }

		/// <summary>Get all users in database.</summary>
		//[Authorize(Roles = "Admin")]
		[HttpGet]
        [Route("api/users")]
        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        /// <summary>Get all students in database.</summary>
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/students")]
        public IEnumerable<UserDTO> GetAllStudents()
        {
            return _userService.GetAllStudents();
        }

        /// <summary>Get user by his id in database.</summary>
        /// <param name="userId">Id of the student to be gotten.</param>
        //[Authorize(Roles = "Mentor, Admin")]
        [HttpGet]
        [Route("api/users/{userId}")]
        public UserDTO GetUserById(int userId)
        {
            return _userService.GetUserById(userId);
        }

        /// <summary>Get user by his phoneNumber.</summary>
        /// <param name="phoneNumber">phoneNumber of the user to be gotten.</param>
        [Authorize(Roles = "Mentor, Admin")]
        [HttpGet]
        [Route("api/users/phone")]
        public UserDTO GetUserByPhoneNumber(string phoneNumber)
        {
            var user = _userService.GetUserByPhoneNumber(phoneNumber);
            return user;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/users/search")]
        public IEnumerable<UserDTO> Search(string searchQuery)
        {
            var searchResult = new List<UserDTO>();
            return searchQuery == null ? searchResult : _userService.Search(searchQuery);
        }

        /// <summary>Get all roles from database.</summary>
        [Authorize(Roles = "Mentor, Admin")]
        [HttpGet]
        [Route("api/roles/")]
        public IActionResult GetAllRoles()
        {
            var roles = _userService.GetAllRoles();
            if (roles== null)
            {
                return NotFound("Не знайдено жодної ролі");
            }

            return Ok(roles);
        }

        // POST: api/Users
        //[Authorize(Roles = "Mentor, Admin")]
        [HttpPost]
        [Route("api/users/")]
        public IActionResult AddNewUser([FromBody]NewUserDTO userDto)
        {
            var newUserModel = _userService.AddUser(userDto);
            return Ok(newUserModel);
        }

        [HttpPost]
        [Route("api/group/{groupId}/new-user")]
        public IActionResult AddNewUserToGroup(int groupId, [FromBody]NewUserDTO newUser)
        {
            var user = new NewUserDTO (newUser.FirstName, newUser.LastName, newUser.PhoneNumber);

            _userService.AddNewUserToGroup(user, groupId);
            return Ok();
        }

        //[Authorize(Roles = "Mentor, Admin")]
        [HttpPost]
        [Route("api/group/user/")]
        public IActionResult AddStudentToGroup(UserGroupDTO newStudentGroupConnection)
        {            
            if (newStudentGroupConnection.StudentId > 0 && newStudentGroupConnection.GroupId > 0)
            {
                _userService.AddUserToGroup(newStudentGroupConnection.StudentId, newStudentGroupConnection.GroupId);
                return Ok();
            }
            return NotFound();
        }

        /// <summary>Changes user role.</summary>
        /// <param name="userRoleToChange">Object that contains user id and new role id</param>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("api/user/changeuserrole")]
        public IActionResult ChangeUserRole([FromBody] dynamic userRoleToChange)
        {
            if (!int.TryParse(userRoleToChange.userId.ToString(), out int userId))
                return BadRequest("Невідомі дані про юзера");

            if (!int.TryParse(userRoleToChange.newRoleId.ToString(), out int newRoleId))
                return BadRequest("Невідомі дані про роль");

            if (userId < 1 || newRoleId < 1)
                return BadRequest("Введено невірні дані");

            return _userService.ChangeUserRole(userId, newRoleId) ? Ok() : StatusCode(500);
        }

    }
}
