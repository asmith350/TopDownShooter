using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour {

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float destroyTimeLimit;

    public GameObject[] echoObjs;
        
    private Rigidbody2D parentRB;
	// Use this for initialization
	void Start () {
        if (transform.parent != null)
        {
            parentRB = transform.parent.GetComponent<Rigidbody2D>();            
        }
        else {
            Debug.Log("No parent");
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        if (parentRB != null) {
            if (parentRB.velocity.magnitude <= 0) { return; }
        }        

        if (timeBtwSpawns <= 0) {
            // spawn echo game objects
            int rand = Random.Range(0, echoObjs.Length);
            GameObject instance = (GameObject)Instantiate(echoObjs[rand], transform.position, transform.rotation);
            Destroy(instance, destroyTimeLimit);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else {
            timeBtwSpawns -= Time.deltaTime;
        }


	}
}
