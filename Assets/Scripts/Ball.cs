using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance
    {
        get => FindObjectOfType<Ball>();
    }

    private Rigidbody2D rb;
    private Vector2 lastVelocity;

    public static Action OnBallDestroy { get; set; }
    public static bool inHole;

    private AudioSource Source { get; set; }

    private void Awake()
    {
        inHole = false;

        rb = GetComponent<Rigidbody2D>();
        Source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
        if(lastVelocity.magnitude <= 0.1f && !inHole)
        {
            OnBallDestroy?.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Source.Play();

        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0.0f);
    }
}