using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    public float speed;

    private void Awake()
    {
        Init();
        player = FindObjectOfType<Player>();
        spwanVirus = FindObjectOfType<SpwanVirus>();
    }

    protected override void Init()
    {
        base.Init();
        gold = GameManager.instance.stage;
        CurrentHp = maxHp;
        DP = maxDp;
        virusFrontSpeed = speed;
    }
}
