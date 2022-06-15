﻿using System;
using System.Globalization;

namespace DiagnosticoPrevio
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ///Declaração das Variáveis
            int idade;
            double imc, altura, peso;
            string nome, sexo, loop, categoria = null, riscos = null, recomendacoes = null, categoriaImc = null;
            bool valido; //Declaração de variável utilizada para validação de dados

            do
            {
                //Obtenção dos Dados:
                do
                {
                    //Obtenção do Nome:
                    Console.Write("\n\tOlá! Bem vindo(a) ao programa de Diagnóstico Prévio do nutricionista Luciano!\n\n" +
                                      "\tPara começarmos, por favor insira seu nome: "); //O "\n" quebra a linha de impressão no console
                                                                                         //O "\t" adiciona um recuo à esquerda na impressão
                    nome = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(nome))
                    {
                        Console.Clear();
                        Console.Write("\n\tPoxa, infelizmente este não é um nome válido...\n\n\tTente novamente: ");
                        nome = Console.ReadLine();
                    }

                    Console.Clear();

                    //Obtenção do Sexo:
                    Console.Write($"\n\tBem vindo(a), {nome}! Por favor, insira seu sexo (M/F): ");
                    sexo = Console.ReadLine();
                    sexo = sexo.ToUpper(); //Coloca a string "sexo" em caixa alta para tornar indiferente a escolha entre
                                           //a inserção de letras minúsculas ou maiúsculas, dando mais liberdade ao usuário

                    //Validação do Caracter indicativo do Sexo:
                    while (sexo != "M" && sexo != "F")
                    {
                        Console.Clear();
                        Console.Write("\n\tDesculpe, não consegui entender qual é o seu sexo.\n\n\tInsira novamente (M para Masculino" +
                                      " e F para Feminino): ");
                        sexo = Console.ReadLine();
                        sexo = sexo.ToUpper();
                    }

                    //Atribuição do nome completo do Sexo:
                    if (sexo == "M") { sexo = "Masculino"; }

                    if (sexo == "F") { sexo = "Feminino"; }


                    //Obtenção da Idade:
                    Console.Write("\n\tPara darmos continuidade, insira a sua idade em anos (máximo: 125): ");
                    valido = int.TryParse(Console.ReadLine(), out idade);

                    //Validação da Idade (Invalidadando idades negativas, não inteiras ou superiores a 125 (idade máxima que o ser humano
                    //consegue viver segundo cientistas)):
                    while (valido == false || idade <= 0 || idade > 125)
                    {
                        Console.Clear();
                        Console.Write("\n\tDesculpe, não consegui entender a sua idade. Lembre de digitá-la em anos completos! \n\t(apenas valores positivos, máximo: 125)\n\n\tInsira novamente: ");
                        valido = int.TryParse(Console.ReadLine(), out idade);
                    }


                    //Obtenção do Peso:
                    Console.Write("\n\tÓtimo! Por gentileza, agora insira o seu peso em Kg (máximo: 600): ");
                    valido = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out peso);
                                                                                                         //Replace juntamente com o NumberStyles.Number
                                                                                                         //possibilitam a inserção de valores decimais
                                                                                                         //com ponto ou vírgula. O InvariantCulture desconsidera
                                                                                                         //a língua do sistema utilizado, considerando apenas a
                                                                                                         //padrão (inglês)

                    //Validação do Peso (Invalidadando não números, pesos negativos e nulos ou superiores a 600 (valor um pouco superior
                    //ao máximo registrado pelo ser humano)):
                    while (valido == false || peso <= 0 || peso > 600)
                    {
                        Console.Clear();
                        Console.Write("\n\tDesculpe, não consegui entender o seu peso. Lembre de digitá-lo em Kg! \n\t(apenas valores positivos, máximo: 600)\n\n\tInsira novamente: ");
                        valido = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out peso);
                    }


                    //Obtenção da Altura:
                    Console.Write("\n\tPara finalizarmos, por favor insira a sua altura em metros (máximo: 2,6): ");
                    valido = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out altura);

                    //Validação da Altura (Invalidando não números, alturas negativas e nulas ou superiores a 2.6 (valor um pouco superior
                    //ao máximo registrado pelo ser humano):
                    while (valido == false || altura <= 0 || altura > 2.6)
                    {
                        Console.Clear();
                        Console.Write("\n\tDesculpe, não consegui entender a sua altura. Lembre de digitá-la em metros! \n\t(apenas valores positivos, máximo: 2,6)\n\n\tInsira novamente: ");
                        valido = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out altura);
                    }

                    Console.Clear();

                    //Opção de revisar e reinserir os dados caso haja algum erro durante o fornecimento dos mesmos
                    Console.Write($"\n\tDADOS:" +
                                  $"\n\n\tNome: {nome}" +
                                  $"\n\tSexo: {sexo}" +
                                  $"\n\tIdade: {idade}" +
                                  $"\n\tPeso: {peso}" +
                                  $"\n\tAltura: {altura}" +
                                  $"\n\n\tConfirmar dados (S/N)? ");

                    
                    loop = Console.ReadLine();
                    loop = loop.ToUpper(); //Coloca a string "loop" em caixa alta para tornar indiferente a escolha entre
                                           //a inserção de letras minúsculas ou maiúsculas, dando mais liberdade ao usuário

                    //Validação do Caracter indicativo do loop para reinserção de dados:
                    while (loop != "S" && loop != "N")
                    {
                        Console.Write("\n\tDesculpe, não consegui entender a sua escolha.\n\n\tInsira novamente (S/N): ");
                        loop = Console.ReadLine();
                        loop = loop.ToUpper();
                    }

                    Console.Clear();

                } while(loop == "N");


                //Definição da Categoria do Paciente:
                categoria = Categoria(idade); //Função Categoria recebe a idade para definir a categoria do paciente


                //Cálculo do IMC:
                imc = Imc(altura, peso); //Função Imc recebe os valores de altura e peso para calcular o IMC


                //Definição dos Riscos, Recomendações e Categoria do IMC com base no IMC: 

                riscos = Riscos(imc); //Função Riscos recebe o valor do IMC para definir os riscos a serem exibidos

                recomendacoes = Recomendacoes(imc); //Função Recomendacoes recebe o valor do IMC para definir as recomendações a serem exibidas

                categoriaImc = CategoriaImc(imc); //Função CategoriaImc recebe o valor do IMC para definir a categoria do IMC a ser exibida


                Console.WriteLine("\n\tDIAGNÓSTICO PRÉVIO\n");
                Console.WriteLine($"\tNome: {nome}\n" +
                                  $"\tSexo: {sexo}\n" +
                                  $"\tIdade: {idade}\n" +
                                  $"\tAltura: {altura}\n" +
                                  $"\tPeso: {peso}\n" +
                                  $"\tCategoria: {categoria}\n\n");

                Console.WriteLine($"\tIMC Desejável: entre 20 e 24\n\n" +
                                  $"\tResultado IMC: {Math.Round(imc, 2)}" + " - " + $"{categoriaImc}\n\n" +
                                  $"\tRiscos: {riscos}\n\n" +
                                  $"\tRecomendações: {recomendacoes}\n\n");


                //Opção de realizar um novo diagnóstico prévio com a inserção de novos dados
                Console.Write("\n\n\tDeseja inserir novos dados para diagnóstico prévio(S/N)? ");
                loop = Console.ReadLine();
                loop = loop.ToUpper(); //Coloca a string "loop" em caixa alta para tornar indiferente a escolha entre
                                       //a inserção de letras minúsculas ou maiúsculas, dando mais liberdade ao usuário

                //Validação do Caracter indicativo do loop:
                while (loop != "S" && loop != "N")
                {
                    Console.Write("\n\tDesculpe, não consegui entender a sua escolha.\n\n\tInsira novamente (S/N): ");
                    loop = Console.ReadLine();
                    loop = loop.ToUpper();
                }

                Console.Clear();
               
            } while (loop == "S");

            Console.Clear();
            Console.WriteLine("\n\tObrigado pela preferência!\n\n\tAté mais e siga com saúde!\n\n");
                        
        }
            static double Imc(double altura, double peso)
            {
                double imc = peso / Math.Pow(altura, 2);
                
                return imc;
            }

            static string Riscos(double imc)
            {
                string risks = null;

                if (imc > 35){ risks = "O obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas."; }

                if (imc <= 35 && imc > 30){ risks = "Quem tem obesidade vai estar mais exposto a doenças graves \n\te ao risco de " +
                                                       "mortalidade.";}            
                
                if (imc <= 30 && imc > 24){ risks = "Aumento de peso apresenta risco moderado para outras \n\tdoenças crônicas e " +
                                                      "cardiovasculares.";}

                if (imc <= 24 && imc >= 20) { risks = "Seu peso está ideal para suas referências.";}                  
                
                if (imc < 20){ risks = "Muitas complicações de saúde como doenças pulmonares e cardiovasculares \n\tpodem estar " +
                                         "associadas ao baixo peso. ";}                    
                
                return risks;
            }

            static string Recomendacoes(double imc)
            {
                string recom = null;

                if (imc > 35){ recom = "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação \n\t" +
                                                "alimentar, um psicólogo e um médico especialista(endócrino).";}                  
                
                if (imc <= 35 && imc > 30){ recom = "Adote uma dieta alimentar rigorosa, com o acompanhamento de um " +
                                                            "nutricionista \n\te um médico especialista(endócrino).";}                

                if (imc <= 30 && imc > 24){ recom = "Adote um tratamento baseado em dieta balanceada, exercício físico e " +
                                                            "medicação. \n\tA ajuda de um profissional pode ser interessante";}

                if (imc <= 24 && imc >= 20) { recom = "Mantenha uma dieta saudável e faça seus exames periódicos."; }
                               

                if (imc < 20){recom = "Inclua carboidratos simples em sua dieta, \n\talém de proteínas - indispensáveis para " +
                                                "ganho de massa magra. Procure um profissional.";}

                return recom;
            }

            static string CategoriaImc(double imc)
            {
                string catImc = null;

                if (imc > 35) { catImc = "Super Obesidade"; }

                if (imc <= 35 && imc > 30) { catImc = "Obesidade"; }

                if (imc <= 30 && imc > 24) { catImc = "Excesso de Peso"; }

                if (imc <= 24 && imc >= 20) { catImc = "Peso Normal"; }

                if (imc < 20) { catImc = "Abaixo do Peso Ideal"; }

                return catImc;
            }

            static string Categoria(int idade)
            {
                string cat = null;

                if (idade > 65) { cat = "Idoso"; }
                if (idade >= 21 && idade <= 65) { cat = "Adulto"; }
                if (idade >= 12 && idade <= 20) { cat = "Juvenil"; }
                if (idade < 12) { cat = "Infantil"; }

                return cat;
            }

    }
}
