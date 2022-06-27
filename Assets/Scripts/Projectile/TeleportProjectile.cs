using System;
using UnityEngine;

public class TeleportProjectile : MonoBehaviour 
{
    
    public GameObject player;
    private CharacterController playerCharCont;
    
    private void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
            playerCharCont = player.GetComponent<CharacterController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag == "Feet")
        {
            playerCharCont.enabled = false;
            player.transform.position = this.gameObject.transform.position;
            playerCharCont.enabled = true;
        }
    }
}