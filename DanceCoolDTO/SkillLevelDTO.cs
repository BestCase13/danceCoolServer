namespace DanceCoolDTO
{
    public class SkillLevelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SkillLevelDTO(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
