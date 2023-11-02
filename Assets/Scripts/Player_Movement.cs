using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость перемещения персонажа

    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Вычисляем направление движения на основе ввода
        moveDirection = new Vector3(horizontalInput, 0, 0);
        moveDirection.Normalize(); // Нормализация для предотвращения быстрого движения по диагонали

        // Применяем скорость и гравитацию
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        // Передвигаем персонаж
        controller.Move(moveDirection * Time.deltaTime);
    }
}
