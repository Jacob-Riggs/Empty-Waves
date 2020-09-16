using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObjects/Character", order = 2)]
public class Character : ScriptableObject {

    public string fullName;
    public Sprite portrait;

}
