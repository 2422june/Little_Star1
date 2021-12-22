using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleType4 : MonoBehaviour
{
    [Header("구로된 영역이 위에서 부터 내려옴")]

    public Transform circleSpawner;
    public GameObject circleObject;     //생성시킬 오브젝트
    public float max_Delay;              //오브젝트가 위에러 내려올때의 딜레이 최대값
    public float max_SpawnDelay;        //오브젝트 생성 딜레이의 최대값
    [SerializeField] private float default_posY;         //오브젝트의 초기 y값을 저장시킬 변수

    private float Delay;                //오브젝트가 위에서 내려올때의 딜레이
    public float spawnDelay;           //오브젝트 생성 딜레이
    private float posY;                 //오브젝트의 y값을 저장시킬 변수
   
    private int random_X;               //오브젝트의 x값을 랜덤으로 돌림

    private void Start()
    {
        spawnDelay = max_SpawnDelay;         //스폰 딜레이값 초기화
        Delay = max_Delay;              //딜레이값 초기화
        posY = default_posY;                                    //y좌표값을 기본 좌표값으로 선언

    }

    private void Update()
    {
        Delay -= Time.deltaTime;
        spawnDelay -= Time.deltaTime;

        if (Delay <= 0)
        {
            if (posY > -6f)      //y가 -6보다 크면 계속 생성시킴
            {
                Instantiate(circleObject, new Vector2(random_X, posY), Quaternion.identity);
                posY--;
            }
            else             //-6 밑으로 내려가면 랜덤으로 x좌표를 바꾸고 y좌표값을 기본 좌표값으로 바꿈
            {
                if (spawnDelay <= 0)
                {
                    random_X = Random.Range(-5, 5);
                    posY = default_posY;
                    spawnDelay = max_SpawnDelay;
                }
            }
            Delay = max_Delay;
        }
    }
}

