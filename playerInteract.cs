using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerInteract : MonoBehaviour
{
private void Update()
    {
        //Grabs code from Dialogue code
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out Dialogue Dialogue))
                {
                    Debug.Log("E BUTTON WORKS");
                    Dialogue.interact();

                }
                }
            }
        }
    }

