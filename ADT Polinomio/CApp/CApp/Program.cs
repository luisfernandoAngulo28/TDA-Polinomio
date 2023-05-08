using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            clsPoly polip = new clsPoly();
            /*polip.Attach(polip, 3, 0);
            polip.Attach(polip, -1, 3);
            polip.Attach(polip, 2, 4);
            */
            polip.Attach(polip, 4, 2);
            polip.Attach(polip, -6, 2);
            polip.Attach(polip, 2, 0);
            Console.WriteLine("P(X)=" + polip.Mostrar(polip));

            clsPoly poliq = new clsPoly();
            // poliq.Attach(poliq, 3, 5);
            poliq.Attach(poliq, 5, 3);
            poliq.Attach(poliq, -1, 2);
            Console.WriteLine("Q(X)=" + poliq.Mostrar(poliq));
            clsPoly polir = new clsPoly();
                     polir = polir.Multii(polip, poliq);
            Console.WriteLine("R(X)=" + polir.Mostrar(polir));

            Console.ReadKey();

        }
    }
}
