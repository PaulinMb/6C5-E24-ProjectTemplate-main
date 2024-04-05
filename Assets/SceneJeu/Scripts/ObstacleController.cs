using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public float amplitude = .1f;
    public float speed = .1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.z += Mathf.Sin(Time.time * speed) * amplitude;
        //position.x += Mathf.Cos(Time.time * speed) * amplitude;
        transform.position = position;
    }
}
