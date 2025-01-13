using System.Collections;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorialTxt;
    [SerializeField] TMP_Text tutorialTextfield;

    void Start()
    {
        StartCoroutine(TutorialText());
    }

    IEnumerator TutorialText()
    {
        tutorialTxt.SetActive(true);
        
        tutorialTextfield.text = "Welcome to Markt Media, where destroying products is a top priority.";
        
        yield return new WaitForSeconds(5);

        tutorialTextfield.text = "If you want to destroy products, you can do so by hitting them with your weapon (LMB)";

        yield return new WaitForSeconds(6);

        // tutorialTextfield.text = "After destroying some products you can switch to new unlocked weapons (1, 2, 3, 4, 5)";

        // yield return new WaitForSeconds(6);

        tutorialTextfield.text = "Your goal is to destroy as many items as possible before the police arrives";

        yield return new WaitForSeconds(5);

        tutorialTextfield.text = "Good luck and have a great time!";

        yield return new WaitForSeconds(5);

        tutorialTxt.SetActive(false);
    }
}
