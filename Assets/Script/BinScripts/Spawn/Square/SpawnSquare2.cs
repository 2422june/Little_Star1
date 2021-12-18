using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSquare2 : MonoBehaviour
{
    [Header ("사각형 가로 패턴")]
    public GameObject squareObject;

    private void Start()
    {
        for (int i = 4; i >= -4; i -= 4)
            Instantiate(squareObject, new Vector2(20, i), Quaternion.identity);
    }
}
