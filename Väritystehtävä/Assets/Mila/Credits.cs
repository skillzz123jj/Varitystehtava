using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject credits;
    [SerializeField] Button closeCredits;
    [SerializeField] Button closeInstructions;

    void Update()
    {
        if (credits.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
            {
                closeCredits.onClick.Invoke();
                GameData.gameData.instructions = false;
            }
           
            HoverCredits();
        }

    }
    public void CloseCredits()
    {
        
        text.text = $"Tekij�t";
       
    }
    public void HoverCredits()
    {
        
        text.text = $"<b>Tekij�t</b>";
    }
    public void Instructions()
    {
        GameData.gameData.instructions = false;

    }

}
