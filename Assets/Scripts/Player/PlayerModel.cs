using System;
using System.Collections.Generic;

public class PlayerModel 
{
    public event Action<Bonus> OnBonusCollected;

    private int _maxBonusNumber = 4;

    private readonly Dictionary<Bonus, int> _bonusCollection;

    public IReadOnlyDictionary<Bonus, int> BonusCollection => _bonusCollection;

    public int MaxBonusNumber  => _maxBonusNumber; 

    public PlayerModel()
    {
        _bonusCollection = new Dictionary<Bonus, int>();
    }

    public void CollectBonus(Bonus bonus)
    {
        if(BonusCollection.ContainsKey(bonus))
            _bonusCollection[bonus]++;
        else
            _bonusCollection.Add(bonus, 1);
        OnBonusCollected?.Invoke(bonus);

    }
}
