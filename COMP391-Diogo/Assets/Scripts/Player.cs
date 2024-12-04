using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed;
    private Vector2 newVelocity;
    public GameObject missile, explosion;
    private bool fireMissile = false;
    public int health = 5;
    [SerializeField] private AudioClip missileSound;
    [SerializeField] private AudioSource missileSource;
    [SerializeField] private float pitchVariation = 0.07f;
    [SerializeField] private float missileCooldown = 0.8f;
    private float missileTimer = 0f;
    
    private Rigidbody2D rb;
    private PlayerInputs inputs;

    private void Awake()
    {
        inputs = new PlayerInputs();
        inputs.Player.Move.performed += context => newVelocity = context.ReadValue<Vector2>();
        inputs.Player.Move.canceled += _ => newVelocity = Vector2.zero;
        inputs.Player.Fire.started += _ => fireMissile = true;
        inputs.Player.Fire.canceled += _ => fireMissile = false;
    }
    private void OnEnable() => inputs.Enable();
    private void OnDisable() => inputs.Disable();

    void Start()
    {
		GameManager.Instance.UpdateHealthUI(health);
        newVelocity = new Vector2(0f, 0f);
        missileSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.Instance.GameIsPaused) { return; }

        HandleMovement();
        HandleAttack();
    }

    private void HandleMovement()
    {
        rb.velocity = newVelocity * speed;
    }

    private void HandleAttack()
    {
        missileTimer += Time.deltaTime;
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
