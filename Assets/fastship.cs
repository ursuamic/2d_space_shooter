using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastship : MonoBehaviour
{
    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;
    public bool canShoot;
    public float fireRate;
    public float health;
    // Start is called before the first frame update

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed * -1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<SpaceShip>().Damage();
            //add a force from the collision
            //TODO make sure the angle of collision matters
            col.otherRigidbody.AddForceAtPosition(rb.velocity * rb.mass, new Vector2(col.GetContact(0).point.x, col.GetContact(0).point.y));
            Die();
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}


