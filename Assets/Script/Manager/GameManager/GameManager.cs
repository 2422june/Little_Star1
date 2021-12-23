using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region SetSingleTon
    public static GameManager GM = null;

    private void Awake()
    {
        if (GM == null)
        {
            GM = this;
            nowScene = NowScene.firstScene;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    #region Set_Field
    public List<Sprite> NextSprite = new List<Sprite>();
    public List<Sprite> BattleSprite = new List<Sprite>();

    public enum NowScene
    {
        firstScene,
        intro, introBattle, gameOver,
        secondScene, secondBattle,
        thirdScene, thirdBattle,
        lastScene
    };

    public enum NextSpriteState
    {
        GameStart, TitleSubject, GameQuit, Next, DialogueNext, Hill
    };

    public enum BattleSpriteState
    {
        beddingKick, findingGlass, light,

        bathRoom, bad, cabinet,
        hair, dry,
        top, bottom,
        exit
    };

    public BattleSpriteState BSS;

    public NextSpriteState NSS;

    public NowScene nowScene;

    public int PlaHp, PlaMaxHp, stage, sceneSkeep;
    public bool nowBattle;

    [SerializeField]
    GameObject Pla;
    #endregion

    void Start()
    {
        PlaHp = PlaMaxHp = 10;
        sceneSkeep = 0;
        nowBattle = false;
        PlayerInterection.PI.SetField(PlaHp, PlaMaxHp);
        PlayerInterection.PI.ShowDark();
        BGMManager.i.BgmPause();

        SetScripts();
        stage = 0;
    }

    void Update()
    {
        #region
        if (Input.GetKeyDown(KeyCode.U))
        {
            ResetScene();
            sceneSkeep++;

            if (sceneSkeep == 9)
            {
                sceneSkeep = 0;
            }

            if (sceneSkeep == 0)
            {
                BGMManager.i.BgmPause();
                SetScene(NowScene.firstScene);
            }
            if (sceneSkeep == 1)
            {
                BGMManager.i.SetBGMVolume(0.5f);
                BGMManager.i.BGMPlay(0);
                SetScene(NowScene.intro);
            }
            if (sceneSkeep == 2)
            {
                FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(1.8f, 1.8f));
                SetScene(NowScene.introBattle);
            }

            if (sceneSkeep == 3)
            {
                FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(1.8f, 1.8f));
                SetScene(NowScene.secondScene);
            }

            if (sceneSkeep == 4)
            {
                FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(1.8f, 1.8f));
                SetScene(NowScene.secondBattle);
            }

            if (sceneSkeep == 5)
            {
                FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(1.8f, 1.8f));
                SetScene(NowScene.thirdScene);
            }

            if (sceneSkeep == 6)
            {
                FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(1.8f, 1.8f));
                SetScene(NowScene.thirdBattle);
            }

            if (sceneSkeep == 7)
            {
                FieldManager.FieldMng.OnField(false, new Vector2(0, 0), new Vector2(1.8f, 1.8f));
                SetScene(NowScene.lastScene);
            }

            if (sceneSkeep == 8)
            {
                FieldManager.FieldMng.OnField(false, new Vector2(0, 0), new Vector2(1.8f, 1.8f));
                SetScene(NowScene.gameOver);
            }
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.Escape) && nowScene != GameManager.NowScene.firstScene)
        {
            BGMManager.i.BgmPause();
            GameManager.GM.SetScene(GameManager.NowScene.firstScene);
            sceneSkeep = 0;
        }
    }

    public void SetScripts()
    {
        TitleManager.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.firstScene);
        IntroManager.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.intro);
        SecondManager.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.secondScene);
        ThirdManager.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.thirdScene);
        LastManager.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.lastScene);
        BattleEvent1.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.introBattle);
        BattleEvent2.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.secondBattle);
        BattleEvent3.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.thirdBattle);
        Stage1_PatternManager.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.introBattle);
        Stage2_PatternManager.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.secondBattle);
        Stage3_PatternManager.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.thirdBattle);
    }

    public void ResetScene()
    {
        //BGMManager.i.BgmPause();

        nowBattle = false;
        stage = 0;

        Txt.i.EndTxt();

        TitleManager.i.isStop = false;
        TitleManager.i.time = 0;
        TitleManager.i.round = 0;
        //FieldManager.FieldMng.OnField(false, new Vector2(0, 0), new Vector2(0, 0));
        DialogueManager.i.SetTypinigSound(0);

        IntroManager.i.time = 0f;
        IntroManager.i.round = 4;
        IntroManager.i.isStop = false;

        SecondManager.i.time = 0f;
        SecondManager.i.round = 3;
        SecondManager.i.isStop = false;

        ThirdManager.i.time = 0f;
        ThirdManager.i.round = 0;
        ThirdManager.i.isStop = false;

        LastManager.i.time = 0f;
        LastManager.i.round = 0;
        LastManager.i.isStop = false;

        Stage1_PatternManager.i.GameSpeed = 1;
        Stage1_PatternManager.i.Timer = 0;
        Stage1_PatternManager.i.Count = 0;
        Stage1_PatternManager.i.DestroyAllGimic();

        Stage2_PatternManager.i.onStart_Stage = false;
        Stage2_PatternManager.i.battle_Timer = 0;
        Stage2_PatternManager.i.battle_Count = 0;
        Stage2_PatternManager.i.DestroyAllGimic();

        Stage3_PatternManager.i.onStartPattern = false;
        Stage3_PatternManager.i.battle_Timer = 34;
        Stage3_PatternManager.i.battle_Count = 0;
        Stage3_PatternManager.i.DestroyAllGimic();

        BattleEvent1.i.events = BattleEvent1.i.round = BattleEvent1.i.choose = 0;
        BattleEvent1.i.time = 0f;
        BattleEvent1.i.isStop = BattleEvent1.i.isBeddingKick = BattleEvent1.i.isLight = BattleEvent1.i.isGlass = false;
        BattleEvent1.i.nowEvent = BattleEvent1.i.startEvent = BattleEvent1.i.isFirst = BattleEvent1.i.complete = false;

        BattleEvent2.i.events = BattleEvent2.i.round = BattleEvent2.i.choose = 0;
        BattleEvent2.i.time = 0f;
        BattleEvent2.i.isStop = BattleEvent2.i.isClearBathRoom = BattleEvent2.i.isClearCabinet = false;
        BattleEvent2.i.hair = BattleEvent2.i.dry = BattleEvent2.i.top = BattleEvent2.i.bottom = false;
        BattleEvent2.i.nowEvent = BattleEvent2.i.startEvent = BattleEvent2.i.isFirst = false;

        BattleEvent3.i.events = BattleEvent3.i.round = BattleEvent3.i.choose = 0;
        BattleEvent3.i.nowEvent = BattleEvent3.i.startEvent = BattleEvent3.i.isFirst = false;
        BattleEvent3.i.time = 0f;
    }

    public void SetScene(NowScene _nowScene)
    {
        nowScene = _nowScene;

        SetScripts();
        ResetScene();

        switch (nowScene)
        {
            case NowScene.firstScene:
                PlayerMovement.PM.SetDefalt();
                Stage3_PatternManager.i.onStartPattern = false;
                FieldManager.FieldMng.OnField(false, new Vector2(0, 0), new Vector2(0, 0));
                Pla.SetActive(true);
                PlayerInterection.PI.SetField(PlaHp, PlaMaxHp);
                PlayerInterection.PI.ShowDark();
                sceneSkeep = 0;
                SceneManager.LoadScene("FirstScene");
                break;

            case NowScene.intro:
                sceneSkeep = 1;
               // SceneManager.LoadScene("Intro");
                break;

            case NowScene.introBattle:
                BGMManager.i.BgmPause();
                sceneSkeep = 2;
                nowBattle = true;
                stage = 1;
                BGMManager.i.BGMOnLoop(false);
                //SceneManager.LoadScene("IntroBattle");
                break;

            case NowScene.gameOver:
                BGMManager.i.BgmPause();
                Pla.SetActive(false);
                sceneSkeep = 8;
                BGMManager.i.BGMOnLoop(true);
                nowBattle = false;
                switch (stage)
                {
                    case 1:
                        Stage1_PatternManager.i.DestroyAllGimic();
                        break;
                    case 2:
                        Stage2_PatternManager.i.DestroyAllGimic();
                        break;
                    case 3:
                        break;

                    default:
                        break;
                }
                BGMManager.i.SetBGMVolume(0.7f);
                BGMManager.i.BGMPlay(2);
                SceneManager.LoadScene("GameOver");
                break;

            case NowScene.secondScene:
                BGMManager.i.BgmPause();
                sceneSkeep = 3;
                BGMManager.i.BGMOnLoop(true);
                nowBattle = false;
                PlayerInterection.PI.AddHp(10);
                //SceneManager.LoadScene("SecondScene");
                break;

            case NowScene.secondBattle:
                BGMManager.i.BgmPause();
                sceneSkeep = 4;
                nowBattle = true;
                stage = 2;
                BGMManager.i.BGMOnLoop(false);
                //SceneManager.LoadScene("SecondBattle");
                break;

            case NowScene.thirdScene:
                sceneSkeep = 5;
                nowBattle = false;
                PlayerInterection.PI.AddHp(10);
                //SceneManager.LoadScene("ThirdScene");
                break;

            case NowScene.thirdBattle:
                PlayerMovement.PM.SetStrong();
                sceneSkeep = 6;
                nowBattle = true;
                stage = 3;
                BGMManager.i.BGMOnLoop(false);
                //SceneManager.LoadScene("ThirdBattle");
                break;

            case NowScene.lastScene:
                Stage3_PatternManager.i.onStartPattern = false;
                BGMManager.i.BgmPause();
                sceneSkeep = 7;
                BGMManager.i.BGMOnLoop(true);
                nowBattle = false;
                PlayerInterection.PI.AddHp(10);
                SceneManager.LoadScene("FirstScene");
                //SceneManager.LoadScene("LastScene");
                break;
        }
    }



}
