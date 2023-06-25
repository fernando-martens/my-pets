using Web.Models.DTO;
using Web.Models.Tables;

namespace Web.Business.Interfaces
{
    public interface IPetsBusiness
    {
        void Delete(PetDTO dto);
        List<PetDTO> GetAll();
        void Insert(PetDTO dto);
        void Update(PetDTO dto);
    }
}
