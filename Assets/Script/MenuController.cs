using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public PlayerData playerData;
    public Text Level;
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerData();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LoadPlayerData()
    {
        // Đọc dữ liệu người chơi từ file lưu trữ
        if (PlayerPrefs.HasKey("PlayerLevel"))
        {
            playerData.playerLevel = PlayerPrefs.GetInt("PlayerLevel");
            playerData.playerScore = PlayerPrefs.GetInt("PlayerScore");
            Level.text = "Level:" + (playerData.playerLevel).ToString();
            Score.text = "Score:" + (playerData.playerScore).ToString();
            //Debug.Log("Player data loaded.");
            Debug.Log("PlayerLevel" + playerData.playerLevel);
            Debug.Log("PlayerScore" + playerData.playerScore);
        }
        else
        {
            //Debug.LogWarning("Player data not found. Starting with default values.");
            // Gán giá trị mặc định nếu không tìm thấy dữ liệu người chơi
            playerData.playerLevel = 0;
            playerData.playerScore = 0;
        }
    }
}
