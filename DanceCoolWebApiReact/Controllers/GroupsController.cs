﻿using System.Collections.Generic;
using DanceCoolBusinessLogic.Services;
using DanceCoolDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace danceCoolWebApi.Controllers
{
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        //GET: api/Groups
        [Authorize]
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
        [Route("api/groups/{groupId}/students/notingroup")]
        public IEnumerable<UserDTO> GetStudentsNotInCurrentGroup(int groupId)
        {
            return _groupService.GetStudentsNotInCurrentGroup(groupId);
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