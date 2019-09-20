using DanceCoolDataAccessLogic.EfStructures.Context;
using DanceCoolDataAccessLogic.EfStructures.Entities;
using DanceCoolDataAccessLogic.Repositories.Interfaces;

namespace DanceCoolDataAccessLogic.Repositories
{
    class UserGroupRepository : BaseRepository<UserGroup>, IUserGroupRepository 
    {
        public UserGroupRepository(DanceCoolContext context) : base(context)
        {
        }

        public UserGroup AddUserToGroup(int userId, int groupId)
        {
            var newUserGroup = new UserGroup
            {
                UserId = userId,
                GroupId = groupId
            };
            Context.UserGroups.Add(newUserGroup);
            return newUserGroup;
        }
    }
}
