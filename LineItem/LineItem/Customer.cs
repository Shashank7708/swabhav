using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineItem
{
   public class Customer
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string address { get; set; }
        public virtual IList<Order> Order { get; set; } = new List<Order>();

    }


    public class Order
    {
        public virtual int Oid { get; set; }

        public virtual string Oname { get; set; }
        public virtual IList<LineItem> LineItem { get; set; } = new List<LineItem>();
        public virtual Customer Customer { get; set; }




    }

    public class LineItem
    {
        public virtual int itemid { get; set; }
        public virtual string Itemname { get; set; }
        public virtual double PerCost { get; set; }
        public virtual int quantity { get; set; }

        public virtual Order Order { get; set; }


    }


    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.id);
            Map(x => x.name)
                .Length(50)
                .Not.Nullable();

            Map(x => x.address)
                    .Length(100)
                .Not.Nullable();

            HasMany(x => x.Order)
                .Inverse()
                .Cascade.All();
              

        }
    }


    public class LineItemMap : ClassMap<LineItem>
    {
        public LineItemMap()
        {
            Id(x => x.itemid);
            Map(x => x.Itemname)
                .Length(50)
                .Not.Nullable();
            Map(x => x.PerCost)
                .Length(50)
                .Not.Nullable();
            Map(x => x.quantity)
                .Length(50)
                .Not.Nullable();

            References(x => x.Order);
                 
        }


    }


    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Oid);
            Map(x => x.Oname)
                .Length(50)
                .Not.Nullable();

            HasMany(x => x.LineItem)
                .Inverse()
                .Cascade.All();


            References(x => x.Customer);
                

        }
    }


    public class Helper13
    {
        static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    initializeSession();
                return _sessionFactory;
            }
        }

        private static void initializeSession()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString("server=.\\SQLExpress; Database=Contact; User Id=sa; Password=root"))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Program>())
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
