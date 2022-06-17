using System;
using System.Globalization;

namespace DiagnosticoPrevio
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ///Declaração das Variáveis
            int idade, editor = 0; //Variável editor armazena valor dado pelo usuário para escolher qual informação deseja editar posteriormente
            double imc, altura, peso;
            string nome, sexo, loop, categoria = null, riscos = null, recomendacoes = null, categoriaImc = null; //Variável loop é utilzada para repetir o programa de acordo com a escolha do usuário
            bool valido; //Variável booleana utilizada para validação de dados
           
            do //Estrutura de repetição para retornar ao início do programa caso seja escolha do usuário ao final da execução, condição se encontra no fechamento das chaves
            {
                //Obtenção dos Dados:
                do //Estrutura de repetição para retornar ao início do programa caso seja escolha do usuário reinserir todos os dados
                {
                    Cabecalho(); //Função que gera o cabeçalho no topo do console sempre que chamada

                    
                    Console.Write("\n\n\tOlá! Bem vindo(a) ao programa de Diagnóstico Prévio do nutricionista Luciano!\n\n");
                                                                                                  //O "\n" quebra a linha de impressão no console
                                                                                                  //O "\t" adiciona um recuo à esquerda na impressão
                    Divisorias(); //Função que gera uma divisória sempre que chamada

                    //Obtenção do Nome, Sexo, Idade, Peso e Altura:
                                      
                    nome = LeDados("nome").ToString();

                    Console.Write($"\n\n\tBem vindo(a), {nome}!\n\n");
                    
                    sexo = LeDados("sexo").ToString();                                     

                    idade = Convert.ToInt32(LeDados("idade"));
                   
                    altura = Convert.ToDouble(LeDados("altura"));
                    
                    peso = Convert.ToDouble(LeDados("peso"));


                    do //Opção de revisar e reinserir os dados caso haja algum erro durante o fornecimento dos mesmos
                    {
                        //"\t" e "\n" são utilizados para realizar o alinhamento vertical dos itens e as quebras de linha desejadas
                        Console.Write($"\n\n\tDADOS:" +
                                      $"\n\n\tNome:\t{nome}" +
                                      $"\n\tSexo:\t{sexo}" +
                                      $"\n\tIdade:\t{idade} anos" +
                                      $"\n\tAltura:\t{altura} metro(s)" +
                                      $"\n\tPeso:\t{peso} Kg\n\n");
                        Divisorias();
                        Console.Write("\tConfirmar dados (S/N)? ");

                        //Leitura da variável loop que vai definir se o programa prosseguirá ou retornará a determinado ponto
                        loop = Console.ReadLine();
                        loop = loop.ToUpper(); //Coloca a string "loop" em caixa alta para tornar indiferente a escolha entre
                                               //a inserção de letras minúsculas ou maiúsculas, dando mais liberdade ao usuário

                        //Validação do Caracter indicativo do loop para reinserção de dados:
                        while (loop != "S" && loop != "N")
                        {
                            Console.Write("\n");
                            Divisorias();
                            Console.Write("\tDesculpe, não consegui entender a sua escolha.\n\n\tInsira novamente (S para 'Sim' e N para 'Não'): ");
                            loop = Console.ReadLine();
                            loop = loop.ToUpper();
                        }

                        editor = 0; //Atribui 0 à variável editor para caso o usuário ja tenha selecionado 6 para reinserir todos os dados anteriormente no trecho a seguir,
                                    //o editor não fique preso no valor 6, que vai proporcionar o retorno ao início do programa, permitindo o resumo do código

                        if (loop == "N") //Caso o usuário não confirme os dados, são dadas opções de correção específicas
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

                            while (valido == false || editor < 1 || editor > 6) //Validação de dados para a variável de correção de dados
                            {
                                Console.Write("\n");
                                Divisorias();
                                Console.Write("\tDesculpe, não consegui entender a sua escolha.\n\n\tInsira novamente (1 - 6): ");
                                valido = int.TryParse(Console.ReadLine(), out editor);
                            }

                            Console.Clear();
                            Cabecalho();

                            //Dependendo da opção escolhida, é chamada a função correspondente ao que quer ser alterado
                            if (editor == 1) { Console.Write("\n\n");  nome = LeDados("nome").ToString(); }
                            else if (editor == 2) { Console.Write("\n\n"); sexo = LeDados("sexo").ToString(); }
                            else if (editor == 3) { Console.Write("\n"); idade = Convert.ToInt32(LeDados("idade")); }
                            else if (editor == 4) { Console.Write("\n"); altura = Convert.ToDouble(LeDados("altura")); }
                            else if (editor == 5) { Console.Write("\n"); peso = Convert.ToDouble(LeDados("peso")); }
                            else { loop = "S"; } //Atribuído valor diferente de "N" para que o programa possa ter continuidade qual não seja escolhida nenhuma opção de 1 a 5
                        }
                    } while (loop == "N"); //Loop para reimprimir os dados com o valor corrigido

                    Console.Clear();

                } while(editor == 6); //Caso o usuário digite 6, ele retorna ao início do programa para a reinserção de todos os dados


                //Definição da Categoria do Paciente:
                categoria = Categoria(idade); //Função Categoria recebe a idade para definir a categoria do paciente


                //Cálculo do IMC:
                imc = Imc(altura, peso); //Função Imc recebe os valores de altura e peso para calcular o IMC


                //Definição dos Riscos, Recomendações e Categoria do IMC com base no IMC: 

                riscos = DefineRRC(imc, "riscos"); //Função Riscos recebe o valor do IMC para definir os riscos a serem exibidos

                recomendacoes = DefineRRC(imc, "recomendações"); //Função Recomendacoes recebe o valor do IMC para definir as recomendações a serem exibidas

                categoriaImc = DefineRRC(imc, "categoriaImc"); //Função CategoriaImc recebe o valor do IMC para definir a categoria do IMC a ser exibida


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
                    Console.Write("\tDesculpe, não consegui entender a sua escolha.\n\n\tInsira novamente (S para 'Sim' e N para 'Não'): ");
                    loop = Console.ReadLine();
                    loop = loop.ToUpper();
                }

                Console.Clear();
               
            } while (loop == "S"); //Se o usuário escolher inserir novos dados, o programa volta ao início

            Console.Clear();
            Cabecalho();
            Console.WriteLine($"\n\n\tObrigado pela preferência, {nome}!\n\n\tAté mais e siga com saúde!\n");
            Divisorias();
                        
        }

        /// <summary>
        /// Função que lê os dados de acordo com o parâmetro passado para a função (nome, sexo, idade, altura e peso)
        /// </summary>
        /// <param name="parametro">O parametro pode ser "nome", "sexo", "idade", "altura" ou "peso"</param>
        /// <returns>Retorna o nome, sexo, idade, altura ou peso, de acordo com o "parametro"</returns>
        static object LeDados(string parametro)
        {
            object dado = null;
            bool valido; //Variável utilizada para fazer certas validações de entrada dentro das condicionais

            //Se o parâmetro for "nome", é realizada a leitura e validação do nome
            if (parametro == "nome")
            {
                Console.Write("\tPor favor insira seu nome: ");
                dado = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(dado.ToString())) //Validação do nome: não aceita apenas espaço em branco
                {
                    Console.Clear();
                    Cabecalho();
                    Console.Write("\n\n\tPoxa, infelizmente este não é um nome válido...\n\n\tTente novamente: ");
                    dado = Console.ReadLine();
                }

                Console.Clear();
                Cabecalho();
            }

            //Se o parâmetro for "sexo", é realizada a leitura e validação do sexo
            if (parametro == "sexo")
            {
                Console.Write("\tPor favor, insira seu sexo (M/F): ");
                dado = Console.ReadLine().ToUpper();
                                       //Coloca a string "sexo" em caixa alta para tornar indiferente a escolha entre
                                       //a inserção de letras minúsculas ou maiúsculas, dando mais liberdade ao usuário

                //Validação do Caracter indicativo do Sexo:
                while (dado.ToString() != "M" && dado.ToString() != "F")
                {
                    Console.Clear();
                    Cabecalho();
                    Console.Write("\n\n\tDesculpe, não consegui entender qual é o seu sexo.\n\n\tInsira novamente (M para Masculino" +
                                  " e F para Feminino): ");
                    dado = Console.ReadLine().ToUpper();
                }

                //Atribuição do nome completo do Sexo:
                if (dado.ToString() == "M") { dado = "Masculino"; }

                if (dado.ToString() == "F") { dado = "Feminino"; }

                Console.Clear();
                Cabecalho();
            }

            //Se o parâmetro for "idade", é realizada a leitura e validação da idade
            if (parametro == "idade")
            {
                int idade;               

                Console.Write("\n\n\tPara darmos continuidade, insira a sua idade em anos (máximo: 125): ");
                valido = int.TryParse(Console.ReadLine(), out idade); //Tenta fazer conversão para inteiro e atribuir para a variável idade
                                                                      //Se conseguir, valido = true, se não, valido = false

                //Validação da Idade (Invalidadando idades negativas, não inteiras ou superiores a 125 (idade máxima que o ser humano
                //consegue viver segundo cientistas) e menores ou iguais a 0):
                while (valido == false || idade <= 0 || idade > 125)
                {
                    Console.Clear();
                    Cabecalho();
                    Console.Write("\n\n\tDesculpe, não consegui entender a sua idade. Lembre de digitá-la em anos completos! \n\t(apenas valores positivos, máximo: 125)\n\n\tInsira novamente: ");
                    valido = int.TryParse(Console.ReadLine(), out idade);
                }

                dado = idade;

                Console.Clear();
                Cabecalho();
            }

            //Se o parâmetro for "altura", é realizada a leitura e validação da altura
            if (parametro == "altura")
            {
                double altura;
                
                Console.Write("\n\n\tÓtimo! Por gentileza, insira a sua altura em metros (máximo: 2,6): ");
                valido = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out altura);
                                                                        //Tenta fazer conversão para double e atribuir para a variável altura
                                                                        //Se conseguir, valido = true, se não, valido = false                                                                      
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

                dado = altura;
            }

            //Se o parâmetro for "peso", é realizada a leitura e validação do peso
            if (parametro == "peso")
            {
                double peso;                

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

                dado = peso;
            }

            return dado;
        }


        /// <summary>
        /// Função que calcula e retorna o IMC
        /// </summary>
        /// <param name="altura">Valor da altura do usuário, definida no programa principal</param>
        /// <param name="peso">Valor do peso do usuário, definido no programa principal</param>
        /// <returns></returns>
        static double Imc(double altura, double peso)
            {
                double imc = peso / Math.Pow(altura, 2); //Fórmula do IMC
                
                return imc;
            }


        /// <summary>
        /// Função que define o Risco, Recomendações ou Categoria do IMC (RRC) com base no IMC, dependendo do parâmetro (riscos, recomendações ou categoriaImc)
        /// </summary>
        /// <param name="imc">Valor do IMC calculado no programa principal com base nos dados do usuário</param>
        /// <param name="parametro">Valor do tipo String que irá definir qual valor será retornada pela fuñção, através da condicionais</param>
        /// <returns>Retorna os Riscos, Recomendações ou Categoria do IMC com base no "parametro"</returns>
        static string DefineRRC(double imc, string parametro)
        {
            string riscos = null, recomendacoes = null, categoriaImc = null;

            //Dependendo do valor do IMC, é atribuído um texto à string de riscos
            if (imc >= 35) 
            {   
                riscos = "O obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas.";
                recomendacoes = "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação \n\talimentar, um psicólogo e um médico especialista(endócrino).";
                categoriaImc = "Super Obesidade";
            }

            if (imc < 35 && imc >= 30)
            {
                riscos = "Quem tem obesidade vai estar mais exposto a doenças graves \n\te ao risco de mortalidade.";
                recomendacoes = "Adote uma dieta alimentar rigorosa, com o acompanhamento de um nutricionista \n\te um médico especialista(endócrino).";
                categoriaImc = "Obesidade";
            }

            if (imc < 30 && imc >= 25)
            {
                riscos = "Aumento de peso apresenta risco moderado para outras \n\tdoenças crônicas e cardiovasculares.";
                recomendacoes = "Adote um tratamento baseado em dieta balanceada, exercício físico e medicação. \n\tA ajuda de um profissional pode ser interessante";
                categoriaImc = "Excesso de Peso";
            }

            if (imc < 25 && imc >= 20) 
            { 
                riscos = "Seu peso está ideal para suas referências.";
                recomendacoes = "Mantenha uma dieta saudável e faça seus exames periódicos.";
                categoriaImc = "Peso Normal";
            }

            if (imc < 20)
            {
                riscos = "Muitas complicações de saúde como doenças pulmonares e cardiovasculares \n\tpodem estar associadas ao baixo peso.";
                recomendacoes = "Inclua carboidratos simples em sua dieta, \n\talém de proteínas - indispensáveis para ganho de massa magra. Procure um profissional.";
                categoriaImc = "Abaixo do Peso Ideal";
            }

            if(parametro == "riscos") { return riscos; }
            else if(parametro == "recomendações") { return recomendacoes; }
            else { return categoriaImc; }
        }

        
        /// <summary>
        /// Atribui a categoria etária de acordo com a idade
        /// </summary>
        /// <param name="idade">Idade do usário, definida no programa principal</param>
        /// <returns>Retorna a categoria etária do usuário, com base na idade</returns>
        static string Categoria(int idade)
            {
                string cat = null;

                //Atribui a categoria etária de acordo com a idade
                if (idade > 65) { cat = "Idoso"; }
                if (idade >= 21 && idade <= 65) { cat = "Adulto"; }
                if (idade >= 12 && idade <= 20) { cat = "Juvenil"; }
                if (idade < 12) { cat = "Infantil"; }

                return cat;
            }


        //Firulas:
        
        /// <summary>
        /// Imprime divisórias no console sempre que chamado
        /// </summary>
        static void Divisorias()
            {

            for (int i = 0; i < Console.WindowWidth; i++) //Cria uma divisória do tamanho da janela do console
                {
                Console.Write("=");
                }

            Console.WriteLine("\n");
            }
        
        /// <summary>
        /// Imprime um cabeçalho sempre que chamado
        /// </summary>
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
