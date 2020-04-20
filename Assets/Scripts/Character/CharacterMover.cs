using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CharacterMover : MonoBehaviour {

    public Transform tf;

    public Animator anim;

    public float moveSpeed;

    public Animation walkLeft;
    public Animation walkRight;
    public Animation walkUp;
    public Animation walkDown;

	// Use this for initialization
	void Start () {
        tf = gameObject.GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();

        StartCoroutine("Walk"); // Start our walk coroutine, instead of using a update for the code inside
	}
	
    public IEnumerator Walk() // Coroutine for movement
    {
        while (true) // Set up a while loop so that it keeps checking for inputs until it is said otherwise
        {
            if (Input.GetKey(KeyCode.A))
            {
                tf.position += Vector3.left * moveSpeed;
                anim.Play("walkleft");
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.Play("idleleft");
            }

            if (Input.GetKey(KeyCode.D))
            {
                tf.position += Vector3.right * moveSpeed;
                anim.Play("walkright");
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.Play("idleright");
            }

            if (Input.GetKey(KeyCode.W))
            {
                tf.position += Vector3.up * moveSpeed;
                anim.Play("walkup");
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.Play("idleup");
            }

            if (Input.GetKey(KeyCode.S))
            {
                tf.position += Vector3.down * moveSpeed;
                anim.Play("walkdown");
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.Play("idledown");
            }
            yield return null;
        }
    }
}
