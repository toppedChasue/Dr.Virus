using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManger : MonoBehaviour
{
    //메인화면 UI
    public GameObject playerStats;
    public GameObject playerSkills;
    public GameObject playerTowers;
    public GameObject optionbtn;

    //광산화면 UI
    public GameObject minerStats;
    public GameObject minerSkills;

    //플레이어 스탯 관련 변수
    public Player player;
    private int powerUpGold;
    private int speedUpGold;

    //총알 관련 변수
    public Bullet bullet;

    public void Start()
    {
        bullet = FindObjectOfType<Bullet>();
    }

    //상태변수
    public bool isPlayerStats;
    public bool isPlayerSkill;
    public bool isPlayerTower;
    public bool isMinerStats;
    public bool isMinerSkill;

    //둘다 켜지는데 하나가 켜지면 하나가 꺼지게 만들기
    public void PlayerStatsUI()
    {
        if (!isPlayerStats)
        {
            isPlayerStats = true;
            if (playerSkills.activeSelf == true || playerTowers.activeSelf == true)
            {
                playerSkills.SetActive(false);
                isPlayerSkill = false;
                playerTowers.SetActive(false);
                isPlayerTower = false;
            }
            playerStats.SetActive(true);
        }
        else if (isPlayerStats)
        {
            playerStats.SetActive(false);
            isPlayerStats = false;
            isPlayerSkill = false;
            isPlayerTower = false;
        }
    }

    public void PlayerSkillsUI()
    {
        if (!isPlayerSkill)
        {
            isPlayerSkill = true;
            if(playerStats.activeSelf ==true || playerTowers.activeSelf == true)
            {
                playerStats.SetActive(false);
                isPlayerStats = false;
                playerTowers.SetActive(false);
                isPlayerTower = false;
            }
            playerSkills.SetActive(true);
        }

        else if (isPlayerSkill)
        {
            playerSkills.SetActive(false);
            isPlayerSkill = false;
            isPlayerStats = false;
            isPlayerTower = false;
        }
    }
    public void PlayerTowersUI()
    {
        if (!isPlayerTower)
        {
            isPlayerTower = true;
            if (playerStats.activeSelf == true || playerSkills.activeSelf == true)
            {
                playerStats.SetActive(false);
                isPlayerStats = false;
                playerSkills.SetActive(false);
                isPlayerSkill = false;
            }
            playerTowers.SetActive(true);
        }

        else if (isPlayerTower)
        {
            playerTowers.SetActive(false);
            isPlayerSkill = false;
            isPlayerStats = false;
            isPlayerTower = false;
        }
    }

    public void MinerStatsUI()
    {
        if (!isMinerStats)
        {
            isMinerStats = true;
            if (minerSkills.activeSelf == true)
            {
                minerSkills.SetActive(false);
                isMinerSkill = false;
            }
            minerStats.SetActive(true);
        }
        else if (isMinerStats)
        {
            minerStats.SetActive(false);
            isMinerStats = false;
            isMinerSkill = false;
        }
    }

    public void MinerSkillsUI()
    {
        if (!isMinerSkill)
        {
            isMinerSkill = true;
            if (minerStats.activeSelf == true)
            {
                minerStats.SetActive(false);
                isMinerStats = false;
            }
            minerSkills.SetActive(true);
        }

        else if (isMinerSkill)
        {
            minerSkills.SetActive(false);
            isMinerSkill = false;
            isMinerStats = false;
        }
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

    public void AtkSpeedUpBtn()
    {
        int gold = speedUpGold;
        if (GameManager.instance.gold >= gold)
        {
            player.attacktTime -= 0.01f;
            GameManager.instance.gold -= gold;
            gold += gold * 2;
        }
        else
            return;
    }
    //public void BulletSpeedUpBtn()
    //{
    //    int gold = speedUpGold;
    //    if (GameManager.instance.gold >= gold)
    //    {
    //        player.attacktTime -= 0.1f;
    //        GameManager.instance.gold -= gold;
    //        gold += gold * 2;
    //    }
    //    else
    //        return;
    //}


}
