using Atelier2C6_101_2024;
using System;
using System.Linq;
using System.Numerics;

class ConnectFourGame
{
    string[] _cases = new string[] { " A", " B", "C", "D", "E", "F", "G" };
    private const int Rows = 6;
    private const int Cols = 7;
    private char[,] board = new char[Rows, Cols];
    private ConsoleColor player1Color = ConsoleColor.Red;
    private ConsoleColor player2Color = ConsoleColor.Yellow;
    private char player1 = 'X';
    private char player2 = 'O';
    private int currentPlayer = 1;
    private bool premierCoup = false;
    public ConnectFourGame()
    {

        InitializeBoard();
        bool partieEnCours = true;
        while (partieEnCours)
        {
            PrintBoard();
            Demander_joueur();
            Console.Clear();
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
             
                Console.Write("_" + board[row, col] + "_|");
               
            }
            Console.WriteLine(" ");
        }
        Console.ResetColor();
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
        char JoueurAcutel = ' ';
        if (!premierCoup)
        {
         JoueurAcutel = QuiVaCommencer(player1, player2);
        Console.WriteLine("C'est a joueur numero "+ JoueurAcutel + " de commencer");
        Console.WriteLine("Tapez La lettre de la colonne choissie:");
            premierCoup = true;
        char choix = Util.SaisirChar();
        int idx = int.Parse(choix.ToString());
        JouerPartie(idx, JoueurAcutel);
        
        }
        else
        {

            if (JoueurAcutel==player1)
            {
                JoueurAcutel = player2;
            }
            else if (JoueurAcutel==player2)
            {
                JoueurAcutel = player1;
            }
            else
            {
            JoueurAcutel = UnEtDeux(player1, player2);

            }
            Console.WriteLine("C'est à joueur " + JoueurAcutel + " de jouer.");

            Console.WriteLine("Tapez la lettre de la colonne choisie:");
            char choix = Util.SaisirChar();
            int idx = int.Parse(choix.ToString());

            JouerPartie(idx, JoueurAcutel);
        }


    }
    public char QuiVaCommencer(char player1, char player2)
    {
        Random random = new Random();
        int randomNumber = random.Next(2);
        return randomNumber == 0 ? player1 : player2;// 0 pour joueur1 1 pour joueur2
    }
    public char UnEtDeux(char player1, char player2)
    {
        char currentPlayerToken = currentPlayer == 1 ? player1 : player2;
        currentPlayer = currentPlayer == 1 ? 2 : 1; 
        return currentPlayerToken;
    }
}


