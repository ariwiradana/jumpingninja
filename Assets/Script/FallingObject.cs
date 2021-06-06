using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float kecepatanMinimal, kecepatanMaximal;

    // Update is called once per frame
    void Update(){
        transform.Translate(Vector3.down * Random.Range(kecepatanMinimal, kecepatanMaximal) * Time.deltaTime);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
