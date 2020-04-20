using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    [MarkImportantInfo]public string name;

    [TextArea(3, 10)]
    [MarkImportantInfo]public string[] sentences;

}
