using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float virusFrontSpeed;
    public float virusUpdownSpeed;


    private Vector3 virusPos; //Virus가 생성되었을 때 위치를 기억하는 변수


    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        Frontmove();
    }
    public void Init()
    {
        virusFrontSpeed = 0;
        virusPos = transform.position;
    }

    private void Frontmove()
    {
        StartCoroutine(VirusMove());
    }

    private IEnumerator VirusMove()
    {

        while (transform.position.y < virusPos.y + 0.4f)
        {
            transform.Translate(new Vector3(-0.4f, 0.5f) * Time.deltaTime);

            yield return null;
        }
        while (transform.position.y > virusPos.y -0.4f)
        {
            transform.Translate(new Vector3(-0.4f, -0.5f) * Time.deltaTime);
            yield return null;
        }
        StartCoroutine(VirusMove());
    }
    
}
