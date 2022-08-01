using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManger : MonoBehaviour
{
    public GameObject playerStatsBtn;
    public GameObject PlayerSkillBtn;
    public GameObject optionbtn;

    //�÷��̾� ���� ���� ����
    public Player player;
    private int powerUpGold;
    private int speedUpGold;

    //�Ѿ� ���� ����

    bool playerStats = false;

    public void PlayerStatsUI()
    {      
        if(!playerStats)
        {
            playerStatsBtn.SetActive(true);
            playerStats = true;
        }
        else if(playerStats)
        {
            playerStatsBtn.SetActive(false);
            playerStats = false;
        }
    }

    public void PowerUpBtn()
    {
        switch (player.power)
        {
            case 0:
                powerUpGold = 100;
                break;
            case 1:
                powerUpGold = 500;
                break;
        }

        if (player.power < 3 && player.gold >= powerUpGold)
        {
            player.power++;
            player.gold -= powerUpGold;
        }
        else
            return;
    }

    public void SpeedUpBtn()
    {
        if (player.gold >= speedUpGold)
        {
            player.attacktTime -= 0.01f;
            player.gold -= speedUpGold;
            speedUpGold += speedUpGold * 2;
        }
        else
            return;
    }
}
