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
                    var infNfse = new InfNfse();
                    infNfse.Numero = GetNodeValue(infNfseNode, "ns:Numero");
                    infNfse.CodigoVerificacao = GetNodeValue(infNfseNode, "ns:CodigoVerificacao");
                    infNfse.DataEmissao = GetNodeValue(infNfseNode, "ns:DataEmissao");
                    infNfse.OutrasInformacoes = GetNodeValue(infNfseNode, "ns:OutrasInformacoes");

                    XmlNode ValoresNfseNode = infNfseNode.SelectSingleNode("ns:ValoresNfse", nsManager);
                    if (ValoresNfseNode != null)
                    {
                        var valoresNfse = new ValoresNfse();
                        valoresNfse.BaseCalculo = GetNodeValue(ValoresNfseNode, "ns:BaseCalculo");
                        valoresNfse.Aliquota = GetNodeValue(ValoresNfseNode, "ns:Aliquota");
                        valoresNfse.ValorIss = GetNodeValue(ValoresNfseNode, "ns:ValorIss");
                        valoresNfse.ValorLiquidoNfse = GetNodeValue(ValoresNfseNode, "ns:ValorLiquidoNfse");

                        infNfse.ValoresNfse = valoresNfse;
                    }

                    XmlNode prestadorServicoNode = infNfseNode.SelectSingleNode("ns:PrestadorServico", nsManager);
                    if (prestadorServicoNode != null)
                    {
                        var prestadorServico = new PrestadorServico();
                        prestadorServico.RazaoSocialPrestador = GetNodeValue(prestadorServicoNode, "ns:RazaoSocial");
                        prestadorServico.NomeFantasiaPrestador = GetNodeValue(prestadorServicoNode, "ns:NomeFantasia");

                        var IdentificacaoPrestadorNode = prestadorServicoNode.SelectSingleNode("ns:IdentificacaoPrestador", nsManager);
                        if (IdentificacaoPrestadorNode != null)
                        {
                            var identificacao = new Identificacao();

                            var CpfCnpjNode = IdentificacaoPrestadorNode.SelectSingleNode("ns:CpfCnpj", nsManager);
                            if (CpfCnpjNode != null)
                                identificacao.Cnpj = GetNodeValue(CpfCnpjNode, "ns:Cnpj");

                            identificacao.InscricaoMunicipal = GetNodeValue(IdentificacaoPrestadorNode, "ns:InscricaoMunicipal");

                            prestadorServico.Identificacao = identificacao;
                        }

                        XmlNode enderecoPrestadorNode = prestadorServicoNode.SelectSingleNode("ns:Endereco", nsManager);
                        if (enderecoPrestadorNode != null)
                        {
                            var endereco = new Endereco();
                            endereco.Logradouro = GetNodeValue(enderecoPrestadorNode, "ns:Endereco");
                            endereco.NumeroEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Numero");
                            endereco.ComplementoEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Complemento");
                            endereco.BairroEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Bairro");
                            endereco.CodigoMunicipioEndereco = GetNodeValue(enderecoPrestadorNode, "ns:CodigoMunicipio");
                            endereco.UfEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Uf");
                            endereco.CepEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Cep");

                            prestadorServico.Endereco = endereco;
                        }

                        XmlNode ContatoNode = prestadorServicoNode.SelectSingleNode("ns:Contato", nsManager);
                        if (ContatoNode != null)
                        {
                            var contato = new Contato();
                            contato.Telefone = GetNodeValue(ContatoNode, "ns:Telefone");
                            contato.Email = GetNodeValue(ContatoNode, "ns:Email");

                            prestadorServico.Contato = contato;
                        }

                        infNfse.PrestadorServico = prestadorServico;
                    }

                    XmlNode orgaoGeradorNode = infNfseNode.SelectSingleNode("ns:OrgaoGerador", nsManager);
                    if (orgaoGeradorNode != null)
                    {
                        var orgaoGerador = new OrgaoGerador();
                        orgaoGerador.CodigoMunicipio = GetNodeValue(orgaoGeradorNode, "ns:CodigoMunicipio");
                        orgaoGerador.Uf = GetNodeValue(orgaoGeradorNode, "ns:Uf");

                        infNfse.OrgaoGerador = orgaoGerador;
                    }

                    XmlNode InfDeclaracaoPrestacaoServicoNode = infNfseNode.SelectSingleNode("ns:DeclaracaoPrestacaoServico", nsManager)
                        .SelectSingleNode("ns:InfDeclaracaoPrestacaoServico", nsManager);
                    if (InfDeclaracaoPrestacaoServicoNode != null)
                    {
                        var infDeclaracaoPrestacaoServico = new InfDeclaracaoPrestacaoServico();
                        infDeclaracaoPrestacaoServico.Competencia = GetNodeValue(InfDeclaracaoPrestacaoServicoNode, "ns:Competencia");
                        infDeclaracaoPrestacaoServico.RegimeEspecialTributacao = GetNodeValue(InfDeclaracaoPrestacaoServicoNode, "ns:RegimeEspecialTributacao");
                        infDeclaracaoPrestacaoServico.OptanteSimplesNacional = GetNodeValue(InfDeclaracaoPrestacaoServicoNode, "ns:OptanteSimplesNacional");
                        infDeclaracaoPrestacaoServico.IncentivoFiscal = GetNodeValue(InfDeclaracaoPrestacaoServicoNode, "ns:IncentivoFiscal");

                        XmlNode ServicoNode = InfDeclaracaoPrestacaoServicoNode.SelectSingleNode("ns:Servico", nsManager);
                        if (ServicoNode != null)
                        {
                            var servico = new Servico();
                            servico.IssRetido = GetNodeValue(ServicoNode, "ns:IssRetido");
                            servico.ItemListaServico = GetNodeValue(ServicoNode, "ns:ItemListaServico");
                            servico.CodigoCnae = GetNodeValue(ServicoNode, "ns:CodigoCnae");
                            servico.CodigoTributacaoMunicipio = GetNodeValue(ServicoNode, "ns:CodigoTributacaoMunicipio");
                            servico.Discriminacao = GetNodeValue(ServicoNode, "ns:Discriminacao");
                            servico.CodigoMunicipio = GetNodeValue(ServicoNode, "ns:CodigoMunicipio");
                            servico.ExigibilidadeISS = GetNodeValue(ServicoNode, "ns:ExigibilidadeISS");
                            servico.MunicipioIncidencia = GetNodeValue(ServicoNode, "ns:MunicipioIncidencia");

                            infDeclaracaoPrestacaoServico.Servico = servico;
                        }

                        XmlNode PrestadorNode = InfDeclaracaoPrestacaoServicoNode.SelectSingleNode("ns:Prestador", nsManager);
                        if (PrestadorNode != null)
                        {
                            var identificacao = new Identificacao();
                            XmlNode CpfCnpjNode = PrestadorNode.SelectSingleNode("ns:CpfCnpj", nsManager);
                            identificacao.Cnpj = GetNodeValue(CpfCnpjNode, "ns:Cnpj");
                            identificacao.InscricaoMunicipal = GetNodeValue(PrestadorNode, "ns:InscricaoMunicipal");

                            infDeclaracaoPrestacaoServico.Prestador = identificacao;
                        }

                        XmlNode TomadorNode = InfDeclaracaoPrestacaoServicoNode.SelectSingleNode("ns:Tomador", nsManager);
                        if (TomadorNode != null)
                        {
                            var tomador = new Tomador();

                            tomador.RazaoSocial = GetNodeValue(TomadorNode, "ns:RazaoSocial");
                            XmlNode CpfCnpjNode = TomadorNode.SelectSingleNode("ns:IdentificacaoTomador", nsManager)
                                .SelectSingleNode("ns:CpfCnpj", nsManager);

                            var identificacao = new Identificacao();
                            identificacao.Cnpj = GetNodeValue(CpfCnpjNode, "ns:Cnpj");
                            tomador.Identificacao = identificacao;

                            XmlNode enderecoPrestadorNode = TomadorNode.SelectSingleNode("ns:Endereco", nsManager);
                            if (enderecoPrestadorNode != null)
                            {
                                var endereco = new Endereco();
                                endereco.Logradouro = GetNodeValue(enderecoPrestadorNode, "ns:Endereco");
                                endereco.NumeroEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Numero");
                                endereco.ComplementoEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Complemento");
                                endereco.BairroEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Bairro");
                                endereco.CodigoMunicipioEndereco = GetNodeValue(enderecoPrestadorNode, "ns:CodigoMunicipio");
                                endereco.UfEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Uf");
                                endereco.CepEndereco = GetNodeValue(enderecoPrestadorNode, "ns:Cep");

                                tomador.Endereco = endereco;
                            }

                            XmlNode ContatoNode = TomadorNode.SelectSingleNode("ns:Contato", nsManager);
                            if (ContatoNode != null)
                            {
                                var contato = new Contato();
                                contato.Telefone = GetNodeValue(ContatoNode, "ns:Telefone");
                                contato.Email = GetNodeValue(ContatoNode, "ns:Email");

                                tomador.Contato = contato;
                            }

                            infDeclaracaoPrestacaoServico.Tomador = tomador;
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

    public class Tomador
    {
        public string RazaoSocial { get; internal set; }
        public Identificacao Identificacao { get; internal set; }
        public Endereco Endereco { get; internal set; }
        public Contato Contato { get; internal set; }
    }

    public class Servico
    {
        public string IssRetido { get; internal set; }
        public string ItemListaServico { get; internal set; }
        public string CodigoCnae { get; internal set; }
        public string CodigoTributacaoMunicipio { get; internal set; }
        public string Discriminacao { get; internal set; }
        public string CodigoMunicipio { get; internal set; }
        public string ExigibilidadeISS { get; internal set; }
        public string MunicipioIncidencia { get; internal set; }
    }

    public class InfNfse
    {
        public string Numero { get; internal set; }
        public string CodigoVerificacao { get; internal set; }
        public string DataEmissao { get; internal set; }
        public string OutrasInformacoes { get; internal set; }
        public PrestadorServico PrestadorServico { get; internal set; }
        public OrgaoGerador OrgaoGerador { get; internal set; }
        public ValoresNfse ValoresNfse { get; internal set; }
    }

    public class ValoresNfse
    {
        public string BaseCalculo { get; internal set; }
        public string Aliquota { get; internal set; }
        public string ValorIss { get; internal set; }
        public string ValorLiquidoNfse { get; internal set; }
    }

    public class PrestadorServico
    {
        public string RazaoSocialPrestador { get; internal set; }
        public string NomeFantasiaPrestador { get; internal set; }
        public Identificacao Identificacao { get; internal set; }
        public Endereco Endereco { get; internal set; }
        public Contato Contato { get; internal set; }
    }

    public class OrgaoGerador
    {
        public string CodigoMunicipio { get; internal set; }
        public string Uf { get; internal set; }
    }

    public class Contato
    {
        public string Telefone { get; internal set; }
        public string Email { get; internal set; }
    }

    public class Identificacao
    {
        public string Cnpj { get; internal set; }
        public string InscricaoMunicipal { get; internal set; }
    }

    public class Endereco
    {
        public string Logradouro { get; internal set; }
        public string NumeroEndereco { get; internal set; }
        public string ComplementoEndereco { get; internal set; }
        public string BairroEndereco { get; internal set; }
        public string CodigoMunicipioEndereco { get; internal set; }
        public string UfEndereco { get; internal set; }
        public string CepEndereco { get; internal set; }
    }

    public class InfDeclaracaoPrestacaoServico
    {
        public string Competencia { get; internal set; }
        public string RegimeEspecialTributacao { get; internal set; }
        public string OptanteSimplesNacional { get; internal set; }
        public string IncentivoFiscal { get; internal set; }
        public Servico Servico { get; internal set; }
        public Identificacao Prestador { get; internal set; }
        public Tomador Tomador { get; internal set; }
    }
}
