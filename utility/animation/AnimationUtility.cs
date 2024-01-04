using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GameDevProject.utility.animation;

public class AnimationUtility
{
    public static List<AnimationFrame> GetFramesFromTextureProperties(int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
    {
        List<AnimationFrame> frames = new List<AnimationFrame>();
        int widthOfFrame = width / numberOfWidthSprites;
        int heightOfFrame = height / numberOfHeightSprites;

        for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
        {
            for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
            {
                frames.Add(new AnimationFrame(new Rectangle(x,y,widthOfFrame, heightOfFrame)));
            }
        }

        return frames;
    }
}