using FacadeAndSingleton.Cap9;

string cpf = "1234";

EmpresaFacade facade = new EmpresaFacadeSingleton().Instancia;
Cliente cliente = facade.BuscaCliente(cpf);

var fatura = facade.CriaFatura(cliente, 5000);
facade.GeraCobranca(Tipo.Boleto, fatura);