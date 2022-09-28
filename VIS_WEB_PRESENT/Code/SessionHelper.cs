using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VIS_WEB_PRESENT.Code
{
    public class SessionHelper
    {
        public static void SetSession(UserSession userSession)
        {
            HttpContext.Current.Session["loginSession"] = userSession;
        }

        public static UserSession GetSession()
        {
            var session = HttpContext.Current.Session["loginSession"];
            if(session == null)
            {
                return null;
            }
            else
            {
                return session as UserSession;
            }
        }
    }
}