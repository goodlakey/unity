using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // ����, ��������� �����

    void OnCollisionEnter(Collision collision)
    {
        // ���������, ����������� �� ���� � ������
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            // ������� ���� �����
            enemy.TakeDamage(damage);
        }

        // ���������� ����
        Destroy(gameObject);
    }
}
