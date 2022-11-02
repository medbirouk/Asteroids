using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 500.0f;
    public float maxTime = 10.0f;
    private Rigidbody2D rigidbody; 

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    } 

    public void Project(Vector2 direction)
    {
        rigidbody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxTime); 

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
