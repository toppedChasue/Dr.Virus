using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanVirus : MonoBehaviour
{
    public GameObject virusPrefab;
    public Transform spwanArea;

    private float waitMadeTime; //�ϳ� �����ǰ� �ٽ� �����ɶ����� ��Ÿ��

    public float currentTime =2;

    public List<Enemy> enemies = new List<Enemy>();


    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            waitMadeTime = 2f;
            StartCoroutine(MadeVirus(waitMadeTime));
            currentTime = 10;
        }
    }

    public IEnumerator MadeVirus(float waitMadeTime)
    {
        for (int i = 0; i < 5; i++)
        {
            float ran = Random.Range(spwanArea.position.y - 2f, spwanArea.position.y + 2f);
            Enemy obj = Instantiate(virusPrefab, new Vector2(spwanArea.position.x, ran), Quaternion.identity).GetComponent<Enemy>();

            enemies.Add(obj);
            yield return new WaitForSeconds(waitMadeTime);
        }
    }
}
