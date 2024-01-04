using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GameDevProject.utility.animation;

public class Animation
{
    public AnimationFrame CurrentFrame { get; set; }
    private List<AnimationFrame> _frames;
    
    private int _counter;
    private double _secondCounter = 0;
    private int _fps;

    public Animation(int fps = 15)
    {
        _frames = new List<AnimationFrame>();
        _fps = fps;
    }

    public void AddFrame(AnimationFrame frame)
    {
        _frames.Add(frame);
        CurrentFrame = _frames[0];
    }

    public void AddFrames(List<AnimationFrame> frames)
    {
        _frames.AddRange(frames);
    }

    public void Update(GameTime time)
    {
        CurrentFrame = _frames[_counter];

        _secondCounter += time.ElapsedGameTime.TotalSeconds;
        
        if (_secondCounter >= 1d / _fps)
        {
            _counter++;
            _secondCounter = 0;
        }

        if (_counter >= _frames.Count)
        {
            _counter = 0;
        }
    }
}