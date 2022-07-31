using Interpreter.Cap4;
using System.Linq.Expressions;

//var esquerda = new Soma(new Soma(new Numero(1), new Numero(100)), new Numero(10));
//var direita = new Subtracao(new Numero(20), new Numero(10));

//var soma = new Soma(esquerda, direita);

//Console.WriteLine(soma.Avalia()); 


//API C#
var soma = Expression.Add(Expression.Constant(10), Expression.Constant(100));
Func<int> func = Expression.Lambda<Func<int>>(soma).Compile();

Console.WriteLine(func());