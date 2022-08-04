using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpwan : MonoBehaviour
{
    public GameObject towerPrefab;
    Transform towerPos;

    Ray ray;
    RaycastHit hitInfo;

    public Camera cam;

    //스킬창버튼을 누름 - 스킬창 나타나고
    //스킬창에서 타워목록버튼 누르면 타워목록창 나옴
    //타워목록창에서 타워 클릭시 자리 지정가능하게 표시
    //타워 생성, 이미 자리에 있을시 타워 교체


    //1. 스킬을 클릭하고
    //2. 장착을 누르면 스킬 창이 빛남
    //3. 빛나는 스킬창을 클릭하면 스킬이 장착됨
    

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            //{
            //    if (hitInfo.transform.CompareTag("TowerPos"))
            //    {
                    Debug.Log(hitInfo);
            //        MakeTower(hitInfo.transform);
            //    }
            //}
            
        }
    }

    public void MakeTower(Transform towerPos)
    {
        Instantiate(towerPrefab, towerPos.position, Quaternion.identity);
    }
}
