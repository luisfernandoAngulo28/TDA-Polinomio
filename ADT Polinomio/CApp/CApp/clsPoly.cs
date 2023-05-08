using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp
{
    public class clsPoly
    {
        //atributos
        const int Max = 10;
        float[] VCoef;
        int[] VExp;
        public int nterm;
        //constructor

        public clsPoly()
        {
            VCoef = new float[Max];
            VExp = new int[Max];
            for (int i = 0; i < Max; i++)
            {
                VCoef[i] = 0;
                VExp[i] = 0;// Console.WriteLine("VCoef "+i+"[" + VCoef[i] + "]");

            }
            nterm = 0;
        }
        //constructor de Copia
        public clsPoly(clsPoly p)
        {
            VCoef = new float[Max];
            VExp = new int[Max];
            for (int i = 0; i <= p.nterm; i++)
            {
                VCoef[i] = p.VCoef[i];
                VExp[i] = p.VExp[i];
            }
            this.nterm = p.nterm;
        }
        //Declara el polinomio Zero 
        public clsPoly Zero()
        {
            return new clsPoly();
        }

        //Es zero el polinomio
        public bool IsZero()
        {
            return (nterm == 0);
        }
        /*VExp[]=[0][1][0][0][0][0][0][0][0]
                  0  1  2  3  4  5  6  7  8          
         VCoef[]=[0][4][0][0][0][0][0][0][0]
                  0  1  2  3  4  5  6  7  8
          */
        //Adciona un termino al polinomio P,coef=1,Exp=3 --->  1X^3 
        public clsPoly Attach(clsPoly p, float Coef, int Exp)
        {
            if ((Coef != 0) && (Exp >= 0))
            {
                p.nterm++;
                p.VExp[Exp] = Exp;
                p.VCoef[Exp] = p.VCoef[Exp] + Coef;
            }
            return p;
        }
        //Eliminar el termino con el exponente EXp del polinomio P
        public clsPoly Reem(clsPoly p, int Exp)
        {
            if (Exp >= 0)
            {
                p.VCoef[Exp] = 0;
                p.VExp[Exp] = 0;
                p.nterm--;
            }
            return p;
        }

        //Obtiene el coheficiente de un termino con el exponente Exp del polinomio
        public float Coef(int Exp)
        {
            return VCoef[Exp];
        }
        public int Exp(int valor)
        {
            return VExp[valor];
        }
        //obtiene el grado de un polinomio
        public int Grado()
        {
            int Exp = 0;
            for (int k = 0; k <Max; k++)
            {
                if (VExp[k] > 0)
                {
                    Exp = VExp[k];
                }
                else
                {
                    if (VExp[k] == 0 && VCoef[k] != 0)
                    {
                        Exp = VExp[k];
                    }
                }
                   

            }
            return Exp;

        }
        public clsPoly Add(clsPoly P, clsPoly Q)
        {
            clsPoly C = new clsPoly();
            while ((P.IsZero() == true && Q.IsZero() == true) == false)
            {
                if (P.Grado() < Q.Grado())
                {
                    C = Attach(C, Q.Coef(Q.Grado()), Q.Grado());
                    Q = Reem(Q, Q.Grado());
                }
                if (P.Grado() > Q.Grado())
                {
                    C = Attach(C, P.Coef(P.Grado()), P.Grado());
                    P = Reem(P, P.Grado());
                }
                if (P.Grado() == Q.Grado())
                {
                    C = Attach(C, P.Coef(P.Grado()) + Q.Coef(Q.Grado()), P.Grado());
                    P = Reem(P, P.Grado());
                    Q = Reem(Q, Q.Grado());
                }

            }
            return C;
        }


        public String Mostrar(clsPoly P)
        {
            string s = "";

            for (int i = 0; i <= 9; i++)
            {
                if (P.VExp[i] == 0 && P.VCoef[i] != 0)
                {
                    s = s + " " + "+" + P.Coef(i);
                }
                else
                {
                    if (P.Coef(i) > 0)
                    {
                        s = s + " " + "+" + Math.Abs(P.Coef(i)) + "X^" + i;

                    }
                    if (P.Coef(i) < 0)
                    {
                        s = s + " " + "-" + Math.Abs(P.Coef(i)) + "X^" + i;

                    }
                }

            }

            return s;
        }

        public override String ToString()
        {
            String s1 = "\n";
            for (int i = 0; i <Max; i++)
            {
                // if (i > 0)
                //{
                // Console.WriteLine("VCoef "+i+"[" + VCoef[i] + "]");

                //  if (i > 1) s1 += " + ";
                //s1 += Convert.ToString(VCoef[i]) + "X" + "^" + Convert.ToString(VExp[i]);
                //}
                s1 = s1 + "VExp " + i + "[" + VExp[i] + "]" + "VCoef " + i + "[" + VCoef[i] + "]\n";
                

            }
            return s1 ;
        }
        public clsPoly SMult(clsPoly P, float coef, int exp)
        {
            clsPoly C = new clsPoly();
            while (P.IsZero() == false)
            {
                C = Attach(C, P.Coef(P.Grado()) * coef, P.Grado() + exp);
                P = Reem(P, P.Grado());
            }
            return C;
        }

        public clsPoly Suma(clsPoly A,clsPoly B)
        {
            clsPoly C = Zero();
            while (!A.IsZero() && !B.IsZero())
            {
                //Console.WriteLine("-------------------|-");
                //Console.WriteLine("A.Grado()= " + A.Grado() + "B.Grado()= " + B.Grado());
                if (A.Grado() < B.Grado())
                { 
                    C = Attach(C, B.Coef(B.Grado()), B.Grado());
                    Console.WriteLine(C.ToString());
                 
           
                    B = Reem(B, B.Grado());
                }
                if (A.Grado() == B.Grado())
                {
                    C = Attach(C, A.Coef(A.Grado()) + B.Coef(B.Grado()), A.Grado());
                    Console.WriteLine(C.ToString());
                    B = Reem(B, B.Grado());
                    A = Reem(A, A.Grado());
                }
                if (A.Grado() > B.Grado())
                {   
                    C = Attach(C, A.Coef(A.Grado()), A.Grado());
                    Console.WriteLine(C.ToString());
                    A = Reem(A, A.Grado());
                }
                Console.WriteLine("cantidad A=" + A.nterm + " " + "cantidad B=" + B.nterm);

            }
            if (!A.IsZero())
            {
                C = Attach(C, A.Coef(A.Grado()), A.Grado());
                Console.WriteLine(C.ToString());
                A = Reem(A, A.Grado());
            }
            else
            {
                if(!B.IsZero())
                {
                    C = Attach(C, B.Coef(B.Grado()), B.Grado());
                    Console.WriteLine(C.ToString());
                    B = Reem(B, B.Grado());
                }
                
            }
       
            return C;
        }







        public clsPoly Mult(clsPoly P, clsPoly Q)
        {
            clsPoly R = Zero();
            clsPoly D = Zero();
            D = Q;
            Console.WriteLine(P.ToString());
            Console.WriteLine(Q.ToString());
            while (P.IsZero() ==false)
            {
                Console.WriteLine("---------------------\n" + Q.ToString());
                while (Q.IsZero() == false)
                {   
                    R = Attach(R, P.Coef(P.Grado()) * Q.Coef(Q.Grado()), P.Grado() + Q.Grado());
                
                    Q = Reem(Q, Q.Grado());
                }
                Q = D;
                P = Reem(P, P.Grado());
            }
            Console.WriteLine("R(X)"+R.Mostrar(R));
            return R;
        }

        public clsPoly SMult2(clsPoly P, clsPoly Q)
        {
            clsPoly R = new clsPoly();
            for (int i = 0; i <= P.Grado(); i++)
            {
                for (int j = 0; j <= Q.Grado(); j++)
                {
                    float coef = P.Coef(i) * Q.Coef(j);
                    int exp = i + j;
                    R = Attach(R, coef, exp);
                }
            }
            Console.WriteLine("R(X)" + R.ToString());
            return R;
        }

        public float Eval(float N)
        {
            float resultado = 0;
            for (int i = nterm; i >= 0; i--)
            {
                resultado = resultado * N + VCoef[i];
            }
            return resultado;
        }

        public clsPoly Multii(clsPoly P, clsPoly Q)
        {
            clsPoly R = Zero();
            for (int contadori = 0; contadori <= P.Grado(); contadori++)
            {
                for (int contadorj = 0; contadorj <= Q.Grado(); contadorj++)
                {
                    float coeficiente = P.Coef(contadori) * Q.Coef(contadorj);
                    int exponente = contadori + contadorj;
                    R = R.Attach(R, coeficiente, exponente);
                }
            }
            return R;
        }
/*
Declare contadori entero;
Declare contadorj entero;
Declare coeficiente entero;
Declare exponente entero;
For(contadori= 1; contadori<=P.grado();contadori++)begin
                For(contadorj= 1; Contadorj<=Q.grado();Contadorj++)begin
                             
             End
end
Return R;
        endFunction

*/
    }

}
