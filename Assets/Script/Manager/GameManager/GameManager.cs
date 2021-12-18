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
        chapter2, chapter2Battle,
        chapter3, chapter3Battle
    };

    public enum NextSpriteState
    {
        GameStart, TitleSubject, GameQuit, Next, DialogueNext
    };

    public enum BattleSpriteState
    {
        beddingKick, findingGlass, light
    };

    public BattleSpriteState BSS;

    public NextSpriteState NSS;

    public NowScene nowScene;

    public int PlaHp, PlaMaxHp, stage, sceneSkeep;
    public bool nowBattle;
    #endregion

    void Start()
    {
        PlaHp = PlaMaxHp = 5;
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
        if (Input.GetKeyDown(KeyCode.U))
        {
            ResetScene();
            sceneSkeep++;

            if (sceneSkeep == 4)
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
                SetScene(NowScene.secondScene);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.S))
        {
            if(BGMManager.i.Eft.volume == 0)
            {
                BGMManager.i.SetBGMVolume(1);
            }
            else
            {
                BGMManager.i.SetBGMVolume(0);
            }
        }
    }

    public void SetScripts()
    {
        TitleManager.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.firstScene);
        IntroManager.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.intro);
        SecondManager.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.secondScene);
        BattleEvent1.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.introBattle);
        Stage1_PatternManager.i.enabled = (GameManager.GM.nowScene == GameManager.NowScene.introBattle);
    }

    public void ResetScene()
    {
        nowBattle = false;
        stage = 0;

        Txt.i.EndTxt();

        TitleManager.i.isStop = false;
        TitleManager.i.time = 0;
        TitleManager.i.round = 0;
        FieldManager.FieldMng.OnField(false, new Vector2(0, 0), new Vector2(0, 0));
        DialogueManager.i.SetTypinigSound(0);

        IntroManager.i.time = 0f;
        IntroManager.i.round = 4;
        IntroManager.i.isStop = false;

        SecondManager.i.time = 0f;
        SecondManager.i.round = 3;
        SecondManager.i.isStop = false;

        Stage1_PatternManager.i.GameSpeed = 1;
        Stage1_PatternManager.i.Timer = 0;
        Stage1_PatternManager.i.Count = 0;
        Stage1_PatternManager.i.DestroyAllGimic();

        BattleEvent1.i.events = BattleEvent1.i.round = BattleEvent1.i.choose = 0;
        BattleEvent1.i.time = 0f;
        BattleEvent1.i.isStop = BattleEvent1.i.isBeddingKick = BattleEvent1.i.isLight = BattleEvent1.i.isGlass = false;
        BattleEvent1.i.nowEvent =  BattleEvent1.i.startEvent = BattleEvent1.i.isFirst = false;
    }

    public void SetScene(NowScene _nowScene)
    {
        nowScene = _nowScene;

        SetScripts();

        switch (nowScene)
        {
            case NowScene.firstScene:
                SceneManager.LoadScene("FirstScene");
                break;

            case NowScene.intro:
                SceneManager.LoadScene("Intro");
                break;

            case NowScene.introBattle:
                nowBattle = true;
                stage = 1;
                BGMManager.i.BGMOnLoop(false);
                SceneManager.LoadScene("IntroBattle");
                break;

            case NowScene.gameOver:
                BGMManager.i.BGMOnLoop(true);
                nowBattle = false;
                ResetScene();
                switch (stage)
                {
                    case 1:
                        Stage1_PatternManager.i.DestroyAllGimic();
                        break;

                    default:
                        break;
                }
                BGMManager.i.SetBGMVolume(0.7f);
                BGMManager.i.BGMPlay(2);
                SceneManager.LoadScene("GameOver");
                break;

            case NowScene.secondScene:
                BGMManager.i.BGMOnLoop(true);
                nowBattle = false;
                SceneManager.LoadScene("SecondScene");
                break;

            case NowScene.secondBattle:
                nowBattle = true;
                stage = 1;
                BGMManager.i.BGMOnLoop(false);
                //SceneManager.LoadScene("SecondScene");
                break;

            case NowScene.chapter2:
                break;
            case NowScene.chapter2Battle:
                break;

            case NowScene.chapter3:
                break;
            case NowScene.chapter3Battle:
                break;
        }
    }
}
