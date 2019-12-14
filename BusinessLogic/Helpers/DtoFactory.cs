using DataAccessLogic.EfStructures.Entities;
using DanceCoolDTO;

namespace DanceCoolBusinessLogic.Helpers
{
    public static class DtoFactory
    {
        #region Converting Models to DTOs
        public static RoleDto RoleModelToRoleDto(Role roleModel)=>
            new RoleDto(roleModel.Id, roleModel.RoleName);

        public static UserDTO UserModelToUserDTO(User userModel) =>
          new UserDTO(userModel.Id,
                  userModel.FirstName,
                  userModel.LastName,
                  userModel.PhoneNumber,
                  RoleModelToRoleDto(userModel.Role));

        public static GroupDTO GroupModelToGroupDTO(Group groupModel) => new GroupDTO(
            groupModel.Id,
            DanceDirectionModelToDTO(groupModel.Direction),
            groupModel.Level == null ? null : SkillLevelModelToDto(groupModel.Level),
            UserModelToUserDTO(groupModel.PrimaryMentor),
            groupModel.SecondaryMentor == null ? null: UserModelToUserDTO(groupModel.SecondaryMentor)
           );

        public static DanceDirectionDTO DanceDirectionModelToDTO(DanceDirection danceDirectionModel) => 
            new DanceDirectionDTO(danceDirectionModel.Id, danceDirectionModel.Name);

        public static SkillLevelDTO SkillLevelModelToDto(SkillLevel skillLevelModel) {
            return new SkillLevelDTO(skillLevelModel.Id, skillLevelModel.Name, skillLevelModel.Description);
            
        }

        #endregion
        #region Converting DTOs to Models

        public static User NewUserDtoToUserModel(NewUserDTO userDto) =>
            new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber
            };
        #endregion
    }
}
