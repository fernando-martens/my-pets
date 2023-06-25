using Microsoft.Extensions.DependencyInjection;
using Web.Business;
using Web.Business.Interfaces;
using Web.Models.Interfaces;

namespace Web.Repository.CrossCutting
{
    public static class NativeInjector
    {

        public static void RegisterBusiness(IServiceCollection services)
        {
            #region Business

            services.AddScoped<IPetsBusiness, PetsBusiness>();

            #endregion

            #region Repository

            services.AddScoped<IPetsRepository, PetsRepository>();

            #endregion

        }

    }
}
