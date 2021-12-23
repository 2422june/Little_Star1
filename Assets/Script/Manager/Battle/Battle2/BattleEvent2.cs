//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BattleEvent2 : MonoBehaviour
//{
//    #region Singleton
//    public static BattleEvent2 i;

//    private void Awake()
//    {
//        if(i == null)
//        {
//            i = this;
//        }
//        else
//        {
//            Destroy(this);
//        }
//    }
//    #endregion

//    #region Set_Field
//    public int events = 0;
//    public int round = 0, choose = 0;
//    public float time = 0f;

//    public bool isStop = false;

//    public bool nowEvent = false, startEvent = false, isFirst = false;

//    [Header("---------------------State---------------------")]
//    public bool isInBathRoom = false;
//    public bool isFrontCabinet = false, isFrontBad = false,
//        isClearBathRoom = false, isClearCabinet = false, hair       = false,
//        dry             = false, top            = false, bottom     = false;

//    #endregion

//    // Start is called before the first frame update
//    void Start()
//    {
//        events = 0;

//        isInBathRoom = isFrontCabinet =  isFrontBad = isClearBathRoom = 
//        isClearCabinet = hair = dry = top = bottom = false;
//}

//    bool IsOffDialogue()
//    {
//        //이전 대사가 꺼졌다면 true 아니면 false 리턴.
//        if (!DialogueManager.i.onDialogue)
//        {
//            return true;
//        }
//        return false;
//    }

//    public void SetChoose(int _choose)
//    {
//        choose = _choose;
//    }

//    private void Update()
//    {
//        switch (events)
//        {
//            case 1:
//                Event1();
//                break;

//            case 2:
//                Event2();
//                break;

//            default:
//                break;
//        }
//    }

//    public void Event1()
//    {
//        if (!isStop)
//        {
//            time += Time.deltaTime;
//        }

//        isClearCabinet = (bottom && top);
//        isClearBathRoom = (hair && dry);

//        #region EventMain

//        //first
//        #region event0
//        if (!isFirst)
//        {
//            if (round == 0 && time >= 0)
//            {
//                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                DialogueManager.i.OnTxt(50, "당신은 침대에서 일어났다.", 0.5f, new Color(255, 255, 255, 255));
//                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                isStop = true;
//                round++;
//            }

//            if (round == 1)
//            {
//                if (IsOffDialogue())
//                {
//                    DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
//                    round=0;
//                    time = -0.5f;
//                    isFirst = true;
//                    isStop = false;
//                }
//            }
//        }
//        #endregion

//        //nani o
//        #region event1
//        if (round == 0 && time >= 0)
//        {
//            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//            DialogueManager.i.OnTxt(50, "이제 뭘 해야하지?", 0.5f, new Color(255, 255, 255, 255));
//            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//            isStop = true;
//            round++;
//        }

//        if (round == 1)
//        {
//            if (IsOffDialogue())
//            {
//                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
//                round++;
//                time = 1.5f;
//                isStop = false;
//            }
//        }
//        #endregion

//        //hint dialogue
//        #region event2
//        if (round == 2 && time >= 2)
//        {
//            if (!isClearBathRoom)
//            {
//                if (!isInBathRoom)
//                {
//                    DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                    DialogueManager.i.OnTxt(50, "우선 씻어야 겠다.", 1f, new Color(255, 255, 255, 255));
//                    DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                }
//                else
//                {
//                    if (!hair)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "이제 머리를 감아야겠다.", 1f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    else if (!dry)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "이제 물을 닦아야겠다.", 1f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                }
//            }
//            else if(!isClearCabinet)
//            {
//                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                DialogueManager.i.OnTxt(50, "이제 옷을 입어야 겠지.", 1f, new Color(255, 255, 255, 255));
//                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//            }
//            else
//            {
//                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                DialogueManager.i.OnTxt(50, "마지막으로 침대에 가방을 가지러 가야 겠지", 2f, new Color(255, 255, 255, 255));
//                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//            }
//            isStop = true;
//            round++;
//        }

//        if (round == 3)
//        {
//            if (IsOffDialogue())
//            {
//                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
//                round++;
//                time = 1.5f;
//                isStop = false;
//            }
//        }
//        #endregion

