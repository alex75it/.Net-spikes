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

        public Rack()
        {
            this.balls = new HashSet<int>();
        }
        public void AddBall(int ball)
        {
            balls.Add(ball);
        }

        public IEnumerable<int> Balls()
        {
            return balls;
        }
    }
}
