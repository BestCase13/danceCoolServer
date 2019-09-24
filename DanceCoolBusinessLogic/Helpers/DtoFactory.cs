using DanceCoolDataAccessLogic.EfStructures.Entities;
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
            groupModel.Direction.Name,
            groupModel.Level?.Name,
            UserModelToUserDTO(groupModel.PrimaryMentor),
            groupModel.SecondaryMentor == null ? null: UserModelToUserDTO(groupModel.SecondaryMentor)
           );

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
