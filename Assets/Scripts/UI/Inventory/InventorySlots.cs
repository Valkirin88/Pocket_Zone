using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventorySlots : MonoBehaviour
{
    public Image Image;

    public Button SlotButton;

    public GameObject RemoveButtonObject;

    [SerializeField]
    private Button RemoveButton;

    public TMP_Text QuantityText;

    public GameObject QuantityPanel;

    public bool IsEmpty;

    public Bonus Bonus;

    private int _quantity;

    private bool _isRemoveButtonShown;

    private void Start()
    {
        SlotButton.enabled = false;
        IsEmpty = true;
        _isRemoveButtonShown = false;

        SlotButton.onClick.AddListener(ShowHideRemoveButton);
    }

    private void Update()
    {
        if (_quantity > 1)
            ShowQuantity();
        else
            HideQuantity();
    }

    private void ShowQuantity()
    {
        QuantityPanel.SetActive(true);
    }

    private void HideQuantity()
    {
        QuantityPanel.SetActive(false);
    }

    private void ShowHideRemoveButton()
    {
        if (!_isRemoveButtonShown)
        { _isRemoveButtonShown = true;
            RemoveButtonObject.SetActive(true);
            RemoveButton = RemoveButtonObject.GetComponent<Button>();
            RemoveButton.onClick.AddListener(RemoveItem);
        }
        if (_isRemoveButtonShown)
        {
            _isRemoveButtonShown = false;
            RemoveButton.onClick.RemoveListener(RemoveItem);
            RemoveButtonObject.SetActive(false);
        }
    }

    private void ShowEmptySlot()
    {
        ShowHideRemoveButton();
        Image.sprite = null;
        SlotButton.enabled = false;
    }

    private void RemoveItem()
    {
        if (_quantity > 1)
            _quantity--;
        else
        {
            _quantity = 0;
            Bonus = null;
            ShowEmptySlot();
        }
    }

    public void AddItem(Bonus bonus, int quantity)
    {
        Bonus = bonus;
        _quantity = quantity;
        QuantityText.text = _quantity.ToString();
        IsEmpty = false;
        Image.sprite = Bonus.BonusData.Image;
        Image.preserveAspect = true;
        SlotButton.enabled = true;
    }

    public void AddSameItem(int quantity)
    {
        _quantity = quantity;
        QuantityText.text = _quantity.ToString();
        ShowQuantity();
    }
}
