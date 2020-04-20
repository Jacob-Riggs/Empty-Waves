using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQExamples : MonoBehaviour {

    [System.Serializable]
    public enum ItemType // Enums to hold the certain types of objects in the game
    {
        Collectable,
        PuzzleUnlock,
        PuzzlePiece
    }

    [System.Serializable]
    public class InventoryItem
    {
        public int id; // Holds an id
        public string itemName; // Holds the name of the object
        public ItemType itemtype; // Holds one of the enum objects
        public int itemLevel; // Holds the item "level," which is for puzzleUnlock items.
    }

    // Create our four keys so that there aren't two different keys made later.
    public InventoryItem keyOne;
    public InventoryItem keyTwo;
    public InventoryItem keyThree;
    public InventoryItem keyFour;

    // Create the invenyory list
    public List<InventoryItem> inventory = new List<InventoryItem>();

    // Create a list to hold all of the possible puzzle keys
    public List<InventoryItem> allPuzzleKeys= new List<InventoryItem>();


    // Use this for initialization
    void Start()
    {
        // Create the keys here so they can be passed into lists, and can be the same.
        keyOne = new InventoryItem { id = 1, itemName = "Puzzle One Key", itemtype = ItemType.PuzzleUnlock, itemLevel = 1 };
        keyTwo = new InventoryItem { id = 2, itemName = "Puzzle Two Key", itemtype = ItemType.PuzzleUnlock, itemLevel = 1 };
        keyThree = new InventoryItem { id = 3, itemName = "Puzzle Three Key", itemtype = ItemType.PuzzleUnlock, itemLevel = 2 };
        keyFour = new InventoryItem { id = 4, itemName = "Puzzle Four Key", itemtype = ItemType.PuzzleUnlock, itemLevel = 1 };


        // Add all keys to allPuzzleKeys
        allPuzzleKeys.Add(keyOne);
        allPuzzleKeys.Add(keyTwo);
        allPuzzleKeys.Add(keyThree);
        allPuzzleKeys.Add(keyFour);

        // Add some keys and other items to our inventory
        inventory.Add(keyOne);
        inventory.Add(keyTwo);
        inventory.Add(keyThree);
        inventory.Add(new InventoryItem { id = 5, itemName = "Piece of Mirror", itemtype = ItemType.Collectable, itemLevel = 0 });
        inventory.Add(new InventoryItem { id = 6, itemName = "Song Lyrics Notebook", itemtype = ItemType.Collectable, itemLevel = 0 });
        inventory.Add(new InventoryItem { id = 7, itemName = "Puzzle Item", itemtype = ItemType.PuzzlePiece, itemLevel = 0 });

    }

    // Update is called once per frame
    void Update () {
		
        if(Input.GetKeyDown("p")) // Press P to show off filter
        {
            FilterForCollectables();
        }

        if(Input.GetKeyDown("l")) // Press l to show off sorting
        {
            SortByLevel();
        }

        if(Input.GetKeyDown("k")) // Press k to show off except
        {
            CheckForKeys();
        }

	}

    void FilterForCollectables() // This function filters through our inventory and will only show our collectables
    {

        // Create a list to store and then show the collectables found in inventory
        List<InventoryItem> collectables = (from item in inventory
                                            where item.itemtype == ItemType.Collectable
                                            select item).ToList();
        
        // Display info of the collectables to the console to show they are found
        foreach (var i in collectables)
        {
            Debug.Log("Name: " + i.itemName + "     Type: " + i.itemtype + "     'Level': " + i.itemLevel);
        }

    }


    void SortByLevel() // This function goes through and orders the keys in our inventory by the level of which puzzle they unlock.
    {
        // Creat a list that will hold the keys in level order
        List<InventoryItem> puzzleUnlocks = (from item in inventory
                                             orderby item.itemLevel
                                             where item.itemtype == ItemType.PuzzleUnlock
                                             select item).ToList();
        // Display keys in order in console
        foreach (var i in puzzleUnlocks)
        {
            Debug.Log("Name: " + i.itemName + "     Type: " + i.itemtype + "     'Level': " + i.itemLevel);
        }

    }

    void CheckForKeys() // This function will compare allPuzzleKeys and our inventory and find out which keys we do not already hold.
    {

        List<InventoryItem> notHeld = (allPuzzleKeys.Except(inventory)).ToList(); // Make a list that will hold all that don't match between our lists when we use "Except"

        // Display the keys that are not in common
        foreach (var i in notHeld)
        {
            Debug.Log("Name: " + i.itemName + "     Type: " + i.itemtype + "     'Level': " + i.itemLevel);
        }



    }

}
