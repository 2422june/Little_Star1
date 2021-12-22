using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleType3 : MonoBehaviour
{
    [Header("구의 영역이 커지고 터진 후 삭제되는 코드")]

    public SpriteRenderer circleObject;     //데미지를 주는 영역으로 바뀌기 전 스프라이트
    public float scaleSpeed;                //영역의 크기 변환을 위한 변수
    public float colorSpeed;                //오브젝트의 색이 바뀌는 속도
    public float maxScale;                  //오브젝트의 최대 크기
    public float minScale;                  //오브젝트의 최소 크기
    public float Timer;
    
    private bool isBoom;                    //구가 터졌는지 안터졌는지 판별 해줄 bool 변수
    private bool isScale;                   //구의 크기를 판별 해줄 bool 변수
    private bool onColor;                   //색 변경을 활성화 시켜줄 bool 변수
    private void Start()
    {
        isScale = true;
        circleObject.color = new Color(1, 0, 0, 0.5f);
    }
    
    private void LateUpdate()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
            StartCoroutine("onScale");
    }

    IEnumerator onScale()
    {
        float speed = Time.deltaTime * scaleSpeed;
        StartCoroutine("onEffect");
        if (isScale)
        {
            if (transform.localScale.x < maxScale && transform.localScale.y < maxScale)
            {   
                transform.localScale = new Vector3(transform.localScale.x + speed * Time.deltaTime, transform.localScale.y + speed * Time.deltaTime, 1);
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                isScale = false;
            }

        }
        else if (!isScale)
        {
            if (transform.localScale.x > minScale && transform.localScale.y > minScale)
            {
                transform.localScale = new Vector3(transform.localScale.x - speed * Time.deltaTime, transform.localScale.y - speed * Time.deltaTime, 1);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator onEffect()
    {
        float g = circleObject.color.g + colorSpeed * Time.deltaTime;
        float b = circleObject.color.b + colorSpeed * Time.deltaTime;
        float a = circleObject.color.a + colorSpeed * Time.deltaTime;

        if (circleObject.color == new Color(1, 0, 0, 0.5f))
        {
            onColor = true;
        }

        if(onColor && g < 0.8f || b < 0.8f)
        {
            circleObject.color = new Color(1, g, b, a);
        }
        else if(circleObject.color == new Color(1, 1, 1, 1))
        {
            yield return new WaitForSeconds(1.5f);
            Destroy(this.gameObject);
        }

    }
}