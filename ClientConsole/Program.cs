using System;
using RickAndMortyConnector.Models;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            bool execute = true;

            while (execute)
            {
                Console.Clear();
                execute = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.WriteLine("======================= Menu Principal =======================");
            Console.WriteLine("Escolha qual informação deseja consultar sobre Rick And Morty:");
            Console.WriteLine("1- Personagens (Desafio - Filtrado)");
            Console.WriteLine("2- Personagens");
            Console.WriteLine("3- Finalizar");
            Console.Write("\r\nEscolha uma das opções para continuar: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Characters();
                    return true;
                case "2":
                    CharactersAll();
                    return true;
                case "3":
                    return DoneApp();
                default:
                    return true;
            }
        }

        private static string CaptureInput()
        {
            Console.Write("Enter the string you want to modify: ");
            return Console.ReadLine();
        }


        private static void CharactersAll()
        {
            Console.Clear();
            Console.WriteLine("Aguarde enquanto a consultar é realizada...");
            List<Character> characters = new RickAndMortyConnector.RickAndMorty().GetCharacters(_status: "", _species: "", _episodeCount: 0);
            Console.Clear();
            Console.WriteLine($"Foram encontraods {characters.Count} personagens.");
            Console.WriteLine("");

            foreach (Character item in characters)
            {
                Console.WriteLine($"{item.id.ToString()} - {item.name}");
            }

            Console.Write("\r\n\r\nPressione ENTER para voltar");
            Console.ReadLine();
        }

        private static void Characters()
        {
            Console.Clear();
            Console.WriteLine("Aguarde enquanto a consultar é realizada...");
            List<Character> characters = new RickAndMortyConnector.RickAndMorty().GetCharacters();
            Console.Clear();
            Console.WriteLine($"Foram encontraods {characters.Count} personagens de 'Status' como desconhecido, da 'Species' Alien e que apareceram em mais de episódio.");
            Console.WriteLine("");

            foreach (Character item in characters)
            {
                Console.WriteLine($"{item.id.ToString()} - {item.name}");
            }

            Console.Write("\r\n\r\nPressione ENTER para voltar");
            Console.ReadLine();

        }

        private static bool DoneApp()
        {
            Console.Clear();
            Console.WriteLine("Wubba Lubba Dub Dub");
            Thread.Sleep(3000);
            Console.Clear();
            return false;
        }
    }
}
