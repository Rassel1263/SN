using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    enum Type
    {
        In,
        Out,
    }


    [SerializeField]
    Type fadeType;

    void Start()
    {
        if (fadeType == Type.Out)
        {
            GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }

    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public IEnumerator FadeOut(int _sceneNumber)
    {
        float a = 0.0f;

        while(a < 1.0f)
        {
            a += 0.01f;
            GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, a);
            yield return null;
        }

        SceneManager.LoadScene(_sceneNumber);
    }
}
