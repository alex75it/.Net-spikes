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
            return balls;
        }
    }
}
