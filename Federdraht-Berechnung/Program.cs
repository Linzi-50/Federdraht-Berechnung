using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Federdraht_Berechnung
{
    class Program
    {

        static double BerechneDrahtvor(double fe2kon, double dekon)
        {
            double k1 = 0.15;// Koeffinzent
            double dvor ;
            
            dvor = k1 * (Math.Pow((fe2kon * dekon), 0.33));
            dvor = (Math.Truncate(dvor));// Berechnet den ganzzahligen Teil von "dvor".

            return dvor;
        }

        static double BerechneDrahtdm(double dekon, double dvor, double f2kon, int zfkon)
        {
            double tauzul ; // tau zulässige Schubspannung  
            double tauf2 ; // tau Schubspannung bei F2
            double d = dvor;
            tauzul = 0.5 * zfkon;
            do
            {
                tauf2 = (8 * (dekon - d) * f2kon) / (Math.PI * Math.Pow(d, 3));
                d = d + 0.1;
            }
            while (tauf2 > tauzul);
            return d ;            

        }

        static void Main(string[] args)        
        {
           
            string zf ; // Zugfestigkeit
            int zfkon; // Zugfestigkeit konvertiert
            double f2kon; //Federkraft konvertiert
            string f2 = " "; //Federkraft
            string de = " "; // Aussendurchmesser
            double dekon; // Aussendurchmesser konvertiert
            
            
            

            Console.Write("Bitte Zugfestigkeit des Federdrahtes  eingeben: ");
            zf = Convert.ToString(Console.ReadLine());
            if ((int.TryParse(zf, out zfkon)) && (zfkon > 0))
            {
                Console.Write("Bitte Aussendurchmesser \"DE\" eingeben: ");
                de = Convert.ToString(Console.ReadLine());
            }
            if ((double.TryParse(de, out dekon)) && (dekon > 0))
            {
                Console.Write("Bitte Federkraft  \"F2\" eingeben: ");
                f2 = Convert.ToString(Console.ReadLine());
            }
            if ((double.TryParse(f2, out f2kon)) && (f2kon > 0))
            {
                double dvor = BerechneDrahtvor(f2kon, dekon); 
                Console.WriteLine("zf= " + zfkon + "   DE = " + dekon + "   F2 = " + f2kon + "   vorberechneter Drahtdurchmesser= " + dvor );
                
                double d = BerechneDrahtdm(dekon, dvor, f2kon, zfkon);
                Console.Write(" Drahtdurchmesser =  " + d);
            }

            else
            {
                Console.WriteLine("Die Eingaben führen zu keinem Ergebnis");
            }

            Console.ReadLine();

        }
    }
}
