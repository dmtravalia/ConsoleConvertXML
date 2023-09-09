using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleConvertXML
{
    public class ConvertXmlToObject
    {
        private XmlDocument xmlDoc;
        private XmlNamespaceManager nsManager;

        public void Convert(string xml)
        {
            using (XmlTextReader xmlReader = new XmlTextReader(xml, XmlNodeType.Element, null))
            {
                xmlReader.WhitespaceHandling = WhitespaceHandling.None;

                xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlReader);

                nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
                nsManager.AddNamespace("ns", "http://www.abrasf.org.br/nfse.xsd");

                XmlNode infNfseNode = xmlDoc.SelectSingleNode("//ns:InfNfse", nsManager);

                if (infNfseNode != null)
                {
                    string numero = GetNodeValue(infNfseNode, "ns:Numero");
                    string codigoVerificacao = GetNodeValue(infNfseNode, "ns:CodigoVerificacao");
                    string dataEmissao = GetNodeValue(infNfseNode, "ns:DataEmissao");
                    string outrasInformacoes = GetNodeValue(infNfseNode, "ns:OutrasInformacoes");

                    Console.WriteLine("Número: " + numero);
                    Console.WriteLine("Código de Verificação: " + codigoVerificacao);
                    Console.WriteLine("Data de Emissão: " + dataEmissao);
                    Console.WriteLine("Outras Informações: " + outrasInformacoes);

                    XmlNode prestadorServicoNode = infNfseNode.SelectSingleNode("ns:PrestadorServico", nsManager);
                    if (prestadorServicoNode != null)
                    {

                        var IdentificacaoPrestadorNode = prestadorServicoNode.SelectSingleNode("ns:IdentificacaoPrestador", nsManager);
                        if (IdentificacaoPrestadorNode != null)
                        {

                            var CpfCnpjNode = IdentificacaoPrestadorNode.SelectSingleNode("ns:CpfCnpj", nsManager);
                            if (CpfCnpjNode != null)
                            {
                                string Cnpj = GetNodeValue(CpfCnpjNode, "ns:Cnpj");

                                Console.WriteLine("Cnpj: " + Cnpj);
                            }

                            string inscricaoMunicipal = GetNodeValue(IdentificacaoPrestadorNode, "ns:InscricaoMunicipal");

                            Console.WriteLine("Inscrição Municipal: " + inscricaoMunicipal);
                        }

                        string razaoSocialPrestador = GetNodeValue(prestadorServicoNode, "ns:RazaoSocial");
                        string nomeFantasiaPrestador = GetNodeValue(prestadorServicoNode, "ns:NomeFantasia");

                        Console.WriteLine("Razão Social: " + razaoSocialPrestador);
                        Console.WriteLine("Nome Fantasia: " + nomeFantasiaPrestador);

                        XmlNode enderecoPrestadorNode = prestadorServicoNode.SelectSingleNode("ns:Endereco", nsManager);

                        if (enderecoPrestadorNode != null)
                        {
                            string endereco = GetNodeValue(enderecoPrestadorNode, "ns:Endereco");
                            string numeroEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Numero");
                            string complementoEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Complemento");
                            string bairroEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Bairro");
                            string codigoMunicipioEndereco = GetNodeValue(enderecoPrestadorNode, "ns:CodigoMunicipio");
                            string ufEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Uf");
                            string cepEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Cep");

                            Console.WriteLine("Endereço: " + endereco);
                            Console.WriteLine("Número: " + numeroEndereco);
                            Console.WriteLine("Complemento: " + complementoEndereco);
                            Console.WriteLine("Bairro: " + bairroEndereco);
                            Console.WriteLine("Código do Município: " + codigoMunicipioEndereco);
                            Console.WriteLine("UF: " + ufEndereco);
                            Console.WriteLine("CEP: " + cepEndereco);
                        }
                    }

                    XmlNode orgaoGeradorNode = infNfseNode.SelectSingleNode("ns:OrgaoGerador", nsManager);
                    if (orgaoGeradorNode != null)
                    {
                        string CodigoMunicipio = GetNodeValue(orgaoGeradorNode, "ns:CodigoMunicipio");
                        string Uf = GetNodeValue(orgaoGeradorNode, "ns:Uf");

                        Console.WriteLine("CodigoMunicipio: " + CodigoMunicipio);
                        Console.WriteLine("Uf: " + Uf);
                    }

                    XmlNode InfDeclaracaoPrestacaoServicoNode = infNfseNode.SelectSingleNode("ns:DeclaracaoPrestacaoServico", nsManager)
                        .SelectSingleNode("ns:InfDeclaracaoPrestacaoServico", nsManager);
                    if (InfDeclaracaoPrestacaoServicoNode != null)
                    {
                        string Competencia = GetNodeValue(InfDeclaracaoPrestacaoServicoNode, "ns:Competencia");
                        string RegimeEspecialTributacao = GetNodeValue(InfDeclaracaoPrestacaoServicoNode, "ns:RegimeEspecialTributacao");
                        string OptanteSimplesNacional = GetNodeValue(InfDeclaracaoPrestacaoServicoNode, "ns:OptanteSimplesNacional");
                        string IncentivoFiscal = GetNodeValue(InfDeclaracaoPrestacaoServicoNode, "ns:IncentivoFiscal");

                        Console.WriteLine("Competencia: " + Competencia);
                        Console.WriteLine("RegimeEspecialTributacao: " + RegimeEspecialTributacao);
                        Console.WriteLine("OptanteSimplesNacional: " + OptanteSimplesNacional);
                        Console.WriteLine("IncentivoFiscal: " + IncentivoFiscal);

                        XmlNode ServicoNode = InfDeclaracaoPrestacaoServicoNode.SelectSingleNode("ns:Servico", nsManager);
                        if (ServicoNode != null)
                        {
                            string IssRetido = GetNodeValue(ServicoNode, "ns:IssRetido");
                            string ItemListaServico = GetNodeValue(ServicoNode, "ns:ItemListaServico");
                            string CodigoCnae = GetNodeValue(ServicoNode, "ns:CodigoCnae");
                            string CodigoTributacaoMunicipio = GetNodeValue(ServicoNode, "ns:CodigoTributacaoMunicipio");
                            string Discriminacao = GetNodeValue(ServicoNode, "ns:Discriminacao");
                            string CodigoMunicipio = GetNodeValue(ServicoNode, "ns:CodigoMunicipio");
                            string ExigibilidadeISS = GetNodeValue(ServicoNode, "ns:ExigibilidadeISS");
                            string MunicipioIncidencia = GetNodeValue(ServicoNode, "ns:MunicipioIncidencia");
                        }

                        XmlNode PrestadorNode = InfDeclaracaoPrestacaoServicoNode.SelectSingleNode("ns:Prestador", nsManager);
                        if (PrestadorNode != null)
                        {
                            string InscricaoMunicipal = GetNodeValue(PrestadorNode, "ns:InscricaoMunicipal");

                            XmlNode CpfCnpjNode = PrestadorNode.SelectSingleNode("ns:CpfCnpj", nsManager);

                            string Cnpj = GetNodeValue(CpfCnpjNode, "ns:Cnpj");
                        }

                        XmlNode TomadorNode = InfDeclaracaoPrestacaoServicoNode.SelectSingleNode("ns:Tomador", nsManager);
                        if (TomadorNode != null)
                        {
                            string RazaoSocial = GetNodeValue(TomadorNode, "ns:RazaoSocial");

                            XmlNode CpfCnpjNode = TomadorNode.SelectSingleNode("ns:IdentificacaoTomador", nsManager)
                                .SelectSingleNode("ns:CpfCnpj", nsManager);

                            string Cnpj = GetNodeValue(CpfCnpjNode, "ns:Cnpj");
                        }
                    }
                }
            }
        }

        private string GetNodeValue(XmlNode parentNode, string nodeName)
        {
            XmlNode node = parentNode.SelectSingleNode(nodeName, nsManager);
            return (node != null) ? node.InnerText : string.Empty;
        }
    }
}
