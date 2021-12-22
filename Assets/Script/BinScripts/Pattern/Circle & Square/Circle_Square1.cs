using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Square1 : MonoBehaviour
{
    [Header("구가 위에서 내려오고 딜레이마다 사각형이 빠른 속도로 떨어짐")]

    public GameObject circleObject;     //떨어지게할 구 오브젝트
    public GameObject squareObject;     //떨어지게할 사각형 오브젝트
    public float max_SpawnDaly;         //오브젝트 스폰 딜레이 최대값
    public float max_SquareDelay;       //사각형 오브젝트 스폰 딜레이 최대값

    private float spawnDelay;                   //생성 딜레이
    private float squareDelay;                  //사각형 생성 딜레이

    private int random_PositionX_Circle;        //구의 x좌표를 랜덤으로 돌려 변수에 저장 
    private int random_PositionX_Square;        //사각형의 x좌표를 랜덤으로 돌려 변수에 저장
    private void Start()
    {
        spawnDelay = 0;
        squareDelay = max_SquareDelay;
    }
    void Update()
    {
        spawnDelay -= Time.deltaTime;
        squareDelay -= Time.deltaTime;

        if (spawnDelay <= 0)
        { 
            random_PositionX_Circle = Random.Range(-8, 9);
            Instantiate(circleObject, new Vector2(random_PositionX_Circle, 5), Quaternion.identity);
            spawnDelay = max_SpawnDaly;
        }
        
        if(squareDelay <= 0)
        {
            random_PositionX_Square = Random.Range(-6, 7);
            Instantiate(squareObject, new Vector2(random_PositionX_Square, 5), Quaternion.identity);
            squareDelay = max_SquareDelay;
        }
    }
}
