using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent3 : MonoBehaviour
{
    #region Singleton
    public static BattleEvent3 i;

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
                DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(800, 150));
                DialogueManager.i.OnTxt(50, "당신의 의지는 꺼지지 않는다.", 1.5f, new Color(255, 255, 255, 255));
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
                time = 0f;
                round++;
            }
        }
        #endregion

        #region event2
        if (round == 0 && time >= 0)
        {
            GameManager.GM.nowBattle = false;
            if (!isFirst)
            {
                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                DialogueManager.i.OnTxt(50, "당신이 승리했다.", 1.5f, new Color(255, 255, 255, 255));
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
                time = 6f;
                isStop = false;
            }
        }
        #endregion

        #region event3
        if (round == 2 && time >= 0.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 300));
            DialogueManager.i.OnTxt(90, "Stage3. 의지와 피로\nClear!!!", 0f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            BGMManager.i.SetEftVolume(1);
            BGMManager.i.EFTPlay(2);
            isStop = true;
            round++;
        }

        if (round == 3)
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
        if (round == 4 && time >= 1f)
        {
            Fade.i.OnFade(3);
            round++;
        }
        #endregion

        #region event5
        if (round == 5 && time >= 13f)
        {
            GameManager.GM.SetScene(GameManager.NowScene.lastScene);
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
        if (true)
        {
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
