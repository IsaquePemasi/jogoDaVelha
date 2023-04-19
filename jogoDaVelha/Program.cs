using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Maximize a tela");
            Thread.Sleep(3000);
            Console.Clear();
            string[,] matriz = new string[3, 3];
            string turno = "X";

            List<string> indexNumeros = new List<string> { };

            int index = 1;

            int tentativas = 1;

            ImprimirTituloJogo();

            index = AlimentarMatriz(matriz, indexNumeros, index);

            ImprimirMatriz(matriz);
            EscolherPosicaoJogada(turno);
            string jogada = Console.ReadLine();

            Console.Clear();

            while (tentativas < 9)
            {
                ImprimirTituloJogo();
                SubstituirValorNaSuaRespectivaCasa(matriz, turno, indexNumeros, jogada);
                ImprimirMatriz(matriz);

                if (matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2] ||
                    matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
                {
                    ImprimirMensagemFimJogoGanhador(turno);
                    break;
                }
                if (matriz[0, 0] == matriz[0, 1] && matriz[0, 1] == matriz[0, 2] ||
                    matriz[1, 0] == matriz[1, 1] && matriz[1, 1] == matriz[1, 2] ||
                    matriz[2, 0] == matriz[2, 1] && matriz[2, 1] == matriz[2, 2])
                {
                    ImprimirMensagemFimJogoGanhador(turno);
                    break;
                }
                if (matriz[0, 0] == matriz[1, 0] && matriz[1, 0] == matriz[2, 0] ||
                    matriz[0, 1] == matriz[1, 1] && matriz[1, 1] == matriz[2, 1] ||
                    matriz[0, 2] == matriz[1, 2] && matriz[1, 2] == matriz[2, 2])
                {
                    ImprimirMensagemFimJogoGanhador(turno);
                    break;
                }
                if (turno == "X")
                {
                    turno = "O";
                }
                else
                {
                    turno = "X";
                }

                Console.WriteLine();
                EscolherPosicaoJogada(turno);
                jogada = Console.ReadLine();

                while (!indexNumeros.Contains(jogada))
                {
                    Console.WriteLine();
                    Console.Write("Jogada inválida. Tente Novamente: ");
                    jogada = Console.ReadLine();
                }

                tentativas++;

                Console.Clear();
            }
            if (tentativas == 9)
            {
                ImprimirTituloJogo();
                ImprimirMatriz(matriz);
                ImprimirMensagemImpate();
            }

            Console.ReadLine();
        }

        private static void ImprimirTituloJogo()
        {

            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                                  JOGO DA VELHA   ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------");
        }

        private static int AlimentarMatriz(string[,] matriz, List<string> indexNumeros, int index)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = index.ToString();
                    indexNumeros.Add(index.ToString());
                    index++;
                }
            }

            return index;
        }

        private static void ImprimirMatriz(string[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"                                  [{matriz[i, j]}] ");
                }
                Console.WriteLine();
            }
        }

        private static void ImprimirMensagemFimJogoGanhador(string turno)
        {
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                                  Fim de Jogo!!!");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"                                                                  \nO jogador [{turno}] ganhou.");
            Console.WriteLine("                     $$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                  $$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                  $$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                $$$$$$$$$$$$$$$$$$$$$$$$$$$ $$$$$");
            Console.WriteLine("               $$$$$$$$$$$$$$  $$$$$$$  $$   $ $$$$");
            Console.WriteLine("             $$$$$$$$$$$   $$   $$$  $$  $   $  $$$$");
            Console.WriteLine("            $$$$%$$$  $ $   $$   $$$  $  $   $$ $ $$");
            Console.WriteLine("           $$$$%%$$$   $ $   $$   $$$  $  $$  $ $ $$$");
            Console.WriteLine("          $$$$$%%$$$$  $ $    $    $$  $  $$$ $ $$ $$$$");
            Console.WriteLine("         $$$$$%%%$$$$$ $$$$   $  $ $$   $ $$$$$ $$ $$$$$");
            Console.WriteLine("        $$$$$$%%%$$$$$$$$$$$  $$ $ $$$$ $ $$$$$$$$$$$$$$$$");
            Console.WriteLine("       $$$$$$%%%$$$$$$$$$$$$$$$ $$$$$$ $$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("      $$$$$$%%%$$%%%%%%$$$$$$$$$$$$$$$ $$$$$$$$$   $$$$$$$$");
            Console.WriteLine("      $$$$$$%%$$%%%%%%%%%$$$$$$$$$$$$$ $$$$$$$     $$$$%$$$");
            Console.WriteLine("      $$$$$$%$$%%%%%%%%%%%$$$$$$$$$$$$$$$$$        $$$$%%$$$");
            Console.WriteLine("      $$$$$$$$%%%%%%%%%%%%%$$$$$$$$$$$             $$$$%%$$$");
            Console.WriteLine("      $$$$$$$%%%            $$$$$$$$                 $$$%%$$$");
            Console.WriteLine("      $$$$$$$%%%            $$$$$$$$                 $$$%%$$$");
            Console.WriteLine("      $$$$$$%%%                                      $$$%%$$");
            Console.WriteLine("      $$$$$$%%%                                      $$$%%$$");
            Console.WriteLine("      $$$$$%%%%                                    % $$$%%$$");
            Console.WriteLine("      $$$$$%%%%                                    %  $$%%$$");
            Console.WriteLine("      $$$$$%%%%                                    %  $$%%$$");
            Console.WriteLine("      $$$$$%%%%                                   %%  $$$%$$");
            Console.WriteLine("      $$$$$%%%%                                  %%%  $$$%$$");
            Console.WriteLine("      $$$$$%%%%                                   %%  $$$%$$");
            Console.WriteLine("      $$$$$%%%%                                   %%  $$$%$$");
            Console.WriteLine("      $$$$$%%%%                                   %%  $$$%$$");
            Console.WriteLine("       $$$$%%%%                             $$$$  %% $$$$%$$");
            Console.WriteLine("      $ $$$%%%% $$$$$$$$$                $$$$$$$$$%% $$$$$$$");
            Console.WriteLine("     $$$ $$%%%  $$$$$$$$$$              $$$$$$$$$$$%% $$$$$$");
            Console.WriteLine("     $$$$  %%%          $$$           $$$$       $$%% $$$$$$");
            Console.WriteLine("     $$$$$$%%%    $$$$$ $$$$         $$$$$$$$$$   $%% $$$$$$");
            Console.WriteLine("     $$$$ %%%  $$$     $$$$$       $$$$$$    $$$  %%% $$$$$");
            Console.WriteLine("     $$$$     $$$$$$$$$ $$$$      $$$$$$$$$$$$$$   %  $$$$$");
            Console.WriteLine("     $$$$     $$$  $ $$  $$$$    $$$$$$  $ $  $$      $$$$");
            Console.WriteLine("     $$$$      $   $$$ %%%$$$         %% $$$          $$$$");
            Console.WriteLine("     $$$$             %%%% $$         %%%%%%  %%%     $$$$");
            Console.WriteLine("      $$$$      %%% %%%%%   $           %%%%%%%       $$$$");
            Console.WriteLine("      $$$$        %%%%%    $$             %%%         $$ $");
            Console.WriteLine("      $$ $          %%     $                          $ $$");
            Console.WriteLine("      $ $$                 $                          $  $");
            Console.WriteLine("      $ $$  $             %$                         $$  $");
            Console.WriteLine("      $  $  $            %%$                          $$$$");
            Console.WriteLine("       $$$  $$         $ %%%                       $ $ $$");
            Console.WriteLine("        $$  $$        $ %%%%          $ $$$       $$ $");
            Console.WriteLine("         $ $$$     $$  %%%%        $$$  $$$     $$$ $");
            Console.WriteLine("         $ $$$    $$  %%%$$$     $$$$    $$$$  $$$$ $");
            Console.WriteLine("         $$$$$$$$$$   $$$$$$$$$$$$$$      $$$$$$$$$ $");
            Console.WriteLine("          $$$$$$$   $$$$$$$$$$$$$$         $$$$$$$$ $");
            Console.WriteLine("          $$$$$$ %%$$$$$$$$$$$$$$      $$$$$$$$$$$$$$");
            Console.WriteLine("          $$$ $$  %$$$$$$$$$$      $$$$$$$$$    $$$$");
            Console.WriteLine("           $$  $   $$$$     $$$$$$$$    $$      $$$");
            Console.WriteLine("           $$  $   %$$$$               $$      $$$$");
            Console.WriteLine("            $  $   %%%%$$$ $$$$$$$$$$$$$       $$$");
            Console.WriteLine("            $$ $$   %%%%             $$       $$$$");
            Console.WriteLine("            $$ $$    %%$$$$ $$$$$$$$$$        $$$");
            Console.WriteLine("             $  $    $$$$$%%%%%%%%%%         $$$$	");
            Console.WriteLine("             $$ $$  $$$$$%%%                 $$$");
            Console.WriteLine("              $  $ $$$$ %%%%%%%%%%%%%%      $$$");
            Console.WriteLine("              $$  $$$$  %%%%%%%%%%%%%       $$$");
            Console.WriteLine("     $$$       $ $$$$   $%%%%              $$$");
            Console.WriteLine("   $$   $$      $$$$$  $$$$               $$$");
            Console.WriteLine("  $  $$  $$   $$$$$$   $$$                $$$");
            Console.WriteLine(" $ $$$$  $$  $$$$$$   $$$$               $$$");
            Console.WriteLine("$  $$$  $$$ $$$$$$ $$$$$$$              $$$");
            Console.WriteLine("$      $$$$$$$$$$   $$$$$$             $$$");
            Console.WriteLine("$  $$   $$$$$$$$     $$$$$$$$$$$$$$$  $$$");
            Console.WriteLine("$$$$$   $$$$$$$       $$$$$$$$$$$$$$$$$$");
            Console.WriteLine("$$$$$$   $$$$$                  $$$$$$");
            Console.WriteLine(" $$$$$   $$$$");
            Console.WriteLine(" $$$$$$  $$$");
            Console.WriteLine("  $$$$$  $$$");
            Console.WriteLine("   $$$$$$$$");
            Console.WriteLine("    $$$$$$");

        }

        private static void EscolherPosicaoJogada(string turno)
        {
            Console.Write($"\nJogador [{turno}], você quer jogar em qual posição? ");
        }

        private static void ImprimirMensagemImpate()
        {
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                                  Fim de Jogo!");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"                                                                  \nNinguém ganhou.");
        }

        private static void SubstituirValorNaSuaRespectivaCasa(string[,] matriz, string turno, List<string> indexNumeros, string jogada)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] == jogada && indexNumeros.Contains(jogada))
                    {
                        matriz[i, j] = turno;
                        indexNumeros.Remove(jogada);
                    }
                }
            }
        }
    }
}