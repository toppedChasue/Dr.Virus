using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 size;
    public LayerMask layer;

    public GameObject bullet;

    private bool isAttack;

    public Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
    }


    private void Attack()
    {
        //���������� ���� ������Ʈ ��ȯ
        Collider2D[] others = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + 8, transform.position.y), size, 0, layer);

        List<Collider2D> col2D = new List<Collider2D>();

        for (int i = 0; i < others.Length; i++)
        {
            col2D.Add(others[i]);
        }

    }

    void OnDrawGizmos()
    {//���� ���� �׷���
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + 8, transform.position.y), size);
    }

}
