using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasView : MonoBehaviour
{
    [SerializeField]
    private Button _shootButton;
    [SerializeField]
    private Button _inventoryButton;

    public Action OnShoot;
    public Action OnInventory;

    private void Start()
    {
        _shootButton.onClick.AddListener(Shoot);
        _inventoryButton.onClick.AddListener(ShowInventory);
    }

    private void Shoot()
    {
        OnShoot?.Invoke();
    }
    private void ShowInventory()
    {
        OnInventory?.Invoke();
    }

}
