using Microsoft.Xna.Framework;

namespace GameDevProject.utility.animation;

public class AnimationFrame
{
    public Rectangle SourceRectangle { get; set; }

    public AnimationFrame(Rectangle sourceRectangle)
    {
        SourceRectangle = sourceRectangle;
    }
}