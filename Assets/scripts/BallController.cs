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

    void startBall()
    {
        rb.AddForce(new Vector3(speed * -1, 0, speed), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Paddle"))
            rb.velocity = new Vector3(collision.relativeVelocity.x, collision.relativeVelocity.y, collision.relativeVelocity.z);
        else
        {
            Vector3 hold = rb.velocity;
            //hold.z = (rb.velocity.z / 2f) + (collision.collider.attachedRigidbody.velocity.z / 3f);
            hold.z *= -1;
            rb.AddForce(Vector3.forward * Mathf.Sign(hold.z) * 1, ForceMode.Impulse);
            speed = speed + .01f;
            rb.velocity = hold * speed;
        }
    }
}