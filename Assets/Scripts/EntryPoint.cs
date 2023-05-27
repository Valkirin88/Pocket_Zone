using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private PlayerView _playerView;
    [SerializeField]
    private SimpleTouchController _touchController;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = new PlayerController(_playerView, _touchController);
    }
}
