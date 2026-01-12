using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISocializeAndIEmotional
{
    class Boy :IEmotionable
    {
        
       void IEmotionable.cry()
        {
            Console.WriteLine("Boy is Crying");
        }
        void IEmotionable.laugh()
        {
            Console.WriteLine("Boy is Laughing");
        }
    }
}
