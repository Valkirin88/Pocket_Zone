using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasView : MonoBehaviour
{
    [SerializeField]
    private Button _shootButton;
    [SerializeField]
    private GameObject _inventoryObject;

    public Action OnShoot;

    private void Start()
    {
        _shootButton.onClick.AddListener(Shoot);
    }

    private void Shoot()
    {
        OnShoot?.Invoke();
    }

    public void AddBonus(GameObject bonusObject)
    {
        Instantiate(bonusObject, _inventoryObject.transform);
        bonusObject.transform.localScale = new Vector3(5,5,0);
    }
}
