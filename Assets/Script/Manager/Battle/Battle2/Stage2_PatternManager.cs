using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_PatternManager : MonoBehaviour
{
    public static Stage2_PatternManager i;
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

    #region //Default_Setting

    [Header("기본 변수 세팅")]
    [SerializeField] public float battle_Count;                    //패턴을 카운트 해줄 변수
    [SerializeField] public float battle_Timer;                    //시작하고 난 후 시간을 재줄 변수
    [SerializeField] public bool onStart_Stage;                    //스테이지의 시작을 판별해줄 불 변수

    #endregion

    #region //Pattern_Field

    [Header("사각형 패턴 프리팹")]

    //패턴 프리팹
    [SerializeField] private GameObject square_Width;                 //오브젝트가 가로로 생성
    [SerializeField] private GameObject square_Hieght;                //오브젝트가 세로로 생성
    [SerializeField] private GameObject square_Order_Hieght;          //오브젝트가 세로로 순자척으로 생성
    [SerializeField] private GameObject square_Width_And_Hieght;      //오브젝트가 가로, 세로 차례대로 랜덤 위치에 생성 
    [SerializeField] private GameObject square_Down;                  //오브젝트가 세로로 순차적으로 떨어짐  
    [SerializeField] private GameObject square_Down_And_Left;         //오브젝트가 아래로 내려가고 왼쪽으로 움직임

    //패턴 프리팹에 접근해줄 게임 오브젝트
    private GameObject square_WidthSpawn;
    private GameObject square_HieghtSpawn;                    
    private GameObject squareOrder_Hieght;
    private GameObject square_WidthAndHieght;
    private GameObject squareDown;
    private GameObject square_DownandLeft;

    [Header ("사각형 & 원 패턴 프리팹")]
    
    //패턴 프리팹
    [SerializeField] private GameObject circle_And_square;            //하늘에서 원 오브젝트가 떨어지고 중간 중간 사각형 오브젝트가 떨어짐.
    
    //패텁 프리팹에 접근해줄 게임 오브젝트
    private GameObject circleAndSquare;
    [Header ("원 패턴 프리팹")]

    //패턴 프리팹
    [SerializeField] private GameObject circle_Field;                 //구로된 오브젝트가 생성되어 작은 영역을 만들며 터짐
    [SerializeField] private GameObject circle_Boom;                  //구로된 오브젝트가 생성되어 산개함
    [SerializeField] private GameObject circle_Meteor;                //구로된 오브젝트가 아래로 내려오며 영역을 만들고 영역이 시간이 지나면 터짐

    //패턴 프리팹에 접근해줄 게임 오브젝트
    private GameObject circleField;
    private GameObject circleBoom_1;
    private GameObject circleBoom_2;
    private GameObject circleMeteor;

    #endregion


    public void DestroyAllGimic()
    {
        DestroyGimic(squareDown);
        DestroyGimic(squareOrder_Hieght);
        DestroyGimic(square_WidthAndHieght);
        DestroyGimic(circleField);
        DestroyGimic(circleAndSquare);
        DestroyGimic(square_HieghtSpawn);
        DestroyGimic(square_WidthSpawn);
        DestroyGimic(square_DownandLeft);
        DestroyGimic(circleMeteor);
        DestroyGimic(circleBoom_2);
        DestroyGimic(circleBoom_1);
    }


    void DestroyGimic(GameObject t)
    {
        if (t != null && t.gameObject != null)
        {
            Destroy(t.gameObject);
        }
    }

    private void Start()
    {
        //변수 초기화
        onStart_Stage = false;
        battle_Count = 0;               
        battle_Timer = 0;
    }

    private void Update()
    {
        if(battle_Count == 0)
        {
            if (BattleEvent2.i.isClearCabinet && BattleEvent2.i.isClearBathRoom && BattleEvent2.i.IsOffEvent())
            {
                if (battle_Count == -1)
                {
                    return;
                }
                DestroyAllGimic();
                BattleEvent2.i.SetEvent(3);
                battle_Count = -1;
            }
        }

        battle_Timer += Time.deltaTime;

        if(battle_Timer >= 2 && !onStart_Stage)
        {
            onStart_Stage = true;
            battle_Timer = 0;
            BGMManager.i.BGMPlay(3);
        }

        if(onStart_Stage)
        {
            StartPattern();
        }

    }
    
    private void StartPattern()
    {
        if (battle_Timer >= 2f && battle_Count == 0)
        {
            circleAndSquare = Instantiate(circle_And_square, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if (battle_Timer >= 8f && battle_Count == 1)
        {
            square_HieghtSpawn = Instantiate(square_Hieght, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 16f && battle_Count == 2)
        {
            Destroy(circleAndSquare.gameObject);
            Destroy(square_HieghtSpawn.gameObject);
            squareDown = Instantiate(square_Down, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 29.5f && battle_Count == 3)
        {
            Destroy(squareDown.gameObject);
            circleBoom_1 = Instantiate(circle_Boom, new Vector2(-4, -7), Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 31.5f && battle_Count == 4)
        {
            circleBoom_2 = Instantiate(circle_Boom, new Vector2(4, -7), Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 37f && battle_Count == 5)
        {
            ;
            Destroy(circleBoom_1.gameObject);
            Destroy(circleBoom_2.gameObject);
            circleMeteor = Instantiate(circle_Meteor, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 45f && battle_Count == 6)       //선택지 1번 생성
        {
            if (!BattleEvent2.i.nowEvent)
            {
                if (!BattleEvent2.i.isClearBathRoom)
                    BattleEvent2.i.SetEvent(1);
                else if (!BattleEvent2.i.isClearCabinet)
                {
                    BattleEvent2.i.SetEvent(2);
                }
            }
            circleAndSquare = Instantiate(circle_And_square, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 57f && battle_Count == 7)
        {
            Destroy(circleMeteor.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 58.5f && battle_Count == 8)
        {
            squareOrder_Hieght = Instantiate(square_Order_Hieght, Vector2.zero, Quaternion.identity);
            Destroy(circleAndSquare.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 72f && battle_Count == 9)
        {
            Destroy(squareOrder_Hieght.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 73f && battle_Count == 10)
        {
            square_WidthAndHieght = Instantiate(square_Width_And_Hieght, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 76f && battle_Count == 11)
        {
            Destroy(circleAndSquare.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 80f && battle_Count == 12)
        {
            Destroy(square_WidthAndHieght.gameObject);
            circleField = Instantiate(circle_Field, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 84f && battle_Count == 13)
        {
            ;
            Destroy(circleField.gameObject);
            circleField = Instantiate(circle_Field, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 88f && battle_Count == 14)      //선택지 2번 생성
        {
            if (!BattleEvent2.i.nowEvent && !BattleEvent2.i.isClearCabinet && BattleEvent2.i.isClearBathRoom)
            {
                BattleEvent2.i.SetEvent(2);
            }
            Destroy(circleField.gameObject);
            circleAndSquare = Instantiate(circle_And_square, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 101.5f && battle_Count == 15)
        {
            square_HieghtSpawn = Instantiate(square_Hieght, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 116f && battle_Count == 16)
        {
            square_WidthSpawn = Instantiate(square_Width, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 131.5f && battle_Count == 17)
        {
            Destroy(square_WidthSpawn.gameObject);
            Destroy(square_HieghtSpawn.gameObject);
            square_DownandLeft = Instantiate(square_Down_And_Left, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if (battle_Timer >= 145f && battle_Count == 18)
        {
            Destroy(square_DownandLeft.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 145.5f && battle_Count == 19)
        {
            circleMeteor = Instantiate(circle_Meteor, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 152f && battle_Count == 20)
        {
            Destroy(circleMeteor.gameObject);
            circleBoom_1 = Instantiate(circle_Boom, new Vector2(-4, -7), Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 154f && battle_Count == 21)
        {
            circleBoom_2 = Instantiate(circle_Boom, new Vector2(4, -7), Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 160f && battle_Count == 22)     //선택지 3번 생성
        {
            if (!BattleEvent2.i.nowEvent && !BattleEvent2.i.isClearCabinet && BattleEvent2.i.isClearBathRoom)
            {
                BattleEvent2.i.SetEvent(2);
            }
            Destroy(circleBoom_1.gameObject);
            Destroy(circleBoom_2.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 170f && battle_Count == 23)
        {
            Destroy(circleAndSquare.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 182 && battle_Count == 24)      //스테이지 끝
        {
            onStart_Stage = false;
            battle_Count = 0;
            battle_Timer = 0;
        }

    }   //패턴 시작

}
