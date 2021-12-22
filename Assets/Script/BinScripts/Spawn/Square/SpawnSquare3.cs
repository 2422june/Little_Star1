using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSquare3 : MonoBehaviour
{
    [Header ("사각형 패턴 (세로)")]
    public GameObject squareObject;
    public float Timer;
    //posX - i  x좌표값은 -3.5 ~ 3.5 사이로

    private bool isTrue;
    private float posX = -5f;

    void Start()
    {
        for (float i = 0f; i <= 10f; i += 5)
        {
            Instantiate(squareObject, new Vector3(posX + i, 10, 0), Quaternion.identity);
            if (i == 10)
                isTrue = true;
        }

    }

    private void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0 && isTrue)
        {
            for (float i = 2.5f; i <= 7.5f; i += 2.5f)
            {
                if(i + posX !=  0)
                    Instantiate(squareObject, new Vector3(posX + i, 10, 0), Quaternion.identity);

                if (i == 7.5f)
                    isTrue = false;
            }
        }
    }

}
