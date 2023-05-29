using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField]
    private Canvas _inventoryCanvas;

    public InventorySlots[] InventorySlots;

    private bool _isInventoryActive = false;

    private void Start()
    {
        InventorySlots = GetComponentsInChildren<InventorySlots>();
    }

    public void ShowHideInventory()
    {
        if (_isInventoryActive)
            _inventoryCanvas.enabled = true;
        else 
            _inventoryCanvas.enabled = false;
    }
}
