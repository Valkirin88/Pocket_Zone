using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private PlayerView _playerView;
    [SerializeField]
    private CanvasView _canvasView;
    [SerializeField]
    private SimpleTouchController _touchController;
    [SerializeField]
    private InventoryView _inventoryView;

    private PlayerModel _playerModel;
    private PlayerController _playerController;
    private CanvasController _canvasController;
    private InventoryController _inventoryController;

    private void Start()
    {
        _playerModel = new PlayerModel();
        _playerController = new PlayerController(_playerModel, _playerView, _touchController, _canvasView);
        _canvasController = new CanvasController(_canvasView);
        _inventoryController = new InventoryController(_inventoryView, _playerModel, _canvasView);
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
