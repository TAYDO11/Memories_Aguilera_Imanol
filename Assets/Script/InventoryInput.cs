using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    public PlayerInventory inventory;

    void Update()
    {
        if (inventory.items.Count == 0) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            inventory.SelectItem(inventory.items[0]);

        if (inventory.items.Count > 1 && Input.GetKeyDown(KeyCode.Alpha2))
            inventory.SelectItem(inventory.items[1]);
    }
}
