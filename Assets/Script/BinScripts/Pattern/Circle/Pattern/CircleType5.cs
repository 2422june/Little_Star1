using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleType5 : MonoBehaviour
{
    public GameObject circleObject;     //생성시킬 오브젝트
    public float maxDelay;              //딜레이의 최대값
    public float positionY;             //오브젝트를 생성시킬 y 좌표값
    public int max_PositionX;         //랜덤으로 돌릴 오브젝트의 x 좌표 최대값
    public int min_PosiitonX;         //랜덤으로 돌릴 오브젝트의 x 좌표 최소값

    private float Delay;                //오브젝트의 생성 딜레이
    private int RandomX;                //랜덤으로 돌릴 오브젝트 x값을 저장시킬 변수 
    void Start()
    {
            
    }

    void Update()
    {
        Delay -= Time.deltaTime;

        if(Delay <= 0)      //딜레이값이 0 이하로되면 오브젝트 생성
        {
            RandomX = Random.Range(min_PosiitonX, max_PositionX);       //x 좌표값을 랜덤으로 돌려줌       
            Instantiate(circleObject, new Vector2(RandomX, positionY), Quaternion.identity);        //오브젝트 생성
            Delay = maxDelay;           //딜레이값을 최대값으로 초기화
        }
    }
}
