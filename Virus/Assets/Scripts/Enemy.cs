using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEnemy
{
    public float CurrentHp { get; set; }
    public float MaxHp { get; set; }
    public float DP { get; set; }
    
}

public enum Type { A, B, C, D}
public class Enemy : MonoBehaviour, IEnemy
{
    //구현 할것-
    //변종바이러스(보스)
    //바이러스 종류 다양화(프리펩 추가)
    //바이러스 종류 마다 스프라이트를 여러개 넣어서 색깔놀이
    //바이러스 스탯을 스테이지 마다 늘리기 

    public string enemyName;
    public Type type;
    protected float maxHp;
    protected float maxDp;
    protected int gold;

    protected float virusFrontSpeed;

    private Vector3 virusPos; //Virus가 생성되었을 때 위치를 기억하는 변수
    public Player player;
    public SpwanVirus spwanVirus;

    public float CurrentHp { get; set; }
    public float MaxHp { get; set; }
    public float DP { get; set; }


    private void Awake()
    {
        Init();
        player = FindObjectOfType<Player>();
        spwanVirus = FindObjectOfType<SpwanVirus>();
    }

    private void Start()
    {
        StartCoroutine(VirusMove());
        
    }

    protected virtual void Init()
    {
        virusFrontSpeed = 0.4f;
        virusPos = transform.position;
    }

    private IEnumerator VirusMove()
    {

        while (transform.position.y < virusPos.y + 0.4f)
        {
            transform.Translate(new Vector3(-virusFrontSpeed, 0.5f) * Time.deltaTime);
            yield return null;
        }
        while (transform.position.y > virusPos.y -0.4f)
        {
            transform.Translate(new Vector3(-virusFrontSpeed, -0.5f) * Time.deltaTime);
            yield return null;
        }
        StartCoroutine(VirusMove());
    }

    //public void DpCheck()
    //{
    //    if (DP > 0)
    //        isDp = true;
    //    else
    //        isDp = false;
    //}

    public void TakeDamage(float damage)
    {
        //방어력이 있으면, 체력 전에 방어력을 먼저 깎는다
        
        if (DP > 0)
        {//방어력이 있고 0보다 크면
            DP -= damage;
            Debug.Log(DP);
            return;
        }

        CurrentHp -= damage;
        if (CurrentHp <= 0)
        {
            GameManager.instance.gold += gold;
            spwanVirus.enemies.Remove(this);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            if (bullet.b_hp >= 1)
            {
                TakeDamage(bullet.damage);
                bullet.b_hp--;
                if (bullet.b_hp == 0)
                {
                    collision.gameObject.SetActive(false);
                    bullet.b_hp = 1;
                    bullet.transform.position = bullet.originPos.position;
                }
            }
        }

        if(collision.gameObject.tag == "Finish")
        {
            virusFrontSpeed = 0f;
        }
    }
}
