using UnityEngine;
using DG.Tweening;
using System;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    private Vector2 _direction;
    private bool _isMoving; 

   public void SetDirection(Vector2 vector2)
   {
        _direction = vector2;
   }

    public void MoveEnable(bool isMoving)
    {
        _isMoving = isMoving;
    }

    private void Move()
    {
        if(_isMoving)
            transform.position = transform.position + new Vector3(_direction.x, _direction.y) * Time.deltaTime * _speed;
    }

    private void Update()
    {
        Move();
    }
}
