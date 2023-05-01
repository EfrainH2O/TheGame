using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    public CharacterController2D mCharacterController2D;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            mCharacterController2D.PseudoDeath();
        }
    }
}
