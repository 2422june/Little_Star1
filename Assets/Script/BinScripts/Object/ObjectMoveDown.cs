using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveDown : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        transform.position = new Vector2(transform.position.x,transform.position.y -1 * Speed * Time.deltaTime);
        if (this.transform.position.y <= -5.8f)
            Destroy(this.gameObject);
    }
}
