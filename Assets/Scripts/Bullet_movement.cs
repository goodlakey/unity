using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float speed;

    public void Initialize(float bulletSpeed)
    {
        speed = bulletSpeed;
    }

    void Update()
    { 
        
        // Задаем угол вращения пули
        float rotationAngle = 270f; // Угол в градусах
        transform.rotation = Quaternion.Euler(0, rotationAngle, 0);
         
       
        
        // Двигаем пулю только по координате Z
        transform.Translate(Vector3.left * speed * Time.deltaTime);

           }
}
