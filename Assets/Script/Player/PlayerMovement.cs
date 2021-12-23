using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    SpriteRenderer srr;

    [SerializeField]
    Sprite defalte;

    [SerializeField]
    Sprite strong;

    public float Speed = 10f;               //이동 속도

    private float horizontal;       //수평
    private float vertical;         //수직 
    float time = 0, rotSpeed = 270;
    Vector3 Movement;      //플레이어 이동

    bool isCanMove = true;
    public bool push = false, canPush = true, isCanAttacked = true, isAttacked = false;

    AudioSource AS;

    

    public static PlayerMovement PM;

    private void Awake()
    {
        if(PM == null)
        {
            PM = this;
            AS = GetComponent<AudioSource>();
            srr = GetComponent<SpriteRenderer>();
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        PlayerTurn();
        if (isCanMove)
        {
            Movement = new Vector3(horizontal, vertical, 0).normalized;
            transform.position += (Movement * Speed * Time.deltaTime);
        }

        Attacked();

        Push();
    }


    void Attacked()
    {
        if (isAttacked)
        {
            rotSpeed = 100;
            isCanAttacked = false;
            time += Time.deltaTime;
            if(time >= 2.0f)
            {
                time = 0;
                rotSpeed = 270;
                isCanAttacked = true;
                isAttacked = false;
            }
        }
    }

    void PlayerTurn() {

        transform.eulerAngles += new Vector3(0, 0, Time.deltaTime * rotSpeed);
    }

    public void SetCanMove(bool _isCanMove)
    {
        isCanMove = _isCanMove;
    }

    void Push()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return)) && canPush)
        {
            push = true;
            canPush = false;
        }

        if ((!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.Return)))
        {
            push = false;
            canPush = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (push)
        {
            if (collision.gameObject.CompareTag("DialogueNext"))
            {
                if(collision.gameObject.GetComponent<DialogueNext>().NSS == GameManager.NextSpriteState.TitleSubject)
                {
                    return;
                }
                AS.Play();
                collision.gameObject.GetComponent<DialogueNext>().Push();
            }
            if (collision.gameObject.CompareTag("BattleNext"))
            {
                AS.Play();
                collision.gameObject.GetComponent<EventNext>().Push();
            }

            push = false;
        }

        if (isCanAttacked)
        {
            if (collision.gameObject.CompareTag("Gimic"))
            {
                PlayerInterection.PI.GetHit();
                isAttacked = true;
            }
        }
    }

    public void SetDefalt()
    {
        srr.sprite = defalte;
    }

    public void SetStrong()
    {
        //srr.sprite = strong;
    }
}
