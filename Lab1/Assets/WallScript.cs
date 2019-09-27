using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject brick;
    public int width=10;
    public int height=10;

    // Start is called before the first frame update
    void Start()
    {
	for(int i=0; i<width; i++){
            for(float j=.5f; j<height; j++){
                GameObject b = Instantiate(brick, new Vector3(i,j,3), new Quaternion());
                b.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
