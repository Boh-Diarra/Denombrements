using System;
using System.Numerics;

namespace Denombrements

{
    /// <summary>
    /// Application console de calcul des permutations, arrangements et combinaisons.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Affiche le menu et exécute le calcul choisi par l'utilisateur.
        /// </summary>
        /// <param name="args">Arguments de la ligne de commande (non utilisés)</param>
        static void Main(string[] args)
        {
            int choix = -1;

            while (choix != 0)
            {
                Console.WriteLine("Permutation ...................... 1");
                Console.WriteLine("Arrangement ...................... 2");
                Console.WriteLine("Combinaison ...................... 3");
                Console.WriteLine("Quitter .......................... 0");

                choix = LireEntier("Choix : ");

                if (choix == 0)
                {
                    Console.WriteLine("Au revoir.");
                }
                else if (choix == 1)
                {
                    int nombreElements = LireEntier("Nombre total d'éléments à gérer = ");

                    if (nombreElements >= 0)
                    {
                        BigInteger resultat = CalculerFactorielle(nombreElements);
                        Console.WriteLine(nombreElements + "! = " + resultat);
                    }
                    else
                    {
                        Console.WriteLine("Erreur : le nombre doit être positif ou nul.");
                    }
                }
                else if (choix == 2 || choix == 3)
                {
                    int nombreTotal = LireEntier("Nombre total d'éléments à gérer = ");
                    int nombreChoisi = LireEntier("Nombre d'éléments dans le sous-ensemble = ");

                    if (nombreTotal >= 0 && nombreChoisi >= 0 && nombreChoisi <= nombreTotal)
                    {
                        if (choix == 2)
                        {
                            BigInteger resultat = CalculerArrangement(nombreTotal, nombreChoisi);
                            Console.WriteLine("A(" + nombreTotal + "/" + nombreChoisi + ") = " + resultat);
                        }
                        else
                        {
                            BigInteger resultat = CalculerCombinaison(nombreTotal, nombreChoisi);
                            Console.WriteLine("C(" + nombreTotal + "/" + nombreChoisi + ") = " + resultat);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Erreur : il faut 0 <= n <= t.");
                    }
                }
                else
                {
                    Console.WriteLine("Erreur : choix invalide. Sélectionnez 0, 1, 2 ou 3.");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Demande un entier à l'utilisateur jusqu'à obtention d'une saisie valide.
        /// </summary>
        /// <param name="message">Message affiché avant la saisie.</param>
        /// <returns>L'entier correctement saisi par l'utilisateur.</returns>
        static int LireEntier(string message)
        {
            int valeur;
            Console.Write(message);

            while (!int.TryParse(Console.ReadLine(), out valeur))
            {
                Console.WriteLine("Erreur : saisissez un nombre entier valide.");
                Console.Write(message);
            }

            return valeur;
        }
        /// <summary>
        /// Calcule la factorielle d'un entier positif ou nul.
        /// </summary>
        /// <param name="n">Entier positif ou nul dont on calcule la factorielle.</param>
        /// <returns>La valeur exacte de n!</returns>
        static BigInteger CalculerFactorielle(int n)
        {
            BigInteger resultat = 1;

            for (long k = 1; k <= n; k++)
            {
                resultat *= k;
            }

            return resultat;
        }

        /// <summary>
        /// Calcule le nombre d'arrangements sans répétition de n éléments parmi t.
        /// </summary>
        /// <param name="t">Nombre total d'éléments, positif ou nul.</param>
        /// <param name="n">Nombre d'éléments sélectionnés, compris entre zéro et t.</param>
        /// <returns>Le nombre d'arrangements correspondant aux paramètres.</returns>
        static BigInteger CalculerArrangement(int t, int n)
        {
            BigInteger resultat = 1;

            for (long k = (long)t - n + 1; k <= t; k++)
            {
                resultat *= k;
            }

            return resultat;
        }

        /// <summary>
        /// Calcule le nombre de combinaisons sans répétition de n éléments parmi t.
        /// </summary>
        /// <param name="t">Nombre total d'éléments, positif ou nul.</param>
        /// <param name="n">Nombre d'éléments sélectionnés, compris entre zéro et t.</param>
        /// <returns>Le nombre de combinaisons correspondant aux paramètres.</returns>
        static BigInteger CalculerCombinaison(int t, int n)
        {
            // C(t, n) = A(t, n) / n! ; la formule ci-dessous limite les calculs inutiles.
            int nombreChoisi = Math.Min(n, t - n);
            BigInteger resultat = 1;

            for (long k = 1; k <= nombreChoisi; k++)
            {
                resultat = resultat * (t - nombreChoisi + k) / k;
            }

            return resultat;
        }
    }
}
