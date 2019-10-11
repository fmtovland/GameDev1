using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int enemyCount=5;
    public float diameter=7;
    public GameObject[] enemys;
    public GameObject enemyType;

    System.Collections.IEnumerator spawn() {
        for(int i=0; true; i=(i+1)%enemyCount) {
            if(enemys[i] == null) {
                float x = Random.value * diameter - (diameter/2);
                float z = Random.value * diameter - (diameter/2);
                float angle = Random.value * 360;
                enemys[i] = Instantiate(enemyType, new Vector3(x,5,z), new Quaternion(0,0,angle,0));

                yield return new WaitForSeconds(1);
            }

            else {
                yield return new WaitForEndOfFrame();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemys = new GameObject[enemyCount];
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
