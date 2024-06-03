using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 clickPos;
    [SerializeField] 
    private float jumpForce = 10.0f;
    bool isJumping = false;

    private void OnCollisionStay(Collision collision)
    {
        isJumping = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        isJumping = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickPos = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0) && !isJumping)
        {
            Vector3 dist = clickPos - Input.mousePosition;
            if(dist.sqrMagnitude == 0) { return; }
            rb.velocity = dist.normalized * jumpForce;
        }


    }
}
