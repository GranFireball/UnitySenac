using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
public float speed;
private float max = 4.0f;
private float min = -4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0.0f, 0.0f);
        if(transform.position.x > max || transform.position.x < min)
        {
            speed = -speed;
        }
    }
}
