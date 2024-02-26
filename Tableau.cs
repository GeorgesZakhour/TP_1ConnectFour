namespace TP_1ConnectFour
{
    internal class Tableau
    {
        private string[] _cases = new string[] { " A ", "  B ", " C", "D", "E", "F", "G" };
        private const int Rows = 6;
        private const int Cols = 7;
        private char[,] board = new char[Rows, Cols];
        private ConsoleColor player1Color = ConsoleColor.Red;
        private ConsoleColor player2Color = ConsoleColor.Yellow;
        private char player1 = 'X';
        private char player2 = 'O';
        private int currentPlayer = 1;

        public Tableau()//constructeur
        {
            InitializeBoard();//initialiser le tableau
        }

        //methode pour initialiser le tableau
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
        //methode pour afficher le tableau
        public void PrintBoard()
        {

            for (int i = 0; i < Cols; i++)
            {
                Console.Write(_cases[i].PadRight(4));
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

                    if (token == player1)//si le jeton est celui du joueur 1
                    {

                        Console.BackgroundColor = player1Color;//la couleur de fond est rouge

                    }
                    else if (token == player2)
                    {


                        Console.BackgroundColor = player2Color;//la couleur de fond est jaune

                    }
                

                    Console.Write("___");
                    Console.ResetColor();
                }
                Console.WriteLine("|");
            }

        }

        public bool JouerPartie(int col, char player)//methode pour jouer une partie
        {
            for (int row = Rows - 1; row >= 0; row--)
            {
                if (board[row, col] == '_')//si la case est vide
                {
                    board[row, col] = player;//le joueur joue
                    return true;
                }

            }

            return false;
        }
        //methode pour demander au joueur de jouer
        public void Demander_joueur()
        {

            char JoueurActuel = UnEtDeux(player1, player2);
            Console.WriteLine($"C'est au joueur {JoueurActuel} de jouer.");
            Console.WriteLine("Tapez la lettre de la colonne choisie (A-G):");

            char choix = char.ToUpper(Console.ReadKey().KeyChar);
            int col = choix - 'A';

            while (col < 0 || col >= Cols || !JouerPartie(col, JoueurActuel))//tant que le choix est invalide
            {
                Console.WriteLine("\nChoix invalide. Veuillez réessayer.");//afficher que le choix est invalide
                choix = char.ToUpper(Console.ReadKey().KeyChar);
                col = choix - 'A';//pour specialiser le choix en ascii A=65 B=66 etc


            }
        }
        //methode pour alterner entre les joueurs
        public char UnEtDeux(char player1, char player2)
        {
            char currentPlayerToken = currentPlayer == 1 ? player1 : player2;//si le joueur actuel est 1 alors le jeton actuel est celui du joueur 1 sinon c'est celui du joueur 2
            currentPlayer = currentPlayer == 1 ? 2 : 1;//si le joueur actuel est 1 alors le joueur actuel est 2 sinon c'est 1
            return currentPlayerToken;//retourner le jeton actuel
        }
        //methode pour verifier si un joueur a gagné
        public bool WinnerWinnerChikenDinner(char player)
        {

            // gagnant horizontal
            for ( int row = 0; row < Rows; row++)
            {
                for ( int col = 0; col <= Cols - 4; col++)
                {
                    if (board[row, col] == player &&//si le joueur a 4 jetons alignés horizontalement
                        board[row, col + 1] == player &&//+1    
                        board[row, col + 2] == player &&
                        board[row, col + 3] == player)
                    {

                        return true;

                    }

                }
            }

            // gagnant vertical
            for ( int col = 0; col < Cols; col++)
            {
                for (int row = 0; row <= Rows - 4; row++)
                {
                    if (board[row, col] == player &&//si le joueur a 4 jetons alignés verticalement
                        board[row + 1, col] == player &&
                        board[row + 2, col] == player &&
                        board[row + 3, col] == player)
                    {

                        return true;
                    }
                }
            }

            // gagnant diagonal
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
            // gagnant diagonal
            for (int row = 3; row < Rows; row++)
            {
                for (int col = 0; col <= Cols - 4; col++)
                {
                    if (board[row, col] == player &&//si le joueur a 4 jetons alignés en diagonale
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

        //methode pour verifier si le tableau est plein
        public bool IsBoardFull()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    if (board[row, col] == '_')//si le tableau n'est pas plein
                    {
                        return false;//retourner faux
                    }
                }
            }
            return true;
        }

       public bool rejouerpartie()
        {
            Console.WriteLine("Voulez-vous rejouer? (O/N)");
            char choix = char.ToUpper(Console.ReadKey().KeyChar);
            while (choix != 'O' && choix != 'N')//tant que le choix est invalide
            {
                Console.WriteLine("\nChoix invalide. Veuillez réessayer.");//afficher que le choix est invalide
                choix = char.ToUpper(Console.ReadKey().KeyChar);
            }
            if (choix == 'O')
            {
                Console.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
