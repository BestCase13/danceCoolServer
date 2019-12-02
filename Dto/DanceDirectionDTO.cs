namespace DanceCoolDTO
{
    public class DanceDirectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DanceDirectionDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
