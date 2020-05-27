using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public GameObject characterName;
    public GameObject lineBox;
    public GameObject questionBox;
    public Image characterSprite;

    private Conversation conversation;

    public void ShowLine(Line line)
    {
        characterSprite.sprite = conversation.characterSprite;
        characterName.GetComponent<TextMeshProUGUI>().text = conversation.characterName;
        questionBox.SetActive(false);
        lineBox.GetComponent<TextMeshProUGUI>().text = line.text;
        lineBox.SetActive(true);
    }

    public void ShowLineWithCharacter(LineWithCharacter lineWithCharacter)
    {
        characterSprite.sprite = lineWithCharacter.characterSprite;
        characterName.GetComponent<TextMeshProUGUI>().text = lineWithCharacter.characterName;
        questionBox.SetActive(false);
        lineBox.GetComponent<TextMeshProUGUI>().text = lineWithCharacter.text;
        lineBox.SetActive(true);
    }

    public void ShowQuestionWithCharacter(QuestionWithCharacter question)
    {
        characterSprite.sprite = question.characterSprite;
        characterName.GetComponent<TextMeshProUGUI>().text = question.characterName;
        lineBox.SetActive(false);
        questionBox.SetActive(true);
        questionBox.GetComponent<QuestionUI>().Show(question);
    }

    public void ShowQuestion(Question question)
    {
        characterSprite.sprite = conversation.characterSprite;
        characterName.GetComponent<TextMeshProUGUI>().text = conversation.characterName;
        lineBox.SetActive(false);
        questionBox.SetActive(true);
        questionBox.GetComponent<QuestionUI>().Show(question);
    }

    public void SetupWithConversation(Conversation conv)
    {
        conversation = conv;
    }
}
