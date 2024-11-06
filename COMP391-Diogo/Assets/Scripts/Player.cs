using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    public int speed;
    private Vector2 newVelocity;
    public GameObject missile, explosion;
    public int health = 5;
    [SerializeField] private AudioClip missileSound;
    [SerializeField] private AudioSource missileSource;
    
	void Start()
    {
		GameManager.Instance.UpdateHealthUI(health);
        newVelocity = new Vector2(0f, 0f);
        missileSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameManager.Instance.GameIsPaused) { return; }

        horizontalInput =  Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        newVelocity.x = horizontalInput;
        newVelocity.y = verticalInput;

        GetComponent<Rigidbody2D>().velocity = newVelocity * speed;

        bool fireMissile = Input.GetButtonDown("Fire1");
        if (fireMissile)
        {
            // create a copy of the missile gameobject
            Instantiate(missile, 
                new Vector3(transform.position.x, transform.position.y + 1f, 0f),
                Quaternion.identity);
            missileSource.PlayOneShot(missileSound);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            DecreaseHealth();
        }
    }

    void DecreaseHealth()
    {
        health--;
		GameManager.Instance.UpdateHealthUI(health);
        if (health <= 0)
        {
			Instantiate(explosion, transform.position, Quaternion.identity);
            GameManager.Instance.EndGame("Player Died");
            Destroy(gameObject);
        }
    }
}
