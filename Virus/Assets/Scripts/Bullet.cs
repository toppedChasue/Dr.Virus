using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string bulletname;
    public Transform target;
    public float damage;
    public float speed;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}