using Web.Models.Interfaces;
using Web.Models.Tables;

namespace Web.Repository
{
    public class PetsRepository: BaseRepository<PetsTable>, IPetsRepository
    {
        public PetsRepository(ApplicationContext context) : base(context)
        {
        }

        public List<PetsTable> ListAll()
        {
            return GetAll();
        }

        public void Insert(PetsTable petsTable)
        {
            Create(petsTable);
        }

        public void Update(PetsTable petsTable)
        {
            Edit(petsTable);
        }

        public PetsTable? GetById(Guid id) 
        {
            return Find(x => x.Id == id);
        }

        public void DeleteByTable(PetsTable petsTable)
        {
            Delete(petsTable);
        }

    }
}