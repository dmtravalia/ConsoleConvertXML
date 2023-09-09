using System;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleConvertXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var xxx = new ConvertXmlToObject();
            xxx.Convert(RespostaXML.XmlOk);

            //using (XmlTextReader xmlReader = new XmlTextReader(RespostaXML.XmlOk, XmlNodeType.Element, null))
            //{
            //    xmlReader.WhitespaceHandling = WhitespaceHandling.None;

            //    XmlDocument xmlDoc = new XmlDocument();
            //    xmlDoc.Load(xmlReader);

            //    XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
            //    nsManager.AddNamespace("ns", "http://www.abrasf.org.br/nfse.xsd");

            //    XmlNode infNfseNode = xmlDoc.SelectSingleNode("//ns:InfNfse", nsManager);

            //    if (infNfseNode != null)
            //    {
            //        string numero = GetNodeValue(infNfseNode, "ns:Numero", nsManager);
            //        string codigoVerificacao = GetNodeValue(infNfseNode, "ns:CodigoVerificacao", nsManager);
            //        string dataEmissao = GetNodeValue(infNfseNode, "ns:DataEmissao", nsManager);
            //        string outrasInformacoes = GetNodeValue(infNfseNode, "ns:OutrasInformacoes", nsManager);

            //        Console.WriteLine("Número: " + numero);
            //        Console.WriteLine("Código de Verificação: " + codigoVerificacao);
            //        Console.WriteLine("Data de Emissão: " + dataEmissao);
            //        Console.WriteLine("Outras Informações: " + outrasInformacoes);

            //        XmlNode prestadorServicoNode = infNfseNode.SelectSingleNode("ns:PrestadorServico", nsManager);

            //        if (prestadorServicoNode != null)
            //        {
            //            string cpfCnpjPrestador = GetNodeValue(prestadorServicoNode, "ns:Cnpj", nsManager);
            //            string inscricaoMunicipalPrestador = GetNodeValue(prestadorServicoNode, "ns:InscricaoMunicipal", nsManager);
            //            string razaoSocialPrestador = GetNodeValue(prestadorServicoNode, "ns:RazaoSocial", nsManager);
            //            string nomeFantasiaPrestador = GetNodeValue(prestadorServicoNode, "ns:NomeFantasia", nsManager);

            //            Console.WriteLine("Prestador de Serviço:");
            //            Console.WriteLine("CPF/CNPJ: " + cpfCnpjPrestador);
            //            Console.WriteLine("Inscrição Municipal: " + inscricaoMunicipalPrestador);
            //            Console.WriteLine("Razão Social: " + razaoSocialPrestador);
            //            Console.WriteLine("Nome Fantasia: " + nomeFantasiaPrestador);

            //            XmlNode enderecoPrestadorNode = prestadorServicoNode.SelectSingleNode("ns:Endereco", nsManager);

            //            if (enderecoPrestadorNode != null)
            //            {
            //                string endereco = GetNodeValue(enderecoPrestadorNode, "ns:Endereco", nsManager);
            //                string numeroEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Numero", nsManager);
            //                string complementoEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Complemento", nsManager);
            //                string bairroEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Bairro", nsManager);
            //                string codigoMunicipioEndereco = GetNodeValue(enderecoPrestadorNode, "ns:CodigoMunicipio", nsManager);
            //                string ufEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Uf", nsManager);
            //                string cepEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Cep", nsManager);

            //                Console.WriteLine("Endereço do Prestador de Serviço:");
            //                Console.WriteLine("Endereço: " + endereco);
            //                Console.WriteLine("Número: " + numeroEndereco);
            //                Console.WriteLine("Complemento: " + complementoEndereco);
            //                Console.WriteLine("Bairro: " + bairroEndereco);
            //                Console.WriteLine("Código do Município: " + codigoMunicipioEndereco);
            //                Console.WriteLine("UF: " + ufEndereco);
            //                Console.WriteLine("CEP: " + cepEndereco);
            //            }
            //        }
            //    }
            //}

            Console.WriteLine("Hello World!");
        }
        

        static string GetNodeValue(XmlNode parentNode, string nodeName, XmlNamespaceManager nsManager)
        {
            XmlNode node = parentNode.SelectSingleNode(nodeName, nsManager);
            return (node != null) ? node.InnerText : string.Empty;
        }
    }
}
