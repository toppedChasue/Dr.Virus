using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    private float powerUpGold;

    public Vector3 cameraOriginPos;
    public Transform cameraTarget;
    private float speed;

    public void PowerUpBtn()
    {
        switch (player.power)
        {
            case 0:
                powerUpGold = 2;
                break;
            case 1:
                powerUpGold = 4;
                break;
        }

        if (player.power < 3 && player.gold >= powerUpGold)
        {
            player.power++;
            player.gold -= (int)powerUpGold;
        }
        else
            return;
    }
}
