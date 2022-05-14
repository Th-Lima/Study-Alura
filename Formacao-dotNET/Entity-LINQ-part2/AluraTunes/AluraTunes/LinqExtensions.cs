using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AluraTunes
{
    public static class LinqExtensions
    {
        public static decimal Mediana<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector)
        {
            var contagem = source.Count();

            var funcSelector = selector.Compile();

            var queryOrdenada = source.Select(funcSelector).OrderBy(total => total);

            var elementoCentral1 = queryOrdenada.Skip(contagem / 2).First();

            var elementoCentral2 = queryOrdenada.Skip((contagem - 1) / 2).First();

            var mediana = (elementoCentral1 + elementoCentral2) / 2;

            return mediana;
        }

        public static TSource Second<TSource>(this IEnumerable<TSource> source)
        {
            return source.Skip(1).First();
        }
    }
}
