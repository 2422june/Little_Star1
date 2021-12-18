using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle1Spawn : MonoBehaviour
{
    [Header ("산개하는 구를 생성시킴")]

    public GameObject circleObject;
    public Transform spawner;
    public float max_Delay;

    private float Delay;

    private void Start()
    {
        Delay = 0;
    }
    private void Update()
    {
        Delay -= Time.deltaTime;

        if(Delay <= 0)
        {
            Instantiate(circleObject, spawner.transform.position, Quaternion.identity);
            Delay = max_Delay;
        }
    }

}
