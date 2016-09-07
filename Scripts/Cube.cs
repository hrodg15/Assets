using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
    public float speed = 15f;
    public GameObject robot;
    private Vector3 offset;

    void Start()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
        offset = new Vector3(0, 1, 0);
    }

    void LateUpdate()
    {
        transform.position = robot.transform.position + offset;
    }


}

