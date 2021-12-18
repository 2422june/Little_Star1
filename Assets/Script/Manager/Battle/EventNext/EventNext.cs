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

        DialogueManager.i.onDialogue = false;
        PlayerInterection.PI.AddHp(5);
        Destroy(this.gameObject);
    }
}
