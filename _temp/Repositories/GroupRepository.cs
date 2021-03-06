﻿using System.Collections.Generic;
using System.Linq;
using DanceCoolDataAccessLogic.EfStructures.Context;
using DanceCoolDataAccessLogic.EfStructures.Entities;
using DanceCoolDataAccessLogic.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DanceCoolDataAccessLogic.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(DanceCoolContext context) : base(context)
        {
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return Context.Groups
                .Include(g => g.Direction)
                .Include(g => g.Level)
                .Include(g => g.PrimaryMentor).ThenInclude(prima => prima.Role)
                .Include(g => g.SecondaryMentor).ThenInclude(seco => seco.Role);
        }

        public Group GetGroupById(int groupId)
        {
            return Context.Groups
                .Include(g => g.Direction)
                .Include(g => g.Level)
                .Include(g => g.PrimaryMentor).ThenInclude(prima => prima.Role)
                .Include(g => g.SecondaryMentor).ThenInclude(seco => seco.Role)
                .First(group => group.Id == groupId);
        }

        public IEnumerable<Group> GetGroupsByUserId(int userId)
        {
            return Context.Groups.Where(group => group.UserGroups.Any(ug => ug.UserId == userId));
        }

        public void AddGroup(Group group)
        {
            Context.Groups.Add(group);
        }

        public bool ChangeGroupLevel(int groupId, int levelId)
        {
            var groupModel = GetGroupById(groupId);
            groupModel.LevelId = levelId;
            Context.SaveChanges();
            return true;
        }

        public bool ChangeGroupMentors(int groupId, int newPrimaryMentorId, int newSecMentorId)
        {
            var groupModel = GetGroupById(groupId);
            groupModel.PrimaryMentorId = newPrimaryMentorId;
            groupModel.SecondaryMentorId = newSecMentorId;
            Context.SaveChanges();
            return true;
        }
    }
}