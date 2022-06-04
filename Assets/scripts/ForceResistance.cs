using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceResistance : MonoBehaviour
{
    public bool b,bb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log(col);
        // b = IsInTopPos(col.gameObject.transform.position, col.gameObject.GetComponent<SpriteRenderer>().bounds.size, transform.position, GetComponent<SpriteRenderer>().bounds.size);
        bb = IsInRightxPos(col.gameObject.transform.position, transform.position, GetComponent<SpriteRenderer>().bounds.size);
        // Debug.Log(b);
        if (col.gameObject.tag == "Player" && bb)
        {
            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
                    col.gameObject.GetComponent<Rigidbody2D>().velocity.x,
                    0
            );
            // Debug.Log(col.gameObject.transform.position);
            // Debug.Log(GetComponent<SpriteRenderer>().bounds.size);

        }
        else if (col.gameObject.tag == "Player" && !bb)
        {
            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
                0,
                col.gameObject.GetComponent<Rigidbody2D>().velocity.y
            );
        }

    }
    // bool IsInTopPos(Vector2 ballpos, Vector2 ballsize, Vector2 position, Vector2 size)
    // {
    //     // get the minimum y position of the ball and the max y position of the ground
    //     // verify if the ball is not touching any of the right and left sides of the ground box
    //     Debug.Log(ballpos.y - ballsize.y / 2);
    //     Debug.Log(position.y + size.y / 2);
    //     return (ballpos.y - ballsize.y / 2).ToString().Substring(0,3) == (position.y + size.y / 2).ToString().Substring(0,3);
    // }
    bool IsInRightxPos(Vector2 ballpos, Vector2 position, Vector2 size)
    {
        float maxright = position.x + size.x / 2;
        float maxleft = position.x - size.x / 2;
        return maxleft <= ballpos.x && ballpos.x <= maxright;
    }
}