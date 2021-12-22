using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Txt : MonoBehaviour
{
    public static Txt i;

    private void Awake()
    {
        if(i == null)
        {
            i = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public List<AudioClip> Efft = new List<AudioClip>();

    public AudioSource typingSound;

    public bool isSet = false, isSetBase = false, isNext;
    float typingTime, typingTiemr;

    int size, accesse;

    string _value;

    [SerializeField]
    GameObject Base, TxtBox;

    Text MyTxt;

    Image BaseImage;

    // Start is called before the first frame update
    void Start()
    {
        accesse = 0;
        MyTxt = TxtBox.GetComponent<Text>();
        BaseImage = GetComponentInChildren<Image>();

        typingSound = GetComponent<AudioSource>();
        isSet = false;
    }

    public void EndTxt()
    {
        MyTxt.text = "";
        MyTxt.enabled = false;
        isSetBase = false;
        isSet = false;
        /*if (GameManager.GM.nowBattle)
        {
            PlayerInterection.PI.AddHp();
        }*/
        DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
        DialogueManager.i.onDialogue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSet)
        {
            if (isNext)
            {
                if (accesse <= size)
                {
                    accesse = size;
                    isNext = false;
                }
                else
                {
                    /*if (GameManager.GM.nowBattle)
                    {
                        PlayerInterection.PI.AddHp();
                    }*/
                    EndTxt();
                }
            }
            else
            {
                Typing();
            }
        }
    }


    void Typing()
    {
        if (accesse <= size)
        {
            typingTiemr += Time.deltaTime;
            if (typingTiemr >= typingTime)
            {
                typingTiemr = 0;
                MyTxt.text = _value.Substring(0, accesse);

                typingSound.Play();
                accesse++;
            }
        }
    }

    //type 1= fade, 2= typing
    public void SetTxt(Vector2 _basePos, Vector2 _baseScale, int fontSize, string value, float _typingTime, Color color)
    {
        MyTxt = TxtBox.GetComponent<Text>();

        MyTxt.rectTransform.sizeDelta = _baseScale - new Vector2(60, 60);

        Vector3 pos = _basePos;
        MyTxt.rectTransform.anchoredPosition = pos;
        

        MyTxt.fontSize = fontSize;

        MyTxt.color = color;

        _value = value;

        typingTiemr = 0;

        MyTxt.text = "";

        size = _value.Length;
        typingTime = (_typingTime) / (float)size;
        accesse = 0;

        OnBase();
        isNext = false;
        isSet = true;
    }


        //---------------------------------------------------------------------------------

    public void OnBase()
    {
        BaseImage = Base.GetComponent<Image>();
        BaseImage.enabled = DialogueManager.i.onBase;
        BaseImage.rectTransform.sizeDelta = DialogueManager.i.baseScale;
        Vector3 pos = DialogueManager.i.basePos;
        BaseImage.rectTransform.anchoredPosition = pos;
    }

    public void SetTypinigSound(int num)
    {
        typingSound.clip = Efft[num];
    }
}
