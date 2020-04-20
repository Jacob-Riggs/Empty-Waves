using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InfoChecker {

	[MenuItem("EmptyWaves/CharacterCheck")]
    private static void CheckCharacter()
    {
        if(Selection.activeGameObject.name != null)
        {
            Debug.Log("Character has a name!");
        }
        {

        }
    }

}
