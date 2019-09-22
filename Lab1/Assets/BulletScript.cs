using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float existed4;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed=Input.GetAxis("Vertical");
	if (speed<.1) speed=1;
        else speed = speed*2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10 * speed);
        transform.Rotate(0,0,30 * Time.deltaTime);
        existed4 += Time.deltaTime;

        if(existed4 > 3f)
        {
	    Destroy(gameObject);
        }
    }
}
