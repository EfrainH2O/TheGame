using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    #region variables
    GameObject Player;
    CharacterController2D mCharacterController2D;
    
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    private bool isPlayerInRange;
    private bool dialogueRunning;
    private int lineIndex;
    #endregion

    #region main
    // Start is called before the first frame update
    void Start() {
        Player = GameObject.Find("DrawCharacter");  
        mCharacterController2D = Player.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //si esta cerca del npc y pica e empezar el dialogo
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.E)){
            if(!dialogueRunning){
                startDialogue();
            }
            //si acabo de escribir la linea y le pica e pasa a la siguiente
            else if(dialogueText.text == dialogueLines[lineIndex]){
            nextLine();
            }
            //si le pica a la e se adelanta la linea para los desesperados que no quieren leer
            else{
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }
    #endregion

    #region  dialogue show
    private void startDialogue(){
        dialogueRunning = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f; //parar la escala de tiempo para que no se pueda mover el personaje
        StartCoroutine(showLine());
    }

    private void nextLine(){
        lineIndex++;
        if(lineIndex < dialogueLines.Length){
            StartCoroutine(showLine());
        }
        else{
            dialogueRunning = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            mCharacterController2D.HealDamage((int)mCharacterController2D.Maxlife); //curar al jugador
            Time.timeScale = 1f; //regresar el tiempo para habilitar el movimiento
        }
    }

    //mostar el texto caracter por caracter
    private IEnumerator showLine(){
        //crar una string vacia
        dialogueText.text = string.Empty;

        //anadir un caracter a la vez a esa string esperando cierto tiempo
        foreach(char ch in dialogueLines[lineIndex]){
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
    #endregion

    #region character detection
    //mostrar signo de que puede interactuar si esta cerca del npc
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    //quitar signo de que puede interactuar si se aleja del npc
    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){    
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
    #endregion
}
