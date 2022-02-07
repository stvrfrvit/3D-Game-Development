using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public float kickDist;
    public float kickForce;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") == true)
        {
            Debug.DrawRay(transform.position, transform.forward * kickDist, Color.green, 1.5f);
            //raycast in forward direction from camera
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, kickDist) == true)
            {
                //get direction player is facing
                Vector3 dir = new Vector3(transform.forward.x, 0, transform.forward.z); //direction **
                //draw kick trajectory
                Debug.DrawRay(transform.position, dir * 3, Color.red, 1.5f);

                if (hit.collider.tag == "Ball") // hit tagged "ball"
                {
                    if (hit.collider.TryGetComponent(out Rigidbody rb) == true) //try to find rigid body on ball
                    {
                        rb.AddForce(dir * kickForce, ForceMode.Impulse); // add instant force to ballsw
                    }

                }
            }
        }
    }
}
