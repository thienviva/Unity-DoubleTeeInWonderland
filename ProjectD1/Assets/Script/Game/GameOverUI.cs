﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class GameOverUI : MonoBehaviour
{
    public List<string> HighScores = new List<string>();
    public GameObject gameover;
    public GameMaster GM;

    //Âm thanh 
    public AudioSource aus;
    public AudioClip menu;
    public AudioClip restart;
    public AudioClip quit;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        if (aus && restart)
        {
            aus.PlayOneShot(restart);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        if (aus && quit)
        {
            aus.PlayOneShot(quit);
        }
        Application.Quit();
    }

    public void Menu()
    {
        if (aus && menu)
        {
            aus.PlayOneShot(menu);
        }
        SceneManager.LoadScene(0);
    }
    public void OnEnable()
    {
        using (StreamReader sr = new StreamReader("highscore.txt"))
        {
            string line;
            // doc va hien thi cac dong trong file cho toi
            // khi tien toi cuoi file. 
            while ((line = sr.ReadLine()) != null)
            {
                HighScores.Add(line);
            }
        }
        HighScores.Add(GM.Points.ToString());
        for (int i = 0; i < HighScores.Count; i++)
        {
            for (int j = i + 1; j < HighScores.Count; j++)
            {
                if (int.Parse(HighScores[j]) > int.Parse(HighScores[i]))
                {
                    string tmp;
                    tmp = HighScores[i];
                    HighScores[i] = HighScores[j];
                    HighScores[j] = tmp;
                }
            }
        }
        using (StreamWriter sw = new StreamWriter("highscore.txt"))
        {
            foreach (string s in HighScores)
            {
                sw.WriteLine(s);
            }
        }
    }
}
