using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Inicializa un tipo Numero en 0.
        /// </summary>
        public Numero() : this(0)
        {

        }

        /// <summary>
        /// Inicializa un tipo Numero segun el parametro indicado como string.
        /// </summary>
        /// <param name="strNumero">El numero recibido como string</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Inicializa un tipo Numero segun el parametro indicado.
        /// </summary>
        /// <param name="numero">El valor con el que se inicia</param>
        public Numero(double numero)
            : this(numero.ToString())
        {

        }

        /// <summary>
        /// Asigna a un tipo Numero el parametro pasado como string, lo valida y guarda en dicho tipo Numero.
        /// </summary>
        /// <param name="strNumero">String a validar y guardar</param>
        public String SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }

        /// <summary>
        /// Valida que el string sea un numero y lo devuelve como double de ser posible, sino como 0.
        /// </summary>
        /// <param name="strNumero">El numero recibido como string.</param>
        /// <returns>El numero validado y pasado a double.</returns>
        private static double ValidarNumero(string strNumero)
        {
            double numero;

            if (!double.TryParse(strNumero, out numero))
            {
                numero = 0;
            }

            return numero;
        }

        /// <summary>
        /// Convierte el numero binario pasado como string en un decimal y lo devuelve.
        /// </summary>
        /// <param name="binario">String a convertir.</param>
        /// <returns>String ya convertido a decimal.</returns>
        public static string BinarioDecimal(string binario)
        {
            double numero = 0;
            string retorno;
            
            if(EsBinario(binario))
            {
                for (int i = binario.Length - 1, j = 0; i >= 0; i--, j++)
                {
                    numero += (double)(double.Parse(binario[i].ToString()) * Math.Pow(2, j));
                }
                retorno = numero.ToString();
            }
            else
            {
                retorno = "No es binario.";
            }

            return retorno;
        }

        /// <summary>
        /// Convierte el numero decimal pasado como string en un binario y lo devuelve.
        /// </summary>
        /// <param name="numero">String a convertir</param>
        /// <returns>String ya convertido a binario</returns>
        public static string DecimalBinario(string numero)
        {
            return DecimalBinario(double.Parse(numero));
        }

        /// <summary>
        /// Convierte el numero decimal pasado como double en un binario y lo devuelve.
        /// </summary>
        /// <param name="numero">Double a convertir</param>
        /// <returns>String ya convertido a binario</returns>
        public static string DecimalBinario(double numero)
        {
            string rta = "";
            string aux = "";
            long numeroAux = (long)numero;

            if (numeroAux != 1)
            {
                long i;

                for (i = numeroAux; i != 0 && i != 1; i /= 2)
                {
                    rta = (i % 2) + rta;
                }

                if (i == 0)
                {
                    aux += "0";
                }
                else
                {
                    rta = 1 + rta;
                    aux += rta;
                }
            }
            else
            {
                aux += "1";
            }

            return aux;
        }

        /// <summary>
        /// Crea la operacion "sumar" para los tipo Numero
        /// y devuelve el resultado como double.
        /// </summary>
        /// <param name="num1">Primer numero a sumar</param>
        /// <param name="num2">Segundo numero a sumar</param>
        /// <returns>Resultado de la suma como double</returns>
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }

        /// <summary>
        /// Crea la operacion "restar" para los tipo Numero
        /// y devuelve el resultado como double.
        /// </summary>
        /// <param name="num1">Primero numero a restar</param>
        /// <param name="num2">Segundo numero a restar</param>
        /// <returns>Resultado de la resta como double</returns>
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }

        /// <summary>
        /// Crea la operacion "multiplicar" para los tipo Numero 
        /// y devuelve el resultado como double.
        /// </summary>
        /// <param name="num1">Primer numero a multiplicar</param>
        /// <param name="num2">Segundo numero a multiplicar</param>
        /// <returns>Resultado de la multiplicacion como double</returns>
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }

        /// <summary>
        /// Crea la operacion "dividir" para los tipo Numero
        /// y devuelve el resultado como double.
        /// </summary>
        /// <param name="num1">Dividendo de la división</param>
        /// <param name="num2">Divisor de la división</param>
        /// <returns>Resultado de la division como double</returns>
        public static double operator /(Numero num1, Numero num2)
        {
            double retorno = 0;

            if (num2.numero == 0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = num1.numero / num2.numero;
            }

            return retorno;
        }

        private static bool EsBinario (string binario)
        {
            bool retorno = true;

            foreach (char a in binario)
            {
                if(!(a.Equals('1') || a.Equals('0')))
                {
                    retorno = false;
                }
            }

            return retorno;
        }
    }
}
