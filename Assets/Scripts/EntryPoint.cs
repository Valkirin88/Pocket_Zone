using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private PlayerView _playerView;
    [SerializeField]
    private CanvasView _canvasView;
    [SerializeField]
    private SimpleTouchController _touchController;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = new PlayerController(_playerView, _touchController, _canvasView);

    }

    private void OnDestroy()
    {
        _playerController.Dispose();
    }
}
