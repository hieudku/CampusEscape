using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed;
    public int x_axis;
    public int limit;
    public int count = 0;

    Rigidbody rb;
    Animator anim1;

    private float speed1;
    private int flip;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim1 = this.GetComponent<Animator>();
        anim1.SetBool("Run", false);
        anim1.SetBool("Jump", false);
        speed1 = speed;
        if (x_axis == 1)
        {
            this.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        if (x_axis == 0) 
        {
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count = count + 1;

        
        float x = this.transform.position.x;
        float z = this.transform.position.z;
        float y = this.transform.position.y;

        if (x_axis == 1)
        {
            anim1.SetBool("Walk", true);
            if (count >= limit)
            {
                Debug.Log("x_axis = 1");
                if (flip == 0)
                {
                    this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                    speed = 0 - speed;
                    count = 0;
                    flip = 1;

                }
                else if (flip == 1)
                {
                    this.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                    count = 0;
                    speed = speed1;
                    flip = 0;

                }
                
            }
            this.transform.position = new Vector3(x + speed, y, z);
            
            
        }
        if (x_axis == 0) 
        {
            anim1.SetBool("Walk", true);
            if (count >= limit)
            {
                Debug.Log("x_axis = 0");
                if (flip == 0)
                {

                    this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    speed = speed1;
                    count = 0;
                    flip = 1;

                }
                else if (flip == 1)
                {
                    this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    count = 0;
                    speed = 0 - speed;
                    flip = 0;

                }

                
            }
            this.transform.position = new Vector3(x, y, z + speed);
        }
        
    }
}
