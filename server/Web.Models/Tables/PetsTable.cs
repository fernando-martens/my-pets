using Web.Models.Enums;

namespace Web.Models.Tables
{
    public class PetsTable
    {

        public PetsTable()
        {
        }

        public PetsTable(Guid id, string name, PetTypeEnum type, string? description)
        {
            Id = id;
            Name = name;
            Type = type;
            Description = description;
        }

        public PetsTable(string name, PetTypeEnum type, string? description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Type = type;
            Description = description;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public PetTypeEnum Type { get; set; }
        public string? Description { get; set; }


    }
}
