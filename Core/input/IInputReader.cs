using Microsoft.Xna.Framework;

namespace GameDevProject.Core.input;

public interface IInputReader
{
    Vector2 ReadInput();
}