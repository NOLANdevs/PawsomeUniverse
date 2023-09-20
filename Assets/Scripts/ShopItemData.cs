using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop/Shop Item")]
public class ShopItemData : ScriptableObject
{
    public GameObject itemPrefab;
    public int itemPrice;
}
