using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTank : MonoBehaviour
{
    public int deathDelay=10;
    public int deathEpicness=3;

    System.Collections.IEnumerator ecksplode() {
        transform.Translate(new Vector3(0,deathEpicness,0));
        yield return new WaitForSeconds(deathDelay);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other) {
        if(other.name.Equals("Bullet")){
            Destroy(other.gameObject);
            StartCoroutine(ecksplode());
        }
    }
}
