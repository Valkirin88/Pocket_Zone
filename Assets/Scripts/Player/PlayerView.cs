using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private Transform _gunTransform;

    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _speed = 3f;

    public event Action<Bonus, Collider2D> OnBonusCollided;

    private Vector2 _direction;
    private bool _isMoving;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bonus bonus = collision.GetComponent<Bonus>();
        if (bonus != null)
        {
            OnBonusCollided?.Invoke(bonus, collision);
        }
    }
    private void Update()
    {
        if (_isMoving)
            transform.position = transform.position + new Vector3(_direction.x, _direction.y) * Time.deltaTime * _speed;
    }

    public void SetDirection(Vector2 vector2)
   {
        _direction = vector2.normalized;
   }

    public void MoveEnable(bool isMoving)
    {
        _isMoving = isMoving;
    }
    
    public void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab, _gunTransform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Direction = _direction;
    }
}
