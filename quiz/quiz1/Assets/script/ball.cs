using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody rigidBody;
    bool go_out = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<ParticleSystem>().Pause();
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (go_out && rigidBody.velocity.magnitude < 0.5f)
        {
            GetComponentInChildren<ParticleSystem>().Play();
            //Debug.Log("mew");
        }
        else {
            GetComponentInChildren<ParticleSystem>().Pause();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(Vector3.up * 500);
            go_out = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            rigidBody.AddForce(Vector3.forward * 500);
            go_out = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rigidBody.AddForce(-Vector3.forward * 500);
            go_out = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigidBody.AddForce(Vector3.right * 500);
            go_out = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigidBody.AddForce(Vector3.left * 500);
            go_out = true;
        }
    }

    void FixedUpdate()
    {

    }
}
