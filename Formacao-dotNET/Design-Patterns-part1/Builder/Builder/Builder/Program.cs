using Builder;

var itens = new List<ItemDaNota>();
double valorTotal = 0;

foreach (var item in itens)
{
    valorTotal += item.Valor;
}

double impostos = valorTotal * 0.05;

NotaFiscal nf = new NotaFiscal("razao", "cnpj", DateTime.Now, valorTotal, impostos, itens, "Obs qualquer");