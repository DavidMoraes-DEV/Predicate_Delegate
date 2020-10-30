using System;
using DelegatePredicate.Entities;
using System.Collections.Generic;

namespace DelegatePredicate
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * PREDICATE:
             - Representa um método que recebe um objeto do tipo T e retorna um valor booleano
             - EXEMPLO: public delegate bool Predicate<in T>(T obj);
             - Então o Predicate é um delegate que recebe um objeto qualquer do tipo "T" e retorna um valor booleano.
             
             * Problema exemplo
            - Fazer um programa que, a partir de uma lista de produtos, remova da lista somente aqueles cujo preço mínimo seja 100.
             */

            List<Product> list = new List<Product>();

            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            Console.WriteLine("List original:");
            foreach (Product p in list)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine();

            list.RemoveAll(ProductTest); //Aqui que entra o Predicate com uma função anônima (função lambda) que define. Recebendo um produto "p" e retorna um valor booleano(true, false) conforme o resultado especificado da função lambda. Nesse caso utilizamos uma função auxiliar separada e colocamos seu nome como referência no parâmetro para a função .RemoveAll, lembrando que podemos colocar uma função lambda diretamente nesse local que ficaria: .RemoveAll(p => p.Price >= 100.0) que daria o mesmo resultado.

            Console.WriteLine("List de produtos com preço menor que R$ 100.00: ");
            foreach (Product p in list)
            {
                Console.WriteLine(p); //Mostra a nova lista dos produtos
            }
        }

        public static bool ProductTest(Product p) //Função auxiliar que recebe um produto e retorna um valor booleano
        {
            return p.Price >= 100.0;
        }
    }
}
