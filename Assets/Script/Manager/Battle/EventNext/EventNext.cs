using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EventNext : MonoBehaviour
{

    GameManager.BattleSpriteState BSS;

    public void Seting(Vector2 _pos, Vector2 _scale, GameManager.BattleSpriteState bss)
    {
        transform.position = new Vector3(_pos.x, _pos.y, 1);
        transform.localScale = _scale;
        BSS = bss;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
    }

    void Update()
    {
        if (!DialogueManager.i.onDialogue)
        {
            Destroy(this.gameObject);
        }
    }

    public void Push()
    {

        if (BSS == GameManager.BattleSpriteState.beddingKick)
        {
            BattleEvent1.i.SetChoose(1);
        }

        if (BSS == GameManager.BattleSpriteState.findingGlass)
        {
            BattleEvent1.i.SetChoose(2);
        }

        if (BSS == GameManager.BattleSpriteState.light)
        {
            BattleEvent1.i.SetChoose(3);
        }
        //-------------------------------------------------------------------------

        if (BSS == GameManager.BattleSpriteState.bad)
        {
            BattleEvent2.i.SetChoose(1);
        }

        if (BSS == GameManager.BattleSpriteState.bathRoom)
        {
            BattleEvent2.i.SetChoose(2);
        }

        if (BSS == GameManager.BattleSpriteState.cabinet)
        {
            BattleEvent2.i.SetChoose(3);
        }

        if (BSS == GameManager.BattleSpriteState.exit)
        {
            BattleEvent2.i.SetChoose(4);
        }

        if (BSS == GameManager.BattleSpriteState.hair)
        {
            BattleEvent2.i.SetChoose(21);
        }

        if (BSS == GameManager.BattleSpriteState.dry)
        {
            BattleEvent2.i.SetChoose(22);
        }

        if (BSS == GameManager.BattleSpriteState.top)
        {
            BattleEvent2.i.SetChoose(31);
        }

        if (BSS == GameManager.BattleSpriteState.bottom)
        {
            BattleEvent2.i.SetChoose(32);
        }
        //-------------------------------------------------------------------------

        DialogueManager.i.onDialogue = false;
        PlayerInterection.PI.AddHp(2);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 0, 255);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
    }
}
