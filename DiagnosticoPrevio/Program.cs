using System;

namespace DiagnosticoPrevio
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ///Declaração das Variáveis
            int idade;
            double imc, altura, peso;
            string nome, sexo, categoria = null, riscos=null, recomendacoes=null, categoriaImc=null;
            bool valido; //Declaração de variável utilizada para validação de dados
            
            //Obtenção dos Dados:

            //Obtenção do Nome:
            Console.Write("Olá! Bem vindo(a) ao programa de Diagnóstico Prévio do nutricionista Luciano!\n\n" +
                              "Para começarmos, por favor insira seu nome: ");
            nome = Console.ReadLine();

            //Obtenção do Sexo:
            Console.Write($"\nBem vindo(a), {nome}! Por favor, insira seu sexo (M/F): ");
            sexo = Console.ReadLine();
            sexo = sexo.ToUpper();

            //Validação do Caracter indicativo do Sexo:
            while (sexo != "M" && sexo != "F")
            {                          
                Console.Write("\nDesculpe, não consegui entender qual é o seu sexo.\n\nInsira novamente (M/F): ");
                sexo = Console.ReadLine();
            }
            
            //Atribuição do nome completo do Sexo:
            if (sexo == "M")
            {
                sexo = "Masculino";
            }
            if (sexo == "F")
            {
                sexo = "Feminino";
            }

            //Obtenção da Idade:
            Console.Write("\nPara darmos continuidade, insira a sua idade em anos: ");
            valido = int.TryParse(Console.ReadLine(), out idade);

            //Validação da Idade:
            while (valido == false || idade < 0)
            {
                Console.Write("\nDesculpe, não consegui entender a sua idade. Lembre de digitá-la em anos completos (apenas valores positivos)!\n\nInsira novamente: ");
                valido = int.TryParse(Console.ReadLine(), out idade);
            }


            //Obtenção do Peso:
            Console.Write("\nÓtimo! Por gentileza, agora insira o seu peso em Kg: ");
            valido = double.TryParse(Console.ReadLine(), out peso);

            //Validação do Peso:
            while (valido == false || peso < 0)
            {
                Console.Write("\nDesculpe, não consegui entender o seu peso. Lembre de digitá-lo em Kg (apenas valores positivos)!\n\nInsira novamente: ");
                valido = double.TryParse(Console.ReadLine(), out peso);
            }


            //Obtenção da Altura:
            Console.Write("\nPara finalizarmos, por favor insira a sua altura em metros: ");
            valido = double.TryParse(Console.ReadLine(), out altura);

            //Validação da Altura:
            while (valido == false || altura < 0)
            {
                Console.Write("\nDesculpe, não consegui entender a sua altura. Lembre de digitá-la em metros (apenas valores positivos)!\n\nInsira novamente: ");
                valido = double.TryParse(Console.ReadLine(), out altura);
            }

            //Definição da Categoria do Paciente:
            if (idade > 65) { categoria = "Idoso"; }
            if(idade >= 21 && idade <= 65) { categoria = "Adulto"; }
            if(idade >= 12 && idade <= 20) { categoria = "Juvenil"; }
            if(idade < 12) { categoria = "Infantil"; }

            //Chamada da função Imc que recebe os valores de altura e peso para calcular o IMC:
            imc = Imc(altura, peso);

            //Definição dos Riscos, Recomendações e Categoria do IMC com base no IMC: 
            riscos = Riscos(imc);

            recomendacoes = Recomendacoes(imc);

            categoriaImc = CategoriaImc(imc);
                        
            
            Console.Clear();
            Console.WriteLine("DIAGNÓSTICO PRÉVIO\n");
            Console.WriteLine($"Nome: {nome}\n" +
                              $"Sexo: {sexo}\n" +
                              $"Idade: {idade}\n" +
                              $"Altura: {altura}\n" +
                              $"Peso: {peso}\n" +
                              $"Categoria: {categoria}\n\n");
            
            Console.WriteLine($"IMC Desejável: entre 20 e 24\n\n" +
                              $"Resultado IMC: {Math.Round(imc,2)}" + " - " + $"{categoriaImc}\n\n" +
                              $"Riscos: {riscos}\n\n" +
                              $"Recomendações: {recomendacoes}\n\n");



            double Imc(double altura, double peso)
            {
                double imc = peso / Math.Pow(altura, 2);
                
                return imc;
            }

            string Riscos(double imc)
            {
                string risks = null;

                if (imc > 35){ risks = "O obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas."; }

                if (imc <= 35 && imc > 30){ risks = "Quem tem obesidade vai estar mais exposto a doenças graves e ao risco de " +
                                                       "mortalidade.";}            
                
                if (imc <= 30 && imc > 24){ risks = "Aumento de peso apresenta risco moderado para outras doenças crônicas e " +
                                                      "cardiovasculares.";}

                if (imc <= 24 && imc >= 20) { risks = "Seu peso está ideal para suas referências.";}                  
                
                if (imc < 20){ risks = "Muitas complicações de saúde como doenças pulmonares e cardiovasculares podem estar " +
                                         "associadas ao baixo peso. ";}                    
                
                return risks;
            }

            string Recomendacoes(double imc)
            {
                string recom = null;

                if (imc > 35){ recom = "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação " +
                                                "alimentar, um psicólogo e um médico especialista(endócrino).";}                  
                
                if (imc <= 35 && imc > 30){ recom = "Adote uma dieta alimentar rigorosa, com o acompanhamento de um " +
                                                            "nutricionista e um médico especialista(endócrino).";}                

                if (imc <= 30 && imc > 24){ recom = "Adote um tratamento baseado em dieta balanceada, exercício físico e " +
                                                            "medicação. A ajuda de um profissional pode ser interessante";}

                if (imc <= 24 && imc >= 20) { recom = "Mantenha uma dieta saudável e faça seus exames periódicos."; }
                               

                if (imc < 20){recom = "Inclua carboidratos simples em sua dieta, além de proteínas - indispensáveis para " +
                                                "ganho de massa magra. Procure um profissional.";}

                return recom;
            }

            string CategoriaImc(double imc)
            {
                string catImc = null;

                if (imc > 35) { catImc = "Super Obesidade"; }

                if (imc <= 35 && imc > 30) { catImc = "Obesidade"; }

                if (imc <= 30 && imc > 24) { catImc = "Excesso de Peso"; }

                if (imc <= 24 && imc >= 20) { catImc = "Peso Normal"; }

                if (imc < 20) { catImc = "Abaixo do Peso Ideal"; }

                return catImc;
            }

        }
    }
}
