﻿using Atelier2C6_101_2024;
using System;
using System.Linq;
using System.Numerics;
using TP_1ConnectFour;

class ConnectFourGame
{
 //classe pour le jeu
    public ConnectFourGame()
    {
        Tableau tableau = new Tableau();//creeation d'un objet tableau
        bool partieEnCours = true;//variable pour verifier si la partie est en cours
        while (partieEnCours)//tant que la partie est en cours
        {
            tableau.PrintBoard();//afficher le tableau
            tableau.Demander_joueur();//demander au joueur de jouer

            Console.Clear();//effacer la console
            if (tableau.IsBoardFull())//si le tableau est plein
            {
                tableau.PrintBoard();//afficher le tableau
                Console.WriteLine("personne n'a gagné");//afficher que personne n'a gagné

              if(tableau.rejouerpartie())//demander si les joueurs veulent rejouer
                {
                     tableau = new Tableau();//creeation d'un nouvel objet tableau
                    partieEnCours = true;//la partie est en cours
                }
                else
                {
                    partieEnCours = false;//la partie est finie
                }
              
            }

            if (tableau.WinnerWinnerChikenDinner('X'))//si le joueur X a gagné
            {
                tableau.PrintBoard();//afficher le tableau
                Console.WriteLine("Le joueur X a gagné!");//afficher que le joueur X a gagné
                partieEnCours = false;//la partie est finie
                if (tableau.rejouerpartie())//demander si les joueurs veulent rejouer
                {
                    tableau = new Tableau();//creeation d'un nouvel objet tableau
                    partieEnCours = true;//la partie est en cours
                }
                else
                {
                    partieEnCours = false;//la partie est finie
                }

            }
            else if (tableau.WinnerWinnerChikenDinner('O'))//meme principe pour le joueur x
            {
                tableau.PrintBoard();
                Console.WriteLine("Le joueur O a gagné!");
                partieEnCours = false;
                if (tableau.rejouerpartie())//demander si les joueurs veulent rejouer
                {
                    tableau = new Tableau();//creeation d'un nouvel objet tableau
                    partieEnCours = true;
                }
                else
                {
                    partieEnCours = false;//la partie est finie
                }

            }

        }
    }
}

