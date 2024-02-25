using Atelier2C6_101_2024;
using System.Net.NetworkInformation;

namespace TP_1ConnectFour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            afficher_titre();//afficher le titre
            ConnectFourGame game = new ConnectFourGame();//creeation d'un objet jeu

          
            

        }
        //methode pour afficher le titre
        private static void afficher_titre()
        {
          
            string Titre = ".... | C O N N E C T  F O U R | .... ";
            string Titre2 = "Coded by The king Georges Z:)";
            Console.WriteLine(Titre);
            Console.WriteLine("        " + Titre2.PadRight(6) + " ");
            Console.WriteLine("_______________________________________________\n");
        }
    }
}