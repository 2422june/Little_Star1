using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    [SerializeField]
    GameObject Field;

    public Vector2 _pos, _scale;
    public bool isOnField = false, isOnWave = false, isCallOnWave = false;

    bool isWaveDown = true;

    public float waveTime = 0f;
    public Vector2 val, max, min, now;
    
    public static FieldManager FieldMng;


    private void Awake()
    {
        if (FieldMng == null)
        {
            FieldMng = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (isCallOnWave)
        {
            isOnWave = true;
        }

        if (isOnWave)
        {

        }
        #region
        /*if (isCallOnWave || !isOnWave)
        {
            if(isWaveDown)
            {
                now.x -= val.x / waveTime;
                now.y -= val.y / waveTime;

                Field.transform.localScale = now;

                if (now.x <= min.x && now.y <= min.y)
                {
                    isWaveDown = false;
                }
            }
            else
            {
                now.x += val.x / waveTime;
                now.y += val.y / waveTime;

                Field.transform.localScale = now;

                if (now.x >= max.x && now.y >= max.y)
                {
                    isWaveDown = true;
                }
            }
        }
        else
        {
            if (nowBigThanValX)
            {
                if (now.x <= max.x)
                {
                    now.x += val.x / waveTime;
                }
            }
            else
            {
                if (now.x >= max.x)
                {
                    now.x += val.x / waveTime;
                }
            }

            if (nowBigThanValY)
            {
                if (now.y <= max.y)
                {
                    now.y += val.y / waveTime;
                }
            }
            else
            {
                if (now.x >= max.x)
                {
                    now.x += val.x / waveTime;
                }
            }
            now.y += val.y / waveTime;

            Field.transform.localScale = now;

            if (now.x >= max.x && now.y >= max.y)
            {
                isWaveDown = true;
            }
        }*/
        #endregion
    }

    public void OnField(bool isOn, Vector2 pos, Vector2 scale)
    {
        isOnField = isOn;
        Field.SetActive(isOnField);
        SetPos(pos);
        SetScale(scale);
    }


    public void OnWave(float time, Vector2 maxScale, Vector2 minScale)
    {
        isCallOnWave = true;
        waveTime = time;
        val = maxScale - minScale;
        max = maxScale;
        min = minScale;
        isWaveDown = true;
        now = Field.transform.localScale;
    }

    public void OffWave(float time, Vector2 scale)
    {
        isOnWave = false;
        waveTime = time;
        now = Field.transform.localScale;
        min = now;
        max = scale;
        val = scale - now;
    }

    public void SetScale(Vector2 scale)
    {
        _scale = scale;
        Field.transform.localScale = _scale;
    }

    public void SetPos(Vector2 pos)
    {
        _pos = pos;
        Field.transform.position = _pos;
    }
}
