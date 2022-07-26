using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 size;
    public LayerMask layer;
 
    // Update is called once per frame
    void Update()
    {
        //���������� ���� ������Ʈ ��ȯ
        Collider2D[] others = Physics2D.OverlapBoxAll(new Vector2(transform.position.x+8, transform.position.y), size, 0, layer);
        
    }




    void OnDrawGizmos()
    {//���� ���� �׷���
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + 8, transform.position.y), size);
    }

}
