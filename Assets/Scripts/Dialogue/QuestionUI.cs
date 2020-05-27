using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class QuestionUI : MonoBehaviour
{
    public GameObject textBox;
    public GameObject buttonModel;
    public GameObject buttonRegion;

    private Question question;

    public void CreateButtons()
    {
        int index = 0;

        GameObject firstButton = null;

        foreach(Choice choice in question.choices)
        {
            GameObject button = Instantiate(buttonModel);
            button.GetComponent<RectTransform>().SetParent(buttonRegion.GetComponent<RectTransform>());

            button.GetComponent<RectTransform>().anchorMin = button.GetComponent<RectTransform>().anchorMin + new Vector2(0,-0.2f*index);
            button.GetComponent<RectTransform>().anchorMax = button.GetComponent<RectTransform>().anchorMax + new Vector2(0, -0.2f * index);

            button.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            button.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);


            button.GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
            button.GetComponent<Button>().onClick.AddListener(delegate {DialogueManager.Instance.ListenChoice(choice); });
            button.SetActive(true);

            if(firstButton == null)
            {
                firstButton = button;
            }
            index++;
        }
      
       
        if (!EventSystem.current.alreadySelecting)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstButton);
        }
    }

    public void Show(Question toDisplay)
    {
        question =  toDisplay;
        textBox.GetComponent<TextMeshProUGUI>().text = toDisplay.text;
        CreateButtons();
    }
}
