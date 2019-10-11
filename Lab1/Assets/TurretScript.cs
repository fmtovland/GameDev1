using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public GameObject bullet;
    public float bulletsPerSecond;
    float lastShot=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastShot += Time.deltaTime;

        if(Input.GetButton("Fire1") && (lastShot > (1/bulletsPerSecond)))
        {
            GameObject b = Instantiate(bullet, transform.position, transform.rotation);
            lastShot = 0;
        }
    }
}
