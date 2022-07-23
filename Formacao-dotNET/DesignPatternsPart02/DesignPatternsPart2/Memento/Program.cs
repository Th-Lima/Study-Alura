using Memento.Cap3;

Historico historico = new Historico();

Contrato c = new Contrato(DateTime.Now, "Thales", TipoContrato.Novo);

historico.Adiciona(c.SalvaEstado());

c.Avanca();
historico.Adiciona(c.SalvaEstado());

c.Avanca();
historico.Adiciona(c.SalvaEstado());


Console.WriteLine("Estado anterior: " + historico.Pega(1).Contrato.Tipo);
Console.WriteLine(c.Tipo);