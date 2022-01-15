using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = Random.Range(1, 5);
        GetComponent<SpriteRenderer>().sortingOrder = Random.Range(-1, 1);
        Debug.Log(speed);
    }

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x > 1.2f)
            Destroy(gameObject);

        transform.Translate(new Vector3(50 * speed * Time.deltaTime, 0, 0));
    }
}
