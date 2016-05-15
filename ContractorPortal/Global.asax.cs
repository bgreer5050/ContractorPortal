using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ContractorPortal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SetUpDataBase();

        }

        private void SetUpDataBase()
        {
            //Does DB Exist

            string path =  System.IO.Path.Combine(Environment.CurrentDirectory, "kgroofing.sqlite");
            bool blnDBExist = System.IO.File.Exists(path);
            if (blnDBExist != true)
            {
                System.Data.SQLite.SQLiteConnection.CreateFile("kgroofing.sqlite");
            }
            //throw new NotImplementedException();

            string strCommandText = "CREATE TABLE requestforquote ([Id] INTEGER PRIMARY KEY, Name TEXT, Address TEXT, Note TEXT, DateTime TEXT,CONSTRAINT [sqlite_master_PK_records]);";
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("Data Source = kgroofing.sqlite; Version = 3;");
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(strCommandText, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            //strCommandText = "CREATE UNIQUE INDEX [sqlite_autoindex_requestforquote_1_requestforquote] ON [requestforquote] ([Id] ASC);";
            //cmd.ExecuteNonQuery();

            conn.Close();

        }
    }
}
