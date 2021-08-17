using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject inventorySlotPrefab;
    public int totalSlots;

    private GridLayoutGroup gridLayoutGroup;

    // Start is called before the first frame update
    void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();

        for (int i = 0; i < totalSlots; i++)
        {
            GameObject inventorySlotGO = Instantiate(inventorySlotPrefab, this.transform);
            // FlowerPlot flowerPlot = inventorySlotGO.GetComponent<InventorySlot>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
