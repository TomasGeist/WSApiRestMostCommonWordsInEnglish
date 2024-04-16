using WSmostCommonWordsInEnglishNuevo.Models;

namespace WSmostCommonWordsInEnglishNuevo.Tools
{
    public class RandomNumber
    {
        public int NumeroRandom(List<Word> lst )
        {
            Random random = new Random();
            int aleatorio = random.Next(lst.Count);

            return aleatorio;
        }
    }
}
