using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct EnemyStats
{
    public float hp;
    public float dp;
}


public class Enemy : MonoBehaviour
{
    [SerializeField]
    EnemyStats enemystat;

    public string enemyName;
    public float virusFrontSpeed;

    private Vector3 virusPos; //Virus가 생성되었을 때 위치를 기억하는 변수
    public Player player;

    private void Awake()
    {
        Init();
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        Frontmove();
    }
    public void Init()
    {
        enemystat.hp = 10;
        virusFrontSpeed = 0.4f;
        virusPos = transform.position;
    }

    private void Frontmove()
    {
        StartCoroutine(VirusMove());
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
    
    public void TakeDamage(float damage)
    {
        enemystat.hp -= damage;
        if(enemystat.hp <= 0)
        {
            player.gold++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            TakeDamage(bullet.damage);

            collision.gameObject.SetActive(false);
            bullet.transform.position = bullet.originPos.position;
        }
    }
}
