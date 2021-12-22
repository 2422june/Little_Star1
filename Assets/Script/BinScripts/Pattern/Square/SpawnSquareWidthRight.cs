using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSquareWidthRight : MonoBehaviour
{
    [SerializeField] private GameObject sqaureObject;
    [SerializeField] private float positionX;
    [SerializeField] private float positionY;

    private void Start()
    {
       for(int i = 1; i >= -1; i-=2)
       {
            Instantiate(sqaureObject, new Vector2(positionX, positionY * i), Quaternion.identity);
       }
    }
}
