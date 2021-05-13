using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthInterface<T>
{
    void TakeDamage(T DamageTaken);

    void Heal(T HealAmount);

    void Dead();
}
