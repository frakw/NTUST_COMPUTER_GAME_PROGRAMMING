using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody rigidBody;
    bool go_out = false;
    float start_time;
    public GameObject Explosion;

    public GameObject mainProjectile;
    public ParticleSystem mainParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        mainProjectile.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        bool pre_go_out = go_out;
        if (go_out && rigidBody.velocity.magnitude < 0.5f && Time.time - start_time > 2.0f)
        {
            GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);

            Destroy(this.gameObject, 0.25f);
            Destroy(explosion, 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(Vector3.up * 500);
            go_out = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            rigidBody.AddForce(Vector3.forward * 500);
            go_out = true;
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            rigidBody.AddForce(-Vector3.forward * 500);
            go_out = true;           
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            rigidBody.AddForce(Vector3.right * 500);
            go_out = true;            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            rigidBody.AddForce(Vector3.left * 500);
            go_out = true;            
        }

        if (go_out != pre_go_out) {
            start_time = Time.time;
        }
    }

    void FixedUpdate()
    {

    }
}
