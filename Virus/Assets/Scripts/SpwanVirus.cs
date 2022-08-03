using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanVirus : MonoBehaviour
{
    //- �߰��Ұ�
    //���� ���� ���̷����� ������ �������̷���(����)����

    
    public GameObject virusPrefab;
    public Transform spwanArea;

    public float waitMadeTime; //�ϳ� �����ǰ� �ٽ� �����ɶ����� ��Ÿ��
    public int enemySpwanCount;

    public List<Enemy> enemies = new List<Enemy>();

    public bool isSpwan;

    public GameManager gameManager;
    private void Start()
    {
        isSpwan = true;
        enemySpwanCount = 10;
    }
    private void Update()
    { 
        
        StartStage();
        NextStage();
    }

    private void StartStage()
    {
        if (isSpwan)
        {
            waitMadeTime = 0.3f;
            StartCoroutine(MadeVirus(waitMadeTime));
            GameManager.instance.stage++;
        }
    }
    private void NextStage()
    {
        if(enemies.Count == 0)
        {
            isSpwan = true;
        }
    }

    public IEnumerator MadeVirus(float waitMadeTime)
    {
        if(isSpwan)
        {
            for (int i = 0; i < enemySpwanCount; i++)
            {
                isSpwan = false;
                float ran = Random.Range(spwanArea.position.y - 2f, spwanArea.position.y + 2f);
                Enemy obj = Instantiate(virusPrefab, new Vector2(spwanArea.position.x, ran), Quaternion.identity).GetComponent<Enemy>();
                enemies.Add(obj);
                yield return new WaitForSeconds(waitMadeTime);
            }
        }
    }
}
