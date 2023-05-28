using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private Transform _gunTransform;

    [SerializeField]
    private GameObject _bullet;

    [SerializeField]
    private float _speed = 3f;

    private Vector2 _direction;
    private bool _isMoving; 


   public void SetDirection(Vector2 vector2)
   {
        _direction = vector2.normalized;
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

    public void Shoot()
    {
        Instantiate(_bullet, _gunTransform.position, Quaternion.identity);
        _bullet.GetComponent<Bullet>().Direction = _direction;
        

    }

    private void Update()
    {
        Move();
        Debug.Log(_direction);
    }
}
