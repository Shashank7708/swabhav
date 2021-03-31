using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernetEg
{
   public class CarMap:ClassMap<Car>
    {
        public CarMap()
        {
            Id(x => x.ID);
            Map(x => x.Name);
        }
    }
}
