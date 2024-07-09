using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using TMPro;
using UnityEngine;

public class GameMenu : SingletonUI<GameMenu>
{
   public TextMeshProUGUI scoreText;
   public TextMeshProUGUI hightScoreText;

   public void UpdateScoreText(int newScore)
   {
      scoreText.text = "Score:" + newScore;
   }
   public void UpdateHightScoreText(int newScore)
   {
      hightScoreText.text = "Hight Score:" + newScore;
   }

   private void Start()
   {
      hightScoreText.text = "hight Score: " + GameData.Instance.HightScore;
   }
}
