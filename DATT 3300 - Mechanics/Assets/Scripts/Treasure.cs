using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Treasure : MonoBehaviour
{
    public Enemy enemy;
    public static int treasure = 0;
    public Text treasureText;
    public AudioSource audio;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && other.tag == "Player")
        {
            treasure++;
            Debug.Log(treasure);
            Destroy(gameObject);
            enemy.AddTreasureSpeed();
            treasureText.text = treasure.ToString();
            audio.Play();
        if (treasure == 6)
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        }  
    }
}
