using System;
using System.Collections.Generic;
using Raylib_cs;


namespace Hilo.Game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Director
    {
        private Card card;
        bool isPlaying = true;
        int totalScore;
        char playerGuess;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            card = new Card();
            totalScore = 100;
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            while (isPlaying)
            {
                PrintCard(0);
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        /// <summary>
        /// Asks the user if they want to roll.
        /// </summary>
        public void GetInputs()
        {
            char guess;
            bool onward = true;
            Console.Write("Higher or lower? [h/l] ");
            while(onward)
            {
                guess = Console.ReadLine()[0];
                if ((guess == 'h') || (guess == 'l'))
                {
                    playerGuess = guess;
                    onward = false;                    
                }
                else
                {
                    Console.Write("Must guess (h)igher or (l)ower: ");
                }
            }
        }

        /// <summary>
        /// Prints the output of the last (0) or a new Card (1)
        /// </summary>
        public void PrintCard(int action)
        {
            if (action == 0)
            {
                Console.WriteLine("The card is: " + card.CurrentValue);
            }
            else
            {
                Console.WriteLine("Next card was: " + card.CurrentValue);
            }
        }

        /// <summary>
        /// Updates the player's score.
        /// </summary>
        public void DoUpdates()
        {
            if (!isPlaying)
            {
                return;
            }

            card.Roll();
            /* // debug info
            Console.Write("current card: " + card.CurrentValue + " ");
            Console.Write("old card: " + card.LastCurrentValue + " ");
            Console.WriteLine("current > last? " + (card.CurrentValue > card.LastCurrentValue));
            */

            if (((card.CurrentValue > card.LastCurrentValue) && playerGuess == 'h') ||
            ((card.CurrentValue < card.LastCurrentValue) && playerGuess == 'l'))
            {
                    totalScore += 100;
            }
            else
                totalScore -= 75;
            PrintCard(1);
        }

        /// <summary>
        /// Displays the dice and the score. Also asks the player if they want to roll again. 
        /// </summary>
        public void DoOutputs()
        {
            if (!isPlaying)
            {
                return;
            }
            
            if (totalScore > 0)
            {
                Console.WriteLine("Your score is: " + totalScore);
            }
            else 
            {
                isPlaying = false;
                Console.WriteLine("Game over!");
            }

            Console.Write("Play again? [y/n] ");
            char userInput = Console.ReadLine()[0];
            if (!(userInput == 'y'))
                isPlaying = false;
            Console.WriteLine();
        }
    }
}


