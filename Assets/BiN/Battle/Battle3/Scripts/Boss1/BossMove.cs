using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [SerializeField] private float boss_Speed;              //보스가 생성되어 내려오는 속도
    [SerializeField] private GameObject circleObject;       //보스가 사라지고 난 후 산개시킬 오브젝트
    [SerializeField] private float Delay;

    private bool isMove;
    private void Update()
    {
        if (transform.position.y >= 0.8f && !isMove)
        {
            transform.Translate(Vector2.down * boss_Speed * Time.deltaTime);
        }
        else
        {
            isMove = true;
        }

        if (isMove)
            StartCoroutine("StayBoss");

        if (transform.position.y >= 8f)
            Destroy(this.gameObject);
    }

    IEnumerator StayBoss()
    {
        yield return new WaitForSeconds(Delay);
        Fade.i.OnFade(0.1f);
        Shot();
        Destroy(this.gameObject);
    }

    private void Shot()
    {
        for(int i = 0; i < 360; i += 24)
        {
            GameObject temp = Instantiate(circleObject) as GameObject;
            Destroy(temp.gameObject, 2f);

            temp.transform.position = this.transform.position;
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }
}
