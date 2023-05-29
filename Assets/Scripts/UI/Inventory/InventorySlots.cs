using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlots : MonoBehaviour
{
    public Sprite Image;

    public Button SlotButton;

    public GameObject RemoveButton;

    public TMP_Text QuantityText;

    public GameObject QuantityPanel;

    public bool IsEmpty = true;

    public Bonus Bonus;

    private int _quantity;

    private void Start()
    {
        SlotButton.enabled = false;
    }

    public void AddItem(Bonus bonus, int quantity)
    {
        Bonus = bonus;
        _quantity = quantity;
        QuantityText.text = _quantity.ToString();
        IsEmpty = false;
        Image = bonus.BonusData.Image;
        SlotButton.enabled = true;
    }

    public void AddSameItem(int quantity)
    {
        _quantity = quantity;
    }



}