//        //invisible next
//        #region event3
//        if (round == 4 && time >= 2.5f)
//        {
//            if (isInBathRoom)
//            {
//                DialogueManager.i.OnBattleNext(new Vector2(4, 3), new Vector2(1, 1), GameManager.BattleSpriteState.hair);
//                DialogueManager.i.OnBattleNext(new Vector2(-4, 3), new Vector2(1, 1), GameManager.BattleSpriteState.dry);
//                DialogueManager.i.OnBattleNext(new Vector2(0, 0), new Vector2(1, 1), GameManager.BattleSpriteState.exit);
//            }
//            else if (isFrontCabinet)
//            {
//                DialogueManager.i.OnBattleNext(new Vector2(4, 3), new Vector2(1, 1), GameManager.BattleSpriteState.top);
//                DialogueManager.i.OnBattleNext(new Vector2(-4, 3), new Vector2(1, 1), GameManager.BattleSpriteState.bottom);
//                DialogueManager.i.OnBattleNext(new Vector2(0, 0), new Vector2(1, 1), GameManager.BattleSpriteState.exit);
//            }
//            else
//            {
//                DialogueManager.i.OnBattleNext(new Vector2(5, 4f), new Vector2(1, 1), GameManager.BattleSpriteState.bathRoom);
//                DialogueManager.i.OnBattleNext(new Vector2(-3, -3f), new Vector2(1, 1), GameManager.BattleSpriteState.cabinet);
//                DialogueManager.i.OnBattleNext(new Vector2(-1, 0f), new Vector2(1, 1), GameManager.BattleSpriteState.bad);
//            }
//            isStop = true;
//            round++;
//        }

//        if (round == 5)
//        {
//            //대사창이 꺼졌는지 확인
//            if (IsOffDialogue())
//            {
//                round++;
//                DialogueManager.i.OnBase(false, new Vector2(0, 300), new Vector2(1200, 250));
//                isStop = false;
//            }
//        }
//        #endregion

//        //calculate
//        #region event4
//        if (round == 6 && time >= 3f)
//        {
//            switch (choose)
//            {
//                case 1:
//                    #region 1
//                    if (isClearBathRoom && isClearCabinet)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "당신은 침대 앞에 섰다.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        isFrontBad = true;
//                    }
//                    else
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "아직 다른 할일이 남았다.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    #endregion
//                    break;

//                case 2:
//                    #region 2
//                    if (isClearBathRoom)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "들어갈 필요가 없다.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    else
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "당신은 씻기위해 화장실로 들어갔다.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        isInBathRoom = true;
//                    }
//                    #endregion
//                    break;

//                case 3:
//                    #region 3
//                    if (isClearBathRoom)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "당신은 옷을 입기 위해 캐비넷으로 갔다.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        isFrontCabinet = true;
//                    }
//                    else
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "일단 씻고 나서 옷을 입자.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    #endregion
//                    break;

//                case 21:
//                    #region 21
//                    if (hair)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "머리는 이미 감았다.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    else
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "당신은 머리를 감았다.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        hair = true;
//                    }
//                    #endregion
//                    break;

//                case 22:
//                    #region 22
//                    if (hair)
//                    {
//                        if (dry)
//                        {
//                            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                            DialogueManager.i.OnTxt(50, "당신은 이미 물기를 다 닦았다.", 0.5f, new Color(255, 255, 255, 255));
//                            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        }
//                        else
//                        {
//                            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                            DialogueManager.i.OnTxt(50, "당신은 물기를 닦았다.", 0.5f, new Color(255, 255, 255, 255));
//                            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                            dry = true;
//                        }
//                    }
//                    else
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "우선 머리를 감아야 한다.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    #endregion
//                    break;

//                case 31:
//                    #region 31
//                    if (top)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "당신은 이미 상의를 입었다.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    else
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "당신은 상의를 입었다.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        top = true;
//                    }
//                    #endregion
//                    break;

//                case 32:
//                    #region 32
//                    if (bottom)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "당신은 이미 하의를 입었다.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    else
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "당신은 하의를 입었다.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        bottom = true;
//                    }
//                    #endregion
//                    break;

//                case 4:
//                    #region 4
//                    if (isInBathRoom)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "당신은 화장실에서 나왔다.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        isInBathRoom = false;
//                    }
//                    if (isFrontCabinet)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "당신은 캐비넷의 앞에서 나왔다.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        isFrontCabinet = false;
//                    }
//                    #endregion
//                    break;

//                default:
//                    break;
//            }
//            isStop = true;
//            round++;
//        }

//        if (round == 7)
//        {
//            //대사창이 꺼졌는지 확인
//            if (IsOffDialogue())
//            {
//                DialogueManager.i.OnBase(false, new Vector2(0, 300), new Vector2(1200, 250));
//                isStop = false;
//                time = 0;
//                round = 0;
//                EndEvent();
//            }
//        }
//        #endregion

//        #endregion
//    }

//    public void Event2()
//    {
//        if (!isStop)
//        {
//            time += Time.deltaTime;
//        }

//        #region event1
//        if (round == 0 && time >= 0)
//        {
//            if (!isFirst)
//            {
//                BGMManager.i.SetBGMVolume(1);
//                //Fade.i.OnFade(3);
//            }
//            round++;
//        }

