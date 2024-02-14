using Atelier2C6_101_2024;
using System;
using System.Linq;
using System.Numerics;

class ConnectFourGame
{
    string[] _cases = new string[] { " A ", "  B ", " C", "D", "E", "F", "G" };
    private const int Rows = 6;
    private const int Cols = 7;
    private char[,] board = new char[Rows, Cols];
    private ConsoleColor player1Color = ConsoleColor.Red;
    private ConsoleColor player2Color = ConsoleColor.Yellow;
    private char player1 = 'X';
    private char player2 = 'O';
    private int currentPlayer = 1;

    public ConnectFourGame()
    {

        InitializeBoard();
        bool partieEnCours = true;
        while (partieEnCours)
        {
            PrintBoard();
            Demander_joueur();

            Console.Clear();
            if (WinnerWinnerChikenDinner(player1))
            {
                Console.WriteLine("Le joueur X a gagné!");
                partieEnCours = false;
            }
            else if (WinnerWinnerChikenDinner(player2))
            {
                Console.WriteLine("Le joueur O a gagné!");
                partieEnCours = false;
            }
        }
    }




    private void InitializeBoard()
    {

        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {
                board[row, col] = '_';
            }
        }
    }
    public void PrintBoard()
    {

        for (int i = 0; i < Cols; i++)
        {
            Console.Write(_cases.ElementAt(i).PadRight(4));
            if (i == 1)
            {
                Console.Write(" ");
            }
        }

        Console.WriteLine();
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {
                char token = board[row, col];
                Console.Write("|");

                
                if (token == player1)
                {
                    Console.BackgroundColor = player1Color;
                }
                else if (token == player2)
                {
                    Console.BackgroundColor = player2Color;
                }

                
                Console.Write("___"); 

                Console.ResetColor(); 
            }
            Console.WriteLine("|");
        }
    }

    public bool JouerPartie(int col, char player)
    {
        for (int row = Rows - 1; row >= 0; row--)
        {
            if (board[row, col] == '_')
            {
                board[row, col] = player;
                return true;
            }
        }
        return false;
    }
    public void Demander_joueur()
    {
        char JoueurActuel = UnEtDeux(player1, player2);
        Console.WriteLine($"C'est au joueur {JoueurActuel} de jouer.");
        Console.WriteLine("Tapez la lettre de la colonne choisie (A-G):");

        char choix = char.ToUpper(Console.ReadKey().KeyChar);
        int col = choix - 'A'; 

        if (col < 0 || col >= Cols || !JouerPartie(col, JoueurActuel))
        {
            Console.WriteLine("Choix invalide. Veuillez réessayer.");
            Demander_joueur();
            return;
        }

       
    }

    public char UnEtDeux(char player1, char player2)
    {
        char currentPlayerToken = currentPlayer == 1 ? player1 : player2;
        currentPlayer = currentPlayer == 1 ? 2 : 1;
        return currentPlayerToken;
    }
    public bool WinnerWinnerChikenDinner(char player)
    {
        
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col <= Cols - 4; col++)
            {
                if (board[row, col] == player &&
                    board[row, col + 1] == player &&
                    board[row, col + 2] == player &&
                    board[row, col + 3] == player)
                {
                    return true;
                }
            }
        }

       
        for (int col = 0; col < Cols; col++)
        {
            for (int row = 0; row <= Rows - 4; row++)
            {
                if (board[row, col] == player &&
                    board[row + 1, col] == player &&
                    board[row + 2, col] == player &&
                    board[row + 3, col] == player)
                {
                    return true;
                }
            }
        }

     
        for (int row = 0; row <= Rows - 4; row++)
        {
            for (int col = 0; col <= Cols - 4; col++)
            {
                if (board[row, col] == player &&
                    board[row + 1, col + 1] == player &&
                    board[row + 2, col + 2] == player &&
                    board[row + 3, col + 3] == player)
                {
                    return true;
                }
            }
        }
        for (int row = 3; row < Rows; row++)
        {
            for (int col = 0; col <= Cols - 4; col++)
            {
                if (board[row, col] == player &&
                    board[row - 1, col + 1] == player &&
                    board[row - 2, col + 2] == player &&
                    board[row - 3, col + 3] == player)
                {
                    return true;
                }
            }
        }
        return false;
        
    }
}

