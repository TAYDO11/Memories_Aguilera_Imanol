using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public PlayerInventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision avec : " + other.name);

        if (other.CompareTag("Item"))
        {
            ItemPickup pickup = other.GetComponent<ItemPickup>();

            if (pickup == null)
            {
                Debug.LogError("ItemPickup manquant sur l’objet !");
                return;
            }

            if (inventory == null)
            {
                Debug.LogError("PlayerInventory non assigné !");
                return;
            }

            inventory.AddItem(pickup.itemData);
            Debug.Log(pickup.itemData.itemName + " ajouté à l’inventaire");

            Destroy(other.gameObject);
        }
    }
}
