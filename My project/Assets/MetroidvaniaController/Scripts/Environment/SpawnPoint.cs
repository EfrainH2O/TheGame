using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool Respawn;
    public bool Save;

    public CharacterController2D mCharacterController2D;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D Collider) {
        if (Collider.gameObject.tag == "Player") 
        {
            SetPoint(Respawn, Save);

        }
    }

    private void SetPoint( bool Respa, bool save )
    {
        if (Respa)
        {
            mCharacterController2D.respawnPoint = mCharacterController2D.transform.position;
        }
        if ( save )
        {
            mCharacterController2D.savePoint = mCharacterController2D.transform.position;
        }
    }
}
