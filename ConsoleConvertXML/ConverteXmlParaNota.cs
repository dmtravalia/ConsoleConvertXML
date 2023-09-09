using System.Collections.Generic;
using System.Xml;

namespace ConsoleConvertXML
{
    public class ConverteXmlParaNota
    {
        private XmlDocument xmlDoc;
        private XmlNamespaceManager nsManager;

        public (InfNfse infNfse, List<MensagemRetorno> mensagens) Convert(string xml)
        {
            using (var xmlReader = new XmlTextReader(xml, XmlNodeType.Element, null))
            {
                xmlReader.WhitespaceHandling = WhitespaceHandling.None;

                xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlReader);

                nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
                nsManager.AddNamespace("ns", "http://www.abrasf.org.br/nfse.xsd");

                var infNfseNode = xmlDoc.SelectSingleNode("//ns:InfNfse", nsManager);
                if (infNfseNode != null)
                {
                    var infNfse = new InfNfse();
                    infNfse.Numero = GetNodeValue(infNfseNode, "ns:Numero");
                    infNfse.CodigoVerificacao = GetNodeValue(infNfseNode, "ns:CodigoVerificacao");
                    infNfse.DataEmissao = GetNodeValue(infNfseNode, "ns:DataEmissao");
                    infNfse.OutrasInformacoes = GetNodeValue(infNfseNode, "ns:OutrasInformacoes");

                    XmlNode valoresNfseNode = infNfseNode.SelectSingleNode("ns:ValoresNfse", nsManager);
                    if (valoresNfseNode != null)
                    {
                        var valoresNfse = new ValoresNfse();
                        valoresNfse.BaseCalculo = GetNodeValue(valoresNfseNode, "ns:BaseCalculo");
                        valoresNfse.Aliquota = GetNodeValue(valoresNfseNode, "ns:Aliquota");
                        valoresNfse.ValorIss = GetNodeValue(valoresNfseNode, "ns:ValorIss");
                        valoresNfse.ValorLiquidoNfse = GetNodeValue(valoresNfseNode, "ns:ValorLiquidoNfse");

                        infNfse.ValoresNfse = valoresNfse;
                    }

                    XmlNode prestadorServicoNode = infNfseNode.SelectSingleNode("ns:PrestadorServico", nsManager);
                    if (prestadorServicoNode != null)
                    {
                        var prestadorServico = new PrestadorServico();
                        prestadorServico.RazaoSocialPrestador = GetNodeValue(prestadorServicoNode, "ns:RazaoSocial");
                        prestadorServico.NomeFantasiaPrestador = GetNodeValue(prestadorServicoNode, "ns:NomeFantasia");

                        var identificacaoPrestadorNode = prestadorServicoNode.SelectSingleNode("ns:IdentificacaoPrestador", nsManager);
                        if (identificacaoPrestadorNode != null)
                        {
                            var identificacao = new Identificacao();

                            var CpfCnpjNode = identificacaoPrestadorNode.SelectSingleNode("ns:CpfCnpj", nsManager);
                            if (CpfCnpjNode != null)
                                identificacao.Cnpj = GetNodeValue(CpfCnpjNode, "ns:Cnpj");

                            identificacao.InscricaoMunicipal = GetNodeValue(identificacaoPrestadorNode, "ns:InscricaoMunicipal");

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

                        XmlNode contatoNode = prestadorServicoNode.SelectSingleNode("ns:Contato", nsManager);
                        if (contatoNode != null)
                        {
                            var contato = new Contato();
                            contato.Telefone = GetNodeValue(contatoNode, "ns:Telefone");
                            contato.Email = GetNodeValue(contatoNode, "ns:Email");

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

                    XmlNode infDeclaracaoPrestacaoServicoNode = infNfseNode.SelectSingleNode("ns:DeclaracaoPrestacaoServico", nsManager)
                        .SelectSingleNode("ns:InfDeclaracaoPrestacaoServico", nsManager);
                    if (infDeclaracaoPrestacaoServicoNode != null)
                    {
                        var infDeclaracaoPrestacaoServico = new InfDeclaracaoPrestacaoServico();
                        infDeclaracaoPrestacaoServico.Competencia = GetNodeValue(infDeclaracaoPrestacaoServicoNode, "ns:Competencia");
                        infDeclaracaoPrestacaoServico.RegimeEspecialTributacao = GetNodeValue(infDeclaracaoPrestacaoServicoNode, "ns:RegimeEspecialTributacao");
                        infDeclaracaoPrestacaoServico.OptanteSimplesNacional = GetNodeValue(infDeclaracaoPrestacaoServicoNode, "ns:OptanteSimplesNacional");
                        infDeclaracaoPrestacaoServico.IncentivoFiscal = GetNodeValue(infDeclaracaoPrestacaoServicoNode, "ns:IncentivoFiscal");

                        XmlNode servicoNode = infDeclaracaoPrestacaoServicoNode.SelectSingleNode("ns:Servico", nsManager);
                        if (servicoNode != null)
                        {
                            var servico = new Servico();
                            servico.IssRetido = GetNodeValue(servicoNode, "ns:IssRetido");
                            servico.ItemListaServico = GetNodeValue(servicoNode, "ns:ItemListaServico");
                            servico.CodigoCnae = GetNodeValue(servicoNode, "ns:CodigoCnae");
                            servico.CodigoTributacaoMunicipio = GetNodeValue(servicoNode, "ns:CodigoTributacaoMunicipio");
                            servico.Discriminacao = GetNodeValue(servicoNode, "ns:Discriminacao");
                            servico.CodigoMunicipio = GetNodeValue(servicoNode, "ns:CodigoMunicipio");
                            servico.ExigibilidadeISS = GetNodeValue(servicoNode, "ns:ExigibilidadeISS");
                            servico.MunicipioIncidencia = GetNodeValue(servicoNode, "ns:MunicipioIncidencia");

                            infDeclaracaoPrestacaoServico.Servico = servico;
                        }

                        XmlNode prestadorNode = infDeclaracaoPrestacaoServicoNode.SelectSingleNode("ns:Prestador", nsManager);
                        if (prestadorNode != null)
                        {
                            var identificacao = new Identificacao();
                            XmlNode CpfCnpjNode = prestadorNode.SelectSingleNode("ns:CpfCnpj", nsManager);
                            identificacao.Cnpj = GetNodeValue(CpfCnpjNode, "ns:Cnpj");
                            identificacao.InscricaoMunicipal = GetNodeValue(prestadorNode, "ns:InscricaoMunicipal");

                            infDeclaracaoPrestacaoServico.Prestador = identificacao;
                        }

                        XmlNode tomadorNode = infDeclaracaoPrestacaoServicoNode.SelectSingleNode("ns:Tomador", nsManager);
                        if (tomadorNode != null)
                        {
                            var tomador = new Tomador();

                            tomador.RazaoSocial = GetNodeValue(tomadorNode, "ns:RazaoSocial");
                            XmlNode CpfCnpjNode = tomadorNode.SelectSingleNode("ns:IdentificacaoTomador", nsManager)
                                .SelectSingleNode("ns:CpfCnpj", nsManager);

                            var identificacao = new Identificacao();
                            identificacao.Cnpj = GetNodeValue(CpfCnpjNode, "ns:Cnpj");
                            tomador.Identificacao = identificacao;

                            XmlNode enderecoPrestadorNode = tomadorNode.SelectSingleNode("ns:Endereco", nsManager);
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

                            XmlNode contatoNode = tomadorNode.SelectSingleNode("ns:Contato", nsManager);
                            if (contatoNode != null)
                            {
                                var contato = new Contato();
                                contato.Telefone = GetNodeValue(contatoNode, "ns:Telefone");
                                contato.Email = GetNodeValue(contatoNode, "ns:Email");

                                tomador.Contato = contato;
                            }

                            infDeclaracaoPrestacaoServico.Tomador = tomador;
                        }
                    }

                    return (infNfse, default);
                }

                var mensagemRetornoNodes = xmlDoc.SelectNodes("//ns:MensagemRetorno", nsManager);
                if (mensagemRetornoNodes != null)
                {
                    var mensagemRetornos = new List<MensagemRetorno>();
                    foreach (XmlNode mensagemRetornoNode in mensagemRetornoNodes)
                    {
                        var mensagemRetorno = new MensagemRetorno();
                        mensagemRetorno.Codigo = GetNodeValue(mensagemRetornoNode, "ns:Codigo");
                        mensagemRetorno.Mensagem = GetNodeValue(mensagemRetornoNode, "ns:Mensagem");
                        mensagemRetorno.Correcao = GetNodeValue(mensagemRetornoNode, "ns:Correcao");

                        mensagemRetornos.Add(mensagemRetorno);
                    }

                    return (default, mensagemRetornos);
                }

                return (default, default);
            }
        }

        private string GetNodeValue(XmlNode parentNode, string nodeName)
        {
            XmlNode node = parentNode.SelectSingleNode(nodeName, nsManager);
            return (node != null) ? node.InnerText : string.Empty;
        }
    }

    public class MensagemRetorno
    {
        public string Codigo { get; set; }
        public string Mensagem { get; set; }
        public string Correcao { get; set; }
    }

    public class Tomador
    {
        public string RazaoSocial { get; set; }
        public Identificacao Identificacao { get; set; }
        public Endereco Endereco { get; set; }
        public Contato Contato { get; set; }
    }

    public class Servico
    {
        public string IssRetido { get; set; }
        public string ItemListaServico { get; set; }
        public string CodigoCnae { get; set; }
        public string CodigoTributacaoMunicipio { get; set; }
        public string Discriminacao { get; set; }
        public string CodigoMunicipio { get; set; }
        public string ExigibilidadeISS { get; set; }
        public string MunicipioIncidencia { get; set; }
    }

    public class InfNfse
    {
        public string Numero { get; set; }
        public string CodigoVerificacao { get; set; }
        public string DataEmissao { get; set; }
        public string OutrasInformacoes { get; set; }
        public PrestadorServico PrestadorServico { get; set; }
        public OrgaoGerador OrgaoGerador { get; set; }
        public ValoresNfse ValoresNfse { get; set; }
    }

    public class ValoresNfse
    {
        public string BaseCalculo { get; set; }
        public string Aliquota { get; set; }
        public string ValorIss { get; set; }
        public string ValorLiquidoNfse { get; set; }
    }

    public class PrestadorServico
    {
        public string RazaoSocialPrestador { get; set; }
        public string NomeFantasiaPrestador { get; set; }
        public Identificacao Identificacao { get; set; }
        public Endereco Endereco { get; set; }
        public Contato Contato { get; set; }
    }

    public class OrgaoGerador
    {
        public string CodigoMunicipio { get; set; }
        public string Uf { get; set; }
    }

    public class Contato
    {
        public string Telefone { get; set; }
        public string Email { get; set; }
    }

    public class Identificacao
    {
        public string Cnpj { get; set; }
        public string InscricaoMunicipal { get; set; }
    }

    public class Endereco
    {
        public string Logradouro { get; set; }
        public string NumeroEndereco { get; set; }
        public string ComplementoEndereco { get; set; }
        public string BairroEndereco { get; set; }
        public string CodigoMunicipioEndereco { get; set; }
        public string UfEndereco { get; set; }
        public string CepEndereco { get; set; }
    }

    public class InfDeclaracaoPrestacaoServico
    {
        public string Competencia { get; set; }
        public string RegimeEspecialTributacao { get; set; }
        public string OptanteSimplesNacional { get; set; }
        public string IncentivoFiscal { get; set; }
        public Servico Servico { get; set; }
        public Identificacao Prestador { get; set; }
        public Tomador Tomador { get; set; }
    }
}
