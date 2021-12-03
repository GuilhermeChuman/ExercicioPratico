using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ExercicioPratico
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com um exercicio(2/3/4/5). Caso deseje encerrar o programa digite 0:");
            string response = Console.ReadLine();

            switch (response)
            {
                case "0":                    
                    break;

                case "1":
                    Console.Out.WriteLine("");
                    exercicio1();
                    Main(null);
                    break;

                case "2":
                    Console.Out.WriteLine("");
                    exercicio2();
                    Main(null);
                    break;

                case "3":
                    Console.Out.WriteLine("");
                    exercicio3();
                    Main(null);
                    break;

                case "4":
                    Console.Out.WriteLine("");
                    exercicio4();
                    Main(null);
                    break;

                case "5":
                    Console.Out.WriteLine("");
                    exercicio5();
                    Main(null);
                    break;

                default :

                    Console.Out.WriteLine("Opção Inválida!");
                    Console.WriteLine("");
                    Main(null);
                    break;
            }         
        }

        public static void exercicio1()
        {
            Console.WriteLine("EXERCÍCIO 1");
            Console.Write("Somatória de 1 a 13: ");

            int index = 13;
            int soma = 0;
            int k = 0;

            while(k < index)
            {
                k = k + 1;
                soma = soma + k;
            }

            Console.WriteLine(soma);
            Console.WriteLine("");
        }

            public static void exercicio2()
        {
            Console.WriteLine("EXERCÍCIO 2");
            Console.Write("Entre com um valor numérico:");

            int value = 0;

            try
            {
                value = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Valor inválido!");
                Console.WriteLine("");
                exercicio2();
            }

            int valorAtual = 1;
            int valorAnterior = 0;
            int soma;
            bool contains = false;

            do
            {

                if (valorAtual == value || valorAnterior == value)
                {
                    contains = true;
                    break;
                }
                else
                {
                    soma = valorAnterior + valorAtual;
                    valorAnterior = valorAtual;
                    valorAtual = soma;

                }

            } while (valorAtual <= value);

            if (contains)
            {
                Console.WriteLine("Valor encontrado na sequência de Fibonnaci!");
                Console.WriteLine("");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Valor não encontrado na sequência de Fibonnaci!");
                Console.WriteLine("");
                Console.WriteLine("");
            }
                
        }

        public static void exercicio3()
        {
            Console.WriteLine("EXERCÍCIO 3");
            Console.WriteLine("");

            StreamReader r = new StreamReader("dados.json");
            string jsonString = r.ReadToEnd();
            FaturaDiaria[] dados = JsonConvert.DeserializeObject<FaturaDiaria[]>(jsonString);

            float menor = float.Parse(dados[0].valor.Replace(".", ","));
            float maior = float.Parse(dados[0].valor.Replace(".", ","));
            float media = 0;
            int counter = 0;

            foreach (var item in dados)
                media = media + float.Parse(item.valor.Replace(".", ","));

            media = media / dados.Length;

            foreach (var item in dados)
            {
                if (float.Parse(item.valor.Replace(".", ",")) <= menor)
                    menor = float.Parse(item.valor.Replace(".",","));

                if (float.Parse(item.valor.Replace(".", ",")) >= maior)
                    maior = float.Parse(item.valor.Replace(".", ","));

                if (float.Parse(item.valor.Replace(".", ",")) > media)
                    counter++;
            }

            Console.WriteLine("Menor Faturamento: R$" + Math.Round(menor,2));
            Console.WriteLine("Maior Faturamento: R$" + Math.Round(maior,2));
            Console.WriteLine("Dias com Faturamento acima da média: "+counter);

            Console.WriteLine("");
            Console.WriteLine("");


        }

        public static void exercicio4()
        {
            Console.WriteLine("EXERCÍCIO 4");
            Console.WriteLine("");

            string jsonData = @"[
                {
                    'estado':'SP',
                    'valor':'67.836,43',
                },
                {
                    'estado':'RJ',
                    'valor':'36.678,66',
                },
                {
                    'estado':'MG',
                    'valor':'29.229,88',
                },
                {
                    'estado':'ES',
                    'valor':'27.165,48',
                },
                {
                    'estado':'Outros',
                    'valor':'19.849,53',
                } 
            ]";

            FaturamentoDistribuidora[] dados = JsonConvert.DeserializeObject<FaturamentoDistribuidora[]>(jsonData);

            float soma = 0;

            foreach (var item in dados)
                soma = soma + float.Parse(item.valor);

            Console.WriteLine("Faturamento total: R$" + soma);
            Console.WriteLine("Faturamento Percentual:");

            foreach (var item in dados)
            {
                item.percentual = ((float.Parse(item.valor) / soma) * 100).ToString();
                Console.WriteLine(item.estado+"=>" + Math.Round(float.Parse(item.percentual),0)+"%");
            }

            Console.WriteLine("");
            Console.WriteLine("");
        }

        public static void exercicio5()
        {
            Console.WriteLine("EXERCÍCIO 5");
            Console.WriteLine("Entre com uma palavra:");
            
            string palavra = Console.ReadLine();
            string palavraReversa = "";

            for (int i = palavra.Length; i >= 1; i--)
                palavraReversa = palavraReversa + palavra[i-1];

            Console.WriteLine("Palavra Reversa: "+ palavraReversa);

            Console.WriteLine("");
            Console.WriteLine("");

        }

        public class FaturamentoDistribuidora
        {
            public string estado { get; set; }
            public string valor { get; set; }
            public string percentual { get; set; }
        }

        public class FaturaDiaria
        {
            public string dia { get; set; }
            public string valor { get; set; }
        }
    }
}
