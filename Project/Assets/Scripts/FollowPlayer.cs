using System.Collections;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    void FixedUpdate()
    {
        transform.position = player.transform.position + Vector3.back;     
    }
}