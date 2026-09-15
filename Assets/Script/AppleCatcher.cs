using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AppleCatcher : MonoBehaviour
{
    public float basketSpeed = 7.0f; // Скорость корзины
    public int lives = 5; // Количество жизней
    public int score = 0; // Очки
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    void Start()
    {
        UpdateUI(); // Обновляем UI при старте
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * basketSpeed * Time.deltaTime;
        transform.position += new Vector3(move, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Apple")) // Проверяем, что столкновение с яблоком
        {
            Destroy(other.gameObject); // Уничтожаем яблоко
            score++; // Увеличиваем счет
            Debug.Log("Яблоко поймано! Текущий счет: " + score);
            UpdateUI(); // Обновляем UI
        }
    }

    public void LoseLife()
    {
        lives--;
        Debug.Log("Жизни уменьшились! Осталось: " + lives);
        UpdateUI();
        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        if (scoreText != null && livesText != null)
        {
            scoreText.text = "Score: " + score;
            livesText.text = "Lives: " + lives;
        }
        else
        {
            Debug.LogError("ScoreText или LivesText не подключены в Inspector!");
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0; // Останавливаем игру
    }
}
