using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private Transform _gunTransform;

    [SerializeField]
    private GameObject _bullet;

    [SerializeField]
    private float _speed = 3f;

    public Action<Bonus> OnBonusCollect;

    private Vector2 _direction;
    private bool _isMoving;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bonus bonus = collision.GetComponent<Bonus>();
        if (bonus != null)
        {
            OnBonusCollect?.Invoke(bonus);
            Destroy(collision.gameObject);
        }
    }

    public void SetDirection(Vector2 vector2)
   {
        _direction = vector2.normalized;
   }

    public void MoveEnable(bool isMoving)
    {
        _isMoving = isMoving;
    }

    public void Move()
    {
        if(_isMoving)
            transform.position = transform.position + new Vector3(_direction.x, _direction.y) * Time.deltaTime * _speed;
    }

    public void Flip()
    {
        transform.localScale = new Vector3(-1 *transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void Shoot()
    {
        Instantiate(_bullet, _gunTransform.position, Quaternion.identity);
        _bullet.GetComponent<Bullet>().Direction = _direction;
    }
}
