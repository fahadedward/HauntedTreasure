using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public Enemy enemy;
    public static int arrows = 0;
    public Text arrowText;
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E) && other.tag == "Player")
        {
            arrows++;
            Destroy(gameObject);
            enemy.AddArrowSpeed();
            arrowText.text = arrows.ToString();
        }
    }
}
