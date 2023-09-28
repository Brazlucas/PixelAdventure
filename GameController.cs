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

    public static GameController instance;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI totalText;

    public GameObject applesObject;

    public GameObject gameOver;

    void Start()
    {
        int numberOfPrefabs = applesObject.transform.childCount;
        //var prefebs = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Prefabs" });
        totalFood = numberOfPrefabs;
        totalText.text = totalFood.ToString();

        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    } 

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
    //public void RestartGame()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

}
