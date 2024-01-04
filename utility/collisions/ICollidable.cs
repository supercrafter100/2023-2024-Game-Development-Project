using Microsoft.Xna.Framework;

namespace GameDevProject.utility.collisions;

public interface ICollidable
{
    public Rectangle GetCollider();
}