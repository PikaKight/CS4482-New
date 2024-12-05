
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 2;

    public TextMeshProUGUI healthText;
    public Animator enemyAnimation;

    public float detectionRange = 5f;
    public float stopDistance = 0.5f; // Distance to stop when near player    
    float distance;


    public bool range;
    public GameObject bullet;
    public int rangeDamage = 2;
    public float fireRange = 10f;
    public float firingRate = 0.5f;
    float firingTimer;
    public Transform firingPlace;


    public int maxHealth;
    float currentHealth;

    public float health { get { return currentHealth; } }


    Rigidbody2D rb;
    GameObject player;

    SpriteRenderer enemy;
    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        enemy = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player");

        currentHealth = maxHealth;

        healthText.text = $"{currentHealth}/{maxHealth}";
    }

    private void Update()
    {
        if (currentHealth <= 0) {
            LevelManager.enemies.Remove(gameObject);
            Destroy(gameObject);

        }
        else
        {
            gameObject.SetActive(true);
        }

        if (player != null)
        {
            distance = Vector2.Distance(rb.position, player.transform.position);
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rb.position;

        if (distance <= detectionRange && distance > stopDistance)
        {
            enemyAnimation.SetTrigger("Walk");

            Vector2 direction = ((Vector2)player.transform.position - rb.position).normalized;
            moveDirection = direction;

            if (direction.x > 0)
            {
                enemy.flipX = false; // Face right
            }
            else if (direction.x < 0)
            {
                enemy.flipX = true; // Face left
            }

            rb.velocity = direction * speed;
        }
        
        else if (distance <= fireRange && distance > detectionRange && firingTimer <= 0)
        {
            GameObject bullet1 = Instantiate(bullet, firingPlace.transform.position, firingPlace.transform.rotation);

            Ranged b1Data = bullet1.GetComponent<Ranged>();
            
            b1Data.shooter = gameObject.tag;
            
            b1Data.damage = rangeDamage;

            firingTimer = firingRate;
        }

        else
        {
            enemyAnimation.SetTrigger("Idle");
        }

        firingTimer -= Time.deltaTime;

    }

    public void changeHealth(int health)
    {
        currentHealth = Mathf.Clamp(currentHealth + health, 0, maxHealth);

        healthText.text = $"{currentHealth}/{maxHealth}";
    }


    void OnCollisionEnter2D(Collision2D other)
    {       
        PlayerControl playerCol = other.gameObject.GetComponent<PlayerControl>();

        if (playerCol != null) {
            enemyAnimation.SetTrigger("Attack");
            enemyAnimation.SetBool("isAttack", true);
            playerCol.changeHealth((damage*-1) + playerCol.meleeResistance);
        }

        enemyAnimation.SetBool("isAttack", false);
    }
}
