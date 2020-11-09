using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 0.0001f;
    public float health = 1;
    public float maxSpeed = 0.0002f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //sets speed of ship by applying forces
        //rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * 50, 0));
        //rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * 50));

        //clamp speed to maxspeed to not get crazy results :p
        //rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        rb.transform.position += Vector3.ClampMagnitude(Input.GetAxis("Horizontal") * rb.transform.right * speed, maxSpeed);
        rb.transform.position += Vector3.ClampMagnitude(Input.GetAxis("Vertical") * rb.transform.up * speed, maxSpeed);

        //Make sure the ship does not go out of bounds
        Vector3 pos = Camera.main.WorldToViewportPoint(rb.transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        rb.transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    public void Damage()
    {
        health--;
        if(health==0)
        {
            Destroy(gameObject);
        }
    }
}
