using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public LINQExamples inventory;

    public ItemScriptableObject scriptableObject;
    public string itemName;
    public ItemScriptableObject loadedItem;

    public LINQExamples.InventoryItem journal;

    public string objectName;
    public int objectLevel;

    public ItemScriptableObject.ItemType type;
    public LINQExamples.ItemType newType;

    // Use this for initialization
    void Start () {

        inventory = GetComponent<LINQExamples>();

        itemName = scriptableObject.name;
        loadedItem = Resources.Load<ItemScriptableObject>(scriptableObject.name);

        objectName = loadedItem.name;
        objectLevel = loadedItem.itemLevel;

        type = loadedItem.itemtype;
        if(type == ItemScriptableObject.ItemType.Collectable)
        {
            newType = LINQExamples.ItemType.Collectable;
        }

        journal = new LINQExamples.InventoryItem { id = 8, itemName = objectName, itemtype = newType, itemLevel = objectLevel };

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<LINQExamples>().inventory.Add(journal);
        Destroy(this.gameObject);
    }

}
