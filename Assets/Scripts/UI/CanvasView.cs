using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasView : MonoBehaviour
{
    [SerializeField]
    private Button _shootButton;

    private Action OnShoot;

    private void Start()
    {
        _shootButton.onClick.AddListener(Shoot);
    }

    private void Shoot()
    {
        OnShoot?.Invoke();
    }
}
