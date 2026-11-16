using UnityEngine;

public class Test : MonoBehaviour
{
    private string promptText = "123";
    void Start()
    {
        Debug.Log("Script started");
    }

    void Update()
    {

    }

    private void HidePrompt()
    {
        if (promptText != null)
        {
            return;
        }
    }
}
    