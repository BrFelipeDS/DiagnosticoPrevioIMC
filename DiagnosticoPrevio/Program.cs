using System;
using System.Globalization;

namespace DiagnosticoPrevio
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ///Declaração das Variáveis
            int idade, editor = 0; //Variável editor armazena valor dado pelo usuário para escolher qual informação deseja editar
            double imc, altura, peso;
            string nome, sexo, loop, categoria = null, riscos = null, recomendacoes = null, categoriaImc = null;
            bool valido; //Variável booleana utilizada para validação de dados
           
            do
            {
                //Obtenção dos Dados:
                do
                {
                    Cabecalho(); //Função que gera o cabeçalho no topo do console

                    
                    Console.Write("\n\n\tOlá! Bem vindo(a) ao programa de Diagnóstico Prévio do nutricionista Luciano!\n\n");
                                                                                                  //O "\n" quebra a linha de impressão no console
                                                                                                  //O "\t" adiciona um recuo à esquerda na impressão
                    Divisorias(); //Função que gera uma divisória sempre que chamada

                    //Obtenção do Nome, Sexo, Idade, Peso e Altura:

                    nome = LeNome();                    

                    Console.Write($"\n\n\tBem vindo(a), {nome}!\n\n");
                    
                    sexo = LeSexo();

                    idade = LeIdade();

                    altura = LeAltura();

                    peso = LePeso();

                    //Opção de revisar e reinserir os dados caso haja algum erro durante o fornecimento dos mesmos

                    do
                    {

                        Console.Write($"\n\n\tDADOS:" +
                                      $"\n\n\tNome:\t{nome}" +
                                      $"\n\tSexo:\t{sexo}" +
                                      $"\n\tIdade:\t{idade} anos" +
                                      $"\n\tAltura:\t{altura} metro(s)" +
                                      $"\n\tPeso:\t{peso} Kg\n\n");
                        Divisorias();
                        Console.Write("\tConfirmar dados (S/N)? ");


                        loop = Console.ReadLine();
                        loop = loop.ToUpper(); //Coloca a string "loop" em caixa alta para tornar indiferente a escolha entre
                                               //a inserção de letras minúsculas ou maiúsculas, dando mais liberdade ao usuário

                        //Validação do Caracter indicativo do loop para reinserção de dados:
                        while (loop != "S" && loop != "N")
                        {
                            Console.Write("\n");
                            Divisorias();
                            Console.Write("\tDesculpe, não consegui entender a sua escolha.\n\n\tInsira novamente (S/N): ");
                            loop = Console.ReadLine();
                            loop = loop.ToUpper();
                        }

                        editor = 0;

                        if (loop == "N")
                        {
                            Console.Write("\n");
                            Divisorias();
                            Console.WriteLine("\tQual dado gostaria de editar?\n\n" +
                                              "\t1 - Nome\n" +
                                              "\t2 - Sexo\n" +
                                              "\t3 - Idade\n" +
                                              "\t4 - Altura\n" +
                                              "\t5 - Peso\n" +
                                              "\t6 - Reinserir todos os dados\n\n");
                            Console.Write("\tInsira sua resposta (1 - 6): ");
                            valido = int.TryParse(Console.ReadLine(), out editor);

                            while (valido == false || editor < 1 || editor > 6)
                            {
                                Console.Write("\n");
                                Divisorias();
                                Console.Write("\tDesculpe, não consegui entender a sua escolha.\n\n\tInsira novamente (1 - 6): ");
                                valido = int.TryParse(Console.ReadLine(), out editor);
                            }

                            Console.Clear();
                            Cabecalho();

                            if (editor == 1) { Console.Write("\n\n");  nome = LeNome(); }
                            else if (editor == 2) { Console.Write("\n\n"); sexo = LeSexo(); }
                            else if (editor == 3) { Console.Write("\n"); idade = LeIdade(); }
                            else if (editor == 4) { Console.Write("\n"); altura = LeAltura(); }
                            else if (editor == 5) { Console.Write("\n"); peso = LePeso(); }
                            else { loop = "S"; }
                        }
                    } while (loop == "N");

                    Console.Clear();

                } while(editor == 6);


                //Definição da Categoria do Paciente:
                categoria = Categoria(idade); //Função Categoria recebe a idade para definir a categoria do paciente


                //Cálculo do IMC:
                imc = Imc(altura, peso); //Função Imc recebe os valores de altura e peso para calcular o IMC


                //Definição dos Riscos, Recomendações e Categoria do IMC com base no IMC: 

                riscos = Riscos(imc); //Função Riscos recebe o valor do IMC para definir os riscos a serem exibidos

                recomendacoes = Recomendacoes(imc); //Função Recomendacoes recebe o valor do IMC para definir as recomendações a serem exibidas

                categoriaImc = CategoriaImc(imc); //Função CategoriaImc recebe o valor do IMC para definir a categoria do IMC a ser exibida


                Cabecalho();

                //Imprimindo os dados do usuário na tela, utilizando espaços e "\t" para alinhá-los verticalmente
                Console.WriteLine($"\n\n\tNome:\t   {nome}\n" +
                                  $"\tSexo:\t   {sexo}\n" +
                                  $"\tIdade:\t   {idade} anos\n" +
                                  $"\tAltura:\t   {altura} metro(s)\n" +
                                  $"\tPeso:\t   {peso} Kg\n" +
                                  $"\tCategoria: {categoria}\n");

                Divisorias();

                //Imprimindo o IMC desejável, o resultado do IMC do usuário e riscos e recomendações associados
                Console.WriteLine($"\tIMC Desejável: entre 20 e 24\n\n" +
                                  $"\tResultado IMC: {Math.Round(imc, 2)}" + " - " + $"{categoriaImc}\n\n" +
                                  $"\tRiscos: {riscos}\n\n" +
                                  $"\tRecomendações: {recomendacoes}\n");

                Divisorias();


                //Opção de realizar um novo diagnóstico prévio com a inserção de novos dados
                Console.Write("\tDeseja inserir novos dados para diagnóstico prévio (S/N)? ");
                loop = Console.ReadLine();
                loop = loop.ToUpper(); //Coloca a string "loop" em caixa alta para tornar indiferente a escolha entre
                                       //a inserção de letras minúsculas ou maiúsculas, dando mais liberdade ao usuário
                

                //Validação do Caracter indicativo do loop:
                while (loop != "S" && loop != "N")
                {
                    Console.Write("\n");
                    Divisorias();
                    Console.Write("\tDesculpe, não consegui entender a sua escolha.\n\n\tInsira novamente (S/N): ");
                    loop = Console.ReadLine();
                    loop = loop.ToUpper();
                }

                Console.Clear();
               
            } while (loop == "S");

            Console.Clear();
            Cabecalho();
            Console.WriteLine($"\n\n\tObrigado pela preferência, {nome}!\n\n\tAté mais e siga com saúde!\n");
            Divisorias();
                        
        }

            static string LeNome()
        {
            string nome;

            Console.Write("\tPor favor insira seu nome: ");
            nome = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(nome))
            {
                Console.Clear();
                Cabecalho();
                Console.Write("\n\n\tPoxa, infelizmente este não é um nome válido...\n\n\tTente novamente: ");
                nome = Console.ReadLine();
            }

            Console.Clear();
            Cabecalho();

            return nome;
        }

            static string LeSexo()
        {
            string sexo;

            Console.Write("\tPor favor, insira seu sexo (M/F): ");
            sexo = Console.ReadLine();
            sexo = sexo.ToUpper(); //Coloca a string "sexo" em caixa alta para tornar indiferente a escolha entre
                                   //a inserção de letras minúsculas ou maiúsculas, dando mais liberdade ao usuário

            //Validação do Caracter indicativo do Sexo:
            while (sexo != "M" && sexo != "F")
            {
                Console.Clear();
                Cabecalho();
                Console.Write("\n\n\tDesculpe, não consegui entender qual é o seu sexo.\n\n\tInsira novamente (M para Masculino" +
                              " e F para Feminino): ");
                sexo = Console.ReadLine();
                sexo = sexo.ToUpper();
            }

            //Atribuição do nome completo do Sexo:
            if (sexo == "M") { sexo = "Masculino"; }

            if (sexo == "F") { sexo = "Feminino"; }

            Console.Clear();
            Cabecalho();

            return sexo;
        }

            static int LeIdade()
        {
            int idade;
            bool valido;

            Console.Write("\n\n\tPara darmos continuidade, insira a sua idade em anos (máximo: 125): ");
            valido = int.TryParse(Console.ReadLine(), out idade);

            //Validação da Idade (Invalidadando idades negativas, não inteiras ou superiores a 125 (idade máxima que o ser humano
            //consegue viver segundo cientistas)):
            while (valido == false || idade <= 0 || idade > 125)
            {
                Console.Clear();
                Cabecalho();
                Console.Write("\n\n\tDesculpe, não consegui entender a sua idade. Lembre de digitá-la em anos completos! \n\t(apenas valores positivos, máximo: 125)\n\n\tInsira novamente: ");
                valido = int.TryParse(Console.ReadLine(), out idade);
            }

            Console.Clear();
            Cabecalho();

            return idade;

        }

            static double LeAltura()
        {
            double altura;
            bool valido;

            Console.Write("\n\n\tÓtimo! Por gentileza, insira a sua altura em metros (máximo: 2,6): ");
            valido = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out altura);
                                                                                    //Replace juntamente com o NumberStyles.Number
                                                                                    //possibilitam a inserção de valores decimais
                                                                                    //com ponto ou vírgula. O InvariantCulture desconsidera
                                                                                    //a língua do sistema utilizado, considerando apenas a
                                                                                    //padrão (inglês)

            //Validação da Altura (Invalidando não números, alturas negativas e nulas ou superiores a 2.6 (valor um pouco superior
            //ao máximo registrado pelo ser humano):
            while (valido == false || altura <= 0 || altura > 2.6)
            {
                Console.Clear();
                Cabecalho();
                Console.Write("\n\n\tDesculpe, não consegui entender a sua altura. Lembre de digitá-la em metros! \n\t(apenas valores positivos, máximo: 2,6)\n\n\tInsira novamente: ");
                valido = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out altura);
            }

            Console.Clear();
            Cabecalho();

            return altura;
        }

            static double LePeso()
        {
            double peso;
            bool valido;

            Console.Write("\n\n\tLegal! Por favor insira o seu peso em Kg (máximo: 600): ");
            valido = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out peso);
                                                                                        
            //Validação do Peso (Invalidadando não números, pesos negativos e nulos ou superiores a 600 (valor um pouco superior
            //ao máximo registrado pelo ser humano)):
            while (valido == false || peso <= 0 || peso > 600)
            {
                Console.Clear();
                Cabecalho();
                Console.Write("\n\n\tDesculpe, não consegui entender o seu peso. Lembre de digitá-lo em Kg! \n\t(apenas valores positivos, máximo: 600)\n\n\tInsira novamente: ");
                valido = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out peso);
            }

            Console.Clear();
            Cabecalho();

            return peso;
        }           

            static double Imc(double altura, double peso)
            {
                double imc = peso / Math.Pow(altura, 2);
                
                return imc;
            }

            static string Riscos(double imc)
            {
                string risks = null;

                if (imc >= 35){ risks = "O obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas."; }

                if (imc < 35 && imc >= 30){ risks = "Quem tem obesidade vai estar mais exposto a doenças graves \n\te ao risco de " +
                                                       "mortalidade.";}            
                
                if (imc < 30 && imc >= 25){ risks = "Aumento de peso apresenta risco moderado para outras \n\tdoenças crônicas e " +
                                                      "cardiovasculares.";}

                if (imc < 25 && imc >= 20) { risks = "Seu peso está ideal para suas referências.";}                  
                
                if (imc < 20){ risks = "Muitas complicações de saúde como doenças pulmonares e cardiovasculares \n\tpodem estar " +
                                         "associadas ao baixo peso. ";}                    
                
                return risks;
            }

            static string Recomendacoes(double imc)
            {
                string recom = null;

                if (imc >= 35){ recom = "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação \n\t" +
                                                "alimentar, um psicólogo e um médico especialista(endócrino).";}                  
                
                if (imc < 35 && imc >= 30){ recom = "Adote uma dieta alimentar rigorosa, com o acompanhamento de um " +
                                                            "nutricionista \n\te um médico especialista(endócrino).";}                

                if (imc < 30 && imc >= 25){ recom = "Adote um tratamento baseado em dieta balanceada, exercício físico e " +
                                                            "medicação. \n\tA ajuda de um profissional pode ser interessante";}

                if (imc < 25 && imc >= 20) { recom = "Mantenha uma dieta saudável e faça seus exames periódicos."; }
                               

                if (imc < 20){recom = "Inclua carboidratos simples em sua dieta, \n\talém de proteínas - indispensáveis para " +
                                                "ganho de massa magra. Procure um profissional.";}

                return recom;
            }

            static string CategoriaImc(double imc)
            {
                string catImc = null;

                if (imc >= 35) { catImc = "Super Obesidade"; }

                if (imc < 35 && imc >= 30) { catImc = "Obesidade"; }

                if (imc < 30 && imc >= 25) { catImc = "Excesso de Peso"; }

                if (imc < 25 && imc >= 20) { catImc = "Peso Normal"; }

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

            static void Divisorias()
            {

            for (int i = 0; i < Console.WindowWidth; i++)
                {
                Console.Write("=");
                }

            Console.WriteLine("\n");
            }

            static void Cabecalho()
            {
            Console.Write("\n       ");
            for (int i = 0; i < 40; i++)
            {
                Console.Write("=");
            }

            Console.Write("    DIAGNÓSTICO PRÉVIO    ");

            for (int i = 0; i < 40; i++)
            {
                Console.Write("=");
            }
        }

    }
}
