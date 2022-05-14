using System;
using Raylib_cs;

namespace Hilo.Game
{
    // TODO: Implement the Card class as follows...
    // 1) Add the class declaration. Use the following class comment.

        /// <summary>
        /// A small cube with a different number of spots on each of its six sides.
        /// 
        /// The responsibility of Card is to keep track of its currently rolled currentValue and the points its
        /// worth.
        /// </summary> 
        class Card 
        {
        // 2) Create the class constructor. Use the following method comment.

            private Random rand;
            private int currentValue;

            private int lastValue;

            public int CurrentValue
            {
                get
                {
                    return this.currentValue;
                }
            }

            public int LastCurrentValue
            {
                get
                {
                    return this.lastValue;
                }
            }

            /// <summary>
            /// Constructs a new instance of Card.
            public Card()
            {
                rand = new Random();
                Roll();
            }
            /// </summary>

    
        // 3) Create the Roll() method. Use the following method comment.
        
            /// <summary>
            /// Generates a new random currentValue and calculates the points for the die. Fives are 
            /// worth 50 points, ones are worth 100 points, everything else is worth 0 points.
            public void Roll()
            {
                lastValue = currentValue;
                currentValue = rand.Next(1,14);
            }
            /// </summary>
        }



        
}