using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISocializeAndIEmotional
{
    class Program
    {
        static void Main(string[] args)
        {
            ISocializable iso = new Man();
            IEmotionable imo = new Man();
            /*  IEmotionable imc = new Boy();
              PrintInfo(iso);
              PrintInfo(imo);
              PrintInfo(imc);
              */
            PrintInfo(iso);
            PrintInfo(imo);
            Console.Read();
        }

        static void PrintInfo(object obj)
        {   /*  if (obj is ISocializable )
            {
                ISocializable iso = (ISocializable)obj;
                iso.depart();
                iso.wish();
                return;
            }
            */

           if (obj is ISocializable && obj is IEmotionable)
            {
                ISocializable iso = (ISocializable)obj;
                IEmotionable imo = (IEmotionable)obj;
                iso.depart();
                iso.wish();
                imo.cry();
                imo.laugh();
                return;

            }
           
            if (obj is IEmotionable && !(obj is ISocializable))
            {
                IEmotionable imo = (IEmotionable)obj;
                imo.cry();
                imo.laugh();
                return;
            }
           
            


        }
    }
}
