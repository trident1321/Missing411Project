using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreenScript : MonoBehaviour
{
    [SerializeField]
    Image panel;
    [SerializeField]
    GameObject quitButton;
    // Start is called before the first frame update
    void Start()
    {
        //panel = GetComponent<Image>();
        Color temp = panel.color;
        temp.a = 0f;
        panel.color = temp;
        quitButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // turn on and off panel
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Color temp = panel.color;
            if (panel.color.a > 0)
            {
                temp.a = 0f;
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                quitButton.SetActive(false);
            }
            else
            {
                temp.a = 0.5f;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                quitButton.SetActive(true);
            }
            panel.color = temp;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
