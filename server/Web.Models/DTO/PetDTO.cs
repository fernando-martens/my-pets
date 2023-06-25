using System.Xml.Linq;
using Web.Models.Enums;
using Web.Models.Tables;

namespace Web.Models.DTO
{
    public class PetDTO
    {

        public PetDTO()
        {

        }

        public PetDTO(PetsTable petsTable)
        {
            Id = petsTable.Id;
            Name = petsTable.Name;
            Type = petsTable.Type;
            Description = petsTable.Description;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public PetTypeEnum Type { get; set; }
        public string? Description { get; set; }


        public PetsTable ToTable()
        {
            return new PetsTable(Name, Type, Description);
        }

        public PetsTable ToTableWithId()
        {
            return new PetsTable(Id, Name, Type, Description);
        }

    }

}
