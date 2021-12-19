using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject prefab;
    public Text arrowText;
    public GameObject projectile;
    public Transform playerRotate;
    public ParticleSystem particles;

    void Start()
    {
        prefab = Resources.Load("Arrow") as GameObject;
        
    }

    
     IEnumerator DestroyArrow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            yield return new WaitForSeconds(2);
            Destroy(projectile);
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            Destroy(projectile);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(Arrow.arrows > 0)
            {
                projectile = Instantiate(prefab, playerRotate.transform.position, playerRotate.transform.rotation) as GameObject;
                projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.velocity = Camera.main.transform.forward * 50;
                Arrow.arrows--;
                particles.Play();
                arrowText.text = Arrow.arrows.ToString();
                StartCoroutine(DestroyArrow());

            }
            
            
        }
    }
}
