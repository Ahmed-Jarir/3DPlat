using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleporter : MonoBehaviour
{
    public GameObject player;
    //public Transform TeleportToPosition;
    public List<Transform> TeleportToPositions;
    public bool Locked = true;

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player" && !Locked){
            foreach(Transform TeleportTo in TeleportToPositions) {
                player.GetComponent<CharacterController>().Move(TeleportTo.position - player.transform.position);
            }
            //player.transform.position = TeleportToPosition.position;
        }
    }
}
