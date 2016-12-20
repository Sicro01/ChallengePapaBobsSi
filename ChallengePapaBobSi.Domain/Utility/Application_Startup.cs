using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengePapaBobsSi.Domain
{
    public static class Application_Startup
    {
        public static void Application_Startup_Domain()
        {
            Persistence.Repositories.AutoMapperPersistenceConfiguration.RegisterMappings();
        }
    }
}
