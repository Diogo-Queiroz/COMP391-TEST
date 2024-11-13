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
    [SerializeField] private float pitchVariation = 0.07f;
    [SerializeField] private float missileCooldown = 0.8f;
    private float missileTimer = 0f;
    
	void Start()
    {
		GameManager.Instance.UpdateHealthUI(health);
        newVelocity = new Vector2(0f, 0f);
        missileSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameManager.Instance.GameIsPaused) { return; }

        HandleMovement();
        HandleAttack();
    }

    private void HandleMovement()
    {
        horizontalInput =  Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        newVelocity.x = horizontalInput;
        newVelocity.y = verticalInput;

        GetComponent<Rigidbody2D>().velocity = newVelocity * speed;
    }

    private void HandleAttack()
    {
        missileTimer += Time.deltaTime;
        bool fireMissile = Input.GetButtonDown("Fire1");
        if (fireMissile && missileTimer > missileCooldown)
        {
            missileTimer = 0f;
            // create a copy of the missile gameobject
            Instantiate(missile, 
                new Vector3(transform.position.x, transform.position.y + 1f, 0f),
                Quaternion.identity);
            missileSource.pitch = Random.Range(1f - pitchVariation, 1f + pitchVariation);
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
