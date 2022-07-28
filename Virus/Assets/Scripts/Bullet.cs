using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string bulletname;
    public float damage;
    public Transform target;
    public float speed;
    public Transform bulletPos;
    public Transform originPos;

    public Rigidbody2D rigid;

    Vector2 dir;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        transform.position = bulletPos.position;
        originPos = bulletPos;

    }
    private void Update()
    {
        dir = target.position - transform.position;
        if (target != null)
        Moving();
        else if(target == null)
        {
            gameObject.SetActive(false);
        }
    }

    private void Moving()
    {
        transform.Translate(dir.normalized * speed * Time.deltaTime);
    }
}