//        if (round == 1)
//        {
//            BGMManager.i.SetBGMVolume(1 - time);
//            if (1 - time <= 0)
//            {
//                time = 4f;
//                round++;
//            }
//        }
//        #endregion

//        #region event2
//        if (round == 2 && time >= 6)
//        {
//            GameManager.GM.nowBattle = false;
//            if (!isFirst)
//            {
//                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                DialogueManager.i.OnTxt(50, "당신은 드디어 준비를 끝냈다.", 1.5f, new Color(255, 255, 255, 255));
//                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//            }
//            isStop = true;
//            round++;
//        }

//        if (round == 3)
//        {
//            if (IsOffDialogue())
//            {
//                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
//                round++;
//                time = 6f;
//                isStop = false;
//            }
//        }
//        #endregion

//        #region event3
//        if (round == 4 && time >= 6.5f)
//        {
//            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 300));
//            DialogueManager.i.OnTxt(90, "Stage2. 등교준비\nClear!!!", 0f, new Color(255, 255, 255, 255));
//            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//            BGMManager.i.SetEftVolume(1);
//            BGMManager.i.EFTPlay(2);
//            isStop = true;
//            round++;
//        }

//        if (round == 5)
//        {
//            if (IsOffDialogue())
//            {
//                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
//                round++;
//                isStop = false;
//            }
//        }
//        #endregion

//        #region event4
//        if (round == 6 && time >= 7f)
//        {
//            Fade.i.OnFade(3);
//            round++;
//        }
//        #endregion

//        #region event5
//        if (round == 7 && time >= 13f)
//        {
//            GameManager.GM.SetScene(GameManager.NowScene.thirdScene);
//        }
//        #endregion

//    }

//    #region Set_End_Event
//    public void SetEvent(int _events)
//    {
//        if (!nowEvent)
//        {
//            events = _events;
//            startEvent = true;
//            nowEvent = true;
//        }
//    }

//    public void EndEvent()
//    {
//        if (isClearBathRoom && isFrontBad && isClearCabinet)
//        {
//            events = 0;
//            time = 0;
//            round = 0;
//            nowEvent = false;
//        }
//    }

