using System;
using System.Threading;

namespace gerador_de_dados
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                // Consola que representa a fabricação de produtos //

                Produto produto = Produto.GerarProdutoAleatorio();
                string resultado = $"{produto.Codigo_Peca};{produto.Data_Producao:dd/MM/yyyy};{produto.Hora_Producao:hh\\:mm\\:ss};{produto.Tempo_Producao};";

                // Exibe o produto gerado
                Console.Clear();
                Console.WriteLine(resultado);

                // Aguarda x segundos antes de gerar o próximo produto
                Thread.Sleep(produto.Tempo_Producao * 1000);
            }
        }
    }
}

