using Bridges.Cap6;

// MODO DE ENVIO
//IEnviador enviadorEmail = new EnviaPorEmail();
IEnviador enviadorSMS = new EnviarPorSMS();


//Tipo da mensagem
IMensagem mensagemAdministrativa = new MensagemAdministrativa("Thales");
//mensagemAdministrativa.Enviador = enviadorEmail;
mensagemAdministrativa.Enviador = enviadorSMS;
mensagemAdministrativa.Envia();

Console.WriteLine(" ----------------------------------------------------- ");

IMensagem mensagemCliente = new MensagemDoCliente("Thales 2");

//mensagemCliente.Enviador = enviadorEmail;
mensagemCliente.Enviador = enviadorSMS;
mensagemCliente.Envia();