//    public bool IsOffEvent()
//    {
//        return (!nowEvent && startEvent);
//    }
//    #endregion
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent2 : MonoBehaviour
{
    #region Singleton
    public static BattleEvent2 i;

    private void Awake()
    {
        if (i == null)
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

    [Header("---------------------State---------------------")]
    public bool isInBathRoom = false;
    public bool isFrontCabinet = false, isFrontBad = false,
        isClearBathRoom = false, isClearCabinet = false, hair = false,
        dry = false, top = false, bottom = false;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        events = 0;

        isInBathRoom = isFrontCabinet = isFrontBad = isClearBathRoom =
        isClearCabinet = hair = dry = top = bottom = false;
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

            case 3:
                EventLast();
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

        #region EventMain

        //first
        #region event0
        if (!isFirst)
        {
            if (round == 0 && time >= 0)
            {
                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                DialogueManager.i.OnTxt(50, "당신은 침대에서 일어났다.", 0.5f, new Color(255, 255, 255, 255));
                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                isStop = true;
                round++;
            }

            if (round == 1)
            {
                if (IsOffDialogue())
                {
                    DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                    round++;
                    isFirst = true;
                    isStop = false;
                }
            }
        }
        #endregion

        //hint dialogue
        #region event2
        if (round == 2 && time >= 2)
        {
            if (!isClearBathRoom)
            {
                if (!hair)
                {
                    DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                    DialogueManager.i.OnTxt(50, "이제 머리를 감아야겠다.", 1f, new Color(255, 255, 255, 255));
                    DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                }
                else if (!dry)
                {
                    DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                    DialogueManager.i.OnTxt(50, "이제 물을 닦아야겠다.", 1f, new Color(255, 255, 255, 255));
                    DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                }
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
                time = 1.5f;
                isStop = false;
            }
        }
        #endregion

        //invisible next
        #region event3
        if (round == 4 && time >= 2.5f)
        {
            if(!hair)
                DialogueManager.i.OnBattleNext(new Vector2(4, 0), new Vector2(1, 1), GameManager.BattleSpriteState.hair);
            if(!dry)
            DialogueManager.i.OnBattleNext(new Vector2(-4, 0), new Vector2(1, 1), GameManager.BattleSpriteState.dry);
            isStop = true;
            round++;
        }

        if (round == 5)
        {
            //대사창이 꺼졌는지 확인
            if (IsOffDialogue())
            {
                round++;
                DialogueManager.i.OnBase(false, new Vector2(0, 300), new Vector2(1200, 250));
                isStop = false;
            }
        }
        #endregion

        //calculate
        #region event4
        if (round == 6 && time >= 3f)
        {
            switch (choose)
            {
                case 21:
                    #region 21
                    if (hair)
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "머리는 이미 감았다.", 0.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                    }
                    else
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "당신은 머리를 감았다.", 0.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                        hair = true;
                    }
                    #endregion
                    break;

                case 22:
                    #region 22
                    if (hair)
                    {
                        if (dry)
                        {
                            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                            DialogueManager.i.OnTxt(50, "당신은 이미 물기를 다 닦았다.", 0.5f, new Color(255, 255, 255, 255));
                            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                        }
                        else
                        {
                            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                            DialogueManager.i.OnTxt(50, "당신은 물기를 닦았다.", 0.5f, new Color(255, 255, 255, 255));
                            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                            dry = true;
                        }
                    }
                    else
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "우선 머리를 감아야 한다.", 0.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                    }
                    #endregion
                    break;

                default:
                    break;
            }
            isStop = true;
            round++;
        }

        if (round == 7)
        {
            //대사창이 꺼졌는지 확인
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 300), new Vector2(1200, 250));
                isStop = false;
                time = 1.5f;
                round = 2;

                isClearBathRoom = (hair && dry);
                if (isClearBathRoom)
                {
                    EndEvent();
                    isFirst = false;
                }
            }
        }
        #endregion

        #endregion
    }

    public void Event2()
    {
        if (!isStop)
        {
            time += Time.deltaTime;
        }


        #region EventMain

        //first
        #region event0
        if (!isFirst)
        {
            if (round == 0 && time >= 0)
            {
                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                DialogueManager.i.OnTxt(50, "당신은 화장실에서 나와 캐비넷 앞에 섰다.", 0.5f, new Color(255, 255, 255, 255));
                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                isStop = true;
                round++;
            }

            if (round == 1)
            {
                if (IsOffDialogue())
                {
                    DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                    round = 2;
                    isFirst = true;
                    isStop = false;
                }
            }
        }
        #endregion

        //hint dialogue
        #region event2
        if (round == 2 && time >= 2)
        {
            if(!isClearCabinet)
            {
                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                DialogueManager.i.OnTxt(50, "이제 옷을 입어야 겠다.", 1f, new Color(255, 255, 255, 255));
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
                time = 1.5f;
                isStop = false;
            }
        }
        #endregion

        //invisible next
        #region event3
        if (round == 4 && time >= 2.5f)
        {
            if (!top)
                DialogueManager.i.OnBattleNext(new Vector2(0, 3), new Vector2(1, 1), GameManager.BattleSpriteState.top);

            if (!bottom)
                DialogueManager.i.OnBattleNext(new Vector2(0, -2), new Vector2(1, 1), GameManager.BattleSpriteState.bottom);
            isStop = true;
            round++;
        }

        if (round == 5)
        {
            //대사창이 꺼졌는지 확인
            if (IsOffDialogue())
            {
                round++;
                DialogueManager.i.OnBase(false, new Vector2(0, 300), new Vector2(1200, 250));
                isStop = false;
            }
        }
        #endregion

        //calculate
        #region event4
        if (round == 6 && time >= 3f)
        {
            switch (choose)
            {
                case 31:
                    #region 31
                    if (top)
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "당신은 이미 상의를 입었다.", 0.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                    }
                    else
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "당신은 상의를 입었다.", 0.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                        top = true;
                    }
                    #endregion
                    break;

                case 32:
                    #region 32
                    if (bottom)
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "당신은 이미 하의를 입었다.", 0.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                    }
                    else
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "당신은 하의를 입었다.", 0.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                        bottom = true;
                    }
                    #endregion
                    break;

                default:
                    break;
            }
            isStop = true;
            round++;
        }

        if (round == 7)
        {
            //대사창이 꺼졌는지 확인
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 300), new Vector2(1200, 250));
                isStop = false;
                time = 1.5f;
                round = 2;
                if (bottom && top)
                {
                    EndEvent();
                    isFirst = false;
                }
            }
        }
        #endregion

        #endregion
    }


    public void EventLast()
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
                DialogueManager.i.OnTxt(50, "당신은 드디어 준비를 끝냈다.", 1.5f, new Color(255, 255, 255, 255));
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
            DialogueManager.i.OnTxt(90, "Stage2. 등교준비\nClear!!!", 0f, new Color(255, 255, 255, 255));
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
            GameManager.GM.SetScene(GameManager.NowScene.thirdScene);
            round++;
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
            isStop = false;
        }
    }

    public void EndEvent()
    {
        events = 0;
        time = 0;
        round = 0;
        nowEvent = false;
        isStop = true;
        isClearCabinet = (bottom && top);
        /*if (isClearBathRoom && isFrontBad && isClearCabinet)
        {
            events = 0;
            time = 0;
            round = 0;
            nowEvent = false;
        }*/
    }

    public bool IsOffEvent()
    {
        return (!nowEvent && startEvent);
    }
    #endregion
}
