using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject mineWorker;

    public float currentTime;
    private float mineTime = 10;

    public int goldPower = 1;

    public Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        DigGold();
    }

    private void DigGold()
    {
        if (currentTime > mineTime)
        {
            player.gold += goldPower;
            currentTime = 0;
        }
    }
}
