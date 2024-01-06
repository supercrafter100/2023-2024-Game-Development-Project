using GameDevProject.Core.movement;
using GameDevProject.utility;
using GameDevProject.utility.collisions;
using GameDevProject.utility.statemachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Core.enemies;

public abstract class Enemy : StateMachine, IGameObject, ICollidable
{
    public abstract void Update(GameTime time);
    public abstract void Draw(SpriteBatch spriteBatch);
    public abstract Rectangle HitBox { get; set; }
    public bool Dead { get; set; } = false;
    
    public Vector2 Position { get; set; }
    public Direction Direction { get; set; } = Direction.Right;
    public abstract Texture2D Texture { get; set; }
    public abstract Rectangle DestinationCharacterRectangle { get; }
}