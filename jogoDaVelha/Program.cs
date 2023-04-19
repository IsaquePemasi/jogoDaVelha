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
            Console.WriteLine("███╗   ███╗ █████╗ ██╗  ██╗██╗███╗   ███╗██╗███████╗███████╗     █████╗     ████████╗███████╗██╗      █████╗ ");
            Console.WriteLine("████╗ ████║██╔══██╗╚██╗██╔╝██║████╗ ████║██║╚══███╔╝██╔════╝    ██╔══██╗    ╚══██╔══╝██╔════╝██║     ██╔══██╗");
            Console.WriteLine("██╔████╔██║███████║ ╚███╔╝ ██║██╔████╔██║██║  ███╔╝ █████╗      ███████║       ██║   █████╗  ██║     ███████║");
            Console.WriteLine("██║╚██╔╝██║██╔══██║ ██╔██╗ ██║██║╚██╔╝██║██║ ███╔╝  ██╔══╝      ██╔══██║       ██║   ██╔══╝  ██║     ██╔══██║");
            Console.WriteLine("██║ ╚═╝ ██║██║  ██║██╔╝ ██╗██║██║ ╚═╝ ██║██║███████╗███████╗    ██║  ██║       ██║   ███████╗███████╗██║  ██║");
            Console.WriteLine("╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝╚═╝     ╚═╝╚═╝╚══════╝╚══════╝    ╚═╝  ╚═╝       ╚═╝   ╚══════╝╚══════╝╚═╝  ╚═");
            Thread.Sleep(3000);
            Console.Clear();
            string[,] matriz = new string[3, 3];
            string turno = "X";

            List<string> indexNumeros = new List<string> { };

            int index = 1;

            int tentativas = 1;

            TituloJogo();

            index = AlimentarMatriz(matriz, indexNumeros, index);

            Matriz(matriz);
            EscolherPosicao(turno);
            string jogada = Console.ReadLine();

            Console.Clear();

            while (tentativas < 9)
            {
                TituloJogo();
                Substituir(matriz, turno, indexNumeros, jogada);
                Matriz(matriz);

                if (matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2] ||
                    matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
                {
                    FimDeJogo(turno);
                    break;
                }
                if (matriz[0, 0] == matriz[0, 1] && matriz[0, 1] == matriz[0, 2] ||
                    matriz[1, 0] == matriz[1, 1] && matriz[1, 1] == matriz[1, 2] ||
                    matriz[2, 0] == matriz[2, 1] && matriz[2, 1] == matriz[2, 2])
                {
                    FimDeJogo(turno);
                    break;
                }
                if (matriz[0, 0] == matriz[1, 0] && matriz[1, 0] == matriz[2, 0] ||
                    matriz[0, 1] == matriz[1, 1] && matriz[1, 1] == matriz[2, 1] ||
                    matriz[0, 2] == matriz[1, 2] && matriz[1, 2] == matriz[2, 2])
                {
                    FimDeJogo(turno);
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
                EscolherPosicao(turno);
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
                TituloJogo();
                Matriz(matriz);
                Empate();
            }

            Console.ReadLine();
        }

        private static void TituloJogo()
        {

            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                            ██╗ ██████╗  ██████╗  ██████╗     ██████╗  █████╗     ██╗   ██╗███████╗██╗     ██╗  ██╗ █████╗ ");
            Console.WriteLine("                            ██║██╔═══██╗██╔════╝ ██╔═══██╗    ██╔══██╗██╔══██╗    ██║   ██║██╔════╝██║     ██║  ██║██╔══██╗");
            Console.WriteLine("                            ██║██║   ██║██║  ███╗██║   ██║    ██║  ██║███████║    ██║   ██║█████╗  ██║     ███████║███████║");
            Console.WriteLine("                       ██   ██║██║   ██║██║   ██║██║   ██║    ██║  ██║██╔══██║    ╚██╗ ██╔╝██╔══╝  ██║     ██╔══██║██╔══██║");
            Console.WriteLine("                       ╚█████╔╝╚██████╔╝╚██████╔╝╚██████╔╝    ██████╔╝██║  ██║     ╚████╔╝ ███████╗███████╗██║  ██║██║  ██║");
            Console.WriteLine("                        ╚════╝  ╚═════╝  ╚═════╝  ╚═════╝     ╚═════╝ ╚═╝  ╚═╝      ╚═══╝  ╚══════╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝");
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

        private static void Matriz(string[,] matriz)
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

        private static void FimDeJogo(string turno)
        {
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                                  Fim de Jogo!!!");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"                                                                  \nO jogador [{turno}] ganhou.");
            Console.WriteLine();
            Console.WriteLine("                                                                             .'|   /`.");
            Console.WriteLine("                                                                           .'.-.`-'.-.`.");
            Console.WriteLine("                                                                      ..._:   .-. .-.   :_...");
            Console.WriteLine("                                                                    .'    '-.(o ) (o ).-'    `.");
            Console.WriteLine("                                                                   :  _    _ _`~(_)~`_ _    _  :");
            Console.WriteLine("                                                                  :  /:   ' .-=_   _=-. `   ;|  :");
            Console.WriteLine("                                                                  :   :|-.._  '     `  _..-|:   :");
            Console.WriteLine("                                                                    `.   `.| | | | | | |.'   .'");
            Console.WriteLine("                                                                      `.   `-:_| | |_:-'   .'");
            Console.WriteLine("                                                                        `-._   ````    _.-'");
            Console.WriteLine("                                                                            ``-------''");
            Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("                                                                                       $$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                                                                                    $$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                                                                                    $$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                                                                                  $$$$$$$$$$$$$$$$$$$$$$$$$$$ $$$$$");
            Console.WriteLine("                                                                                 $$$$$$$$$$$$$$  $$$$$$$  $$   $ $$$$");
            Console.WriteLine("                                                                               $$$$$$$$$$$   $$   $$$  $$  $   $  $$$$");
            Console.WriteLine("                                                                              $$$$%$$$  $ $   $$   $$$  $  $   $$ $ $$");
            Console.WriteLine("                                                                             $$$$%%$$$   $ $   $$   $$$  $  $$  $ $ $$$");
            Console.WriteLine("                                                                            $$$$$%%$$$$  $ $    $    $$  $  $$$ $ $$ $$$$");
            Console.WriteLine("                                                                           $$$$$%%%$$$$$ $$$$   $  $ $$   $ $$$$$ $$ $$$$$");
            Console.WriteLine("                                                                          $$$$$$%%%$$$$$$$$$$$  $$ $ $$$$ $ $$$$$$$$$$$$$$$$");
            Console.WriteLine("                                                                         $$$$$$%%%$$$$$$$$$$$$$$$ $$$$$$ $$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                                                                        $$$$$$%%%$$%%%%%%$$$$$$$$$$$$$$$ $$$$$$$$$   $$$$$$$$");
            Console.WriteLine("                                                                        $$$$$$%%$$%%%%%%%%%$$$$$$$$$$$$$ $$$$$$$     $$$$%$$$");
            Console.WriteLine("                                                                        $$$$$$%$$%%%%%%%%%%%$$$$$$$$$$$$$$$$$        $$$$%%$$$");
            Console.WriteLine("                                                                        $$$$$$$$%%%%%%%%%%%%%$$$$$$$$$$$             $$$$%%$$$");
            Console.WriteLine("                                                                        $$$$$$$%%%            $$$$$$$$                 $$$%%$$$");
            Console.WriteLine("                                                                        $$$$$$$%%%            $$$$$$$$                 $$$%%$$$");
            Console.WriteLine("                                                                        $$$$$$%%%                                      $$$%%$$");
            Console.WriteLine("                                                                        $$$$$$%%%                                      $$$%%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                    % $$$%%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                    %  $$%%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                    %  $$%%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                   %%  $$$%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                  %%%  $$$%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                   %%  $$$%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                   %%  $$$%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                   %%  $$$%$$");
            Console.WriteLine("                                                                         $$$$%%%%                             $$$$  %% $$$$%$$");
            Console.WriteLine("                                                                        $ $$$%%%% $$$$$$$$$                $$$$$$$$$%% $$$$$$$");
            Console.WriteLine("                                                                       $$$ $$%%%  $$$$$$$$$$              $$$$$$$$$$$%% $$$$$$");
            Console.WriteLine("                                                                       $$$$  %%%          $$$           $$$$       $$%% $$$$$$");
            Console.WriteLine("                                                                       $$$$$$%%%    $$$$$ $$$$         $$$$$$$$$$   $%% $$$$$$");
            Console.WriteLine("                                                                       $$$$ %%%  $$$     $$$$$       $$$$$$    $$$  %%% $$$$$");
            Console.WriteLine("                                                                       $$$$     $$$$$$$$$ $$$$      $$$$$$$$$$$$$$   %  $$$$$");
            Console.WriteLine("                                                                       $$$$     $$$  $ $$  $$$$    $$$$$$  $ $  $$      $$$$");
            Console.WriteLine("                                                                       $$$$      $   $$$ %%%$$$         %% $$$          $$$$");
            Console.WriteLine("                                                                       $$$$             %%%% $$         %%%%%%  %%%     $$$$");
            Console.WriteLine("                                                                        $$$$      %%% %%%%%   $           %%%%%%%       $$$$");
            Console.WriteLine("                                                                        $$$$        %%%%%    $$             %%%         $$ $");
            Console.WriteLine("                                                                        $$ $          %%     $                          $ $$");
            Console.WriteLine("                                                                        $ $$                 $                          $  $");
            Console.WriteLine("                                                                        $ $$  $             %$                         $$  $");
            Console.WriteLine("                                                                        $  $  $            %%$                          $$$$");
            Console.WriteLine("                                                                         $$$  $$         $ %%%                       $ $ $$");
            Console.WriteLine("                                                                          $$  $$        $ %%%%          $ $$$       $$ $");
            Console.WriteLine("                                                                           $ $$$     $$  %%%%        $$$  $$$     $$$ $");
            Console.WriteLine("                                                                           $ $$$    $$  %%%$$$     $$$$    $$$$  $$$$ $");
            Console.WriteLine("                                                                           $$$$$$$$$$   $$$$$$$$$$$$$$      $$$$$$$$$ $");
            Console.WriteLine("                                                                            $$$$$$$   $$$$$$$$$$$$$$         $$$$$$$$ $");
            Console.WriteLine("                                                                            $$$$$$ %%$$$$$$$$$$$$$$      $$$$$$$$$$$$$$");
            Console.WriteLine("                                                                            $$$ $$  %$$$$$$$$$$      $$$$$$$$$    $$$$");
            Console.WriteLine("                                                                             $$  $   $$$$     $$$$$$$$    $$      $$$");
            Console.WriteLine("                                                                             $$  $   %$$$$               $$      $$$$");
            Console.WriteLine("                                                                              $  $   %%%%$$$ $$$$$$$$$$$$$       $$$");
            Console.WriteLine("                                                                              $$ $$   %%%%             $$       $$$$");
            Console.WriteLine("                                                                              $$ $$    %%$$$$ $$$$$$$$$$        $$$");
            Console.WriteLine("                                                                               $  $    $$$$$%%%%%%%%%%         $$$$	");
            Console.WriteLine("                                                                               $$ $$  $$$$$%%%                 $$$");
            Console.WriteLine("                                                                                $  $ $$$$ %%%%%%%%%%%%%%      $$$");
            Console.WriteLine("                                                                                $$  $$$$  %%%%%%%%%%%%%       $$$");
            Console.WriteLine("                                                                       $$$       $ $$$$   $%%%%              $$$");
            Console.WriteLine("                                                                     $$   $$      $$$$$  $$$$               $$$");
            Console.WriteLine("                                                                    $  $$  $$   $$$$$$   $$$                $$$");
            Console.WriteLine("                                                                   $ $$$$  $$  $$$$$$   $$$$               $$$");
            Console.WriteLine("                                                                  $  $$$  $$$ $$$$$$ $$$$$$$              $$$");
            Console.WriteLine("                                                                  $      $$$$$$$$$$   $$$$$$             $$$");
            Console.WriteLine("                                                                  $  $$   $$$$$$$$     $$$$$$$$$$$$$$$  $$$");
            Console.WriteLine("                                                                  $$$$$   $$$$$$$       $$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                                                                  $$$$$$   $$$$$                  $$$$$$");
            Console.WriteLine("                                                                   $$$$$   $$$$");
            Console.WriteLine("                                                                   $$$$$$  $$$");
            Console.WriteLine("                                                                    $$$$$  $$$");
            Console.WriteLine("                                                                     $$$$$$$$");
            Console.WriteLine("                                                                      $$$$$$");

        }

        private static void EscolherPosicao(string turno)
        {
            Console.Write($"\nJogador [{turno}], você quer jogar em qual posição? ");
        }

        private static void Empate()
        {
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                                  Fim de Jogo!");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"                                                                  \nNinguém ganhou.");
            Console.WriteLine();
            Console.WriteLine("                                                                   +--^----------,--------,-----,--------^-,");
            Console.WriteLine("                                                                   | |||||||||   `--------'     |          O");
            Console.WriteLine("                                                                   `+---------------------------^----------|");
            Console.WriteLine("                                                                     ``_,---------,---------,--------------'");
            Console.WriteLine("                                                                       / XXXXXX /'|       /'");
            Console.WriteLine("                                                                      / XXXXXX /  ``    /'");
            Console.WriteLine("                                                                     / XXXXXX /`-------'");
            Console.WriteLine("                                                                    / XXXXXX /");
            Console.WriteLine("                                                                   / XXXXXX /   ");
            Console.WriteLine("                                                                  (________(                ");
            Console.WriteLine("                                                                   `------'              ");
            Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("                                                                                       $$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                                                                                    $$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                                                                                    $$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                                                                                  $$$$$$$$$$$$$$$$$$$$$$$$$$$ $$$$$");
            Console.WriteLine("                                                                                 $$$$$$$$$$$$$$  $$$$$$$  $$   $ $$$$");
            Console.WriteLine("                                                                               $$$$$$$$$$$   $$   $$$  $$  $   $  $$$$");
            Console.WriteLine("                                                                              $$$$%$$$  $ $   $$   $$$  $  $   $$ $ $$");
            Console.WriteLine("                                                                             $$$$%%$$$   $ $   $$   $$$  $  $$  $ $ $$$");
            Console.WriteLine("                                                                            $$$$$%%$$$$  $ $    $    $$  $  $$$ $ $$ $$$$");
            Console.WriteLine("                                                                           $$$$$%%%$$$$$ $$$$   $  $ $$   $ $$$$$ $$ $$$$$");
            Console.WriteLine("                                                                          $$$$$$%%%$$$$$$$$$$$  $$ $ $$$$ $ $$$$$$$$$$$$$$$$");
            Console.WriteLine("                                                                         $$$$$$%%%$$$$$$$$$$$$$$$ $$$$$$ $$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                                                                        $$$$$$%%%$$%%%%%%$$$$$$$$$$$$$$$ $$$$$$$$$   $$$$$$$$");
            Console.WriteLine("                                                                        $$$$$$%%$$%%%%%%%%%$$$$$$$$$$$$$ $$$$$$$     $$$$%$$$");
            Console.WriteLine("                                                                        $$$$$$%$$%%%%%%%%%%%$$$$$$$$$$$$$$$$$        $$$$%%$$$");
            Console.WriteLine("                                                                        $$$$$$$$%%%%%%%%%%%%%$$$$$$$$$$$             $$$$%%$$$");
            Console.WriteLine("                                                                        $$$$$$$%%%            $$$$$$$$                 $$$%%$$$");
            Console.WriteLine("                                                                        $$$$$$$%%%            $$$$$$$$                 $$$%%$$$");
            Console.WriteLine("                                                                        $$$$$$%%%                                      $$$%%$$");
            Console.WriteLine("                                                                        $$$$$$%%%                                      $$$%%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                    % $$$%%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                    %  $$%%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                    %  $$%%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                   %%  $$$%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                  %%%  $$$%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                   %%  $$$%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                   %%  $$$%$$");
            Console.WriteLine("                                                                        $$$$$%%%%                                   %%  $$$%$$");
            Console.WriteLine("                                                                         $$$$%%%%                             $$$$  %% $$$$%$$");
            Console.WriteLine("                                                                        $ $$$%%%% $$$$$$$$$                $$$$$$$$$%% $$$$$$$");
            Console.WriteLine("                                                                       $$$ $$%%%  $$$$$$$$$$              $$$$$$$$$$$%% $$$$$$");
            Console.WriteLine("                                                                       $$$$  %%%          $$$           $$$$       $$%% $$$$$$");
            Console.WriteLine("                                                                       $$$$$$%%%    $$$$$ $$$$         $$$$$$$$$$   $%% $$$$$$");
            Console.WriteLine("                                                                       $$$$ %%%  $$$     $$$$$       $$$$$$    $$$  %%% $$$$$");
            Console.WriteLine("                                                                       $$$$     $$$$$$$$$ $$$$      $$$$$$$$$$$$$$   %  $$$$$");
            Console.WriteLine("                                                                       $$$$     $$$  $ $$  $$$$    $$$$$$  $ $  $$      $$$$");
            Console.WriteLine("                                                                       $$$$      $   $$$ %%%$$$         %% $$$          $$$$");
            Console.WriteLine("                                                                       $$$$             %%%% $$         %%%%%%  %%%     $$$$");
            Console.WriteLine("                                                                        $$$$      %%% %%%%%   $           %%%%%%%       $$$$");
            Console.WriteLine("                                                                        $$$$        %%%%%    $$             %%%         $$ $");
            Console.WriteLine("                                                                        $$ $          %%     $                          $ $$");
            Console.WriteLine("                                                                        $ $$                 $                          $  $");
            Console.WriteLine("                                                                        $ $$  $             %$                         $$  $");
            Console.WriteLine("                                                                        $  $  $            %%$                          $$$$");
            Console.WriteLine("                                                                         $$$  $$         $ %%%                       $ $ $$");
            Console.WriteLine("                                                                          $$  $$        $ %%%%          $ $$$       $$ $");
            Console.WriteLine("                                                                           $ $$$     $$  %%%%        $$$  $$$     $$$ $");
            Console.WriteLine("                                                                           $ $$$    $$  %%%$$$     $$$$    $$$$  $$$$ $");
            Console.WriteLine("                                                                           $$$$$$$$$$   $$$$$$$$$$$$$$      $$$$$$$$$ $");
            Console.WriteLine("                                                                            $$$$$$$   $$$$$$$$$$$$$$         $$$$$$$$ $");
            Console.WriteLine("                                                                            $$$$$$ %%$$$$$$$$$$$$$$      $$$$$$$$$$$$$$");
            Console.WriteLine("                                                                            $$$ $$  %$$$$$$$$$$      $$$$$$$$$    $$$$");
            Console.WriteLine("                                                                             $$  $   $$$$     $$$$$$$$    $$      $$$");
            Console.WriteLine("                                                                             $$  $   %$$$$               $$      $$$$");
            Console.WriteLine("                                                                              $  $   %%%%$$$ $$$$$$$$$$$$$       $$$");
            Console.WriteLine("                                                                              $$ $$   %%%%             $$       $$$$");
            Console.WriteLine("                                                                              $$ $$    %%$$$$ $$$$$$$$$$        $$$");
            Console.WriteLine("                                                                               $  $    $$$$$%%%%%%%%%%         $$$$	");
            Console.WriteLine("                                                                               $$ $$  $$$$$%%%                 $$$");
            Console.WriteLine("                                                                                $  $ $$$$ %%%%%%%%%%%%%%      $$$");
            Console.WriteLine("                                                                                $$  $$$$  %%%%%%%%%%%%%       $$$");
            Console.WriteLine("                                                                       $$$       $ $$$$   $%%%%              $$$");
            Console.WriteLine("                                                                     $$   $$      $$$$$  $$$$               $$$");
            Console.WriteLine("                                                                    $  $$  $$   $$$$$$   $$$                $$$");
            Console.WriteLine("                                                                   $ $$$$  $$  $$$$$$   $$$$               $$$");
            Console.WriteLine("                                                                  $  $$$  $$$ $$$$$$ $$$$$$$              $$$");
            Console.WriteLine("                                                                  $      $$$$$$$$$$   $$$$$$             $$$");
            Console.WriteLine("                                                                  $  $$   $$$$$$$$     $$$$$$$$$$$$$$$  $$$");
            Console.WriteLine("                                                                  $$$$$   $$$$$$$       $$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                                                                  $$$$$$   $$$$$                  $$$$$$");
            Console.WriteLine("                                                                   $$$$$   $$$$");
            Console.WriteLine("                                                                   $$$$$$  $$$");
            Console.WriteLine("                                                                    $$$$$  $$$");
            Console.WriteLine("                                                                     $$$$$$$$");
            Console.WriteLine("                                                                      $$$$$$");
        }

        private static void Substituir(string[,] matriz, string turno, List<string> indexNumeros, string jogada)
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