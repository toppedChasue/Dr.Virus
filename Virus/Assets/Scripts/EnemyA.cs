using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    public float speed;
    public float maxHp;
    public float maxDp;
    public int enemyGold;

    private void Awake()
    {
        Init();
        player = FindObjectOfType<Player>();
        spwanVirus = FindObjectOfType<SpwanVirus>();
    }

    protected override void Init()
    {
        base.Init();
        gold = enemyGold * GameManager.instance.stage;
        CurrentHp = maxHp;
        DP = maxDp;
        virusFrontSpeed = speed;
    }
}
