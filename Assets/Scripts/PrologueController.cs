using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueController : MonoBehaviour
{
    public GameObject blackPanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name=="Player")
        {
            blackPanel.SetActive(true);
            SceneManager.LoadScene(2);
        }
    }
}
