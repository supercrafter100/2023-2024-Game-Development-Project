using GameDevProject.Core.input;
using Microsoft.Xna.Framework;

namespace GameDevProject.Core.movement;

public interface IMovable
{
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    public IInputReader InputReader { get; set; }
}