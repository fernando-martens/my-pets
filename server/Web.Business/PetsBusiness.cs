using Web.Business.Interfaces;
using Web.Models.DTO;
using Web.Models.Interfaces;
using Web.Models.Tables;

namespace Web.Business
{
    public class PetsBusiness: IPetsBusiness
    {
        private readonly IPetsRepository petsRepository;


        public PetsBusiness(IPetsRepository petsRepository)
        {
            this.petsRepository = petsRepository;
        }

        public List<PetDTO> GetAll()
        {
            return petsRepository.ListAll()
                .Select((e) => new PetDTO(e)).ToList();
        }

        public void Insert(PetDTO dto)
        {
            PetsTable petTable = dto.ToTable();
            petsRepository.Insert(petTable);
        }

        public void Update(PetDTO dto)
        {
            PetsTable petTable = dto.ToTableWithId();
            petsRepository.Update(petTable);

        }

        public void Delete(PetDTO dto)
        {
            PetsTable petTable = dto.ToTableWithId();
            petsRepository.DeleteByTable(petTable);

        }

    }
}