using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ChallengePapaBobsSi
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Domain.Application_Startup.Application_Startup_Domain();
        }

        void Application_Error()
        {
            //What just happened?
            Exception ex = Server.GetLastError();
            var innerException = ex.InnerException;

            Response.Write("<h2>Somthing bad happened...</h2>");
            Response.Write("<p>" + innerException.Message + "</p>");

            Server.ClearError();
        }

        void DatabaseError(DbEntityValidationException dbEx)
        {
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    Trace.TraceInformation("Property: {0} Error: {1}",
                                            validationError.PropertyName,
                                            validationError.ErrorMessage);
                }
            }
        }
    }
}