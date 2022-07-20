using Observer;

NotaFiscalBuilder criador = new NotaFiscalBuilder();

criador
    .ParaEmpresa("Caelum Ension e Inovacao")
    .ComCnpj("23.456.789/0001-12")
    .ComItem(new ItemDaNota("item1", 100.0))
    .ComItem(new ItemDaNota("item2", 200.0))
    .NaDataAtual()
    .ComObservacoes("Uma obs qualquer");

criador.AdicionaAcao(new EnviadorDeEmail());
criador.AdicionaAcao(new EnviadorDeSms());
criador.AdicionaAcao(new NotaFiscalDAO());

NotaFiscal nf = criador.Constroi();

Console.WriteLine(nf.ValorBruto);
Console.WriteLine(nf.Impostos);