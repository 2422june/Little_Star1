using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdManager : MonoBehaviour
{
    public static ThirdManager i;

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

    public float time;

    public bool isStop;
    public int round;

    Txt txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GameObject.Find("DialogueMng").GetComponent<Txt>();
        time = 0f;
        round = 0;
        isStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStop)
        {
            time += Time.deltaTime;
        }

        Intro();
        /*if (IsOffDialogue())
        {
            round--;
        }*/
    }

    bool IsOffDialogue()
    {
        if (!DialogueManager.i.onDialogue)
        {
            round++;
            return true;
        }
        return false;
    }

    void Intro()
    {
        #region Dialogue.1
        if (round == 0 && time >= 1)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1500, 250));
            DialogueManager.i.OnTxt(50, "당신은 후드를 입고, 가방을 맸다.", 2f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 1)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.2
        if (round == 2 && time >= 1.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1500, 200));
            DialogueManager.i.OnTxt(50, "이제 출발하면 된다.",
                1.5f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 3)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.3
        if (round == 4 && time >= 2f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "당신은 비장한 마음으로 신발을 신었다.",
                2.5f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 5)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.4
        if (round == 6 && time >= 2.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300f), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "그리고 당신은 문고리를 잡았다.",
                2f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
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

        #region Dialogue.5
        if (round == 8 && time >= 3f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "그때였다.",
                0.5f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 9)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
                time = 0;
            }
        }
        #endregion

        #region Dialogue.6
        if (round == 10 && time >= 0.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "당신은 갑자기 거부감을 풍겨오는 손잡이에서 손을 땠다.",
                2f, new Color(255, 255, 255, 255));
            round++;
        }

        if (round == 11 && time >= 4)
        {
            txt.isNext = true;
            DialogueManager.i.onDialogue = false;
            DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));

            round++;
        }
        #endregion

        #region Dialogue.7
        if (round == 12 && time >= 4.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "동시에 온몸에 큰 무게감을 느끼고 있다.",
                1.5f, new Color(255, 255, 255, 255));
            round++;
        }

        if (round == 13 && time >= 7)
        {
            BGMManager.i.SetBGMVolume(0.4f);
            BGMManager.i.BGMPlay(5);
            txt.isNext = true;
            DialogueManager.i.onDialogue = false;
            DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
            time = 0;
            round++;
        }
        #endregion

        #region Dialogue.8
        if (round == 14 && time >= 0.5f)
        {
            //BGMManager.i.BGMPlay(5);
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(70, "피로라는 이름의 무게감.",
                2f, new Color(255, 0, 0, 255));
            round++;
        }

        if (round == 15 && time >= 4)
        {
            txt.isNext = true;
            DialogueManager.i.onDialogue = false;
            DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
            round++;
        }
        #endregion

        #region Dialogue.9
        if (round == 16 && time >= 4.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(60, "하지만",
                0.5f, new Color(255, 255, 255, 255));
            //isStop = true;
            round++;
        }

        if (round == 17 && time >= 6)
        {
            txt.isNext = true;
            DialogueManager.i.onDialogue = false;
            DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
            round++;
        }
        #endregion

        #region Dialogue.10
        if (round == 18 && time >= 6.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(70, "당신은 하고 싶은 것 이 있기에,",
                2f, new Color(255, 255, 255, 255));
            round++;
        }

        if (round == 19 && time >= 10)
        {
            txt.isNext = true;
            DialogueManager.i.onDialogue = false;
            DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
            round++;
        }
        #endregion

        #region Dialogue.11
        if (round == 20 && time >= 10.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(70, "아직 포기할 생각이 없기에,",
                2f, new Color(255, 255, 255, 255));
            round++;
        }

        if (round == 21 && time >=14)
        {
            txt.isNext = true;
            DialogueManager.i.onDialogue = false;
            DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
            round++;
        }
        #endregion

        #region Dialogue.12
        if (round == 22 && time >= 14.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(80, "아직은 더 할 수 있기에,",
                2f, new Color(255, 255, 255, 255));
            round++;
        }

        if (round == 23 && time >= 18)
        {
            txt.isNext = true;
            DialogueManager.i.onDialogue = false;
            DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
            round++;
        }
        #endregion

        #region Dialogue.13
        if (round == 24 && time >= 18.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(100, "당신은 맞서 싸운다.",
                2f, new Color(255, 255, 255, 255));
            round++;
        }

        if (round == 25 && time >= 22)
        {
            txt.isNext = true;
            DialogueManager.i.onDialogue = false;
            //BGMManager.i.BgmPause();
            DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
            round++;
        }
        #endregion

        #region Dialogue.14
        if (round == 26 && time >= 22.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "마지막 전투가 시작되었다.",
                2f, new Color(255, 255, 255, 255));
            //DialogueManager.i.OnDialogueNext(new Vector2(0, -2), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            //isStop = true;
            round++;
        }

        if (round == 27 && time >= 26)
        {
            txt.isNext = true;
            DialogueManager.i.onDialogue = false;
            DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
            round++;
        }
        #endregion

        #region Dialogue.16
        if (round == 28 && time >= 26.5f)
        {
            //타이핑 사운드 변경
            DialogueManager.i.SetTypinigSound(1);

            DialogueManager.i.OnBase(true, new Vector2(0, 200), new Vector2(1500, 300));
            DialogueManager.i.OnTxt(90, "전투3.\n의지와 피로.",
                3f, new Color(255, 255, 255, 255));
            //DialogueManager.i.OnDialogueNext(new Vector2(0f, -1f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            //isStop = true;
            round++;
        }

        if (round == 29 && time >= 34f)
        {
            txt.isNext = true;
            DialogueManager.i.onDialogue = false;
            //타이핑 사운드 변경
            DialogueManager.i.SetTypinigSound(0);

            DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
            //isStop = false;

            //씬 변경
            GameManager.GM.SetScene(GameManager.NowScene.thirdBattle);
            round++;
        }
        #endregion
    }
}
