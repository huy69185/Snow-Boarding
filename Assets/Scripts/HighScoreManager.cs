using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public int currentFlips; // Số lần lật hiện tại
    public int highestFlips; // Flip cao nhất từng đạt được
    public TextMeshProUGUI flipMessage; // Hiển thị thông báo
    public TextMeshProUGUI highestFlipText; // Hiển thị flip cao nhất

    void Start()
    {
        // Lấy flip cao nhất từ PlayerPrefs
        highestFlips = PlayerPrefs.GetInt("HighestFlips", 0);
        DisplayHighestFlips();
    }

    public void CheckHighestFlips()
    {
        // Lấy PlayerMovement trong Scene
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player == null) return; // Kiểm tra nếu không tìm thấy player

        // Lấy số lần Flip từ PlayerMovement
        currentFlips = player.TotalFlipCount;

        if (currentFlips > highestFlips)
        {
            highestFlips = currentFlips;
            PlayerPrefs.SetInt("HighestFlips", highestFlips);
            PlayerPrefs.Save();
            flipMessage.text = "New Highest Flips!";
        }
        else
        {
            flipMessage.text = "Try to beat the record!";
        }

        DisplayHighestFlips();
    }


    public void DisplayHighestFlips()
    {
        highestFlipText.text = highestFlips.ToString();
    }
}