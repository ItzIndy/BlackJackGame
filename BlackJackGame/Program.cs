using System;

namespace BlackJackGame {
    class Program {
        static void Main(string[] args) {
            Deck deck = new Deck();
            for(int i = 0; i < 52; i++) {
                Console.WriteLine($"{i} - {deck.Draw().FaceValue}");
            }

            Console.WriteLine("----------------------");
            Deck deck2 = new Deck();
            deck2.Shuffle();
            for (int i = 0; i < 52; i++) {
                Console.WriteLine($"{i} - {deck2.Draw().FaceValue}");
            }

            Console.ReadKey();
        }
    }
}
