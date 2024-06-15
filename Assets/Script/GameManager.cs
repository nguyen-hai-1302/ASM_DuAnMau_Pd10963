using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerData playerData;

    void Start()
    {

        if (playerData == null)
        {
            // Tạo mới một PlayerData nếu chưa tồn tại
            playerData = ScriptableObject.CreateInstance<PlayerData>();

            // Khởi tạo giá trị cho màn chơi đầu tiên
            playerData.playerLevel = 0;
            // Khởi tạo giá trị đầu tiên cho điểm số
            playerData.playerScore = 0;

            //Debug.Log("Initial player data set.");
        }
        else
        {
            // gọi hàm lấy dữ liệu người chơi nếu dữ liệu người chơi khác null
            LoadPlayerData();
        }
    }


    void LoadPlayerData()
    {
        // Đọc dữ liệu người chơi từ file lưu trữ
        if (PlayerPrefs.HasKey("PlayerLevel"))
        {
            playerData.playerLevel = PlayerPrefs.GetInt("PlayerLevel");
            playerData.playerScore = PlayerPrefs.GetInt("PlayerScore");
            //Debug.Log("Player data loaded.");
            Debug.Log("PlayerLevel" + playerData.playerLevel);
            Debug.Log("playerScore" + playerData.playerScore);
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
