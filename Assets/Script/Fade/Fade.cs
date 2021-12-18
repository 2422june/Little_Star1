using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public GameObject whiteFadeBase;
    public GameObject darkFadeBase;

    Image whiteFade;
    Image darkFade;
    #region SetSingleTon
    public static Fade i = null;

    void Awake()
    {
        if(i == null)
        {
            i = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    float _time, _timer;
    bool isFade, fadeIn;
    Color _color;

    // Start is called before the first frame update
    void Start()
    {
        whiteFadeBase = GameObject.Find("WhiteFade");
        whiteFadeBase.SetActive(false);

        darkFadeBase = GameObject.Find("DarkFade");
        darkFadeBase.SetActive(false);
        darkFade = darkFadeBase.GetComponent<Image>();
        darkFade.color = new Color(1, 0, 0, 0.5f);

        _time = _timer = 0;
        isFade = fadeIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFade)
        {
            if (fadeIn)
            {
                _timer += (1.0f / _time) * Time.deltaTime;
                if(_timer >= 1)
                {
                    _timer = 1;
                    fadeIn = false;
                }
            }
            else
            {
                _timer -= (1.0f / _time) * Time.deltaTime;
                if (_timer <= 0)
                {
                    _timer = 0;
                    isFade = false;
                    whiteFadeBase.SetActive(false);
                }
            }

            _color = new Color(1, 1, 1, _timer);
            whiteFade.color = _color;
        }
    }

    public void OnFade(float time)
    {
        if (!isFade)
        {
            whiteFadeBase.SetActive(true);
            whiteFade = whiteFadeBase.GetComponentInChildren<Image>();
            whiteFade.color = _color = new Color(1, 1, 1, 0);
            _time = time;
            _timer = 0;
            fadeIn = isFade = true;
        }
    }

    public void SetDark()
    {
        darkFadeBase.SetActive(true);
        darkFade = darkFadeBase.GetComponent<Image>();
        darkFade.color = new Color(1, 0, 0, 0.5f);
        Invoke("OutDark", 0.3f);
    }

    public void OutDark()
    {
        //darkFade.color = new Color(0, 0, 0, 0);
        darkFadeBase.SetActive(false);
    }

    public void OutFade(float time)
    {
        if (isFade)
        {
            _time = time;
            _timer = 1;
            fadeIn = false;
        }
    }
}
