using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawn : MonoBehaviour
{
    [Header ("영역 스폰")]

    public GameObject circleObject;
    public float posX, posY, maxTimer;
    
    
    private float Timer;
    private bool positionX, positionY;
    private int cnt, countX, countY;

    private void Start()
    {
        countX = 1;
        countY = 1;
        positionX = true;
        Timer = maxTimer;
    }

    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0 && positionX)
        {
            spawnX();
            Timer = maxTimer;
        }
        else if (Timer <= 0 && positionY)
        {
            spawnY();
            Timer = maxTimer;
        }

        if (cnt == 2)
        {
            positionX = false;
            positionY = true;
        }
        else if (cnt == 4)
        {
            positionY = false;
        }
    }

    private void spawnX()
    {

            if (countX != 0)
            {
                Instantiate(circleObject, new Vector2(countX * posX, posY), Quaternion.identity);
                cnt++;
            }
        countX--;

    }

    private void spawnY()
    {
        if (countY != 0)
        {
            Instantiate(circleObject, new Vector2(countY * posX, -1 * posY), Quaternion.identity);
            cnt++;
        }
        countY--;
    }
}
