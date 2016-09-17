using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R = Rack;
using Should;

namespace Spikes.Tests
{
    [TestFixture, Category("Rack")]
    public class RackTest
    {

        [Test]
        public void ANewRack_Should_ContainsNoBalls()
        {
            R.Rack rack = new R.Rack();

            rack.Balls().ShouldBeEmpty();
        }

        [Test]
        public void WhenAddABall_BallsReturnABall()
        {
            R.Rack rack = new R.Rack();

            rack.AddBall(1);

            rack.Balls().ShouldNotBeEmpty();
            rack.Balls().Count().ShouldEqual(1);
            rack.Balls().First().ShouldEqual(1);               
        }

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        public void AddBall_when_BallisNotInTheValidRange_should_RaiseArgumentOutOfRangeException(int ball)
        {
            // rule "Balls must be numbered between 1 and 49"
            R.Rack rack = new R.Rack();

            Assert.Throws<ArgumentOutOfRangeException>( () => rack.AddBall(ball));
        }

        [Test]
        public void AddBall_when_RackIsFull_should_RaiseException()
        {
            // rule "There must not be more than 7 balls on the rack"
            int size = 7;
            R.Rack rack = new R.Rack(/*size*/);

            // add the maximum number of balls
            for (int counter = 1; counter <= size; counter++)
                rack.AddBall(counter);

            Assert.Throws<Exception>(() => rack.AddBall(size+1));
        }

        [Test]
        public void AddBall_when_ABallAlreadyExists_should_RaiseArgumentException()
        {
            // rule "The same ball must not be added more than once"
            R.Rack rack = new R.Rack();

            rack.AddBall(1);

            Assert.Throws<ArgumentException>(() => rack.AddBall(1));
        }

        [Test]
        public void Balls_should_ReturnOrderedListOfBalls()
        {
            R.Rack rack = new R.Rack();

            rack.AddBall(3);
            rack.AddBall(4);
            rack.AddBall(2);
            rack.AddBall(1);

            int[] balls = rack.Balls().ToArray();
            int[] orderedBalls = new SortedSet<int>(balls).ToArray();
            balls.ShouldEqual(orderedBalls);
        }
    }
}
