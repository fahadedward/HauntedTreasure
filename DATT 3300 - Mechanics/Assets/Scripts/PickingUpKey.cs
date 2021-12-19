using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpKey : MonoBehaviour
{
    public Component doorCollider;

    void Start()
    {
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            doorCollider.GetComponent<BoxCollider>().enabled = true;
            Destroy(gameObject);
          
        }
           
        }
    }
