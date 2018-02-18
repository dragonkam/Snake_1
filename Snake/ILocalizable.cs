using System.Drawing;

namespace SnakeGame
{
    public interface ILocalizable
    {
        Point Location { get; }
        Rectangle Bounds { get; }
    }
}
