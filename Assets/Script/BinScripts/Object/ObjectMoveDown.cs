using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveDown : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime, Space.Self);
        if (this.transform.position.y <= -5.8f)
            Destroy(this.gameObject);
    }
}
