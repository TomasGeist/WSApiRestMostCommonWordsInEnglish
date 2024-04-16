using WSmostCommonWordsInEnglishNuevo.Models;
using System.Collections.Generic;
namespace WSmostCommonWordsInEnglishNuevo.Tools
{
    public class RandomNumber<T>
    {
        public int GenerarNumeroEnteroAleatorio(List<T> lst)
        {
            Random random = new Random();
            int aleatorio = random.Next(lst.Count);
            return aleatorio;
        }
    }
}
