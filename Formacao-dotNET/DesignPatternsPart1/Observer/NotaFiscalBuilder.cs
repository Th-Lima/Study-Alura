namespace Observer
{
    public class NotaFiscalBuilder
    {
        public string RazaoSocial { get; private set; }
        public string Cnpj { get; private set; }
        public string Observacoes { get; private set; }
        public DateTime Data { get; private set; }
        
        public double ValorTotal;
        public double Impostos;
        public List<ItemDaNota> TodosItens = new List<ItemDaNota>();

        private IList<IAcaoAposGerarUmaNota> _todasAcoesAposSeremExecutadas = new List<IAcaoAposGerarUmaNota>();
        
        public NotaFiscal Constroi()
        {
            NotaFiscal nf =  new NotaFiscal(RazaoSocial, Cnpj, Data, ValorTotal, Impostos, TodosItens, Observacoes);

            foreach (var acao in _todasAcoesAposSeremExecutadas)
            {
                acao.Executa(nf);
            }

            return nf;
        }

        public void AdicionaAcao(IAcaoAposGerarUmaNota novaAcao)
        {
            this._todasAcoesAposSeremExecutadas.Add(novaAcao);
        }

        public NotaFiscalBuilder ParaEmpresa(string razaoSocial)
        {
            this.RazaoSocial = razaoSocial;

            return this;
        }

        public NotaFiscalBuilder ComObservacoes(string observacoes)
        {
            this.Observacoes = observacoes;

            return this;
        }

        public NotaFiscalBuilder NaDataAtual()
        {
            this.Data = new DateTime();

            return this;
        }

        public NotaFiscalBuilder ComCnpj(string cnpj)
        {
            this.Cnpj = cnpj;

            return this;
        }

        public NotaFiscalBuilder ComItem(ItemDaNota item)
        {
            TodosItens.Add(item);
            ValorTotal += item.Valor;
            Impostos += item.Valor * 0.05;

            return this;
        }
    }
}
