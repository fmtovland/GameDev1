using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public GameObject bullet;
    public float bulletsPerSecond=5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable() {
        StartCoroutine(shooting());
    }

    //Start in OnEnable, no need to disable
    System.Collections.IEnumerator shooting() {
        while (true) {
            if(Input.GetButton("Fire1")) {
                Instantiate(bullet, transform.position, transform.rotation);
                yield return new WaitForSeconds(1/bulletsPerSecond);
            }

            else {
                yield return new WaitForEndOfFrame();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
