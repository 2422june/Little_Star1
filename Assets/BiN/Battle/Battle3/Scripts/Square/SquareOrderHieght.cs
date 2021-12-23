using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareOrderHieght : MonoBehaviour
{
    [Header ("오브젝트가 세로로 순차적으로 생성되며 이동함")]

    #region //Field

    [SerializeField] private GameObject squareObject_Up;
    [SerializeField] private GameObject squareObject_Down;

    [Header("좌표값 변수 선언")]
    [SerializeField] private float min_PositionX;
    [SerializeField] private float max_PositionX;
    [SerializeField] private float min_PositionY;
    [SerializeField] private float max_PositionY;

    [Header("딜레이 변수")]
    [SerializeField] private float Delay;
    [SerializeField] private float spawnDelay;

    #endregion

    private void Start()
    {
        StartCoroutine("UpPattern");
    }
    IEnumerator UpPattern()
    {
        for(float x = min_PositionX; x <= max_PositionX; x++)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(squareObject_Up, new Vector2(x, max_PositionY), Quaternion.identity);

            if (x >= max_PositionX)
            {
                yield return new WaitForSeconds(Delay);
                StartCoroutine("DownPattern");
                StopCoroutine("UpPattern");
            }
        }
    }

    IEnumerator DownPattern()
    {
        for (float x = max_PositionX; x >= min_PositionX; x--)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(squareObject_Down, new Vector2(x, min_PositionY), Quaternion.identity);

            if (x <= min_PositionX)
            {
                yield return new WaitForSeconds(Delay);
                StartCoroutine("UpPattern");
                StopCoroutine("DownPattern");
            }
        }
    }
}
