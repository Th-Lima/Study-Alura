using Alura.Filmes.App.Negocio;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Filmes.App.Extensions
{
    public static class ClassificacaoEnumExtensions
    {
        private static Dictionary<string, ClassificacaoEnum> mapa = new Dictionary<string, ClassificacaoEnum>
        {
            { "G", ClassificacaoEnum.Livre },
            { "PG", ClassificacaoEnum.MaioresQue10Anos },
            { "PG-13", ClassificacaoEnum.MaioresQue13Anos },
            { "R", ClassificacaoEnum.MaioresQue14Anos },
            { "NC-17", ClassificacaoEnum.MaioresQue18Anos }
        };

        public static string FromEnumToString(this ClassificacaoEnum value)
        {
            return mapa.First(x => x.Value == value).Key;
        }

        public static ClassificacaoEnum FromStringToEnum(this string value)
        {
            return mapa.First(x => x.Key == value).Value;
        }
    }
}
