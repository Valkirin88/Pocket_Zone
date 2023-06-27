using System;
using System.Collections.Generic;

public class PlayerModel 
{
    public event Action<Bonus> OnBonusCollected;

    private int _maxBonusNumber = 4;

    private readonly Dictionary<string, int> _bonusCollection;

    public IReadOnlyDictionary<string, int> BonusCollection => _bonusCollection;

    public int MaxBonusNumber  => _maxBonusNumber; 

    public PlayerModel()
    {
        _bonusCollection = new Dictionary<string, int>();
    }

    public void CollectBonus(Bonus bonus)
    {
        if(BonusCollection.ContainsKey(bonus.BonusData.ItemID))
            _bonusCollection[bonus.BonusData.ItemID]++;
        else
            _bonusCollection.Add(bonus.BonusData.ItemID, 1);
        OnBonusCollected?.Invoke(bonus);

        UnityEngine.Debug.Log(_bonusCollection[bonus.BonusData.ItemID]);

    }
}
