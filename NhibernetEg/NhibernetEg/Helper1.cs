using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernetEg
{
    class Helper1
    {
        static ISessionFactory _sessionFactory;

       private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSession();
                return _sessionFactory;
            }
        }

        private static void InitializeSession()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString("server =.\\SQLExpress; Database = CrudOnEmp; User Id = sa; Password = root"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(true, true))
                .BuildSessionFactory();

        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

    }
}
