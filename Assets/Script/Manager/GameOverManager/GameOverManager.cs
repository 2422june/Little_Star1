using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{

    void Start()
    {
        GameManager.GM.ResetScene();
        GameManager.GM.SetScripts();
    }
}
