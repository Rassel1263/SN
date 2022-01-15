using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField]
    Text text;

    float destColor = 1.0f;
    float startTime = 2.0f;

    bool drawFont = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (startTime <= 0.0f )
        {
            if (!drawFont)
            {
                drawFont = true;

                text.gameObject.SetActive(true);
                text.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                StartCoroutine(Blink());
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    Fade fade = GameObject.Find("Fade").GetComponent<Fade>();
                    fade.StartCoroutine(fade.FadeOut(1));
                }
            }
        }
        else
        {
            startTime -= Time.deltaTime;
        }

        transform.position = Vector2.Lerp(transform.position, new Vector2(0, 0), 0.05f);
    }

    IEnumerator DrawStart()
    {
        float a = 0.0f;

        while (a < 1.0f)
        {
            a += Time.deltaTime;
            text.color = new Color(0, 0, 0, a);

            yield return null;
        }

        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            if (text.color.a >= 1.0f || text.color.a <= 0.0f)
            {
                destColor = -destColor;
                Mathf.Clamp(destColor, 0, 1);
            }

            text.color += new Color(0, 0, 0, Time.deltaTime * destColor);

            yield return null;
        }
    }
}
