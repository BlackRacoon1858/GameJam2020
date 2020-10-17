using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public float speed = 25.0f;
    public float jump = 5.0f;
    public float run = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if(hor != 0.0f || ver != 0.0f)
        {
            Vector3 dir = transform.forward * ver + transform.right * hor;

            if (Input.GetKey("left shift"))
            {
                rigidbody.MovePosition(transform.position + dir * run * Time.deltaTime);
            }
            else 
            {
                rigidbody.MovePosition(transform.position + dir * speed * Time.deltaTime);
            }
        }

        if(Input.GetButtonDown("Jump"))
        {
            rigidbody.velocity = new Vector3(0, jump, 0);
        }
    }
}
