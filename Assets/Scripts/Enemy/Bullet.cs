﻿using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    private Vector2 target;
    private static readonly int speed = 3;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Enemy")) { return; }
        
        if (collider2D.CompareTag("Player")) { collider2D.GetComponent<Health>().TakeDamage(); }

        Destroy(this.gameObject);
    }

    private void Update ()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance(this.transform.position,target) <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }
}