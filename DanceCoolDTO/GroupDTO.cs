namespace DanceCoolDTO
{
    public class GroupDTO
    {
        public int GroupId { get; set; }
        public string GroupDirection { get; set; }
        public string GroupLevel { get; set; }
        public UserDTO PrimaryMentor { get; set; }
        public UserDTO SecondaryMentor { get; set; }

        public GroupDTO(int groupId, string groupDirection, string groupLevel, UserDTO primaryMentor, UserDTO secondaryMentor)
        {
            GroupId = groupId;
            GroupDirection = groupDirection;
            GroupLevel = groupLevel;
            PrimaryMentor = primaryMentor;
            SecondaryMentor = secondaryMentor;
        }
    }
}