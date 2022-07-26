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
        //감지범위에 들어온 오브젝트 반환
        Collider2D[] others = Physics2D.OverlapBoxAll(new Vector2(transform.position.x+8, transform.position.y), size, 0, layer);
        
    }




    void OnDrawGizmos()
    {//감지 범위 그려줌
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + 8, transform.position.y), size);
    }

}
