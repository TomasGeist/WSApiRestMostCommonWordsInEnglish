namespace WSmostCommonWordsInEnglishNuevo.Response
{
    public class Respuesta
    {
        public int Codigo {  get; set; }

        public string Mensaje {  get; set; }
        
        public object Data {  get; set; }


        public Respuesta()
        {
            Codigo = 0;
        }
    }
}
