using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            AddCoin();
            Destroy(coin);
        }
    }

    public void AddCoin()
    {
        _coins++;
        Debug.Log(_coins);
    }
}
