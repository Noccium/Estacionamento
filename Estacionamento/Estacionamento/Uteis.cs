using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estacionamento
{
    public static class Uteis
    {
        public static bool ValidaPlaca(string placa)
        {
            return  placa.Length == 7 &&
                    ContemLetras(placa.Substring(0, 3)) && 
                    ContemNumeros(placa.Substring(3, 4));
        }
        public static bool ContemLetras(string placaLetras)
        {
            return placaLetras.Where(letra => char.IsLetter(letra)).Count() == 3;
        }
        public static bool ContemNumeros(string placaNumeros)
        {
            return placaNumeros.Where(numero => char.IsNumber(numero)).Count() == 4;
        }
    }
}
