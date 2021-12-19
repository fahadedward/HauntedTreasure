using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent enemy;
    public AudioSource audio;
    int health = 6;
    public Transform healthBar;
    private void Start()
    {
        Debug.Log("Game Started");
        audio = GetComponent<AudioSource>();
        
    }
    void Update()
    {
        enemy.SetDestination(player.position);
        FaceTarget();
        ScarySound();
        
        
    }

   
    public void AddArrowSpeed()
    {
        if (Arrow.arrows > 0 || Arrow.arrows < 6)
        {
            enemy.speed += 2;
        }
    }
    public void AddTreasureSpeed()
    {
        
        if (Treasure.treasure > 0 || Treasure.treasure < 6)
        {
            enemy.speed += 3;
        }
    }
    
    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion rotate = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime);
    }

    private void ScarySound()
    {
        Vector3 distance = (player.position - transform.position);
        
        float length = distance.magnitude;
        Debug.Log(length);
        if(length > 70)
        {
            audio.Play();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
            if(collision.collider.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
            if(collision.collider.tag == "Arrow")
        {
            health -= 1;
            Debug.Log("Ouch");
            enemy.speed -= 1;
            healthBar.localScale -= new Vector3(1, 0, 0);  

        }
        if (health == 0)
        {
            Destroy(gameObject);
        }

    }
}
    
       

