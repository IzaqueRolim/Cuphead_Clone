using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    void Start()
    {
        Destroy(this.gameObject,3f);
    }

    
    void Update()
    {
        transform.Translate(new Vector2(Time.deltaTime*5,0));
    }
}
