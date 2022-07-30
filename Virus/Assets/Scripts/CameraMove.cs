using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform mineCameraPos;
    public Transform CameraOriginPos;
    
    public float speed;

    public bool isMoveToMine = false;
    public bool isMoveToMain = false;

    public GameObject goToMineBtn;
    public GameObject goToMainBtn;

    public GameObject mainUIGroup;
    public GameObject mineUIGroup;



    // Update is called once per frame
    void Update()
    {
        if(isMoveToMine)
        {
            transform.position = Vector3.MoveTowards(transform.position, mineCameraPos.position, Time.deltaTime * speed);
            if (transform.position == mineCameraPos.position)
                isMoveToMine = false;
        }

        if (isMoveToMain)
        {
            transform.position = Vector3.MoveTowards(transform.position, CameraOriginPos.position, Time.deltaTime * speed);
            if (transform.position == CameraOriginPos.position)
                isMoveToMain = false;
        }

    }

    public void GoToMineBtn()
    {
        isMoveToMine = true;
        goToMineBtn.SetActive(false);
        goToMainBtn.SetActive(true);
        mainUIGroup.SetActive(false);
        mineUIGroup.SetActive(true);
    }
    public void GotoMainBtn()
    {
        isMoveToMain = true;
        goToMineBtn.SetActive(true);
        goToMainBtn.SetActive(false);
        mainUIGroup.SetActive(true);
        mineUIGroup.SetActive(false);
    }
}
