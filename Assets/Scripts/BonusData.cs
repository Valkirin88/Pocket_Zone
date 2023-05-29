using UnityEngine;

[CreateAssetMenu(fileName ="Bonus", menuName = "ScriptableObjects/Bonus")]
public class BonusData : ScriptableObject
{
    [SerializeField]
    private string _itemName;

    [SerializeField]
    private GameObject _item;

    [SerializeField]
    private Sprite _image;

    public GameObject Item => _item;

    public Sprite Image  => _image; 
}
