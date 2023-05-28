using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private PlayerView _playerView;
    [SerializeField]
    private CanvasView _canvasView;
    [SerializeField]
    private SimpleTouchController _touchController;

    private PlayerModel _playerModel;
    private PlayerController _playerController;

    private void Start()
    {
        _playerModel = new PlayerModel();
        _playerController = new PlayerController(_playerModel, _playerView, _touchController, _canvasView);

    }

    private void Update()
    {
        _playerController.Update();
    }

    private void OnDestroy()
    {
        _playerController.Dispose();
    }
}
