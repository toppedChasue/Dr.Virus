using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEnemy
{
    public float CurrentHp { get; set; }
    public float MaxHp { get; set; }
    
}

public class Enemy : MonoBehaviour, IEnemy
{
    //���� �Ұ�-
    //�������̷���(����)
    //���̷��� ���� �پ�ȭ(������ �߰�)
    //���̷��� ���� ���� ��������Ʈ�� ������ �־ ������̷� ��������
    //���̷��� ������ �������� ���� �ø��� 

    public string enemyName;
    public float maxHp;
    public int gold;

    public float virusFrontSpeed;

    private Vector3 virusPos; //Virus�� �����Ǿ��� �� ��ġ�� ����ϴ� ����
    public Player player;
    public SpwanVirus spwanVirus;

    public float CurrentHp { get; set; }
    public float MaxHp { get; set; }

    Coroutine my_Cor;
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

    //���̷��� �ϳ��� �����뼱�� �����ϸ� �� ����


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
        CurrentHp -= damage;
        if(CurrentHp <= 0)
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
