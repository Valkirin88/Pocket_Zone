using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel 
{
    public Action<Bonus> OnBonusCollect;

    private Dictionary<Bonus, int> _bonusCollection;

    public PlayerModel()
    {
        _bonusCollection = new Dictionary<Bonus, int>();
    }

    public void CollectBonus(Bonus bonus)
    {
        if(_bonusCollection.ContainsKey(bonus))
            _bonusCollection[bonus]++;
        else
            _bonusCollection.Add(bonus, 1);
        OnBonusCollect?.Invoke(bonus);

    }
}
