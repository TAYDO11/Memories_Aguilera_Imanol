using UnityEngine;

public class LightController3D : MonoBehaviour
{
    public Light playerLight;
    public PlayerInventory inventory;

    void Start()
    {
        if (playerLight != null)
            playerLight.enabled = false;

        inventory.ItemSelected += OnItemSelected;
    }

    void OnItemSelected(ItemData item)
    {
        if (playerLight != null)
            playerLight.enabled = item.givesLight;
    }
}