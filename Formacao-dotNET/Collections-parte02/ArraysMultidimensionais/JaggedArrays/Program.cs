using System;

namespace JaggedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //Familia 1: Familia Flinstones 
            //Familia 2: Familia Simpsons 
            //Familia 3: Familia Dona Florinda 

            //JAGGED ARRAY - ARRAY DENTEADO - TAMBÉM CHAMDO DE ARRAY DE ARRAYS
            //Número fixo na vertical e número indefinido na horizontal
            
            //Exemplo:
            //Fred, Wilma, Pedrita >
            //Homer, Marge, Lisa, Bart, Maggie >
            //Florinda, Kiko >

            string[][] familias = new string[3][];

            familias[0] = new string[] { "Fred", "Wilma", "Pedrita" };
            familias[1] = new string[] { "Homer", "Marge", "Lisa", "Bart", "Maggie" };
            familias[2] = new string[] { "Florinda", "Kiko" };
          
            //foreach (var familia in familias)
            //{
            //    Console.WriteLine(string.Join(",", familia));
            //}

            for (int i = 0; i < familias.Length; i++)
            {
                Console.WriteLine($"Familia {i + 1}: {string.Join(",", familias[i])}" );
            }
        }
    }
}
