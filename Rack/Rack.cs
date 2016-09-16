using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rack
{
    public class Rack : IRack
    {
        private HashSet<int> balls;
        private const int SIZE = 7;
        private const int BALL_MIN = 1;
        private const int BALL_MAX = 49;       

        public Rack()
        {
            this.balls = new HashSet<int>();
        }
        public void AddBall(int ball)
        {
            if (ball < BALL_MIN || ball > BALL_MAX)
                throw new ArgumentOutOfRangeException(nameof(ball), ball, string.Format($"Balls must be numbered between {BALL_MIN} and {BALL_MAX}."));

            if (balls.Contains(ball))
                throw new ArgumentException(string.Format($"The same ball must not be added more than once. Rack already contains the ball {ball}."));

            if (balls.Count == SIZE)
                throw new Exception($"There must not be more than {SIZE} balls on the rack.");

            balls.Add(ball);
        }

        public IEnumerable<int> Balls()
        {
            return Sort(balls);
        }
        internal IEnumerable<int> Sort(IEnumerable<int> balls)
        {
            int[] orderedBalls = balls.ToArray();
            int startPosition = 0;
            while (startPosition < orderedBalls.Length - 1)
            for (int position = startPosition; position < orderedBalls.Length-1; position++)
            {
                // check if item[x] is bigger than item[x+1] and switch values if true
                if (orderedBalls[position] > orderedBalls[position + 1])
                {
                    int temp = orderedBalls[position + 1]; // store B apart
                    orderedBalls[position + 1] = orderedBalls[position]; // move A in B
                    orderedBalls[position] = temp; // move B in A
                }
                else
                {
                    startPosition++;
                }
            }
            return orderedBalls;
        }
    }
}
