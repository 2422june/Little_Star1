using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleType1_Down : MonoBehaviour
{
    [Header("구가 일정 위치까지 내려가고 난 후 터짐")]

    public GameObject circleObject;                     //오브젝트가 산개하기전 오브젝트
    public GameObject fragment;                         //산개한 후 오브젝트
    public float Speed, minHieght, maxHieght;           //오브젝트 이동 속도, 최소 높이, 최대 높이
    public bool onColor;                                //오브젝트가 올라갈지 내려갈지 판별해줄 bool 변수

    private SpriteRenderer circleColor;                 //구 색 변경
    private float Slow, posY;                           //오브젝트가 느려지는 정도, 오브젝트의 초기 좌표값
    private bool onSlow;                                //오브젝트의 슬로우, 마무리를 판별해줄 bool 변수
    private bool onEnd;

    private void Start()
    {
        circleColor = circleObject.GetComponent<SpriteRenderer>();
        posY = circleObject.transform.position.y;       //오브젝트의 초기값 저장
        Slow = 1f;                                      
    }
    private void FixedUpdate()
    {
        StartCoroutine("Effect");
        transform.Translate(Vector2.down * Speed * Time.deltaTime * Slow);
        Down();
    }


    private void Down()     //오브젝트가 위에서 생성되서 아래로 내려옴
    {

        if (transform.position.y <= minHieght)        //y 최소값보다 작아지면 오브젝트 슬로우
        {
            onSlow = true;
        }
        
        if (transform.position.y <= maxHieght)       //y 최대값 보다 작아지면 오브젝트 산개
        {
            onEnd = true;
        }

        if (onSlow)
        {
            Slow = 0.2f;
        }
        
        if (onEnd)
        {
            Shot();
            Destroy(this.gameObject);
        }
    }
    private void Shot()                                 //오브젝트 산개
    {
        for(int i = 0; i < 360; i += 48)
        {
            Fade.i.OnFade(0.1f);
            GameObject temp = Instantiate(fragment);            //산개할 오브젝트 생성
            Destroy(temp, 2f);                                      //산개한 오브젝트를 2초 후 삭제

            temp.transform.position = circleObject.transform.position;
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

    IEnumerator Effect()        //터지기 전 오브젝트 색 변경
    {
        if(onColor)
        {
            yield return new WaitForSeconds(0.1f);
            circleColor.color = new Color(1, 0, 0, 1);
            onColor = false;
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            circleColor.color = new Color(1, 1, 1, 1);
            onColor = true;
        }
    }

}
