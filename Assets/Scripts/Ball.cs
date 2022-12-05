using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D body;
    private bool touch = false;
    private Vector3 angle;
    private float speed;

    private void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        touch = true;
        Debug.LogError("odbij");

        //angle = Vector3.Reflect(body.velocity.normalized, collision.contacts[0].normal);
    }
    private void Update()
    {
        var kat = angle;
        if (touch)
        {
            Odbij(kat);
        }
        touch = false;
    }

    private void Odbij(Vector3 angle)
    {
        //body.velocity = angle * 10f;
        body.velocity += body.velocity * 1f;
        if(body.velocity.magnitude > 1) body.velocity = Vector3.ClampMagnitude(body.velocity, 10);
    }
}
