using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatafomrs : MonoBehaviour
{
    public Transform[] tarjet;
    public float speed;

    int curPos = 0;
    int nextPos = 1;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, tarjet[nextPos].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, tarjet[nextPos].position) <= 0)
        {
            curPos = nextPos;
            nextPos++;

            if (nextPos > tarjet.Length - 1)
            {
                nextPos = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
