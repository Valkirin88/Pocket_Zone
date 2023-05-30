using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlots : MonoBehaviour
{
    public Image Image;

    public Button SlotButton;

    public GameObject RemoveButton;

    public TMP_Text QuantityText;

    public GameObject QuantityPanel;

    public bool IsEmpty;

    public Bonus Bonus;

    private int _quantity;

    private void Start()
    {
        SlotButton.enabled = false;
        IsEmpty = true;
     
    }

    public void AddItem(Bonus bonus, int quantity)
    {
        Bonus = bonus;
        _quantity = quantity;
        QuantityText.text = _quantity.ToString();
        IsEmpty = false;
        Image.sprite = bonus.BonusData.Image;
        Image.preserveAspect = true;
        SlotButton.enabled = true;
    }

    public void AddSameItem(int quantity)
    {
        _quantity = quantity;
    }
}
