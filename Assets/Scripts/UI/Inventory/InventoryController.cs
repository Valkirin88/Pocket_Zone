using System;
using System.Collections.Generic;

public class InventoryController
{
    private readonly InventoryView _inventoryView;
    private readonly PlayerModel _playerModel;
    private readonly IReadOnlyDictionary<Bonus, int> _bonusCollection;
    private readonly CanvasView _canvasView;
    private bool _isPresent;

    public InventoryController(InventoryView view, PlayerModel playerModel, CanvasView canvasView)
    {
        _inventoryView = view;
        _playerModel = playerModel;
        _canvasView = canvasView;
        _bonusCollection = _playerModel.BonusCollection;

        _playerModel.OnBonusCollected += AddItem;
        _canvasView.OnInventoryClicked += _inventoryView.ShowHideInventory;
    }

    private void AddItem(Bonus bonus)
    {
        _isPresent = false;
        for (int i = 0; i < _inventoryView.InventorySlots.Length; i++)
        {
            if (_inventoryView.InventorySlots[i].IsEmpty && !_isPresent)
            {
                int quantity = _bonusCollection[bonus];
                _inventoryView.InventorySlots[i].AddItem(bonus, quantity);
                _isPresent = true;
            }
            if(!_inventoryView.InventorySlots[i].IsEmpty && String.Equals(bonus.BonusData.ItemID, _inventoryView.InventorySlots[i].Bonus.BonusData.ItemID) && !_isPresent)
            {
                int quantity = _bonusCollection[bonus];
                _inventoryView.InventorySlots[i].AddSameItem(quantity);
                _isPresent = true;
            }
        }
    }
}
