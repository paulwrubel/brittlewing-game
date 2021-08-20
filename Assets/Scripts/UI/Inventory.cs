using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject inventorySlotPrefab;
    public int totalSlots;
    public Item[] items;

    private GridLayoutGroup gridLayoutGroup;
    private InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();

        items = new Item[totalSlots];
        items[0] = new FlowerItem(SpeciesType.Popper, new Genome(SpeciesType.Popper, "11"), GrowthStage.Seedling);
        items[1] = new FlowerItem(SpeciesType.Popper, new Genome(SpeciesType.Popper, "11"), GrowthStage.Seedling);

        slots = new InventorySlot[totalSlots];

        for (int i = 0; i < totalSlots; i++)
        {
            GameObject inventorySlotGO = Instantiate(inventorySlotPrefab, this.transform);
            InventorySlot inventorySlot = inventorySlotGO.GetComponent<InventorySlot>();

            if (items[i] != null)
            {
                inventorySlot.Fill(items[i]);
            }

            slots[i] = inventorySlot;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
