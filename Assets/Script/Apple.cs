using UnityEngine;

public class Apple : MonoBehaviour
{
    public float fallSpeed = 3.0f;
    private AppleCatcher catcher;

    void Start()
    {
        catcher = FindObjectOfType<AppleCatcher>();
    }

    void Update()
    {
    transform.position += Vector3.down * fallSpeed * Time.deltaTime;

    if (transform.position.y < -5) // Если яблоко упало ниже экрана
    {
        FindObjectOfType<AppleCatcher>().LoseLife(); // Вызываем потерю жизни
        Destroy(gameObject); // Уничтожаем яблоко
    }
    }
}
