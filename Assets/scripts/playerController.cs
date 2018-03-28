using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

    public float speed;
    Rigidbody rb;
    Scene name;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        name = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update ()
    {
        if (name.name == "2d pong")
        {
            if (Input.GetKey(KeyCode.A)) //Left
            {
                rb.velocity = new Vector3(0, 0, speed);
            }

            else if (Input.GetKey(KeyCode.D)) //Right
            {
                rb.velocity = new Vector3(0, 0, -speed);
            }
            else
                rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
/*

    for()
    if i == score
    [].game.set(true)

    [i].game.set(false)

 * /
