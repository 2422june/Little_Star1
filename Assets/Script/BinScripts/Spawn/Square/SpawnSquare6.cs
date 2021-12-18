using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSquare6 : MonoBehaviour
{
    [Header("사각형 영역 가로 세로 랜덤 생성")]

    public GameObject squareObject_Horizontal;         //수평 오브젝트
    public GameObject squareObject_Vertical;           //수직 오브젝트
    public float maxDelay;                             //딜레이의 최대값
    public int max_Count;                              //카운트값의 최대치를 정해주기위한 변수

    private float Delay;                               //오브젝트 생성 딜레이
    private int random_X;                              //X 좌표값을 랜덤으로 소환 해줄 위치
    private int random_Y;                              //Y 좌표값 랜덤으로 소환 해줄 위치
    private int Count;                                 //일정 카운트가 되면 페이드 효과를 생성함 
    private void Start()
    {
        Delay = maxDelay;
        random_X = Random.Range(-4, 5);             //수평 좌표를 랜덤으로 돌려줌
        random_Y = Random.Range(-4, 5);             //수직 좌표를 랜덤으로 돌려줌

        //오브젝트 생성 (- 좌표와 + 좌표, 수평, 수직 하나씩 소환)
        Instantiate(squareObject_Horizontal, new Vector2(10, Mathf.Round(random_Y)), Quaternion.identity);
        Instantiate(squareObject_Vertical, new Vector2(Mathf.Round(random_X), 10), Quaternion.identity);

    }
    private void Update()
    {
        Delay -= Time.deltaTime;

        if(Delay <= 0)           
        {
            random_X = Random.Range(-4, 5);             //수평 좌표를 랜덤으로 돌려줌
            random_Y = Random.Range(-4, 5);             //수직 좌표를 랜덤으로 돌려줌

            //오브젝트 생성 (- 좌표와 + 좌표, 수평, 수직 하나씩 소환)
            Instantiate(squareObject_Horizontal, new Vector2(10, Mathf.Round(random_Y)), Quaternion.identity);      
            Instantiate(squareObject_Vertical, new Vector2(Mathf.Round(random_X), 10), Quaternion.identity);
            Delay = maxDelay;
            Count++;
        }
        
        if(Count == max_Count)
        {
            Fade.i.OnFade(0.1f);
            Count = 0;
        }
    }
}
