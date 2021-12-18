using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSquare5 : MonoBehaviour
{
    [Header("사각형 영역 2개 생성")]

    public GameObject squareObject;
    public float maxDelay;              //오브젝트 생성 딜레이의 최대값
    public float position_X;            //x 좌표값

    private float Delay;                //오브젝트의 생성 딜레이 

    private void Start()
    {
        Instantiate(squareObject, new Vector2(position_X, 10), Quaternion.identity);
        Instantiate(squareObject, new Vector2(position_X * -1, 10), Quaternion.identity);
        Delay = maxDelay;
    }

    private void Update()
    {
        Delay -= Time.deltaTime;
        if(Delay <= 0)
        {
            Instantiate(squareObject, new Vector2(position_X, 10), Quaternion.identity);
            Instantiate(squareObject, new Vector2(position_X * -1, 10), Quaternion.identity);
            Delay = maxDelay;
        }
        
    }
}
