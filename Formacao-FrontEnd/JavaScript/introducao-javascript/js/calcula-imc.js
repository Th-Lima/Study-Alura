var titulo = document.querySelector(".titulo");
titulo.textContent = "Aparecida Nutricionista";

var pacientes = document.querySelectorAll(".paciente");

for(var i = 0; i < pacientes.length; i++) {

    var paciente = pacientes[i];

    var tdPeso = paciente.querySelector(".info-peso");
    var peso = tdPeso.textContent;

    var tdAltura = paciente.querySelector(".info-altura");
    var altura = tdAltura.textContent;

    var tdIMC = paciente.querySelector(".info-imc");

    var pesoValido = true;
    var alturaValida = true;

    if(peso <= 0 || peso >= 1000){
        console.log("Peso Inválido");
        pesoValido = false;
        tdIMC.textContent = "Peso Inválido";
        
        // paciente.setAttribute("class", "paciente-invalido");
        pacienteInvalido(paciente, "class", "paciente-invalido");
    }

    if(altura <= 0 || altura >= 3.00){
        console.log("Altura inválida");
        alturaValida = false;
        tdIMC.textContent = "Altura inválida";
        
        // paciente.setAttribute("class", "paciente-invalido");
        pacienteInvalido(paciente, "class", "paciente-invalido");
    }

    var imc = 0;
    if(pesoValido && alturaValida){
        imc = calculaImc(peso, altura);
        tdIMC.textContent = imc;
    }
}

function calculaImc(peso, altura){
    var imc = 0;
    imc = peso / (altura * altura);

    return imc.toFixed(2);
}

function pacienteInvalido(item, atributo, valorAtributo){
    item.setAttribute(atributo, valorAtributo);
}