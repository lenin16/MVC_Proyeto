using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_web
{
    public class CrystalReportCn
    {
        public static CrystalDecisions.Shared.ConnectionInfo GetConnectionInfo()
        {
            var SCon = new System.Data.SqlClient.SqlConnectionStringBuilder(
                System.Configuration.ConfigurationManager.ConnectionStrings["ProyectosCn"].ConnectionString);
            CrystalDecisions.Shared.ConnectionInfo conInfo = new CrystalDecisions.Shared.ConnectionInfo();
            conInfo.ServerName = SCon.DataSource;
            conInfo.DatabaseName = SCon.InitialCatalog;
            conInfo.UserID = SCon.UserID;
            conInfo.Password = SCon.Password;

            return conInfo;
        }

    }
}