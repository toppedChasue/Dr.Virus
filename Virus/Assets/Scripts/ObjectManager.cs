using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject playerBulletPrefab;
    public GameObject enemyAPrefab;

    GameObject[] playerBullet;
    GameObject[] enemyA;

    GameObject[] targetPool;
    void Awake()
    {
        playerBullet = new GameObject[20];

        enemyA = new GameObject[10];

        Generate();
    }
    void Generate()
    {
        for (int index = 0; index < playerBullet.Length; index++)
        {
            playerBullet[index] = Instantiate(playerBulletPrefab);
            playerBullet[index].SetActive(false);
        } 
        for (int index = 0; index < enemyA.Length; index++)
        {
            enemyA[index] = Instantiate(enemyAPrefab);
            enemyA[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "Basic":
                targetPool = playerBullet;

                break;
        }

        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }
        return null;
    }
}
