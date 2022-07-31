using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManger : MonoBehaviour
{
    public GameObject playerStatsBtn;
    public GameObject PlayerSkillBtn;
    public GameObject optionbtn;

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
}
