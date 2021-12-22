using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSquare4 : MonoBehaviour
{
    [Header("사각형 세로 패턴 (순차적으로 나옴)")]

    public GameObject squareObject;  //생성시킬 오브젝트
    public float max_SpawnDealy;     //스폰 딜레이의 최대값
    public float defualt_Delay;      //딜레이 초기값
    public float defualt_X;          //오브젝트가 생성된 초기 좌표값 X
    public int maxCount;             //카운트의 최대값

    private float spawnCount;        //오브젝트가 몇개 생성됬는지 새려줄 카운트 
    private float position_X;        //오브젝트를 생성 좌표값 X
    private float spawnDlay;         //스폰 딜레이
    private float Delay;             //오브젝트 생성 딜레이

    private void Start()
    {
        position_X = defualt_X;
        spawnCount = 0;
    }

    private void Update()
    {
        spawnDlay -= Time.deltaTime;
        Delay -= Time.deltaTime;
        SpawnSquare();
    }

    private void SpawnSquare()
    {
        if(spawnDlay <= 0)
        {
            if (Delay <= 0)
            {
                //오브젝트 생성
                Instantiate(squareObject, new Vector2(position_X, 10), Quaternion.identity);

                Delay = defualt_Delay;          //딜레이를 초기 상태로 돌려놓음
                position_X += 3f;               //x 좌표값을 변환시켜줌
                spawnCount++;                   //오브젝트가 몇번 생성되었는지 새려줌
            }

        }
        
        
        if(spawnCount == maxCount)      //오브젝트가 최대값까지 생성되면 초기값으로 초기화
        {
            spawnCount = 0;                  //오브젝트 카운트롤 0으로 바꿈
            position_X = defualt_X;          //오브젝트의 x 좌표값을 초기값으로 돌려놓음
            spawnDlay = max_SpawnDealy;      //스폰 딜레이를 최대값으로 초기화함
        }

    }
}
