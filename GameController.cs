using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;

    public int totalFood;

    public int currentLevelIndex;

    public static GameController instance;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI totalText;

    public GameObject applesObject;

    public GameObject gameOver;

    public GameObject nextLevel;

    public GameObject alert;

    public GameObject isChecked;

    void Start()
    {
        int numberOfPrefabs = applesObject.transform.childCount;
        //var prefebs = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Prefabs" });
        totalFood = numberOfPrefabs;
        totalText.text = totalFood.ToString();

        instance = this;
    }

    private void Update()
    {
        if (totalFood == totalScore)
        {
            isChecked.SetActive(true);
            scoreText.color = Color.red;
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void ShowNextLevel()
    {
        if (totalScore == totalFood)
        {
            nextLevel.SetActive(true);
        }
        else
        {
            alert.SetActive(true);
        }
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
    //public void RestartGame()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    public void LoadNextLevel()
    {
        currentLevelIndex++;

        string nextLevelName = "lvl_" + currentLevelIndex;

        if (SceneManager.GetSceneByName(nextLevelName) != null)
        {
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            Debug.LogWarning("Next level not found: " + nextLevelName);
        }
    }

}
