using System.Collections;
using TMPro;
using UnityEngine;

public class CoinTaker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _playerScoreText;

    private int _score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
        {
            _score += 5;
            collision.gameObject.SetActive(false);
            _scoreText.text = $"Score : {_score}";
            StartCoroutine(nameof(ShowAndHidePlayerScoreText));
        }
    }

    private IEnumerator ShowAndHidePlayerScoreText()
    {
        yield return new WaitForSeconds(0.1f);
        _playerScoreText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _playerScoreText.gameObject.SetActive(false);
    }
}
