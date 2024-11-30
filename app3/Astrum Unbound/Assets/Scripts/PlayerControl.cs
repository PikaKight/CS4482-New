using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class PlayerControl : MonoBehaviour
{
    public float speed;
    public InputAction moveAction;
    public InputAction pauseAction;
    public int maxHealth;
    public float timeInvincible;
    public int lives = 3;
    
    public int maxMana = 100;
    public int spellCost = 5;
    public bool spell = false;

    public InputAction shootAction;
    public Transform firingPoint;
    public float fireRate = 0.5f;
    public GameObject bullet;
    public int rangedDamage = 3;
    float fireTimer;

    public Animator playerAnimation;
    public TextMeshProUGUI healthStatus;
    public TextMeshProUGUI manaStatus;

    Rigidbody2D rb;
    Vector2 move;
    bool isInvincible;
    float damageCooldown;
    bool isFacingRight = true;
    public float health { get { return currentHealth; } }
    public float mana { get { return currentMana; } }

    float currentHealth = 0;
    float currentMana = 0;

    float orgX;
    float orgY;

    // Start is called before the first frame update
    void Start()
    {
        moveAction.Enable();

        pauseAction.Enable();

        shootAction.Enable();

        rb = GetComponent<Rigidbody2D>();

        changeHealth(maxHealth);
        changeMana(0);

        orgX = gameObject.transform.localPosition.x;
        orgY = gameObject.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        move = moveAction.ReadValue<Vector2>();

        if (move.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move.x < 0 && isFacingRight)
        {
            Flip();

        }


        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown <= 0)
            {
                isInvincible = false;
            }
        }

        
        if (pauseAction.WasPressedThisFrame())
        {
            GameManager.isPaused = !GameManager.isPaused;
            Debug.Log("Pressed: " + GameManager.isPaused);
        }

        if (shootAction.WasPressedThisFrame() && fireTimer <= 0)
        {
            GameObject bullet1 = Instantiate(bullet, firingPoint.position, firingPoint.rotation);

            Ranged b1Data = bullet1.GetComponent<Ranged>();

            b1Data.damage = rangedDamage;

            b1Data.shooter = gameObject.name;

            fireTimer = fireRate;
        }

        if (shootAction.WasPressedThisFrame() && fireTimer <= 0 && spell && currentMana >= spellCost)
        {
            GameObject bullet1 = Instantiate(bullet, firingPoint.position, firingPoint.rotation);

            Ranged b1Data = bullet1.GetComponent<Ranged>();

            b1Data.damage = rangedDamage;

            b1Data.shooter = gameObject.name;

            fireTimer = fireRate;

            changeMana(spellCost * -1);
        }


        fireTimer -= Time.deltaTime;

        if (currentHealth <= 0)
        {
            lives -= 1;
            
            Vector2 position = transform.position;

            position.x = orgX;
            position.y = orgY;
            transform.position = position;

            currentHealth = maxHealth;

            healthStatus.text = currentHealth.ToString() + " HP";

        }
    }

    void FixedUpdate()
    {
        bool isMove = move == new Vector2(0.0f, 0.0f);

        Vector2 position = (Vector2)rb.position + (move * speed * Time.deltaTime);

        if (!isMove)
        {
            playerAnimation.SetTrigger("Walk");
        }
        else
        {
            playerAnimation.SetTrigger("Idle");
        }



        rb.MovePosition(position);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void changeHealth(int health)
    {
        if (health < 0)
        {
            if (isInvincible)
            {
                return;
            }

            isInvincible = true;
            damageCooldown = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + health, 0, maxHealth);
        healthStatus.text = $"Health: {currentHealth} HP";
    }

    public void changeMana(int manaGain)
    {

        currentMana = Mathf.Clamp(currentMana + manaGain, 0, maxMana);
        manaStatus.text = $"Mana: {currentMana} MP";
    }
}
