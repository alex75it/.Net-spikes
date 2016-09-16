using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rack
{
    /// <summary>
    /// Represent a lottery rack where balls can be added and displayed.
    /// </summary>
    interface IRack
    {
        /// <summary>
        ///     Returns all the balls on the rack. The list of the balls is sorted
        ///     in ascending order.
        /// </summary>
        /// <returns>An enumeration of all the balls on the rack in order.</returns>
        IEnumerable<int> Balls();

        /// <summary>
        ///     Add a new ball to the rack
        ///     * Balls must be numbered between 1 and 49.
        ///     * There must not be more than 7 balls on the rack.
        ///     * The same ball must not be added more than once.
        /// </summary>
        /// <param name="ball">The value of the ball.</param>
        /// <exception cref="Exception">If any of the invariants are violated.</exception>
        void AddBall(int ball);
    }
}
