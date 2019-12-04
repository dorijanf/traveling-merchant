using UnityEngine;
using UnityEngine.UI;

public class EnterAmount : MonoBehaviour
{
    public InputField inputField;
    public bool isActive;
    int amount;


    private void Start()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    public void Update()
    {
        if (isActive)
        {
            gameObject.SetActive(true);
            inputField.characterValidation = InputField.CharacterValidation.Integer;
            var inputText = inputField.GetComponentInChildren<Text>().text;
            if (inputField.isFocused && inputField.text != "" && Input.GetKey(KeyCode.Return))
            {
                amount = int.Parse(inputText);
                isActive = false;
                gameObject.SetActive(false);
            }
        }

    }

    public void setActive()
    {
        isActive = true;
    }

    public int GetAmount()
    {
        return amount;
    }
}
