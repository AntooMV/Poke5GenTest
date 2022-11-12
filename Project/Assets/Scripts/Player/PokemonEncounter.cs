using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonEncounter : MonoBehaviour
{
    public Collider2D grass;
    public bool axis, rng, isgrass;
    private void Update()
    {

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider == grass)
        {
            isgrass = true;
            if (Input.GetAxisRaw("Horizontal") + Input.GetAxisRaw("Vertical") != 0 &&
                Random.value >= 0.8) Debug.Log("KEK");
        }

    }
}
