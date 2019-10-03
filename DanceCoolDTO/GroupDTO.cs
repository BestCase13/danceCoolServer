namespace DanceCoolDTO
{
    public class GroupDTO
    {
        public int GroupId { get; set; }
        public DanceDirectionDTO GroupDirection { get; set; }
        public SkillLevelDTO GroupLevel { get; set; }
        public UserDTO PrimaryMentor { get; set; }
        public UserDTO SecondaryMentor { get; set; }

        public GroupDTO(int groupId, DanceDirectionDTO groupDirection, SkillLevelDTO groupLevel, UserDTO primaryMentor, UserDTO secondaryMentor)
        {
            GroupId = groupId;
            GroupDirection = groupDirection;
            GroupLevel = groupLevel;
            PrimaryMentor = primaryMentor;
            SecondaryMentor = secondaryMentor;
        }
    }
}