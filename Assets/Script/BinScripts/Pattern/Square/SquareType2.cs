using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareType2 : MonoBehaviour
{
    [Header ("�簢�� ��ֹ� ���� (����)")]

    public SpriteRenderer squareObject;     //������ ������Ʈ�� �÷��� �ٲٱ� ���� ��������Ʈ ����

    public float scaleSpeed;                //������ ���� �ӵ� ����
    public float colorSpeed;                //�� ���� �ӵ� ����
    public float objectSpeed;               //������Ʈ�� �����϶��� ���ǵ尪
    public float minWidth;                  //�ּ� �̵� �ʺ�
    public float maxWidth;                  //�ִ� �̵� �ʺ�

    private bool onColor, onDestroy, isColor, isMove, destroyObj, onScale;
 
    //x -0.5 -> 0.5 -> 0 -> �÷� ���� -> ������ ���� �ϸ� ���İ� ���� -> ����
    

    private void Start()
    {
        onScale = false;
        //���� �Ͼ������ ����
        isMove = true;
        squareObject.color = new Color(1, 0, 0, 1);
    }
    private void Update()
    {
        //������Ʈ �̵� �ڵ�
        if (transform.position.x > minWidth && isMove)        //������Ʈ�� -2���� �̵�
        {
            transform.Translate(Vector2.left * objectSpeed * Time.deltaTime);
        }
        else if(transform.position.x < maxWidth)        //������Ʈ�� -2���� �̵��ϸ� 2��ǥ�� �̵�
        {
            transform.Translate(Vector2.right * objectSpeed * Time.deltaTime);

            isMove = false;
            onColor = true;
        }
        

        if(onColor)     //�̵� �� ����Ʈ ȿ��
        {
            StartCoroutine("Effect", 2f);
        }
                
    }

    IEnumerator Effect()
    {
        float g = squareObject.color.g + colorSpeed * Time.deltaTime;       //�׸� �� ����
        float b = squareObject.color.b + colorSpeed * Time.deltaTime;       //���� �� ����
        float a = squareObject.color.a - colorSpeed * Time.deltaTime;       //���� �� ����

        if(transform.localScale.y < 1f && onScale)      //������Ʈ�� y ũ�⸦ �ø�
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + scaleSpeed * Time.deltaTime, transform.localScale.z);
        }

        if (squareObject.color == new Color(1, 1, 1, 1))
        {
            isColor = true;
        }

        if (isColor)        //�÷��� ����� �ٲ�
        {
            squareObject.color = new Color(1, 0, 0, 1);
            isColor = false;
        }
        else                //�ٲٰ� �� �� �÷� ����
        {
            squareObject.color = new Color(1, g, b, a);
            destroyObj = true;
            onScale = true;
        }

        if(a < 0.3f && destroyObj)      //���İ��� 0.3 �����϶� ������Ʈ ����
        {
            Destroy(this.gameObject);
        }

        yield return null;
    }
}