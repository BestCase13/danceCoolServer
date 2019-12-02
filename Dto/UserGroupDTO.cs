namespace DanceCoolDTO
{
    public class UserGroupDTO
    {
        public int StudentId { get; set; }
        public int GroupId { get; set; }

        public UserGroupDTO(int studentId, int groupId)
        {
            StudentId = studentId;
            GroupId = groupId;
        }
    }
}
