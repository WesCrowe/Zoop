using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public string[] levels;
    public int selected_idx;
    public string selected_level;

    public void LoadLevel()
    {
        SceneManager.LoadScene(selected_level);
    }
    public void SelectLevel(int idx)
    {
        selected_idx = idx;
        selected_level = levels[selected_idx];
    }
}
