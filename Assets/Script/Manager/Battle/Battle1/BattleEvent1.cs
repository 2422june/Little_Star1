using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent1 : MonoBehaviour
{
    #region Singleton
    public static BattleEvent1 i;

    private void Awake()
    {
        if(i == null)
        {
            i = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    #region Set_Field
    public int events = 0;
    public int round = 0, choose = 0;
    public float time = 0f;
    public bool isStop = false;
    public bool isBeddingKick = false, isLight = false, isGlass = false, complete = false;
    public bool nowEvent = false, startEvent = false, isFirst = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        events = 0;
    }

    bool IsOffDialogue()
    {
        //이전 대사가 꺼졌다면 true 아니면 false 리턴.
        if (!DialogueManager.i.onDialogue)
        {
            return true;
        }
        return false;
    }

    public void SetChoose(int _choose)
    {
        choose = _choose;
    }

    private void Update()
    {
        switch (events)
        {
            case 1:
                Event1();
                break;

            case 2:
                Event2();
                break;

            default:
                break;
        }
    }

    public void Event1()
    {

        if (!isStop)
        {
            time += Time.deltaTime;
        }

        #region event1
        if (round == 0 && time >= 0)
        {
            if (!isFirst)
            {
                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                DialogueManager.i.OnTxt(50, "당신의 몸은 아직 잠들어 있다.", 1.5f, new Color(255, 255, 255, 255));
                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            }
            isStop = true;
            round++;
        }

        if (round == 1)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                round++;
                time = 1.5f;
                isStop = false;
                isFirst = true;
            }
        }
        #endregion

        #region event2
        if (round == 2 && time >= 2)
        {
            isStop = true;
            if (isBeddingKick)
            {
                round = 4;
            }
            else
            {
                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                DialogueManager.i.OnTxt(50, "손은 이불안에 있으며,", 1f, new Color(255, 255, 255, 255));
                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                round++;
            }
        }

        if (round == 3)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                round++;
                time = 1.5f;
                isStop = false;
            }
        }
        #endregion

        #region event3
        if (round == 4 && time >= 2)
        {
            isStop = true;
            if (isGlass)
            {
                round = 6;
            }
            else
            {
                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                DialogueManager.i.OnTxt(50, "안경을 쓰지 않아 보이지 않고,", 1f, new Color(255, 255, 255, 255));
                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                round++;
            }
        }

        if (round == 5)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                round++;
                time = 1.5f;
                isStop = false;
            }
        }
        #endregion

        #region event4
        if (round == 6 && time >= 2)
        {
            isStop = true;
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
            DialogueManager.i.OnTxt(50, "전등을 키지 않아, 눈이 뜨이질 않는다.", 1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            round++;
        }

        if (round == 7)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                round++;
                time = 1.5f;
                isStop = false;
            }
        }
        #endregion

        #region event5
        if (round == 8 && time >= 2)
        {
            isStop = true;
            //if (!isFirst)
            //{
            //    DialogueManager.DialogueMng.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
            //    DialogueManager.DialogueMng.OnTxt(50, "이대로는 안된다.", 1f, new Color(255, 255, 255, 255));
            //    DialogueManager.DialogueMng.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            //}
            round++;
        }

        if (round == 9)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
                round = 12;
                time = 2.1f;
            }
        }
        #endregion

        /*#region event6
        if (round == 10 && time >= 2.1f)
            {
                if (!isFirst)
                {
                    DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                    DialogueManager.i.OnTxt(50, "뭔가 행동을 해야만, 한다.", 1.5f, new Color(255, 255, 255, 255));
                    DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                }
                else
                {
                    DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                    DialogueManager.i.OnTxt(50, "아직 잠을 다 깨지 못 했다.", 1.5f, new Color(255, 255, 255, 255));
                    DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            }
            isFirst = true;
            isStop = true;
                round++;
            }

            if (round == 11)
            {
                if (IsOffDialogue())
                {
                    DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                    isStop = false;
                    round++;
                }
            }
            #endregion*/

        #region event7
            if (round == 12 && time >= 2.2f)
            {
                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                DialogueManager.i.OnTxt(50, "무엇을 해야하지?.", .5f, new Color(255, 255, 255, 255));
                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                isStop = true;
                round++;
            }

            if (round == 13)
            {
                if (IsOffDialogue())
                {
                    DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                    isStop = false;
                    round++;
                }
            }
            #endregion

        #region event8
        if (round == 14 && time >= 2.3f)
        {
            if(!isBeddingKick)
                DialogueManager.i.OnBattleNext(new Vector2(0, -3f), new Vector2(1, 1), GameManager.BattleSpriteState.beddingKick);
            if(!isGlass)
                DialogueManager.i.OnBattleNext(new Vector2(3, 0f), new Vector2(1, 1), GameManager.BattleSpriteState.findingGlass);
            if(!isLight)
                DialogueManager.i.OnBattleNext(new Vector2(-5, 3f), new Vector2(1, 1), GameManager.BattleSpriteState.light);
            isStop = true;
            round++;
        }

        if (round == 15)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 300), new Vector2(1200, 250));
                round++;
                time = 2;
                isStop = false;
            }
        }
        #endregion

        #region event9
        if (round == 16 && time >= 2.3f)
        {
            switch (choose)
            {
                case 1:
                    DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                    DialogueManager.i.OnTxt(50, "당신은 이불킥을 했다.\n이제 팔을 움직일 수 있다.", 1.5f, new Color(255, 255, 255, 255));
                    DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                    isBeddingKick = true;
                    break;

                case 2:
                    if (!isBeddingKick)
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "먼저 손을 이불 안에서 빼야 한다.\n피곤해...", 1f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                    }
                    else
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "당신은 안경을 썼다.\n이제 전등 스위치가 보인다.", 1.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                        isGlass = true;
                    }
                    break;

                case 3:
                    if (!isGlass)
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "전등 스위치가 안보여...\n안경을 써야 한다.", 1f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                    }
                    else
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "당신은 전등 스위치를 눌렀다.", .5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                        isLight = true;
                    }
                    break;
            }

            round++;
            isStop = true;
        }

        if (round == 17)
        {
            //대사창이 꺼졌는지 확인
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 300), new Vector2(1200, 250));
                isStop = false;
                time = 0;
                round = 0;
                EndEvent();
            }
        }
        #endregion
    }

    public void Event2()
    {
        if (!isStop)
        {
            time += Time.deltaTime;
        }

        #region event1
        if (round == 0 && time >= 0)
        {
            if (!isFirst)
            {
                BGMManager.i.SetBGMVolume(1);
                //Fade.i.OnFade(3);
            }
            round++;
        }

        if (round == 1)
        {
            BGMManager.i.SetBGMVolume(1 - time);
            if (1 - time <= 0)
            {
                time = 4f;
                round++;
            }
        }
        #endregion

        #region event2
        if (round == 2 && time >= 6)
        {
            GameManager.GM.nowBattle = false;
            if (!isFirst)
            {
                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                DialogueManager.i.OnTxt(50, "당신은 드디어 잠에서 깨어났다.", 1.5f, new Color(255, 255, 255, 255));
                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            }
            isStop = true;
            round++;
        }

        if (round == 3)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                round++;
                time = 6f;
                isStop = false;
            }
        }
        #endregion

        #region event3
        if (round == 4 && time >= 6.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 300));
            DialogueManager.i.OnTxt(90, "Stage1. 수면욕\nClear!!!", 0f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            BGMManager.i.SetEftVolume(1);
            BGMManager.i.EFTPlay(2);
            isStop = true;
            round++;
        }

        if (round == 5)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                round++;
                isStop = false;
            }
        }
        #endregion

        #region event4
        if (round == 6 && time >= 7f)
        {
            Fade.i.OnFade(3);
            round++;
        }
        #endregion

        #region event5
        if (round == 7 && time >= 13f)
        {
            GameManager.GM.SetScene(GameManager.NowScene.secondScene);
        }
        #endregion

    }

    #region Set_End_Event
    public void SetEvent(int _events)
    {
        if (!nowEvent)
        {
            events = _events;
            startEvent = true;
            nowEvent = true;
        }
    }

    public void EndEvent()
    {
        if (isBeddingKick && isGlass && isLight)
        {
            complete = true;
            events = 0;
            time = 0;
            round = 0;
            nowEvent = false;
        }
    }

    public bool IsOffEvent()
    {
        return (!nowEvent && startEvent);
    }
    #endregion
}
