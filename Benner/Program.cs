using System.Xml.Linq;

public class Program
{
    public static void Main()
    {
        Network network = new Network(8); //instancia a classe passando 8 elementos

        //Conexões dos elementos realizadas conforme descrito no problema
        //Executa o método Connect da classe networt
        network.Connect(1, 2);
        network.Connect(6, 2);
        network.Connect(2, 4);
        network.Connect(5, 8);

        Console.WriteLine("A conexão entre o elemento 1 e 6 é: " + network.Query(1, 6)); //Conexão existe no grafo
        Console.WriteLine("A conexão entre o elemento 6 e 4 é: " + network.Query(6, 4)); //Conexão existe no grafo
        Console.WriteLine("A conexão entre o elemento 7 e 4 é: " + network.Query(7, 4)); //Conxão falsa. 7 não tem ligação
        Console.WriteLine("A conexão entre o elemento 5 e 6 é: " + network.Query(5, 6)); //Conexão falsa. 5 e 6 não se conectam
    }
}