using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cawotte.Toolbox;
using UnityEngine.InputSystem;

public class DialogueManager : Singleton<DialogueManager>
{
    public GameObject dialogueBox;
    public Conversation[] conversations;

    public Conversation introConversation;
    public int index = 0;

    private Conversation selectedConversation;
    private bool waitForButton = false;
    private bool testEndOfDialogue = true;

    private Controls playerControls;
    private bool introMode;
    private bool running;
    private void Awake()
    {
        playerControls = new Controls();
    }

    public void ShowIntro()
    {
        testEndOfDialogue = false;
        introMode = true;
        waitForButton = false;
        running = true;
        //Selects a conversation at random
        selectedConversation = introConversation;
        dialogueBox.GetComponent<DialogueUI>().SetupWithConversation(selectedConversation);
        
        index = 0;
        AdvanceDialogue();
        dialogueBox.SetActive(true);
        playerControls.GameControls.Disable();
        playerControls.UiControls.Enable();
        playerControls.UiControls.SkipDialogue.performed += OnSkipDialogue;
        playerControls.UiControls.AdvanceDialogue.performed += OnAdvanceDialogue;

        GameManager.Instance.Cursor.gameObject.SetActive(false);
    }

    public void InitializeAndShow()
    {
        Debug.Log("Starting Dialogue");
        testEndOfDialogue = false;
        introMode = false;
        waitForButton = false;
        running = true;
        //Selects a conversation at random
        selectedConversation = conversations[UnityEngine.Random.Range(0, conversations.Length - 1)];
        dialogueBox.GetComponent<DialogueUI>().SetupWithConversation(selectedConversation);
        index = 0;
        
        AdvanceDialogue();
        dialogueBox.SetActive(true);
        playerControls.GameControls.Disable();
        playerControls.UiControls.Enable();

        GameManager.Instance.Cursor.gameObject.SetActive(false);
    }

    public void EndDialogue()
    {
        if(introMode)
        {
            GameManager.Instance.EndIntro();
        }
        else
        {
            GameManager.Instance.EndDialogue();
        }

        running = false;
        dialogueBox.SetActive(false);
        testEndOfDialogue = true;
        waitForButton = false;
        playerControls.UiControls.Enable();
        playerControls.GameControls.Enable();

        GameManager.Instance.Cursor.gameObject.SetActive(true);
    }

    private void OnSkipDialogue(InputAction.CallbackContext ctx)
    {
        if(running)
        {
            SkipDialogue();
        }
    }
    private void SkipDialogue()
    {
        EndDialogue();
    }

    private void OnAdvanceDialogue(InputAction.CallbackContext ctx)
    {
        if (!waitForButton && !testEndOfDialogue && running)
        {
            AdvanceDialogue();
        }
    }

    public void AdvanceDialogue()
    {
        if (index >= selectedConversation.elementsQueue.Length)
        {
            EndDialogue();
            Debug.Log("Fin");
            return;
        }

        if (selectedConversation.elementsQueue[index] is LineWithCharacter)
        {
            Debug.Log("J'affiche : " + index);
            waitForButton = false;
            LineWithCharacter toDisplay = selectedConversation.elementsQueue[index] as LineWithCharacter;
            Debug.Log(toDisplay);
            dialogueBox.GetComponent<DialogueUI>().ShowLineWithCharacter(toDisplay);
            index++;
            return;
        }

       
        if (selectedConversation.elementsQueue[index] is Line)
        {
            Debug.Log("J'affiche : "+index);
            waitForButton = false;
            Line toDisplay = selectedConversation.elementsQueue[index] as Line;
            Debug.Log(toDisplay);
            dialogueBox.GetComponent<DialogueUI>().ShowLine(toDisplay);
            index++;
            return;
        }

        if (selectedConversation.elementsQueue[index] is QuestionWithCharacter)
        {
            waitForButton = true;
            playerControls.UiControls.Disable();
            QuestionWithCharacter toDisplay = selectedConversation.elementsQueue[index] as QuestionWithCharacter;
            dialogueBox.GetComponent<DialogueUI>().ShowQuestionWithCharacter(toDisplay);
            index++;
            return;
        }

        if (selectedConversation.elementsQueue[index] is Question)
        {
            waitForButton = true;
            Question toDisplay = selectedConversation.elementsQueue[index] as Question;
            playerControls.UiControls.Disable();
            dialogueBox.GetComponent<DialogueUI>().ShowQuestion(toDisplay);
            index++;
            return;
        }
    }

    public void ListenChoice(Choice choosed)
    {
        GameManager.Instance.ProcessChoice(choosed);
        waitForButton = false;

        if(choosed.followUpConversation != null)
        {
            selectedConversation = choosed.followUpConversation;
            index = 0;
            dialogueBox.GetComponent<DialogueUI>().SetupWithConversation(choosed.followUpConversation);
        }

        playerControls.UiControls.Enable();

        AdvanceDialogue();
    }

    /*
    public void Update()
    {
        if(Input.GetKeyDown("space") && !waitForButton && !testEndOfDialogue)
        {
           AdvanceDialogue();
        }
    }
    */
}
