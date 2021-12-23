using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterection : MonoBehaviour
{
    #region SetSingleTon
    public static PlayerInterection PI;

    private void Awake()
    {
        if (PI == null)
        {
            PI = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion


    #region SetField
    public SpriteRenderer SRR;
    public int hp, maxHp;
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Hill();
        }
    }

    public void SetField(int _hp, int _maxHp)
    {
        hp = _hp;
        maxHp = _maxHp;
        SRR = GetComponent<SpriteRenderer>();
    }

    public void ShowDark()
    {
        float val4 = (1.0f / maxHp) * hp;
        SRR.color = new Color(val4, val4, val4, 1);
    }

    public void Hill()
    {
        AddHp(maxHp);
    }

    public void AddHp(int i)
    {
        Blue();
        Invoke("Yellow", 1f);
        if (hp + i < GameManager.GM.PlaMaxHp)
        {
            hp += i;
        }
        else
        {
            hp = GameManager.GM.PlaMaxHp;
        }
        BGMManager.i.EFTPlay(1);
    }

    public void GetHit()
    {
        hp--;
        Red();
        Invoke("Yellow", 1f);
        Fade.i.SetDark();
        BGMManager.i.EFTPlay(0);
        if (hp <= 0)
        {
            GameManager.GM.SetScene(GameManager.NowScene.gameOver);
            DestroyObj();
        }
    }

    public void DestroyObj()
    {
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }

    public void Red()
    {
        SRR.color = Color.red;
    }

    public void Blue()
    {
        SRR.color = Color.green;
    }

    public void Yellow()
    {
        SRR.color = new Color(255, 255, 255, 255);
        ShowDark();
    }
}
