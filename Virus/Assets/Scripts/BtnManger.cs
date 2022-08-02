using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManger : MonoBehaviour
{
    //����ȭ�� UI
    public GameObject playerStatsBtn;
    public GameObject PlayerSkillBtn;
    public GameObject optionbtn;

    //Mineȭ�� Ui
    public GameObject MineStatsBtn;

    //�÷��̾� ���� ���� ����
    public Player player;
    private int powerUpGold;
    private int speedUpGold;

    //�Ѿ� ���� ����

    //���º���
    public bool isPlayerStats = true;

    public void PlayerStatsUI()
    {
        if (isPlayerStats)
        {
            playerStatsBtn.SetActive(isPlayerStats);
            isPlayerStats = !isPlayerStats;
        }
        
        //else if(playerStats)
        //{
        //    playerStatsBtn.SetActive(false);
        //    playerStats = false;
        //}
    }

    public void PowerUpBtn()
    {
        switch (player.power)
        {
            case 0:
                powerUpGold = 1;
                break;
            case 1:
                powerUpGold = 2;
                break;
        }

        if (player.power < 3 && GameManager.instance.gold >= powerUpGold)
        {
            player.power++;
            GameManager.instance.gold -= powerUpGold;
        }
        else
            return;
    }

    public void SpeedUpBtn()
    {
        if (GameManager.instance.gold >= speedUpGold)
        {
            player.attacktTime -= 0.01f;
            GameManager.instance.gold -= speedUpGold;
            speedUpGold += speedUpGold * 2;
        }
        else
            return;
    }
}
