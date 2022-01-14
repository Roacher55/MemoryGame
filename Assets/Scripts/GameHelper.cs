using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    public int mistakes = 0;

    float timer = 0f;

    bool boolEndGameYTimer = false;

    [SerializeField] GameObject gridEndGame;
    [SerializeField] Text textMistake;
    [SerializeField] Text textTime;


    private void Update()
    {
        if(boolEndGameYTimer == false)
             timer += Time.deltaTime;

        QuitorOrReload();
    }
    public void Win(List<GameObject> slots)
    {
        int count = 0;
        foreach (var slot in slots)
        {
            if(slot.GetComponent<Image>().sprite != null)
            {
                count++;
            }
        }

        if(slots.Count == count)
        {
            boolEndGameYTimer = true;
            gridEndGame.SetActive(true);
            textMistake.text = "Mistakes: " + mistakes;
            textTime.text = "Time: " + System.Math.Round(timer, 2);
            Invoke("RestartGame", 10f);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void QuitorOrReload()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKey("space"))
        {
            RestartGame();
        }
    }
}
