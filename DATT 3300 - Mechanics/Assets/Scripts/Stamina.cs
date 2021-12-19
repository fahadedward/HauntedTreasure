using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stamina : MonoBehaviour
{
    public float stamina = 5f;
    public float maxStamina = 5f;
    public float walkSpeed;
    public float runningSpeed;
    public bool isRunning;
    public Slider staminaBar;
    public AudioSource audio;


    PlayerMovement player;
    void Start()
    {
        player = gameObject.GetComponent<PlayerMovement>();
        walkSpeed = player.walkSpeed;
        runningSpeed = player.runningSpeed;
        staminaBar.value = maxStamina;
        staminaBar.maxValue = maxStamina;
        audio = GetComponent<AudioSource>();
       
    }
    public void SetRunning(bool isRunning)
    {
        this.isRunning = isRunning;
        if (isRunning)
        {
            player.walkSpeed = runningSpeed;
            
        } else
        {
            player.walkSpeed = walkSpeed;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetRunning(true);
            audio.Play();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SetRunning(false);
            audio.Stop();
        }
        if (isRunning)
        {
            stamina -= Time.deltaTime;
            staminaBar.value = stamina;
            
            Debug.Log(stamina);
            if (stamina < 0)
            {
                stamina = 0;
                SetRunning(false);
                audio.Stop();
            }
        }
        else if (stamina < maxStamina)
        {
            stamina += Time.deltaTime;
            staminaBar.value = stamina;
            Debug.Log(stamina);
        }

    }
}

