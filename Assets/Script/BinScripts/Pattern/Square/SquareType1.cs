using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareType1 : MonoBehaviour
{
    public GameObject squareObject;
    public Transform squareSpawner;
    public float maxTimer;

    private float Timer;
    private bool isPos;
    
    private void Update()
    {
        Timer -= Time.deltaTime;

        if( Timer <= 0 && isPos)
        {
            Instantiate(squareObject, new Vector3(squareSpawner.position.x, -3f, 0), Quaternion.identity);
            Timer = maxTimer;
            isPos = false;
        }
        else if(Timer <= 0 && !isPos)
        {
            Instantiate(squareObject, new Vector3(squareSpawner.position.x, 3f, 0), Quaternion.identity);
            Timer = maxTimer;
            isPos = true;
        }

    }
}
