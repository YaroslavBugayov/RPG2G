using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowAnimation : MonoBehaviour
{

    private Animator animator;
    private Vector3 previousPosition;

    private void Start()
    {
        animator = GetComponent<Animator>();
        previousPosition = transform.position;
    }

    private void Update()
    {
        // Проверяем, изменилась ли позиция коровы
        bool isMoving = transform.position != previousPosition;
        
        // Обновляем предыдущую позицию коровы
        previousPosition = transform.position;
        
        // Переключение анимации в зависимости от значения isMoving
        animator.SetBool("isMoving", isMoving);
    }
}
