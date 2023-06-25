using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business;
using Web.Business.Interfaces;
using Web.Models.Interfaces;

namespace Web.Infra.CrossCutting
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
