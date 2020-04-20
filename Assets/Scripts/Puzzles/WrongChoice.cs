using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongChoice : MonoBehaviour {

    public int sceneToLoad;

    public AudioClip clip;
    private Vector3 position;

    // Use this for initialization
    void Start() {
        position = transform.position;
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            // play death sound
            AudioSource.PlayClipAtPoint(clip, position);
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
