using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 size;
    public LayerMask layer;

    public GameObject bullet;
    public Transform bulletPos;

    //일정 범위 내에 들어온 적을 감지함

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

    //감지한 적을 리스트에 담아서

    //타겟으로 삼고

    //총알 생성 후 타켓의 정보를 알려줌

    void OnDrawGizmos()
    {//감지 범위 그려줌
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + 8, transform.position.y), size);
    }
}
