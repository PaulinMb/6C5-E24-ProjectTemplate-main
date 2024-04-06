using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    private float amplitude = .1f;
    private float speed = .1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x += Mathf.Sin(Time.time * speed) * amplitude;
        //position.x += Mathf.Cos(Time.time * speed) * amplitude;
        transform.position = position;
    }
}
