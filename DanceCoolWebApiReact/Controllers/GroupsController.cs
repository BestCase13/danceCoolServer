﻿using System.Collections.Generic;
using DanceCoolBusinessLogic.Services;
using DanceCoolDTO;
using Microsoft.AspNetCore.Mvc;

namespace danceCoolWebApi.Controllers
{
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private IGroupService _groupService;
        private IUserService _userService;

        public GroupsController(IGroupService groupService, IUserService userService)
        {
            _groupService = groupService;
            _userService = userService;
        }

        //GET: api/Groups
        [HttpGet]
        [Route("api/groups")]
        public IEnumerable<GroupDTO> GetAllGroups()
        {
            return _groupService.GetAllGroups();
        }

        // GET: api/Groups/5
        [HttpGet]
        [Route("api/groups/{id}")]
        public GroupDTO GetGroupById(int id)
        {
            return _groupService.GetGroupById(id);
        }

        [HttpGet]
        [Route("api/groups/{groupId}/users/")]
        public IEnumerable<UserDTO> GetUsersById(int groupId)
        {
            return _userService.GetUsersFromGroup(groupId);
        }

        [HttpGet]
        [Route("api/students/")]
        public  IEnumerable<UserDTO> GetAllStudents()
        {
            return _userService.GetAllStudents();
        }


        //// POST: api/Groups
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Groups/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}