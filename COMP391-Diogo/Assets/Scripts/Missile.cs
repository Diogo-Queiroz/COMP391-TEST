using System;
using Unity.Mathematics;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float lifeTime;
    public float force;
    public GameObject explosion;
    
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force), 
            ForceMode2D.Impulse);
        Destroy(gameObject, lifeTime);
    }

    void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
