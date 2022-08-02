using Adapter.Cap8;

Cliente cliente = new Cliente();

cliente.Nome = "Vitor";
cliente.Endereco = "Teste";
cliente.DataDeNascimento = DateTime.Now;

string xml = new GeradorXml().GeraXml(cliente);

Console.WriteLine(xml);