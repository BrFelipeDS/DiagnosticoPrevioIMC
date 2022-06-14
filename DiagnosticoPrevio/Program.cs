using System;

namespace DiagnosticoPrevio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int idade;
            double imc, altura, peso;
            string nome, sexo, categoria = null, riscos=null, recomendacoes=null, categoriaImc=null;
            
            //Obtenção dos Dados:

            //Obtenção do Nome:
            Console.Write("Olá! Bem vindo(a) ao programa de Diagnóstico Prévio do nutricionista Luciano!\n\n" +
                              "Para começarmos, por favor insira seu nome: ");
            nome = Console.ReadLine();

            //Obtenção do Sexo:
            Console.Write($"\nBem vindo(a), {nome}! Por favor, insira seu sexo (M/F): ");
            sexo = Console.ReadLine();

            //Validação do Caracter indicativo do Sexo:
            while (sexo.ToUpper() != "M" && sexo.ToUpper() != "F")
            {                          
                Console.Write("\nDesculpe, não consegui entender qual é o seu sexo. Insira novamente (M/F): ");
                sexo = Console.ReadLine();
            }
            
            //Atribuição do nome completo do Sexo:
            if (sexo.ToUpper() == "M")
            {
                sexo = "Masculino";
            }
            else if (sexo.ToUpper() == "F")
            {
                sexo = "Feminino";
            }

            //Obtenção da Idade:
            Console.Write("\nPara darmos continuidade, insira a sua idade em anos: ");
            idade = Math.Abs(Convert.ToInt32(Console.ReadLine()));

            //Obtenção do Peso:
            Console.Write("\nÓtimo! Por gentileza, agora insira o seu peso em Kg: ");
            peso = double.Parse(Console.ReadLine());

            //Obtenção da Altura:
            Console.Write("\nPara finalizarmos, por favor insira a sua altura em metros: ");
            altura = double.Parse(Console.ReadLine());

            //Definição da Categoria do Paciente:
            if(idade > 65) { categoria = "Idoso"; }
            if(idade >= 21 && idade <= 65) { categoria = "Adulto"; }
            if(idade >= 12 && idade <= 20) { categoria = "Juvenil"; }
            if(idade < 12) { categoria = "Infantil"; }

            //Cálculo do IMC do Paciente:
            imc = peso / Math.Pow(altura, 2);

            //Definição dos Riscos, Recomendações e Categoria do IMC com base no IMC: 
            if(imc > 35) { riscos = "O obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas.";
                           recomendacoes = "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação " +
                                           "alimentar, um psicólogo e um médico especialista(endócrino).";
                           categoriaImc = "Super Obesidade";}
            
            if (imc <= 35 && imc > 30) { riscos = "Quem tem obesidade vai estar mais exposto a doenças graves e ao risco de " +
                                                   "mortalidade.";
                                          recomendacoes = "Adote uma dieta alimentar rigorosa, com o acompanhamento de um " +
                                                          "nutricionista e um médico especialista(endócrino).";
                                          categoriaImc = "Obesidade";}

            if (imc <= 30 && imc > 24) { riscos = "Aumento de peso apresenta risco moderado para outras doenças crônicas e " +
                                                  "cardiovasculares.";
                                         recomendacoes = "Adote um tratamento baseado em dieta balanceada, exercício físico e " +
                                                         "medicação. A ajuda de um profissional pode ser interessante";
                                         categoriaImc = "Excesso de Peso";}

            if (imc <= 24 && imc >= 20) { riscos = "Seu peso está ideal para suas referências.";
                                         recomendacoes = "Mantenha uma dieta saudável e faça seus exames periódicos.";
                                         categoriaImc = "Peso Normal";}

            if (imc < 20) { riscos = "Muitas complicações de saúde como doenças pulmonares e cardiovasculares podem estar " +
                                     "associadas ao baixo peso. ";
                            recomendacoes = "Inclua carboidratos simples em sua dieta, além de proteínas - indispensáveis para " +
                                            "ganho de massa magra. Procure um profissional.";
                            categoriaImc = "Abaixo do Peso Ideal";}


            Console.Clear();
            Console.WriteLine("DIAGNÓSTICO PRÉVIO\n");
            Console.WriteLine($"Nome: {nome}\n" +
                              $"Sexo: {sexo}\n" +
                              $"Idade: {idade}\n" +
                              $"Altura: {altura}\n" +
                              $"Peso: {peso}\n" +
                              $"Categoria: {categoria}\n");
            
            Console.WriteLine($"IMC Desejável: entre 20 e 24\n\n" +
                              $"Resultado IMC: {Math.Round(imc,2)}" + " - " + $"{categoriaImc}\n\n" +
                              $"Riscos: {riscos}\n\n" +
                              $"Recomendações: {recomendacoes}\n\n");




        }
    }
}
