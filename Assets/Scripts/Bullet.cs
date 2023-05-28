using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    public Vector2 Direction;

    private void Start()
    {
        Destroy(gameObject,2);
    }

    private void Update()
    {
        transform.position = transform.position + new Vector3(Direction.x, Direction.y) * Time.deltaTime * _speed;
    }


}
