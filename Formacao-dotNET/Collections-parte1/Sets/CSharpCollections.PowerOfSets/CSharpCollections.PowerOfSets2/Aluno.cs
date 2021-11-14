namespace CSharpCollections.PowerOfSets2
{
    public class Aluno
    {
        private string nome;
        private int numeroMatricula;

        public Aluno(string nome, int numeroMatricula)
        {
            this.nome = nome;
            this.numeroMatricula = numeroMatricula;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Numero
        {
            get { return numeroMatricula; }
            set { numeroMatricula = value; }
        }

        public override string ToString()
        {
            return $"[Nome: {this.nome} | Número de matrícula: {numeroMatricula}]";
        }

        public override bool Equals(object obj)
        {
            Aluno objNome = obj as Aluno;
            //var objNome = (Aluno)obj;
            
            if(objNome == null)
            {
                return false;
            }

            return this.nome.Equals(objNome.nome);        
        }

        public override int GetHashCode()
        {
            return this.nome.GetHashCode();
        }
    }
}
