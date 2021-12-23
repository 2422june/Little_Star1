using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppear : MonoBehaviour
{
    [Header("보스가 스폰되고 게임 화면에 천천히 나타남")]

    [SerializeField] private GameObject boss_Object;         //생성시킬 보스 오브젝트
    
    private void Start()
    {
        Instantiate(boss_Object, new Vector2(0f, 8f), Quaternion.identity);
    }

}
