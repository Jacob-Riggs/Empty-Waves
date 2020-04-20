using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class SaveSettings : MonoBehaviour {

    public GameObject volumeSlider;

    public float volumeController;

    public float volume;

    public void Start()
    {
       
    }
    

    // This save function will grab our volume setting in the menu and will set it in a JSON function as "Volume, [amount]". Then it will save the contents of our settings into a SettingsSave.json file to be loaded later.
    void Save()
    {
        JSONObject settingsJson = new JSONObject();
        settingsJson.Add("Volume", volume);

        Debug.Log(settingsJson.ToString());

        string path = Application.persistentDataPath + "/SettingsSave.json";
        File.WriteAllText(path, settingsJson.ToString());
    }

    // This load function will access the SettingsSave.json file and sift through it, finding the volume amount. Once it is able to grab that value, it will access our volume value in the settings and alter it to match, if it has chamged.
    void Load()
    {
        string path = Application.persistentDataPath + "/SettingsSave.json";
        string jsonString = File.ReadAllText(path);
        JSONObject settingsJson = (JSONObject)JSON.Parse(jsonString);

        Debug.Log(settingsJson.ToString());

        volumeSlider.GetComponent<VolumeController>().volumeAudio.volume = settingsJson["Volume"];
    }

    public void Update()
    {
        // Show off save and load by using S and L.
        volumeController = volumeSlider.GetComponent<VolumeController>().volumeAudio.volume;
        volume = volumeController;
        if (Input.GetKeyDown(KeyCode.S)) Save();
        if (Input.GetKeyDown(KeyCode.L)) Load();
    }
    

}
