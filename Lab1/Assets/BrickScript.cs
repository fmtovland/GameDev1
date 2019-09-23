using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color",new Vector4(Random.value,Random.value,Random.value,Random.value));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Equals("Bullet")){
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
