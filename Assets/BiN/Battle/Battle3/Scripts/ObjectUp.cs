using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUp : MonoBehaviour
{
    [Header("사각형 오브젝트를 아래에서 위로 이동")]

    public SpriteRenderer squareObject;     //생성한 오브젝트의 컬러를 바꾸기 위한 스프라이트 렌더

    public float scaleSpeed;                //스케일 변경 속도 변수
    public float colorSpeed;                //색 변경 속도 변수
    public float objectSpeed;               //오브젝트가 움직일때의 스피드값
    public float minHieght;                 //최소 이동 높이
    public float maxHieght;                 //최대 이동 높이    
    [SerializeField] private bool onFade;
    private bool onColor, onDestroy, isColor, isMove, destroyObj, onScale;

    //x -0.5 -> 0.5 -> 0 -> 컬러 변경 -> 스케일 변경 하며 알파값 변경 -> 삭제


    private void Start()
    {
        onScale = false;
        //색을 하얀색으로 지정
        isMove = true;
        squareObject.color = new Color(1, 0, 0, 1);
    }
    private void Update()
    {
        //오브젝트 이동 코드
        if (transform.position.y < maxHieght && isMove)        //오브젝트가 -2까지 이동하면 0좌표로 이동
        {
            transform.Translate(Vector2.up * objectSpeed * Time.deltaTime);
        }
        else if (transform.position.y > minHieght)        //오브젝트가 -2까지 이동
        {
            transform.Translate(Vector2.down * objectSpeed * Time.deltaTime);

            if (onFade)
                Fade.i.OnFade(0.1f);
            isMove = false;
            onColor = true;
        }
        if (onColor)     //이동 후 이펙트 효과
            StartCoroutine("Effect", 2f);

    }

    IEnumerator Effect()
    {
        float g = squareObject.color.g + colorSpeed * Time.deltaTime;       //그린 값 연산
        float b = squareObject.color.b + colorSpeed * Time.deltaTime;       //블루 값 연산
        float a = squareObject.color.a - colorSpeed * Time.deltaTime;       //알파 값 연산

        if (transform.localScale.x < 1f && onScale)      //오브젝트의 y 크기를 늘림
        {
            transform.localScale = new Vector3(transform.localScale.x + scaleSpeed * Time.deltaTime, transform.localScale.y, transform.localScale.z);
        }

        if (squareObject.color == new Color(1, 1, 1, 1))
        {
            isColor = true;
        }

        if (isColor)        //컬러를 레드로 바꿈
        {
            squareObject.color = new Color(1, 0, 0, 1);
            isColor = false;
        }
        else                //바꾸고 난 후 컬러 변경
        {
            squareObject.color = new Color(1, g, b, a);
            destroyObj = true;
            onScale = true;
        }

        if (a < 0.3f && destroyObj)      //알파값이 0.3 이하일때 오브젝트 삭제
        {
            Destroy(this.gameObject);
        }

        yield return null;
    }
}
