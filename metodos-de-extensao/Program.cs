Pessoa[] mundo = new Pessoa[6];
mundo[0] = new Pessoa("Leonardo Falango", 18);
mundo[1] = new Pessoa("chatao do meu lado aqui", 19);
mundo[2] = new Pessoa("podres", 20);
mundo[3] = new Pessoa("known", 18);
mundo[4] = new Pessoa("vem ni mim", 18);
mundo[5] = new Pessoa("murilo", 18);
mundo[5] = new Pessoa("Leonardão Véio", 98);


// foreach (var x in mundo.Where(p => p.Idade == 18)) Console.WriteLine(x);
// foreach (var x in mundo.Where(p => p.Idade == 19)) Console.WriteLine(x);
int maximo = mundo.Max(p => p.Idade);
Console.WriteLine(maximo);
Console.WriteLine(mundo.Average(p => p.Idade));


public class Pessoa
{
    public int Idade { get; set; }
    public string Nome { get; set; }
    public Pessoa(string nome, int idade)
    {
        this.Idade = idade;
        this.Nome = nome;
    }
}

public static class MyExtensionsMethods
{
    public static IEnumerable<R> Select<T, R>
    (
        this IEnumerable<T>  entrada, Transformador<T, R> f
    )
    {
        var it = entrada.GetEnumerator();
        while (it.MoveNext())
            yield return f(it.Current);
    }

    public delegate R Transformador<T, R>(T n);


    public static IEnumerable<T> Where<T>(
        this IEnumerable<T> coll,
        Func<T, bool> condition
    )
    {
        var it = coll.GetEnumerator();
        while (it.MoveNext())
            if (condition(it.Current))
                yield return it.Current;
    }

    public static int Max<T>(
        this IEnumerable<T> coll,
        Func<T, int> func
    )
    {
        var it = coll.GetEnumerator();
        int max = int.MinValue;
        while (it.MoveNext())
            if (max < func(it.Current)) max = func(it.Current);
        return max;
    }

    public static double Average<T>(
        this IEnumerable<T> coll,
        Func<T, int> func
    )
    {
        var it = coll.GetEnumerator();
        int soma = 0;
        int count  = 0;
        while (it.MoveNext())
        {
            soma += func(it.Current);
            count++;
        }
        return soma/count;
    }

}