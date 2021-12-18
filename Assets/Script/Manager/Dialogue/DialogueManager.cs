using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager i;

    [SerializeField]
    Txt TxtObj;

    void Awake()
    {
        if(i == null)
        {
            i = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public string txt;
    public bool onBase = false, onDialogue;
    public int fontScale;
    public float typingTime;
    public Vector2 basePos, baseScale, nextPos;
    public Color fontColor;

    [SerializeField]
    GameObject TextBox, Base, DialogueNext, BattleNext;

    Image DialogueBaseImage;
    Text DialogueTextBoxText;
    Text DialogueNextText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.GM.NSS = GameManager.NextSpriteState.GameStart;
        Base = GameObject.Find("DialogueBase");
        TextBox = GameObject.Find("DialogueText");
        DialogueBaseImage = Base.GetComponent<Image>();
        DialogueTextBoxText = TextBox.GetComponent<Text>();
        DialogueNextText = DialogueNext.GetComponentInChildren<Text>();
        TxtObj = GetComponent<Txt>();
        TextBox.SetActive(false);
        Base.SetActive(false);
    }
    public void OnBase(bool _isOn, Vector2 _pos, Vector2 _scale)
    {
        onBase = _isOn;
        Base.SetActive(onBase);
        basePos = _pos;
        baseScale = _scale;
    }
    public void OnTxt(int _fontScale, string _txt, float _typingTime, Color _color)
    {
        if (!onDialogue)
        {
            TextBox.SetActive(true);
            TextBox.GetComponentInChildren<Text>().enabled = true;
            fontScale = _fontScale;
            txt = _txt;
            typingTime = _typingTime;
            fontColor = _color;
            TxtObj.SetTxt(basePos, baseScale, fontScale, txt, typingTime, fontColor);
            onDialogue = true;
        }
    }

    public void OnDialogueNext(Vector2 pos, Vector2 scale, GameManager.NextSpriteState NSS)
    {
        GameObject next = Instantiate(DialogueNext) as GameObject;
        next.GetComponent<SpriteRenderer>().sprite = GameManager.GM.NextSprite[(int)NSS];
        next.GetComponent<DialogueNext>().Seting(pos, scale, NSS);
        onDialogue = true;
    }

    public void OnBattleNext(Vector2 pos, Vector2 scale, GameManager.BattleSpriteState BSS)
    {
        GameObject next = Instantiate(BattleNext) as GameObject;
        next.GetComponent<SpriteRenderer>().sprite = GameManager.GM.BattleSprite[(int)BSS];
        next.GetComponent<EventNext>().Seting(pos, scale, BSS);
        onDialogue = true;
    }

    public void SetTypinigSound(int num)
    {
        TxtObj.SetTypinigSound(num);
    }
}