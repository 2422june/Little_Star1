using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleType2 : MonoBehaviour
{
    [Header("구가 랜덤적으로 생성되어 날아감")]
    public GameObject circleObject;
    public float max_Timer;

    private float randomY, Timer;
    private void Start()
    {
        Timer = max_Timer;
    }
    private void Update()
    {
        Timer -= Time.deltaTime;
        spawnObject();
    }
    
    private void spawnObject()      //오브젝트 생성 함수
    {
                              //y좌표를 랜덤으로 지정해줌.
        Vector2 randomPos = new Vector3(10, randomY);       
        if(Timer <= 0f )
        {
            randomY = Random.Range(-3, 4);
            Instantiate(circleObject, randomPos, Quaternion.identity);
            Timer = max_Timer;
        }
    }
}
