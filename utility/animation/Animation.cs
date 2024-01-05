using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GameDevProject.utility.animation;

public class Animation
{
    public AnimationFrame CurrentFrame { get; set; }
    public List<AnimationFrame> Frames;
    
    public int Counter;
    private double _secondCounter = 0;
    private int _fps;

    public Animation(int fps = 15)
    {
        Frames = new List<AnimationFrame>();
        _fps = fps;
    }

    public void AddFrame(AnimationFrame frame)
    {
        Frames.Add(frame);
        CurrentFrame = Frames[0];
    }

    public void AddFrames(List<AnimationFrame> frames)
    {
        Frames.AddRange(frames);
        CurrentFrame = Frames[0];
    }

    public void Update(GameTime time)
    {
        CurrentFrame = Frames[Counter];

        _secondCounter += time.ElapsedGameTime.TotalSeconds;
        
        if (_secondCounter >= 1d / _fps)
        {
            Counter++;
            _secondCounter = 0;
        }

        if (Counter >= Frames.Count)
        {
            Counter = 0;
        }
    }

    public void Reset()
    {
        Counter = 0;
    }
}