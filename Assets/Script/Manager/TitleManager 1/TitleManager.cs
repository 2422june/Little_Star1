using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    public static TitleManager i;

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
    GameObject Player, Field;

    public float time;

    public bool isStop;
    public int round;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        round = 0;
        isStop = false;

        Cursor.visible = false;

        FieldManager.FieldMng.OnField(false, new Vector2(0, 0), new Vector2(0, 0));
        DialogueManager.i.SetTypinigSound(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStop)
        {
            time += Time.deltaTime;
        }

        if (IsOffDialogue())
        {
            round--;
            Intro();
        }
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
        #region Dialogue.0
        if (round == 0)
        {
            DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(1000, 400));
            DialogueManager.i.OnTxt(50, "조작법\n이동 : 이동키\n상호작용, 확인 : enter, space", 10f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);

            isStop = true;
            round++;
        }

        if (round == 1)
        {
            IsOffDialogue();
        }
        #endregion

        #region Dialogue.1
        if (time >= 0 && round == 2)
        {
            BGMManager.i.SetBGMVolume(0.5f);
            BGMManager.i.BGMPlay(0);
            DialogueManager.i.OnDialogueNext(new Vector2(0, 3f), new Vector2(1.5f, 1.5f), GameManager.NextSpriteState.TitleSubject);
            DialogueManager.i.OnDialogueNext(new Vector2(0, -1.8f), new Vector2(1.5f, 1.5f), GameManager.NextSpriteState.GameStart);
            DialogueManager.i.OnDialogueNext(new Vector2(0, -3.8f), new Vector2(1.5f, 1.5f), GameManager.NextSpriteState.GameQuit);
            isStop = true;
            round++;
        }

        if (round == 3)
        {
            if (IsOffDialogue())
            {
                isStop = false;
            }
        }
        #endregion

    }
}
