using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 clickPos;
    [SerializeField]
    private float jumpForce;
    bool isJumping = false;

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 normal = contact.normal;
        Vector3 upVector = new Vector3(0, 1, 0);
        Vector3 downVector = new Vector3(0, -1, 0);
        float dotUN = Vector3.Dot(upVector, normal);
        float dotDN = Vector3.Dot(downVector, normal);
        float dotUpAngle = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        float dotDownAngle = Mathf.Acos(dotDN) * Mathf.Rad2Deg;

        if (Physics.gravity.y < 0)
        {
            if (dotUpAngle <= 45)
            {
                isJumping = false;
            }
        }
        else
        {
            if (dotDownAngle <= 45)
            {
                isJumping = false;
            }
        }
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
            Vector3 dir = clickPos - Input.mousePosition;
            float distance = dir.magnitude / 15;
            if (dir.sqrMagnitude == 0) { return; }
            if (distance > jumpForce) { distance = jumpForce; }
            rb.velocity = dir.normalized * distance;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Physics.gravity = new Vector3(0, -Physics.gravity.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Physics.gravity += new Vector3(0, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Physics.gravity -= new Vector3(0, 1, 0);
        }
    }
}
