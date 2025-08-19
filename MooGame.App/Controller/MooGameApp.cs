using MooGame.App.Helper;
using MooGame.App.Interfaces;

namespace MooGame.App.Controller;

public class MooGameApp : IGame
{
    private MooGameController _controller;
    public MooGameApp(INumberGenerator _numberGenerator, IInputOutput _inputOutput)
    {
        _controller = new MooGameController(_numberGenerator, _inputOutput);
    }

    public void RunGame()
    {
        _controller.Play();
    }
}
