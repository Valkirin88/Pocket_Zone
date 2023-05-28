using System;
using UnityEngine;

public class PlayerController : IDisposable
{
    private PlayerModel _model;
    private PlayerView _view;
    private SimpleTouchController _touchController;
    private CanvasView _canvasView;

    public PlayerController(PlayerModel playerModel, PlayerView playerView, SimpleTouchController touchController, CanvasView canvasView)
    {
        _model = playerModel;
        _view = playerView;
        _touchController = touchController;
        _canvasView = canvasView;
        _view.OnBonusCollect += _model.CollectBonus;
        _touchController.TouchEvent += _view.SetDirection;
        _touchController.TouchStateEvent += _view.MoveEnable;
        _canvasView.OnShoot += _view.Shoot;
    }

  
    public void Update()
    {
        _view.Move();
    }

    public void Dispose()
    {
        _touchController.TouchEvent -= _view.SetDirection;
        _touchController.TouchStateEvent -= _view.MoveEnable;
    }
}
