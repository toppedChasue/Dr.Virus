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

    //��ųâ��ư�� ���� - ��ųâ ��Ÿ����
    //��ųâ���� Ÿ����Ϲ�ư ������ Ÿ�����â ����
    //Ÿ�����â���� Ÿ�� Ŭ���� �ڸ� ���������ϰ� ǥ��
    //Ÿ�� ����, �̹� �ڸ��� ������ Ÿ�� ��ü


    //1. ��ų�� Ŭ���ϰ�
    //2. ������ ������ ��ų â�� ����
    //3. ������ ��ųâ�� Ŭ���ϸ� ��ų�� ������
    

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
