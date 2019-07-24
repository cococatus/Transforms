using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversion : MonoBehaviour
{
    private Vector3 point;
    private Vector3 vector;
    private Vector3 direction;

    void Start()
    {
        //transform.position = new Vector3(2f, 0f, 0f);
        //transform.localScale = new Vector3(1f, 1f, 1f);
    }

    void Update()
    {
        point = transform.TransformPoint(Vector3.forward*3);
        vector = transform.TransformVector(Vector3.forward*3);
        direction = transform.TransformDirection(Vector3.forward*3);

        Debug.DrawLine(transform.parent.localPosition + Vector3.up, point+Vector3.up, Color.magenta);
        Debug.DrawLine(transform.position, point+Vector3.down, Color.cyan);
        Debug.DrawLine(transform.position, point+Vector3.left, Color.green);
        Debug.DrawLine(transform.position, point+Vector3.right, Color.red);
        Debug.DrawLine(transform.position, point+Vector3.forward, Color.white);
        Debug.DrawLine(transform.position, point+Vector3.back, Color.black);
        Debug.DrawLine(transform.position=Vector3.up*0.5f, transform.parent.position+Vector3.up*0.5f, Color.yellow);

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Debug.DrawLine(new Vector3(-i, 0, -j), new Vector3(-j, 0, -i), Color.blue);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(point, 0.1f);
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(vector, 0.1f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(direction, 0.1f);
    }
}
