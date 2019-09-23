using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject brick;

    // Start is called before the first frame update
    void Start()
    {
	for(int i=0; i<10; i++){
            for(int j=0; j<10; j++){
                Instantiate(brick, new Vector3(i,j+.5f,3), new Quaternion());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
