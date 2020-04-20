using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightChoice : MonoBehaviour {

    public GameObject door;

    public AudioClip clip;
    private Vector3 position;

    // Use this for initialization
    void Start() {
        position = transform.position;
    }

    // Update is called once per frame
    void Update() {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // play door unlock sound
            AudioSource.PlayClipAtPoint(clip, position);
            door.SetActive(true);    
        }
    }

}
