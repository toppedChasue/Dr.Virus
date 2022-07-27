using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 size;
    public LayerMask layer;

    public GameObject bullet;
    public Transform bulletPos;

    //���� ���� ���� ���� ���� ������

    private void Start()
    {
        SearchVirus();
    }
    private void SearchVirus()
    {
        Collider2D[] obj = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + 8, transform.position.y), size, 0, layer);

        List<Collider2D> collider2Ds = new List<Collider2D>();
        Debug.Log(collider2Ds);

        for (int i = 0; i < obj.Length; i++)
        {
            collider2Ds.Add(obj[i]);
            Debug.Log(collider2Ds[i] + "/" + i);
        }
    }

    //������ ���� ����Ʈ�� ��Ƽ�

    //Ÿ������ ���

    //�Ѿ� ���� �� Ÿ���� ������ �˷���

    void OnDrawGizmos()
    {//���� ���� �׷���
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + 8, transform.position.y), size);
    }
}
