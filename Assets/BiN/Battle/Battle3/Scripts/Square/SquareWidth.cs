using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareWidth : MonoBehaviour
{
    [Header("사각형을 가로로 생성")]

    [SerializeField] private GameObject squareObject;       //생성시킬 게임 오브젝트
    [SerializeField] private float spawnDelay;              //새싱시킬 오브젝트의 생성 딜레이값
    
    [Header ("좌표값")]
    [SerializeField] private int max_PositionY;             //오브젝트의 y값을 랜덤으로 돌림 (최대값)
    [SerializeField] private int min_PositionY;             //오브젝트의 y값을 랜덤으로 돌림 (최소값)    
    private int Count = 0;
    private int random_PositionY;                           //랜덤으로 돌린 오브젝트의 y 좌표값
    private int positionX = 8;

    private void Start()
    {
        StartCoroutine("SpawnSquare");
    }

    IEnumerator SpawnSquare()
    {
        random_PositionY = Random.Range(min_PositionY, max_PositionY);

        yield return new WaitForSeconds(spawnDelay);
        Count++;
        if(Count == 3)
        {
            Fade.i.OnFade(0.1f);
            Count = 0;
        }
        Instantiate(squareObject, new Vector2(positionX, random_PositionY), Quaternion.identity);
        StartCoroutine("SpawnSquare");
    }
}
