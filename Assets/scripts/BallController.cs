using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    Rigidbody rb;
    public float speed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("startBall", 0);
    }

    void Update()
    {
      if(rb.velocity.x < 5f && rb.velocity.z < 5f)
        {
            Vector3 hold = rb.velocity;
            hold.z = 1f * rb.velocity.z;
            hold.x = 1f * rb.velocity.x;
            rb.velocity = hold;
        }
    }

    void startBall()
    {
        rb.AddForce(new Vector3(speed * -1, 0, speed), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Paddle"))
        {
            Vector3 hold = rb.velocity;
            hold.z *= -1;
            rb.AddForce(hold);
            rb.velocity = hold * speed;
        }
        else
        {
            Vector3 hold = rb.velocity;
            hold.z *= -1;
            rb.AddForce(Vector3.forward * Mathf.Sign(hold.z) * -1, ForceMode.Impulse);
            rb.velocity = hold * speed;
        }
    }
}