using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awan : MonoBehaviour
{
    public float kecepatanMinimal, kecepatanMaximal;
    

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(Vector3.right * Random.Range(kecepatanMinimal, kecepatanMaximal) * Time.deltaTime);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
