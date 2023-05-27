using System;
using UnityEngine;

public class PlayerController 
{
    private PlayerView _playerView;
    private SimpleTouchController _touchController;

    public PlayerController(PlayerView playerView, SimpleTouchController touchController)
    {
        _playerView = playerView;
        _touchController = touchController;
        _touchController.TouchEvent += _playerView.SetDirection;
        _touchController.TouchStateEvent += _playerView.MoveEnable;
    }
    

}
