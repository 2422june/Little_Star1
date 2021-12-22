using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMOver : MonoBehaviour
{

    public void Push()
    {
        GameManager.GM.SetScene(GameManager.NowScene.firstScene);
    }
}
