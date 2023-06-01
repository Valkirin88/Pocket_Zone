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
            if (_inventoryView.InventorySlots[i] == null && !_isPresent)
            {
                int quantity = _bonusCollection[bonus];
                _inventoryView.InventorySlots[i].AddItem(bonus, quantity);
                _isPresent = true;
                UnityEngine.Debug.Log("new");
            }
 if(_inventoryView.InventorySlots[i] != null && bonus.BonusData == _inventoryView.InventorySlots[i].Bonus.BonusData && !_isPresent)
            {
                int quantity = _bonusCollection[bonus];
                _inventoryView.InventorySlots[i].AddSameItem(quantity);
                _isPresent = true;
            }

        }



        //_isPresent = false;

        //for (int i = 0; i < _inventoryView.InventorySlots.Length; i++)
        //{
        //   UnityEngine.Debug.Log(i);
        //    if (_inventoryView.InventorySlots[i].Bonus!=null)
        //    {
        //        if (bonus.BonusData == _inventoryView.InventorySlots[i].Bonus.BonusData)
        //        {
        //            int quantity = _bonusCollection[bonus];
        //            _inventoryView.InventorySlots[i].AddSameItem(quantity);
        //            _isPresent = true;
        //            UnityEngine.Debug.Log("same");
        //        }

        //    }
        //    if (!_isPresent)
        //    {

        //            if (_inventoryView.InventorySlots[i].IsEmpty && !_isPresent)
        //            {
        //                int quantity = _bonusCollection[bonus];
        //                _inventoryView.InventorySlots[i].AddItem(bonus, quantity);
        //                _isPresent = true;
        //                UnityEngine.Debug.Log("new");
        //            }
        //    }
        //}
    }
}
