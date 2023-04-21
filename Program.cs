using System.Security.Cryptography.X509Certificates;

namespace jogodavelha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object[,] sheet = new object[3, 3];
            int numero = 1;
            int vez = 0;
            int jogador = 0;
            int jogada = 0;
            int linha = 0;
            int coluna = 0;
            string resposta = "s";
            bool vencedor = false;
            int jogadas = 0;
            bool end = false;

            Console.WriteLine("Jogo da Velha Interativo!!!");
            Console.WriteLine(" ");
            Console.WriteLine("Tabuleiro base: ");

            for (int i = 0; i < sheet.GetLength(0); i++)
            {
                for (int j = 0; j < sheet.GetLength(1); j++)
                {
                    sheet[i, j] = numero;
                    Console.Write(sheet[i, j] + " ");
                    numero++;
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Para fazer sua jogada basta escolher o número referente ao lugar o qual você quer colocar o seu sinal.");
            Console.WriteLine(" ");
            do
            {
                //JOGADOR 1
                do
                {
                    jogadas++;
                    Console.WriteLine("É a vez do jogador 1 (X) ");
                    Console.Write("Faça sua jogada: ");
                    jogada = int.Parse(Console.ReadLine());
                    Console.WriteLine(" ");
                    if (jogada < 0 || jogada > 9)
                    {
                        Console.Write("Jogada invalida, Faça outra jogada: ");
                        jogada = int.Parse(Console.ReadLine());

                    }

                    if (jogada == 1 || jogada == 2 || jogada == 3)
                    {
                        linha = 0;
                        coluna = jogada - 1;
                    }
                    else if (jogada == 4 || jogada == 5 || jogada == 6)
                    {
                        linha = 1;
                        coluna = jogada - 4;
                    }
                    else
                    {
                        linha = 2;
                        coluna = jogada - 7;
                    }

                    if (sheet[linha, coluna] == "X" || sheet[linha, coluna] == "O")
                    {
                        Console.WriteLine("Jogada inválida! Essa posição já está ocupada.");
                    }
                    else
                    {
                        sheet[linha, coluna] = "X";

                        for (int i = 0; i < sheet.GetLength(0); i++)
                        {
                            for (int j = 0; j < sheet.GetLength(1); j++)
                            {
                                Console.Write(sheet[i, j] + " ");
                            }
                            Console.WriteLine(" ");
                        }
                        Console.WriteLine(" ");

                        //Verificação ganhador X
                        for (int i = 0; i < sheet.GetLength(0); i++)
                        {
                            if (sheet[i, 0] == sheet[i, 1] && sheet[i, 1] == sheet[i, 2])
                            {
                                vencedor = true;
                            }
                        }

                        for (int j = 0; j < sheet.GetLength(1); j++)
                        {
                            if (sheet[0, j] == sheet[1, j] && sheet[1, j] == sheet[2, j])
                            {
                                vencedor = true;
                            }
                        }

                        if (sheet[0, 0] == sheet[1, 1] && sheet[1, 1] == sheet[2, 2])
                        {
                            vencedor = true;
                        }

                        if (sheet[0, 2] == sheet[1, 1] && sheet[1, 1] == sheet[2, 0])
                        {
                            vencedor = true;
                        }

                        if (vencedor)
                        {
                            Console.WriteLine("Jogador X é o ganhador!!!");
                            Console.WriteLine("Deseja jogar de novo? (s) ou (n)");
                            resposta = Console.ReadLine();
                            if (resposta == "s")
                            {
                                jogadas = 0;
                                numero = 1;
                                for (int i = 0; i < sheet.GetLength(0); i++)
                                {
                                    for (int j = 0; j < sheet.GetLength(1); j++)
                                    {
                                        sheet[i, j] = numero;
                                        Console.Write(sheet[i, j] + " ");
                                        numero++;
                                    }
                                    Console.WriteLine(" ");
                                }
                                jogador = 0;
                            }
                            else
                            {
                                end = true;
                                jogador = 10;
                            }
                        }
                        vencedor = false;
                        if (jogadas == 9 && vencedor == false)
                        {
                            Console.WriteLine("EMPATE!!!");
                            Console.WriteLine(" ");
                            Console.WriteLine("Deseja jogar de novo? (s) ou (n)");
                            resposta = Console.ReadLine();
                            Console.WriteLine(" ");
                            if (resposta == "s")
                            {
                                numero = 1;
                                for (int i = 0; i < sheet.GetLength(0); i++)
                                {
                                    for (int j = 0; j < sheet.GetLength(1); j++)
                                    {
                                        sheet[i, j] = numero;
                                        Console.Write(sheet[i, j] + " ");
                                        numero++;
                                    }
                                    Console.WriteLine(" ");
                                }
                                jogador = 0;
                            }
                            else
                            {
                                jogador = 3;
                                end = true;
                            }
                        }
                        else
                        {
                            jogador = 1;
                            vencedor = false;
                        }
                    }
                }
                while (jogador == 0);

                //JOGADOR 2 ======================================================================================
                if (jogador == 1 && end == false)
                {
                    jogadas++;
                    Console.WriteLine("É a vez do jogador 2 (O) ");
                    Console.Write("Faça sua jogada: ");
                    jogada = int.Parse(Console.ReadLine());
                    Console.WriteLine(" ");
                    if (jogada < 0 || jogada > 9)
                    {
                        Console.Write("Jogada invalida, Faça outra jogada: ");
                        jogada = int.Parse(Console.ReadLine());

                    }

                    if (jogada == 1 || jogada == 2 || jogada == 3)
                    {
                        linha = 0;
                        coluna = jogada - 1;
                    }
                    else if (jogada == 4 || jogada == 5 || jogada == 6)
                    {
                        linha = 1;
                        coluna = jogada - 4;
                    }
                    else
                    {
                        linha = 2;
                        coluna = jogada - 7;
                    }

                    if (sheet[linha, coluna] == "X" || sheet[linha, coluna] == "O")
                    {
                        Console.WriteLine("Jogada inválida! Essa posição já está ocupada.\t");
                    }
                    else
                    {
                        sheet[linha, coluna] = "O";

                        for (int i = 0; i < sheet.GetLength(0); i++)
                        {
                            for (int j = 0; j < sheet.GetLength(1); j++)
                            {
                                Console.Write(sheet[i, j] + " ");
                            }
                            Console.WriteLine(" ");
                        }
                        Console.WriteLine(" ");


                        //Verificação de ganhador O
                        for (int i = 0; i < sheet.GetLength(0); i++)
                        {
                            if (sheet[i, 0] == sheet[i, 1] && sheet[i, 1] == sheet[i, 2])
                            {
                                vencedor = true;
                            }
                        }

                        for (int j = 0; j < sheet.GetLength(1); j++)
                        {
                            if (sheet[0, j] == sheet[1, j] && sheet[1, j] == sheet[2, j])
                            {
                                vencedor = true;
                            }
                        }

                        if (sheet[0, 0] == sheet[1, 1] && sheet[1, 1] == sheet[2, 2])
                        {
                            vencedor = true;
                        }

                        if (sheet[0, 2] == sheet[1, 1] && sheet[1, 1] == sheet[2, 0])
                        {
                            vencedor = true;
                        }

                        if (vencedor)
                        {
                            Console.WriteLine("Jogador O é o ganhador!!!");
                            Console.WriteLine("Deseja jogar de novo? (s) ou (n)");
                            resposta = Console.ReadLine();
                            Console.WriteLine(" ");
                            if (resposta == "s")
                            {
                                jogadas = 0;
                                numero = 1;
                                for (int i = 0; i < sheet.GetLength(0); i++)
                                {
                                    for (int j = 0; j < sheet.GetLength(1); j++)
                                    {
                                        sheet[i, j] = numero;
                                        Console.Write(sheet[i, j] + " ");
                                        numero++;
                                    }
                                    Console.WriteLine(" ");
                                }
                            }
                        }
                        jogador = 0;
                    }
                }
                vencedor = false;
            }
            while (resposta == "s");
            
            if (resposta != "s")
            {
                Console.WriteLine("Obrigado por jogar!!!");
            }
        }

    }
}