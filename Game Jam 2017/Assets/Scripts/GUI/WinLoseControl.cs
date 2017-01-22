using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinLoseControl : MonoBehaviour
{
    private GameObject player;
    private Text t;
    private bool over = false;
    public bool GetOver { get { return over;  } }

    private void Start()
    {
        player = GameObject.Find("Player(Clone)");
        t = this.gameObject.GetComponent<Text>();
    }

    void Update()
    {
        if (!player.activeInHierarchy && !over)
        {
            Lose();
        }
        else if (player.transform.position == new Vector3(1, 1, 0) && !over)
        {
            Win();
        }
    }

    public void Lose()
    {
        t.text = "Sorry, you have lost Press R to Restart";
        over = true;
    }

    public void Win()
    {
        t.text = "Congratulations, you have won Press 'R' to Restart";
        over = true;
    }

}
