using System;
using UnityEngine;

public class PlayerController : IDisposable
{
    private PlayerView _playerView;
    private SimpleTouchController _touchController;
    private CanvasView _canvasView;

    public PlayerController(PlayerView playerView, SimpleTouchController touchController, CanvasView canvasView)
    {
        _playerView = playerView;
        _touchController = touchController;
        _canvasView = canvasView;
        _touchController.TouchEvent += _playerView.SetDirection;
        _touchController.TouchStateEvent += _playerView.MoveEnable;
    }

    public void Dispose()
    {
        _touchController.TouchEvent -= _playerView.SetDirection;
        _touchController.TouchStateEvent -= _playerView.MoveEnable;
    }
}
