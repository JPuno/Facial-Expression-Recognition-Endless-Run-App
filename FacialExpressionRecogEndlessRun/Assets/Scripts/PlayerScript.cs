using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    
    private CharacterController _controller;
    public bool isbutton;
    public bool isdead;
    public float _speed;
    public float time;
    public float _jumpHeight;
    [SerializeField]
    private float _gravity=1f;
    private float yvelocity = 0.0f;
    public Animator animator;
    private PlayerEmotions playerEmotions;
    public Image staminabar;
    public float stamina;
    public float StartStamina;
    public float staminapersecond;
    bool isground;
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        playerEmotions = GetComponent<PlayerEmotions>();
        stamina = StartStamina;
    }

    void Update()
    {
        Player();
        Stamina();
        
       
    }
    //player controls and physics
   void Player()
    {
        Vector3 direction = new Vector3(1, 0, 0);
        Speedup();
        Vector3 velocity = direction * _speed;
        animator.SetFloat("Speed", _speed);
        float dominantEmotion = Mathf.Max(playerEmotions.currentJoy, playerEmotions.currentSurprise);
        if (!isdead)
        {
            if (_controller.isGrounded == true)
            {
                if (!isbutton)
                {
                    if (Input.GetKey(KeyCode.LeftAlt) || playerEmotions.currentSurprise > 50)
                    {
                        _controller.radius = 0.4f;
                        animator.SetBool("IsCrouching", true);

                    }
                    else
                    {

                        _controller.radius = 0.5f;
                        animator.SetBool("IsCrouching", false);
                    }
                }


                if (Input.GetKeyDown(KeyCode.Space) && !isbutton || playerEmotions.currentJoy > 50 && !isbutton)
                {
                    yvelocity = _jumpHeight;
                    animator.SetBool("IsJumping", true);
                }
                else
                {
                    
                    animator.SetBool("IsJumping", false);
                }


            }
            else
            {
                yvelocity -= _gravity;
            }
        }
        velocity.y = yvelocity;
        _controller.Move(velocity * Time.deltaTime);
        
    }
    //DDA 10 seconds changes
    void Speedup()
    {
        if (!isdead)
        {
            if (time <= 0)
            {
                _speed += .1f;
                time = 10f;
            }

            time -= Time.deltaTime;
            time = Mathf.Clamp(time, 0f, Mathf.Infinity);
        }
    }
    // if you run out of stamina you are dead
    void Stamina()
    {
        GameManager GM = FindObjectOfType<GameManager>();
        if (!isdead)
        {
            stamina -= staminapersecond * Time.deltaTime;
            staminabar.fillAmount = stamina / StartStamina;
        }
        if (stamina <= 0)
        {
            GM.isdead = true;
        }
    }
   public void CheatControlJump()
    {
       
        if (!isdead)
        {
            if (_controller.isGrounded == true)
            {
               
                    yvelocity = _jumpHeight;
                    animator.SetBool("IsJumping", true);
               
            }
            else
            {
                yvelocity -= _gravity;
                animator.SetBool("IsJumping", false);
            }


        }
        
    }
    public void enableCheatControlCrouch()
    {
       
        if (!isdead)
        {
            if (_controller.isGrounded == true)
            {
                _controller.radius = 0.4f;
                animator.SetBool("IsCrouching", true);
            }
        }
        
    }
    public void disableCheatControlCrouch()
    {

        if (!isdead)
        {
            if (_controller.isGrounded == true)
            {
                _controller.radius = 0.5f;
                animator.SetBool("IsCrouching", false);
            }
        }

    }
}
