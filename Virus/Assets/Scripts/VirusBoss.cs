using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBoss : Enemy
{
    public float speed;
    public float maxDp;
    public float maxHp;
    public int enemyGold;

    public float currentTime;
    public float maxTime;

    private void Awake()
    {
        Init();
        player = FindObjectOfType<Player>();
        spwanVirus = FindObjectOfType<SpwanVirus>();

    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= maxTime)
        {
            currentTime = maxTime;
        }
        Debug.Log(CurrentHp);
        BossHealthUp();
    }

    protected override void Init()
    {
        base.Init();
        gold = enemyGold * GameManager.instance.stage;
        maxHp = ((GameManager.instance.stage * 2) + maxHp);
        CurrentHp = maxHp;
        DP = ((GameManager.instance.stage * 2) + maxDp) * 2;
        virusFrontSpeed = speed;
    }

    void BossHealthUp()
    {
        if (currentTime >= maxTime && CurrentHp < maxHp / 2)
        {
            StartCoroutine(HealthUp());
        }
    }

    IEnumerator HealthUp()
    {
        speed = 0f;
        yield return new WaitForSeconds(1f);
        currentTime = 0;
        CurrentHp += maxHp / 2;
        yield return new WaitForSeconds(0.1f);
        virusFrontSpeed = speed;
    }
}
