using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 size;
    public LayerMask layer;

    public Transform target;

    public GameObject bullet;
    public Transform bulletPos;
    public float attackRange;

    public int power;

    private float currentTime;
    public float attacktTime;

    List<Enemy> enemies = new List<Enemy>();

    public ObjectManager objectManager;

    public bool isAttack;


    private void Update()
    {
        SearchVirus();
    }
    private void SearchVirus()
    {
        Collider2D[] obj = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + 8, transform.position.y), size, 0, layer);
        List<Enemy> enemies = new List<Enemy>();
        foreach (Collider2D enemycol in obj)
        {
            Enemy enemy1 = enemycol.GetComponent<Enemy>();
            enemies.Add(enemy1);
        }

        currentTime += Time.deltaTime;

        if (enemies != null)
        {
            float shortDis = attackRange;
            for (int i = 0; i < enemies.Count; i++)
            {
                target = null;
                float dis = Vector3.Distance(transform.position, enemies[i].transform.position);
                //타워와 에너미의 거리를 dis변수에 넣어줌
                if (dis < shortDis)
                {
                    shortDis = dis;
                    target = enemies[i].transform;
                }//가장 가까운 거리에 있는 적을 타겟으로 넣어줌
            }
            if (target != null && currentTime > attacktTime && isAttack)
            {
                //isAttack = false;
                Attack();
            }
        }

    }
    private void Attack()
    {
        switch (power)
        {
            case 0:
                SingleBullet();
                break;
            case 1:
                SingleBullet();
                Invoke("SingleBullet", 0.1f);
                break;
            case 2:
                SingleBullet();
                Invoke("SingleBullet", 0.1f);
                Invoke("SingleBullet", 0.2f);
                break;
        }
        return;
    }

    private void SingleBullet()
    {
        var obj = objectManager.MakeObj("Basic");
        Bullet bulletObj = obj.GetComponent<Bullet>();
        bulletObj.target = target;
        bulletObj.bulletPos = bulletPos;
        currentTime = 0;
    }

    void OnDrawGizmos()
    {//감지 범위 그려줌
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + 8, transform.position.y), size);
    }
}
