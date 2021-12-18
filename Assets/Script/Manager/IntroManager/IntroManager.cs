using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{

    public static IntroManager i;

    void Awake()
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

    [SerializeField]
    GameObject Player;

    public float time;
    public bool isStop;
    public int round;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        round = 4;
        isStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        //시간이 흐르면 시간 흐르게 하기
        if (!isStop)
        {
            time += Time.deltaTime;
        }

        //다음 대사를 띄워도 되면 다음 대사를 띄울 준비
        if (IsOffDialogue())
        {
            //라운드 교정(위 함수에서 실수함)
            round--;

            Intro();
        }

    }

    bool IsOffDialogue()
    {
        //이전 대사가 꺼졌다면 true 아니면 false 리턴.
        if (!DialogueManager.i.onDialogue)
        {
            round++;
            return true;
        }
        return false;
    }

    void Intro()
    {

        #region Dialogue.2
        if (round == 4 && time >= 4)
        {
            //대사창 띄우기(필수, 대사가 대사창 위치에서 생성됨)(대사창 띄움?, 위치, 크기)
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));

            //대사 띄우기(폰트 사이즈, 내용, 타이핑 시간, 색갈)
            DialogueManager.i.OnTxt(50, "사감선생님의 방송소리가\n희미하게 들려온다.", 2f, new Color(255, 255, 255, 255));

            //Next창 띄우기 (위치, 크기, 타입)
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);

            //시간아 멈춰라
            isStop = true;

            //다음 라운드로
            round++;
        }

        if (round == 5)
        {
            //대사창이 꺼졌는지 확인
            if (IsOffDialogue())
            {
                //대사창 꺼주기 (대사는 자동으로 꺼짐)
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));

                //시간아 흘러라
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.3
        if (round == 6 && time >= 5.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(-400, 400), new Vector2(500, 230));
            DialogueManager.i.OnTxt(50, "[방송]\n아침점호! 아침점호!",
                1.5f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(-2.5f, 1.8f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 7)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.4
        if (round == 8 && time >= 6.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "당신은 초점이 흐린 눈에 힘을 줬다.",
                2.5f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 9)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));

                //필드 생성
                FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(1.7f, 1.7f));

                Player.transform.position = new Vector2(0, 0);
                isStop = false;
            }
        }
        #endregion


        //필드 크기 조정 이벤트1
        #region Dialogue.5
        if (round == 10 && time >= 7f)
        {
            float scale = (2 - (time - 7f));
            FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(scale, scale));
            if (scale <= 1)
            {
                scale = 1;
                FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(scale, scale));
                time = 7f;
                round++;
            }
        }
        #endregion


        //필드 크기 조정 이벤트2
        #region Dialogue.6
        if (round == 11 && time >= 7.5f)
        {
            float scale = (1 + (time - 7.5f));
            FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(scale, scale));
            if (scale >= 1.8f)
            {
                scale = 1.8f;
                FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(scale, scale));
                time = 7.5f;
                round++;
                DialogueManager.i.OnDialogueNext(new Vector2(0, 0), new Vector2(1, 1), GameManager.NextSpriteState.Next);
            }
        }

        if (round == 12)
        {
            if (IsOffDialogue())
            {
                time = 8;
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.7
        if (round == 13 && time >= 8f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "이곳은 GBSW 고등학교.",
                1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 14)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.8
        if (round == 15 && time >= 8.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "당신은 이곳의 학생이다.",
                1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 16)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.9
        if (round == 17 && time >= 9f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "그리고 지금 당신은 눈을뜨고,\n침대에서 일어나 준비를 한 뒤, 등교를 해야한다.",
                4f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 18)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.10
        if (round == 19 && time >= 11f)
        {
            BGMManager.i.BgmPause();
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "그때 \"수면욕\"이 나타났다.",
                2.5f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, -1.8f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 20)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.11
        if (round == 21 && time >= 11.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 100), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "그 \"수면욕\" 이라는 것은 마치 이불과 같아서,",
                3f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, -0.8f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 22)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.12
        if (round == 23 && time >= 12f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "한번 빠지게 되면, 빠져나오기 어려울 것 이다.",
                3.3f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, 0.8f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 24)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.13
        if (round == 25 && time >= 14f)
        {
            //타이핑 사운드 변경
            DialogueManager.i.SetTypinigSound(1);

            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(1500, 300));
            DialogueManager.i.OnTxt(90, "전투1.\n이불과 수면욕.",
                3f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 26)
        {
            if (IsOffDialogue())
            {
                //타이핑 사운드 변경
                DialogueManager.i.SetTypinigSound(0);

                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;

                //씬 변경
                GameManager.GM.SetScene(GameManager.NowScene.introBattle);
            }
        }
        #endregion
    }
}
