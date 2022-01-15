using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    Sprite[] clouds;

    [SerializeField]
    GameObject cloudPrefab;

    float time;

    void Start()
    {
        time = Random.Range(1, 3);
        StartCoroutine(CloudSystem());
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    IEnumerator CloudSystem()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            time = Random.Range(1, 3);
            GameObject cloud = Instantiate(cloudPrefab);
            cloud.transform.position = new Vector3(-300, Random.Range(-140, 140));
            cloud.GetComponent<SpriteRenderer>().sprite = clouds[Random.Range(0, clouds.Length)];
        }
    }
}
