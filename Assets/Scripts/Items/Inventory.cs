using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{

    public int size;
    public UnityEvent<int> onItemChange;

    private Item[] items;

    void Awake()
    {
        onItemChange = new UnityEvent<int>();
        items = new Item[size];
    }


    // Start is called before the first frame update
    void Start()
    {
        SetAt(0, new FlowerItem(SpeciesType.Popper, new Genome(SpeciesType.Popper, "11"), GrowthStage.Seedling));
        SetAt(1, new FlowerItem(SpeciesType.Popper, new Genome(SpeciesType.Popper, "11"), GrowthStage.Seedling));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public TItem GetAt<TItem>(int index) where TItem : Item
    {
        return (TItem)this.items[index];
    }

    public TItem GetAndEmptyAt<TItem>(int index) where TItem : Item
    {
        TItem item = (TItem)this.items[index];
        this.items[index] = null;
        this.onItemChange.Invoke(index);
        return item;
    }

    public void SetAt(int index, Item item)
    {
        this.items[index] = item;
        this.onItemChange.Invoke(index);
    }
}
