using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanVirus : MonoBehaviour
{
    public GameObject virusPrefab;
    public Transform spwanArea;

    private float waitMadeTime; //하나 생성되고 다시 생성될때까지 쿨타임


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            waitMadeTime = 2f;
            StartCoroutine(MadeVirus(waitMadeTime));
        }
    }

    public IEnumerator MadeVirus(float waitMadeTime)
    {
        for (int i = 0; i < 5; i++)
        {
            float ran = Random.Range(spwanArea.position.y - 2f, spwanArea.position.y + 2f);
            Move obj = Instantiate(virusPrefab, new Vector2(spwanArea.position.x, ran), Quaternion.identity).GetComponent<Move>();
            yield return new WaitForSeconds(waitMadeTime);
        }
    }
}
