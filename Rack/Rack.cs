using System;
using System.Collections.Generic;
using System.Linq;

namespace Rack
{
    public class Rack : IRack
    {       
        private const int SIZE = 7;
        private const int BALL_MIN = 1;
        private const int BALL_MAX = 49;   
        private int[] balls = new int[SIZE];
        private int emptySlot = 0;

        public void AddBall(int ball)
        {
            if (ball < BALL_MIN || ball > BALL_MAX)
                throw new ArgumentOutOfRangeException(nameof(ball), ball, string.Format($"Balls must be numbered between {BALL_MIN} and {BALL_MAX}."));

            if (balls.Contains(ball))
                throw new ArgumentException(string.Format($"The same ball must not be added more than once. Rack already contains the ball {ball}."));

            if (emptySlot == SIZE)
                throw new Exception($"There must not be more than {SIZE} balls on the rack.");

            // insert the ball in the correct position (bubbling other balls up) or in the empty slot
            int position = emptySlot++;
            while (position > 0 && balls[position-1] > ball)
                balls[position] = balls[--position]; // move ball up
            balls[position] = ball;
        }

        public IEnumerable<int> Balls()
        {
            return balls.TakeWhile(b => b != 0);
        }
    }
}
