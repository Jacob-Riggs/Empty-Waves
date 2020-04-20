using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Name", menuName = "ScriptableObjects/Items", order = 1)]
public class ItemScriptableObject : ScriptableObject {

    public enum ItemType // Enums to hold the certain types of objects in the game
    {
        Collectable,
        PuzzleUnlock,
        PuzzlePiece
    }

    public string itemName { // Holds the name of the object 
        get
        {
            return itemName;
        }
    }
    public ItemType itemtype; // Holds one of the enum objects
    public int itemLevel; // Holds the item "level," which is for puzzleUnlock items.

}
