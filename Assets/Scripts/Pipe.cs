using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);

        if(transform.position.x < -22){
            Destroy(gameObject);
        }
        
    }

    public void SetSpeed(float newSpeed){
        speed = newSpeed;
    }
}
