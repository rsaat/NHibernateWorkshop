using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
namespace NHibernateWorkshop.SessionFactoryBuilders
{
    public class JetHbmSessionFactoryBuilder : ISessionFactoryBuilder
    {
        public ISessionFactory BuildSessionFactory()
        {

           

            //FileHelper.DeletePreviousDbFiles();
            //var dbFile = FileHelper.GetDbFileName();
            var configuration = new Configuration();
            
            //configuration.AddProperties(new Dictionary<string, string>
            //                                    {
            //                                        { Environment.ConnectionString, string.Format("Data Source={0};Version=3;New=True;", dbFile) }
            //                                    });

            
            configuration.Configure("jet.hibernate.cfg.xml");
            var schemaExport = new SchemaExport(configuration);
            schemaExport.Create(true, true);
            var temp = configuration.BuildSessionFactory();
            var l = temp.GetAllClassMetadata();
            return temp;
        }
    }
}