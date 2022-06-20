using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleporter : MonoBehaviour
{
    public GameObject player;
    public GameObject TeleportToPosition;
    //public List<Transform> TeleportToPositions;
    public bool Locked = true;

    //private ThirdPersonCharacterController playerCharCont;
    private CharacterController playerCharCont;
    
    private void Start()
    {
        playerCharCont = player.GetComponent<CharacterController>();
    }


    public void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player" && !Locked){
            playerCharCont.enabled = false;
            collision.gameObject.transform.position = TeleportToPosition.transform.position;
            playerCharCont.enabled = true;
        }
    }
}
