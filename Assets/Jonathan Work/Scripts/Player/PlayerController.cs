using UnityEngine;
using System.Collections;

namespace ClearSky
{
    public class PlayerController : MonoBehaviour
    {
        // Components
        private Rigidbody2D rb;
        private Animator anim;
        public Camera sceneCamera;
        public GameManager gameManager;
        public Transform skeletonParent;

        // Movement
        public float moveSpeed;
        private int direction = 1;
        [HideInInspector]
        public Vector2 moveDir;
        private Vector2 mousePos;
        Vector3 movement;

        // Health
        public int maxHealth = 100;
        private int currentHealth;
        private bool alive = true;

        // Combat
        public GameObject fireballPrefab;
        public Transform firePoint;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            currentHealth = maxHealth;
            Debug.Log("Player starts with " + currentHealth + " health.");
        }

        void Update()
        {
            if (alive)
            {
                HandleInput();
            }
        }

        void FixedUpdate()
        {
            if (alive)
            {
                Run();
            }
        }

        private void HandleInput()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDir = new Vector2(moveX, moveY).normalized;
            mousePos = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    
            if (moveDir != Vector2.zero)
            {
                anim.SetBool("isRun", true);
            }
            else
            {
                anim.SetBool("isRun", false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }
    
        private void Move()
        {
            rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
        }

        private void Attack()
        {
            anim.SetTrigger("attack");
            Vector2 firePointPosition = firePoint.position;
            Vector2 direction = (mousePos - firePointPosition).normalized;

            GameObject fireball = Instantiate(fireballPrefab, firePointPosition, Quaternion.identity);
            fireball.GetComponent<Fireball>().Initialize(direction);
        }

        public void TakeDamage(int amount)
        {
            anim.SetTrigger("hurt");
            currentHealth -= amount;
            Debug.Log("Player took " + amount + " damage, current health: " + currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }
        
        private void Die()
        {
            anim.SetTrigger("die");
            alive = false;
            Debug.Log("Player Died");
            #if UNITY_EDITOR
                gameManager.GameOver();
                UnityEditor.EditorApplication.isPlaying = false;
                gameManager.GameOver();
            #else
                gameManager.GameOver();
                Application.Quit();
                gameManager.GameOver();
            #endif

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                TakeDamage(10); // Example damage value
            }
        }

        public void IncreaseSpeed(float amount)
        {
            moveSpeed += amount;
            Debug.Log("Speed increased to: " + moveSpeed);
        }

        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            bool isRunning = false;

            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            if (moveX != 0)
            {
                direction = moveX < 0 ? -1 : 1;
                moveVelocity.x = moveX;
                transform.localScale = new Vector3(direction * 0.4f, 0.4f, 0.4f);
                isRunning = true;
            }

            if (moveY != 0)
            {
                moveVelocity.y = moveY;
                isRunning = true;
            }

            anim.SetBool("isRun", isRunning);
            transform.position += moveVelocity.normalized * moveSpeed * Time.deltaTime;
        }

    }
}
