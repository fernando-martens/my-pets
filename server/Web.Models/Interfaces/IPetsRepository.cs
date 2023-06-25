using Web.Models.Tables;

namespace Web.Models.Interfaces
{
    public interface IPetsRepository
    {
        void DeleteByTable(PetsTable petsTable);
        PetsTable? GetById(Guid id);
        void Insert(PetsTable petsTable);
        List<PetsTable> ListAll();
        void Update(PetsTable petsTable);
    }
}
    