using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float jumpForce = 1000f;
    [SerializeField] private float gravity = -9.81f;
    private float speedValue;
    private Rigidbody rb;
    private bool isGround = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, gravity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 velocity = rb.velocity;
        velocity.x = horizontalInput * speedValue;
        velocity.z = verticalInput * speedValue;
        rb.velocity = velocity;
        if (isGround && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(transform.up*jumpForce);
            isGround = false;
            speedValue += 3f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Hall")
        isGround = true;
        speedValue = speed;
        
    }
}
