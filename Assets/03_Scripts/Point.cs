using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour 
{
    public static Point Instance;
    private void Awake()
    {
        Instance = this;
    }
    [SerializeField] Text pointText = null;
    public int point = 0;

    private void Start()
    {
        point = 0;
    }
    private void Update()
    {
        pointText.text = $"Score : {PlayerPrefs.GetInt("score")}";
    }
    public void PlusPoint()
    {
        point++;
    }
}
