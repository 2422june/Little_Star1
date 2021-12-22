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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GetHit();
        }
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
        //int val = (maxHp - hp);
        //float val2 = 1.0f / (float)(maxHp - val);
        //float val3 = ((float)maxHp / (float)val) / (float)maxHp;
        float val4 = (1.0f / maxHp) * hp;
        //Fade.i.SetDark((float)val / (float)maxHp);
        SRR.color = new Color(val4, val4, val4, 1);
    }

    public void Hill()
    {
        hp = maxHp;
        ShowDark();
    }

    public void AddHp(int i)
    {
        if(hp + i < GameManager.GM.PlaMaxHp)
        {
            hp += i;
        }
        else
        {
            hp = GameManager.GM.PlaMaxHp;
        }
        BGMManager.i.EFTPlay(1);
        ShowDark();
    }

    public void GetHit()
    {
        hp--;
        Fade.i.SetDark();
        BGMManager.i.EFTPlay(0);
        ShowDark();
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
}
