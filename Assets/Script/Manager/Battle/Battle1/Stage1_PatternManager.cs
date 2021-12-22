using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_PatternManager : MonoBehaviour
{
    [Header("스테이지 1의 패턴")]

    //배속
    public float GameSpeed;
    //오브젝트 스폰 타입
    //구
    public GameObject spawnCircleType1_Up;             //구가 위로 올라가다 산개
    public GameObject spawnCircleType1_Down;           //구가 아래로 내려가다 산개
    public GameObject spawnCircleType2;                //구가 랜덤적으로 생성되어 왼쪽으로 흘러감
    public GameObject spawnCircleType5;                //구가 랜덤적으로 생성되어 아래로 내려감
    //사각형
    public GameObject spawnSquareType4;                //사각형이 세로로 왼쪽에서 순차적으로 생성
    public GameObject spawnSquareType5;
    public GameObject spawnSquareType6;                //사각형이 가로, 세로로 랜덤 생성 
    public GameObject spawnSquareType7;                //사각형을 위 아래로 생성시키고 이동시킴


    //구 스포너
    private GameObject circleSpawnerType1_Up;
    private GameObject circleSpawnerType1_Up2;
    private GameObject circleSpawnerType1_Up3;
    private GameObject circleSpawnerType1_Down;
    private GameObject circleSapwnerType2;
    private GameObject circleSpawnerType5;

    //사각형 스포너
    private GameObject squareSpawnerType4;
    private GameObject squareSpawnerType5;
    private GameObject squareSpawnerType6;
    private GameObject squareSpawnerType7;

    public float Timer;
    public int Count;

    public bool isEndLastEvent;

    public static Stage1_PatternManager i;
    private void Awake()
    {
        if (i == null)
        {
            i = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Count = 0;
        Timer = 0;
        GameSpeed = 1;
    }

    private void Update()
    {
        if(Count == 0)
        {
            if (BattleEvent1.i.complete)// && !BattleEvent1.i.IsOffEvent())
            {
                if (Count == -1)
                {
                    return;
                }
                DestroyAllGimic();
                BattleEvent1.i.SetEvent(2);
                Count = -1;
            }
        }

        Time.timeScale = GameSpeed;
        Timer += Time.deltaTime;

        Shot();
    }

    public void DestroyAllGimic()
    {
        DestroyGimic(squareSpawnerType4);
        DestroyGimic(squareSpawnerType5);
        DestroyGimic(squareSpawnerType6);
        DestroyGimic(squareSpawnerType7);
        DestroyGimic(circleSpawnerType1_Up);
        DestroyGimic(circleSpawnerType1_Up2);
        DestroyGimic(circleSpawnerType1_Up3);
        DestroyGimic(circleSpawnerType1_Down);
        DestroyGimic(circleSapwnerType2);
        DestroyGimic(circleSpawnerType5);
    }


    void DestroyGimic(GameObject t)
    {
        if(t != null && t.gameObject != null)
        {
            Destroy(t.gameObject);
        }
    }

    void Shot()
    {
        if (Count >= 0)
        {
            if (Timer >= 2 && Count == 0)
            {
                BGMManager.i.SetBGMVolume(0.4f);
                BGMManager.i.BGMPlay(1);
                Count++;
            }
            else if (Timer >= 4 && Count == 1)
            {
                circleSapwnerType2 = Instantiate(spawnCircleType2, new Vector2(10, 0), Quaternion.identity);
                Count++;
            }
            else if (Timer >= 14 && Count == 2)
            {
                squareSpawnerType7 = Instantiate(spawnSquareType7, new Vector2(10, 0), Quaternion.identity);
                Count++;
            }
            else if (Timer >= 24 && Count == 3)
            {
                Destroy(circleSapwnerType2.gameObject);
                Destroy(squareSpawnerType7.gameObject);
                Count++;
            }
            else if (Timer >= 28 && Count == 4)
            {
                circleSpawnerType1_Up = Instantiate(spawnCircleType1_Up, new Vector2(-2, -5.5f), Quaternion.identity);
                circleSpawnerType1_Down = Instantiate(spawnCircleType1_Down, new Vector2(2, 5.5f), Quaternion.identity);
                Count++;
            }
            else if (Timer >= 42 && Count == 5)
            {
                squareSpawnerType4 = Instantiate(spawnSquareType4, new Vector2(0, 0), Quaternion.identity);
                Count++;
            }
            else if (Timer >= 58 && Count == 6)      //선택지 발생
            {
                if(!BattleEvent1.i.complete)
                    BattleEvent1.i.SetEvent(1);
                Destroy(circleSpawnerType1_Up.gameObject);
                Destroy(circleSpawnerType1_Down.gameObject);
                Destroy(squareSpawnerType4.gameObject);
                circleSpawnerType5 = Instantiate(spawnCircleType5, Vector2.zero, Quaternion.identity);
                Count++;
            }
            else if (Timer >= 68.5 && Count == 7)
            {
                Destroy(circleSpawnerType5.gameObject);
                squareSpawnerType6 = Instantiate(spawnSquareType6, Vector2.zero, Quaternion.identity);
                Count++;
            }
            else if (Timer >= 80.5 && Count == 8)
            {

                Destroy(squareSpawnerType6.gameObject);
                float posX = -10;

                circleSpawnerType1_Up = Instantiate(spawnCircleType1_Up, new Vector2(posX += 5, -6), Quaternion.identity);
                Destroy(circleSpawnerType1_Up.gameObject, 4f);

                circleSpawnerType1_Up2 = Instantiate(spawnCircleType1_Up, new Vector2(posX += 5, -6), Quaternion.identity);
                Destroy(circleSpawnerType1_Up2.gameObject, 4f);

                circleSpawnerType1_Up3 = Instantiate(spawnCircleType1_Up, new Vector2(posX += 5, -6), Quaternion.identity);
                Destroy(circleSpawnerType1_Up3.gameObject, 4f);
                Count++;
            }
            else if (Timer >= 84 && Count == 9)
            {
                float posX = -10;
                squareSpawnerType5 = Instantiate(spawnSquareType5, Vector2.zero, Quaternion.identity);

                circleSpawnerType1_Up = Instantiate(spawnCircleType1_Up, new Vector2(posX += 5, -6), Quaternion.identity);
                Destroy(circleSpawnerType1_Up.gameObject, 10f);

                circleSpawnerType1_Up2 = Instantiate(spawnCircleType1_Up, new Vector2(posX += 5, -6), Quaternion.identity);
                Destroy(circleSpawnerType1_Up2.gameObject, 10f);

                circleSpawnerType1_Up3 = Instantiate(spawnCircleType1_Up, new Vector2(posX += 5, -6), Quaternion.identity);
                Destroy(circleSpawnerType1_Up3.gameObject, 10f);
                Count++;
            }
            else if (Timer >= 92f && Count == 10)
            {
                Destroy(squareSpawnerType5.gameObject);
                Count++;
            }
            else if (Timer >= 94 && Count == 11)
            {
                circleSpawnerType5 = Instantiate(spawnCircleType5, Vector2.zero, Quaternion.identity);
                Count++;
            }
            else if (Timer >= 96 && Count == 12)
            {
                squareSpawnerType4 = Instantiate(spawnSquareType4, Vector2.zero, Quaternion.identity);
                Count++;
            }
            else if (Timer >= 110 && Count == 13)
            {
                Destroy(squareSpawnerType4.gameObject);
                Count++;
            }
            else if (Timer >= 119 && Count == 14)
            {
                Destroy(circleSpawnerType5.gameObject);
                Count++;
            }
            else if (Timer >= 124 && Count == 15)
            {
                Timer = 0;
                Count = 0;
            }
        }
    }
}
