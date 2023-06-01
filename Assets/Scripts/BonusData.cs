using UnityEngine;

[CreateAssetMenu(fileName ="Bonus", menuName = "ScriptableObjects/Bonus")]
public class BonusData : ScriptableObject
{
    [SerializeField]
    private string _itemID;

    [SerializeField]
    private GameObject _itemPrefab;

    [SerializeField]
    private Sprite _image;

    public GameObject ItemPrefab => _itemPrefab;

    public Sprite Image  => _image;

    public string ItemID  => _itemID; 
}
