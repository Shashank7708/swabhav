using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISocializeAndIEmotional
{
    class Man :Boy,ISocializable,IEmotionable
    {
        void ISocializable.wish()
        {
            Console.WriteLine("Man is wishing");
        }
        void ISocializable.depart()
        {
            Console.WriteLine("Man is Departing");
        }
        void IEmotionable.cry()
        {
            Console.WriteLine("Man is Crying");
        }
        void IEmotionable.laugh()
        {
            Console.WriteLine("Man is Laughing");
        }
    }
}
