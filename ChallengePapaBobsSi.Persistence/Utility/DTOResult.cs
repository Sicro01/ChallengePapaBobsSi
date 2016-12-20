using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengePapaBobsSi.Persistence.Repositories
{
    public class DTOResult
    {
        public bool Success { get; set; }
        public object DynamicObject { get; set; }
    }
}