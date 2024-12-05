using UnityEngine;
using UnityEngine.InputSystem;

public class Melee : Collidable
{
    public int damagePoint = 2;
    public float pushForce = 2.0f;

    public Transform attackPoint;

    public InputAction attackAction;
    public Animator attackAnimation;

    public bool isEnemy = false;

    float cooldown = 0.01f;
    float lastSwing;

    bool isAttack = false;

    protected override void Start()
    {
        base.Start();

        if (!isEnemy)
        {
            attackAction.Enable();
        }

        
        lastSwing = 0.0f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        

        if (attackAction.WasPressedThisFrame() && (Time.time - lastSwing > cooldown) && !isAttack && !isEnemy) {
            
            StartAttack();
        }

        else
        {
            EndAttack();
        }
               
    }

    void StartAttack()
    {
        isAttack = true;
        lastSwing = Time.time;

        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;

        attackAnimation.SetBool("isAttack", true);
        attackAnimation.SetTrigger("Attack");

        float animationLength = GetAnimationLength("melee");
        Invoke(nameof(EndAttack), animationLength);
    }

    void EndAttack()
    {
        isAttack = false;

        // Disable attack collider
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

        // Reset animation states
        attackAnimation.SetBool("isAttack", false);
    }

    float GetAnimationLength(string animationName)
    {
        // Get the animation length dynamically
        foreach (AnimationClip clip in attackAnimation.runtimeAnimatorController.animationClips)
        {
            if (clip.name == animationName)
            {
                return clip.length;
            }
        }
        Debug.LogWarning($"Animation '{animationName}' not found!");
        
        return 0.3f; // Default fallback duration
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            Debug.Log("Attacked: " + coll.name);

            EnemyController enemy = coll.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.changeHealth(damagePoint * -1);
            }

        }
    }
}
