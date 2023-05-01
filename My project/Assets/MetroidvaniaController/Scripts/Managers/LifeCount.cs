using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 

public class LifeCount : MonoBehaviour
{
   [SerializeField] private CharacterController2D mCharacterController2D;
   [SerializeField] private Image TotalhealthBar;
   [SerializeField] private Image CurrentHealthBar;
   

    void Start() {
        TotalhealthBar.fillAmount = mCharacterController2D.Maxlife/5f;
  
    }
    void Update() {
        CurrentHealthBar.fillAmount = mCharacterController2D.life / 5f;
   
    }
    
}