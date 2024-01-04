using GameDevProject.utility.statemachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Core.gameStates;

public abstract class GameState : State
{
    public virtual void OnDraw(SpriteBatch batch) {}
}