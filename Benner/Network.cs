using System;
using System.Collections.Generic;

public class Network
{
    private int[] parent;
    private int[] rank;
    private int tamanho;

    public Network(int numeroElemento) 
    //Construtor recebendo o valor 8 passado como parâmetro no Programa principal
    {
        if (numeroElemento <= 0)
        {
            throw new ArgumentException("O número de elementos deve ser maior que 0.");
        }

        tamanho = numeroElemento;
        parent = new int[tamanho + 1];
        rank = new int[tamanho + 1];

        for (int i = 1; i <= tamanho; i++)
        {
            parent[i] = i;
            rank[i] = 0;
        }
    }

    public void Connect(int element1, int element2)
    /*Método Connect onde recebe os 2 valores a serem conectados
     * Recebe 2 parametros inteiros
     * Faz a conexão dos números dos elementos
     */
    {
        //O número da conexão não pode ser < 0 e tambem não pode ser maior que o maior elemento do grafo (8)
        if (element1 <= 0 || element1 > tamanho || element2 <= 0 || element2 > tamanho)
        {
            throw new ArgumentException("Os elementos devem estar no intervalo válido.");
        }
        Union(element1, element2);
    }

    public bool Query(int element1, int element2) 
    /* Método público Query que verifica se os elementos estão conectados
     * Recebe 2 parametros inteiros
     * Retorna verdadeiro ou falso 
     */
    {
        //O número da conexão não pode ser < 0 e tambem não pode ser maior que o maior elemento do grafo (8)
        if (element1 <= 0 || element1 > tamanho || element2 <= 0 || element2 > tamanho)
        {
            throw new ArgumentException("Os elementos devem estar no intervalo válido.");
        }
        return Find(element1) == Find(element2);
    }

    private int Find(int element)
    //Método privado Find que verifica se os numeros estão conectados
    {
        if (parent[element] != element)
        {
            parent[element] = Find(parent[element]); 
        }
        return parent[element];
    }

    private void Union(int element1, int element2)
    //Método privado Union que faz a conexão dos elementos
    {
        int raiz1 = Find(element1);
        int raiz2 = Find(element2);

        if (raiz1 != raiz2)
        {
            if (rank[raiz1] > rank[raiz2])
            {
                parent[raiz2] = raiz1;
            }
            else if (rank[raiz1] < rank[raiz2])
            {
                parent[raiz1] = raiz2;
            }
            else
            {
                parent[raiz2] = raiz1;
                rank[raiz1]++;
            }
        }
    }
}