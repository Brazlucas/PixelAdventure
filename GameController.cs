using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;

public class GameController : MonoBehaviour
{
    public int totalScore;

    public int totalFood;

    public static GameController instance;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI totalText;

    public GameObject applesObject;

    void Start()
    {
        int numberOfPrefabs = applesObject.transform.childCount;
        //Iniciar quantidade total da comida no cen�rio
        //var prefebs = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Prefabs" });
        totalFood = numberOfPrefabs;
        totalText.text = totalFood.ToString();

        instance = this;
    }

    public void UpdateScoreText()
    {
        //if (totalScore == totalFood)
        //{
        //}
        scoreText.text = totalScore.ToString();
    }

}
