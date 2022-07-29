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

    private float maxXpos = 15f;

    public Rigidbody2D rigid;

    Vector3 dir;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        transform.position = bulletPos.position;
        originPos = bulletPos;

        dir = target.position - transform.position;
    }
    private void Update()
    {
        if (target == null) // Ÿ���� ������ ó�� ���� ���� Ÿ���� ��ġ�� ��� ����
            Moving();

        else if (target != null)
        {
            dir = target.position - transform.position;
            //Ÿ���� ������ ���� ������ ��� ������Ʈ �ǰ��ؼ� ���󰡰� ��
            Moving();
        }

        if (transform.position.x > maxXpos)
        { //�Ѿ��� �ʹ� �ָ� ����� �ʰ� ����
            transform.position = originPos.position;
            //��Ȱ��ȭ ���� ��ġ�� ���� ��ġ�� ����
            gameObject.SetActive(false);
        }
    }

    private void Moving()
    {
        transform.position += dir.normalized * speed * Time.deltaTime;
    }


}