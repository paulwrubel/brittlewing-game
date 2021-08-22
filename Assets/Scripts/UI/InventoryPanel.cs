using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{

    public GameObject inventorySlotPrefab;
    public Inventory inventory;

    private GridLayoutGroup gridLayoutGroup;
    private InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();

        slots = new InventorySlot[inventory.size];

        for (int i = 0; i < inventory.size; i++)
        {
            GameObject inventorySlotGO = Instantiate(inventorySlotPrefab, this.transform);
            InventorySlot inventorySlot = inventorySlotGO.GetComponent<InventorySlot>();
            inventorySlot.inventory = this.inventory;
            inventorySlot.index = i;

            if (inventory.GetAt<Item>(i) != null)
            {
                inventorySlot.Fill(inventory.GetAt<Item>(i));
            }

            slots[i] = inventorySlot;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
