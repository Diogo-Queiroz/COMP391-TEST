using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Range(-4, 4)]
    public float minValue, maxValue;
    public int health = 5, scoreOnHit = 2, scoreOnDestroy = 6;
    Vector2 inDirection;
    
    void Start()
    {
        float x = Random.Range(minValue, maxValue);
        float y = Random.Range(minValue, maxValue);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y), 
            ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Missile"))
        {
            Destroy(other.gameObject);
            // Decrease the health of the asteroid
            DecreaseHealth();
			GameManager.Instance.ChangeScore(scoreOnHit);
        }
        else
        {
            WallCollision(other);            
        }
    }

    void FixedUpdate()
    {
        inDirection = GetComponent<Rigidbody2D>().velocity;        
    }

    void WallCollision(Collision2D other)
    {
        Vector2 inNormal = other.GetContact(0).normal;
        Vector2 result = Vector2.Reflect(inDirection, inNormal);
        GetComponent<Rigidbody2D>().velocity = result;
    }

    void DecreaseHealth()
    {
        health--;
        if (health <= 0)
        {
            // Destroy the asteroid
			GameManager.Instance.ChangeScore(scoreOnDestroy);
            GameManager.Instance.AsteroidDestroyed();
            Destroy(gameObject);
        }
    }
}
