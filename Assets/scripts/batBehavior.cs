using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batBehavior : MonoBehaviour
{
    public GameObject pathStart;
    public GameObject pathEnd;
    public int speed;
    private Vector3 startPosition;
    private Vector3 endPosition;
    [SerializeField] private Transform enemy;
    private Vector2 initScale;

    void Start()
    {
        startPosition = pathStart.transform.position;
        endPosition = pathEnd.transform.position;
        StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
        initScale = enemy.localScale;
    }

    void Update()
    {
        if (transform.position == endPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
            enemy.localScale = new Vector2(initScale.x * -1, initScale.y);
        }
        if (transform.position == startPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
            enemy.localScale = new Vector2(initScale.x * 1, initScale.y);
        }
    }

    IEnumerator Vector3LerpCoroutine(GameObject obj, Vector3 target, float speed)
    {
        Vector3 startPosition = obj.transform.position;
        float time = 0f;

        while (obj.transform.position != target)
        {
            obj.transform.position = Vector3.Lerp(startPosition, target, (time / Vector3.Distance(startPosition, target)) * speed);
            time += Time.deltaTime;
            yield return null;
        }
    }

}
