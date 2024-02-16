using Atelier2C6_101_2024;
using System;
using System.Linq;
using System.Numerics;
using TP_1ConnectFour;

class ConnectFourGame
{
 
    public ConnectFourGame()
    {
        Tableau tableau = new Tableau();
        bool partieEnCours = true;
        while (partieEnCours)
        {
            tableau.PrintBoard();
            tableau.Demander_joueur();

            Console.Clear();
            if (tableau.WinnerWinnerChikenDinner('X'))
            {
                tableau.PrintBoard();
                Console.WriteLine("Le joueur X a gagné!");
                partieEnCours = false;
            }
            else if (tableau.WinnerWinnerChikenDinner('Y'))
            {
                tableau.PrintBoard();
                Console.WriteLine("Le joueur O a gagné!");
                partieEnCours = false;
            }
        }
    }
}

