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

    public float virusFrontSpeed;

    private Vector3 virusPos; //Virus가 생성되었을 때 위치를 기억하는 변수

    private void Awake()
    {
        Init();
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
            Destroy(gameObject);
        }
    }
}
