using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueNext : MonoBehaviour
{

    Txt txt;
    public GameManager.NextSpriteState NSS;

    public void Seting(Vector2 _pos, Vector2 _scale, GameManager.NextSpriteState nss)
    {
        txt = GameObject.Find("DialogueMng").GetComponent<Txt>();
        transform.position = new Vector3(_pos.x, _pos.y, 1);
        transform.localScale = _scale;
        NSS = nss;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if ((txt.isNext && !txt.isSet) || !DialogueManager.i.onDialogue)
        {
            txt.isNext = false;
            Destroy(this.gameObject);
        }
    }

    public void Push()
    {

        if (NSS == GameManager.NextSpriteState.GameQuit)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
        }

        if (NSS == GameManager.NextSpriteState.GameStart)
        {
            txt.EndTxt();
            DialogueManager.i.onDialogue = false;
            GameManager.GM.SetScene(GameManager.NowScene.intro);
        }

        if (NSS == GameManager.NextSpriteState.Next)
        {
            txt.isNext = true;
            DialogueManager.i.onDialogue = false;
            Destroy(this.gameObject);
        }

        if (NSS == GameManager.NextSpriteState.DialogueNext)
        {
            txt.isNext = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && NSS != GameManager.NextSpriteState.TitleSubject)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 0, 255);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && NSS != GameManager.NextSpriteState.TitleSubject)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
    }
}
