using System;
using System.Collections.Generic;

public class InventoryController
{
    private InventoryView _inventoryView;
    private PlayerModel _playerModel;
    private bool isPresent;
    private Dictionary<Bonus, int> _bonusCollection;
    private CanvasView _canvasView;

    public InventoryController(InventoryView view, PlayerModel playerModel, CanvasView canvasView)
    {
        _inventoryView = view;
        _playerModel = playerModel;
        _canvasView = canvasView;
        _bonusCollection = _playerModel.BonusCollection;
        _playerModel.OnBonusCollect += AddItem;
        _canvasView.OnInventory += _inventoryView.ShowHideInventory;
    }

    private void AddItem(Bonus bonus)
    {
        
        isPresent = false;
        for (int i = 0; i < _inventoryView.InventorySlots.Length; i++)
        {
            
            if (_inventoryView.InventorySlots[i].Bonus!=null && String.Equals(bonus.BonusData.Item, _inventoryView.InventorySlots[i].Bonus.BonusData.Item))
            {
                int quantity = _bonusCollection[bonus];
                _inventoryView.InventorySlots[i].AddSameItem(quantity);
                isPresent = true;
                UnityEngine.Debug.Log("same");
            }
            if (!isPresent)
            {
                for (int j = 0; j < _inventoryView.InventorySlots.Length; j++)
                {
                    if (_inventoryView.InventorySlots[i].IsEmpty)
                    {
                        int quantity = _bonusCollection[bonus];
                        _inventoryView.InventorySlots[i].AddItem(bonus, quantity);
                        isPresent = true;
                    }
                }
            }
        }

    }
}
