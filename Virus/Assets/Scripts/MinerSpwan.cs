using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerSpwan : MonoBehaviour
{
    public GameObject[] minerPos;
    public GameObject minerPrefab;

    private int minerCount;

    public void SpwanMiner()
    {
        switch(minerCount)
        {
            case 0:
                Instantiate(minerPrefab, minerPos[0].transform.position, Quaternion.identity);
                minerCount++;
                break;
            case 1:
                Instantiate(minerPrefab, minerPos[1].transform.position, Quaternion.identity);
                minerCount++;
                break;
            case 2:
                Instantiate(minerPrefab, minerPos[2].transform.position, Quaternion.identity);
                minerCount++;
                break;
            case 3:
                return;
        }
    }
}
