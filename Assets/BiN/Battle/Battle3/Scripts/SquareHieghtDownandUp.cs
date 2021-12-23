using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareHieghtDownandUp : MonoBehaviour
{
    [Header("사각형 오브젝트가 아래에서 솟아나고 위에서 떨어짐")]

    [SerializeField] private GameObject squareObject_Up;        //올라가는 오브젝트
    [SerializeField] private GameObject squareObject_Down;      //내려가는 오브젝트
    
    [Header ("오브젝트가 생성될 좌표값")]
    [SerializeField] private int max_PositionX;
    [SerializeField] private int min_PositionX;
    [SerializeField] private int max_PositionY;
    [SerializeField] private int min_PositionY;

    private int random_PositionX;       //x 좌표값을 랜덤으로 돌려 저장시킬 변수

    [SerializeField] private float Delay;

    private void Start()
    {
        StartCoroutine("StartPattern");
    }

    IEnumerator StartPattern()
    {
        random_PositionX = Random.Range(min_PositionX, max_PositionX);

        Instantiate(squareObject_Down, new Vector2(random_PositionX, max_PositionY), Quaternion.identity);      //내려가는 오브젝트 생성
        yield return new WaitForSeconds(Delay);

        Instantiate(squareObject_Up, new Vector2(random_PositionX, min_PositionY), Quaternion.identity);        //올라가는 오브젝트 생성
        yield return new WaitForSeconds(Delay);

        StartCoroutine("StartPattern");
    }
}
