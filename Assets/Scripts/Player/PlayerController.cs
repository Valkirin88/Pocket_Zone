using System;
using UnityEngine;

public class PlayerController : IDisposable
{
    private readonly PlayerModel _model;
    private readonly PlayerView _view;
    private readonly SimpleTouchController _touchController;
    private readonly CanvasView _canvasView;

    public PlayerController(PlayerModel playerModel, PlayerView playerView, SimpleTouchController touchController, CanvasView canvasView)
    {
        _model = playerModel;
        _view = playerView;
        _touchController = touchController;
        _canvasView = canvasView;

        _view.OnBonusCollided += CollectBonus;
        _touchController.TouchEvent += _view.SetDirection;
        _touchController.TouchStateEvent += _view.MoveEnable;
        _canvasView.OnShootClicked += _view.Shoot;
    }

    private void CollectBonus(Bonus bonus, Collider2D collision)
    {
        if (_model.BonusCollection.Count < _model.MaxBonusNumber)
        {
            _model.CollectBonus(bonus);
            UnityEngine.Object.Destroy(collision.gameObject);
        }
    }

    public void Dispose()
    {
        _view.OnBonusCollided -= CollectBonus;
        _touchController.TouchEvent -= _view.SetDirection;
        _touchController.TouchStateEvent -= _view.MoveEnable;
        _canvasView.OnShootClicked -= _view.Shoot;
    }
}
