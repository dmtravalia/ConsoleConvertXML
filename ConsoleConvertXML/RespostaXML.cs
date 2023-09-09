namespace ConsoleConvertXML
{
    public static class RespostaXML
    {
        public static string XmlOk = @"<?xml version=""1.0"" encoding=""utf-8""?>
<GerarNfseResposta xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://www.abrasf.org.br/nfse.xsd"">
  <ListaNfse>
    <CompNfse>
      <Nfse versao=""2.02"">
        <InfNfse Id=""NFSe202300000000004"">
          <Numero>202300000000004</Numero>
          <CodigoVerificacao>8LXP-Z4RU</CodigoVerificacao>
          <DataEmissao>2023-09-06T19:37:31.843</DataEmissao>
          <OutrasInformacoes>ISS Retido pelo Tomador.\s\nOptante do Simples Nacional.\s\n</OutrasInformacoes>
          <ValoresNfse>
            <BaseCalculo>6</BaseCalculo>
            <Aliquota>5</Aliquota>
            <ValorIss>0.3</ValorIss>
            <ValorLiquidoNfse>5.7</ValorLiquidoNfse>
          </ValoresNfse>
          <PrestadorServico>
            <IdentificacaoPrestador>
              <CpfCnpj>
                <Cnpj>27618814000140</Cnpj>
              </CpfCnpj>
              <InscricaoMunicipal>1125188</InscricaoMunicipal>
            </IdentificacaoPrestador>
            <RazaoSocial>Ricardo Santana Nascimento - ME</RazaoSocial>
            <NomeFantasia>FJ VISTORIA VEICULAR</NomeFantasia>
            <Endereco>
              <Endereco>Rua da Homologação</Endereco>
              <Numero>9999</Numero>
              <Complemento>9999</Complemento>
              <Bairro>Bairro da Homologação</Bairro>
              <CodigoMunicipio>9999999</CodigoMunicipio>
              <Uf>HM</Uf>
              <Cep>99999999</Cep>
            </Endereco>
            <Contato>
              <Telefone>7930255575</Telefone>
              <Email>fjvistoriaveicular@gmail.com</Email>
            </Contato>
          </PrestadorServico>
          <OrgaoGerador>
            <CodigoMunicipio>9999999</CodigoMunicipio>
            <Uf>HM</Uf>
          </OrgaoGerador>
          <DeclaracaoPrestacaoServico>
            <InfDeclaracaoPrestacaoServico>
              <Rps Id=""RpsCC26"">
                <IdentificacaoRps>
                  <Numero>6</Numero>
                  <Serie>CC2</Serie>
                  <Tipo>1</Tipo>
                </IdentificacaoRps>
                <DataEmissao>2023-03-28</DataEmissao>
                <Status>1</Status>
              </Rps>
              <Competencia>2023-03-01</Competencia>
              <Servico>
                <Valores>
                  <ValorServicos>6</ValorServicos>
                </Valores>
                <IssRetido>1</IssRetido>
                <ItemListaServico>1703</ItemListaServico>
                <CodigoCnae>8299799</CodigoCnae>
                <CodigoTributacaoMunicipio>1703</CodigoTributacaoMunicipio>
                <Discriminacao>Teste realizado pelo Call Center para validação do Igor.</Discriminacao>
                <CodigoMunicipio>9999999</CodigoMunicipio>
                <ExigibilidadeISS>1</ExigibilidadeISS>
                <MunicipioIncidencia>9999999</MunicipioIncidencia>
              </Servico>
              <Prestador>
                <CpfCnpj>
                  <Cnpj>27618814000140</Cnpj>
                </CpfCnpj>
                <InscricaoMunicipal>1125188</InscricaoMunicipal>
              </Prestador>
              <Tomador>
                <IdentificacaoTomador>
                  <CpfCnpj>
                    <Cnpj>64614619000179</Cnpj>
                  </CpfCnpj>
                </IdentificacaoTomador>
                <RazaoSocial>SUBSTITUTO TESTE WS</RazaoSocial>
                <Endereco>
                  <Endereco>Avenida Tonico dos Santos</Endereco>
                  <Numero>846</Numero>
                  <Complemento>Bloc2, apt7</Complemento>
                  <Bairro>Jardim Induberaba</Bairro>
                  <CodigoMunicipio>3170107</CodigoMunicipio>
                  <Uf>MG</Uf>
                  <CodigoPais>1058</CodigoPais>
                  <Cep>38040000</Cep>
                </Endereco>
                <Contato>
                  <Telefone>11111111111</Telefone>
                  <Email>flag@webiss.com</Email>
                </Contato>
              </Tomador>
              <RegimeEspecialTributacao>6</RegimeEspecialTributacao>
              <OptanteSimplesNacional>1</OptanteSimplesNacional>
              <IncentivoFiscal>2</IncentivoFiscal>
            </InfDeclaracaoPrestacaoServico>
          </DeclaracaoPrestacaoServico>
        </InfNfse>
      <Signature xmlns=""http://www.w3.org/2000/09/xmldsig#""><SignedInfo><CanonicalizationMethod Algorithm=""http://www.w3.org/TR/2001/REC-xml-c14n-20010315"" /><SignatureMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#rsa-sha1"" /><Reference URI=""#NFSe202300000000004""><Transforms><Transform Algorithm=""http://www.w3.org/2000/09/xmldsig#enveloped-signature"" /><Transform Algorithm=""http://www.w3.org/TR/2001/REC-xml-c14n-20010315"" /></Transforms><DigestMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#sha1"" /><DigestValue>DWXYs5MV1fylR654Jm6HSZeqc9c=</DigestValue></Reference></SignedInfo><SignatureValue>W6LjmiEMNGsSww9XwvOJFlpoVbv6nAhufW4aYRuTtu2ywFKQvTtl5hq/E4naVH/YPb56p+ASA1hMp8XsxzKPTkxbD12rW3cEqbzcn5uMzyKnyU/BAYrLGSVuFuWqzghHu5ca9cHVYhe6dmLxMiJPA+sJ1VoGhJ0EOUHt7wONBHkYAw42+AatilmAgNkSGV8D0yd2Tvl130X4ruhwJIJMiklTo8TbOmw2G40I6mUsHYHB5rO9pde79/XQraxcnVizti6FlZNvc2G+I3TMnofxtSgJaWok8+8mU9ig3ahWzcmuKCn6JjmAOb2bFfO/QWad7f905zFB1tmld6S0MenM3g==</SignatureValue><KeyInfo><X509Data><X509Certificate>MIIDhDCCAmwCCQDphtjCrb6skzANBgkqhkiG9w0BAQUFADCBgzELMAkGA1UEBhMCQlIxCzAJBgNVBAgTAlJKMRcwFQYDVQQHEw5SaW8gZGUgSmFuZWlybzEsMCoGA1UEChMjV2ViRmlzIFByb2Nlc3NhbWVudG8gZGUgZGFkb3MgTHRkYS4xDzANBgNVBAsTBldlYkZpczEPMA0GA1UEAxMGV2ViRmlzMB4XDTE0MTEwNzEyMTcxOVoXDTM1MDgyODEyMTcxOVowgYMxCzAJBgNVBAYTAkJSMQswCQYDVQQIEwJSSjEXMBUGA1UEBxMOUmlvIGRlIEphbmVpcm8xLDAqBgNVBAoTI1dlYkZpcyBQcm9jZXNzYW1lbnRvIGRlIGRhZG9zIEx0ZGEuMQ8wDQYDVQQLEwZXZWJGaXMxDzANBgNVBAMTBldlYkZpczCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAN15DxqK4UcfLInTmp2XsYUPp33oJB0AjazjIrdtIhwjEl+RDBORPsbn8O4Uz7xDlFa8IKaeEyMUPAZ9f7Vggv5wr+R+KKqv51gaR+qh7m1Rfa3K/mNdle/AN3gs10yuBLM8Bsu5LtUJX7yHI15aapFomMISEM9N30SwcYl/e2moARnajKocvAHUE2yUKw7gkv7rxvJNg34oq4CY/VxEhJHgvQCB/4c4f4vBApWkD+7UaUpC58DPbwStsZow+3upM6690S4/UmPmKZ6jPgiHbDLY5LPwSIp4gktULrhdKyu8sgC4Ej4Ntm1c2pefQjSfvpIPAlI8cXtO0dJJQM8gntECAwEAATANBgkqhkiG9w0BAQUFAAOCAQEAh4A/I0XYUwSA0B/tDGM/6SnG3aEXxNTllBzFgQWajozyZgNw2nSCosi9kfoea0LXGmvrzSkg7daI+rwSbvb6/sLN+vZXr96+6z7+NdAAhWnYuG4MDkgZTLua7mQ+rqBgkL6XyGYigrcYJg+IMO2884idnU4MijfcvIr1aQsKQFNAnXLXz28gESppGbH3teXHahFm1pJUQFQhn4no+p6I0F2QLDam0I2agPzM2DjU0lULPnHGwgc1tzYNfKsFw3UcrAVnp3dKh2dnxTvmMGrgToh0+RG/3sdpDjDYBnwA/OATIIGWhYhc05LYN8wCxLzhpRBM6ocvrXm3KEDj674/YA==</X509Certificate></X509Data></KeyInfo></Signature></Nfse>
    </CompNfse>
  </ListaNfse>
</GerarNfseResposta>";

        public static string XmlFalha = @"<?xml version=""1.0"" encoding=""utf-8""?>
<GerarNfseResposta xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://www.abrasf.org.br/nfse.xsd"">
  <ListaMensagemRetorno>
    <MensagemRetorno>
      <Codigo>L000</Codigo>
      <Mensagem>Erro ao criar rascunho da nota fiscal.</Mensagem>
      <Correcao>---</Correcao>
    </MensagemRetorno>
    <MensagemRetorno>
      <Codigo>E10 </Codigo>
      <Mensagem>RPS já informado. </Mensagem>
      <Correcao>Para essa Inscrição Municipal/CNPJ já existe um RPS informado com o mesmo número, série e tipo.</Correcao>
    </MensagemRetorno>
  </ListaMensagemRetorno>
</GerarNfseResposta>";
    }
}
