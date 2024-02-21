using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float moveSpeed = 5f;

    // Canvas
    public Canvas canvas;
    public Button playAgainButton;

    // Roll
    private float rollBoost = 3f;
    private float rollTime = 0;
    private bool rollOnce = false;
    private bool isDelay = false;
    private float rollDelay = 0f;
    public float RollDelayTime = 2f;
    private readonly float ROLL_TIME = 0.35f;

    private Animator animator;
    private Vector3 moveInput;
    public SpriteRenderer weaponRD;

    public Image stamina;

    // Heal
    public Image healBar;
    public float totalHeal = 100f;
    private float healValue;

    // Hit
    private float HitAnimator = 0.2f;
    private float _hitAnimator = 0f;

    public TilemapCollider2D obstacle;

    void Start()
    {
        healValue = totalHeal;
        animator = GetComponent<Animator>();
        stamina.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Pause game and resume
        pauseAndResume();

        // Player dead
        playerDead();

        // Rotate player
        RotatePlayer();

        // Player move
        playerMove();

        // Player roll
        playerRoll();

        // Hit
        if (_hitAnimator > 0)
        {
            _hitAnimator -= Time.deltaTime;
        } else
        {
            animator.SetBool("IsHit", false);
        }
    }

    private void pauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1f;
        }
    }

    private void playerMove()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        if (moveInput.x != 0)
        {
            if (moveInput.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        animator.SetFloat("Speed", moveInput.sqrMagnitude);
        transform.position += moveInput * moveSpeed * Time.deltaTime;
    }

    private void playerRoll()
    {
        // Roll and roll delay
        if (Input.GetKeyDown(KeyCode.Space) && rollTime <= 0 && rollDelay <= 0)
        {
            moveSpeed += rollBoost;
            rollTime = ROLL_TIME;
            rollTime -= Time.deltaTime;
            rollDelay = RollDelayTime;
            isDelay = true;
            rollOnce = true;
            animator.SetBool("Roll", rollOnce);
            obstacle.isTrigger = true;
        }
        if (rollTime <= 0 && rollOnce == true)
        {
            moveSpeed = 5f;
            rollOnce = false;
            animator.SetBool("Roll", rollOnce);
            obstacle.isTrigger = false;
        }
        else
        {
            rollTime -= Time.deltaTime;
        }
        if (isDelay)
        {
            rollDelay -= Time.deltaTime;
            stamina.fillAmount = (RollDelayTime - Mathf.Abs(rollDelay)) / RollDelayTime;
        }
        if (rollDelay <= 0)
        {
            isDelay = false;
            stamina.fillAmount = 1;
        }
    }

    private void OnFinishDeadAnimation()
    {
        canvas.sortingOrder = 2;
        playAgainButton.onClick.AddListener(() => PlayAgain());
        Time.timeScale = 0f;
    }
    
    private void PlayAgain()
    {
        canvas.sortingOrder = -1;
        Time.timeScale = 1f;
    }

    private void playerDead()
    {
        if (healValue <= 0)
        {
            animator.SetBool("IsDead", true);
        }
    }

    private void RotatePlayer()
    {
        if (weaponRD.transform.eulerAngles.z > 90 && weaponRD.transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void TakeDamage(float damage)
    {
        healValue -= damage;
        if (!rollOnce)
        {
            _hitAnimator = HitAnimator;
            animator.SetBool("IsHit", true);
            healBar.fillAmount = (healValue / totalHeal);
        }
    }
}
