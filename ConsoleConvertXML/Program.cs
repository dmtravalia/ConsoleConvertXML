namespace ConsoleConvertXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var converteXmlParaNota = new ConverteXmlParaNota();
            var (infNfse, mensagens) = converteXmlParaNota.Convert(RespostaXML.XmlOk);
        }
    }
}
