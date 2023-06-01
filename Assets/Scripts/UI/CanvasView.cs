using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasView : MonoBehaviour
{
    [SerializeField]
    private Button _shootButton;
    [SerializeField]
    private Button _inventoryButton;

    public event Action OnShootClicked;
    public event Action OnInventoryClicked;

    private void Start()
    {
        _shootButton.onClick.AddListener(Shoot);
        _inventoryButton.onClick.AddListener(ShowInventory);
    }

    private void OnDestroy()
    {
        _shootButton.onClick.RemoveListener(Shoot);
        _inventoryButton.onClick.RemoveListener(ShowInventory);
    }

    private void Shoot()
    {
        OnShootClicked?.Invoke();
    }
    private void ShowInventory()
    {
        OnInventoryClicked?.Invoke();
    }
}
