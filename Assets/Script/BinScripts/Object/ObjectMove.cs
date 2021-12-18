using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime, Space.Self);
        if(this.transform.position.x <= -10)
            Destroy(this.gameObject);
    }

}
