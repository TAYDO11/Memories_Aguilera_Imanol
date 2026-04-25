using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();
    public ItemData selectedItem;

    public delegate void OnItemSelected(ItemData item);
    public event OnItemSelected ItemSelected;

    public void AddItem(ItemData item)
    {
        items.Add(item);
        Debug.Log(item.itemName + " ajouté à l'inventaire");
    }

    public void SelectItem(ItemData item)
    {
        selectedItem = item;
        ItemSelected?.Invoke(item);
        Debug.Log(item.itemName + " sélectionné");
    }
}