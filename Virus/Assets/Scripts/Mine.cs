using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject mineWorker;

    public float currentTime;
    private float mineTime = 10;

    public int goldPower = 1;

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
            GameManager.instance.gold += goldPower;
            currentTime = 0;
        }
    }
}
