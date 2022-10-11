using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayStoreBtn()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=online.cashondelivery.app&hl=en_US&gl=US");
    }
}
