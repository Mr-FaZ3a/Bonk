using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicscript : MonoBehaviour
{
    [SerializeField]
    private KeyCode up, down, left, right;
    Rigidbody2D body;
    bool iscolliding,inx,iny;
    [SerializeField]
    private KeyCode Stronger;
    public GameObject shield;
    public Finish_restart controller;
    Color shieldrbg;
    float shieldmass = 10f ;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        shieldrbg = shield.GetComponent<SpriteRenderer>().color;
    }
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            // iny = col.gameObject.GetComponent<ForceResistance>().b;
            inx = col.gameObject.GetComponent<ForceResistance>().bb;
            iscolliding = true;
        }

    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            iscolliding = false;    
        }
    }
    void Update()
    {
        if (controller.is_started)
        {
            if (iscolliding == true && Input.GetKey(up) && inx)
            {
                body.AddForce(Vector2.up * 250);
            }
            if (Input.GetKey(up))
            {
                body.AddForce(Vector2.up * 10);
            }
            else if (Input.GetKey(down))
            {
                body.AddForce(Vector2.down * 10);
            }
             if (Input.GetKey(right))
            {
                body.AddForce(Vector2.right * 10);
            }
            else if (Input.GetKey(left))
            {
                body.AddForce(Vector2.left * 10);
            }
        }
    }
    void FixedUpdate()
    {
        // GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        if (Input.GetKey(Stronger))
        {
            shield.SetActive(true);
            body.mass = shieldmass;
            if (shieldmass > 6f)
            {   
                shieldmass -= 0.02f;
                shieldrbg.a -= 0.004f;
                shield.GetComponent<SpriteRenderer>().color = shieldrbg;
            }
        }
        else {
            body.mass = 5;
            shield.SetActive(false);
            if (shieldmass < 10f)
            {
                shieldmass += 0.02f;
                shieldrbg.a += 0.004f;
                shield.GetComponent<SpriteRenderer>().color = shieldrbg;
            }
        }
    }
}
