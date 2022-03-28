using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NOUS_challenge_app.DAL.DI;

namespace NOUS_challenge_app.BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBusinessLogic(IServiceCollection services, IConfiguration config)
        {
            services.AddDataRegister(config);
        }
    }
}
