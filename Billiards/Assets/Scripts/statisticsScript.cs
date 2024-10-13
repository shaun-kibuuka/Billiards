using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statisticsScript : MonoBehaviour
{


    public Text win;
    public Text loss;
    public Text winLoss;
    
    public static int wins = 0;
    public static int losses = 0;
  
    // Start is called before the first frame update
    void Start()
    {
        wins = PlayerPrefs.GetInt("Wins", 0);
	losses = PlayerPrefs.GetInt("Losses", 0);
	updateStatisticsUI();
    }
	
    public void addWin() 
    {
        Currency.coins += 50;
        Currency.updateCoins();
	wins++;
	saveStatistics();
	updateStatisticsUI();
    }

    public void addLoss() 
    {
	losses++;
	saveStatistics();
	updateStatisticsUI();
    }

    private void saveStatistics() 
    {
	PlayerPrefs.SetInt("Wins", wins);
	PlayerPrefs.SetInt("Losses", losses);
    }
 	
    private void updateStatisticsUI()
    {
	win.text = "Win:         " + wins.ToString();
       loss.text = "Loss:        " + losses.ToString();

	float winLossRatio = losses == 0 ? wins : (float)wins/losses;
    winLoss.text = "Win/Loss:    " + winLossRatio.ToString("F2");
    }
}
