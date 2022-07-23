using Flyweight.Cap2;

NotasMusicais notas = new NotasMusicais();

var musica = new List<INota>()
{
   notas.Pega("do"),
   notas.Pega("re"),
   notas.Pega("mi"),
   notas.Pega("fa"),
   notas.Pega("fa"),
   notas.Pega("fa"),
   notas.Pega("mi"),
   notas.Pega("mi"),
   notas.Pega("mi"),
   notas.Pega("mi"),
   notas.Pega("mi"),
   notas.Pega("re"),
   notas.Pega("mi"),
   notas.Pega("mi"),
   notas.Pega("fa"),
   notas.Pega("do"),
   notas.Pega("mi"),
   notas.Pega("fa"),
   notas.Pega("sol"),
   notas.Pega("sol"),
   notas.Pega("mi"),
   notas.Pega("fa"),
   notas.Pega("fa"),
   notas.Pega("mi"),
   notas.Pega("do"),
   notas.Pega("re"),
   notas.Pega("la"),
   notas.Pega("si"),
   notas.Pega("do"),
   notas.Pega("fa"),
   notas.Pega("la"),
};

Piano piano = new Piano();

piano.Toca(musica);

