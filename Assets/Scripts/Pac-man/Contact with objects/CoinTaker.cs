using System.Collections;
using TMPro;
using UnityEngine;

public class CoinTaker : MonoBehaviour
{
    private const int MaxScore = 1330;

    [SerializeField] private WinHandler _winHandler;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _playerScoreText;

    private int _score;

    public int Score => _score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>() && gameObject.activeSelf)
        {
            _score += 5;
            collision.gameObject.SetActive(false);
            _scoreText.text = $"Score : {_score}";
            StartCoroutine(nameof(ShowAndHidePlayerScoreText));

            if (_score == MaxScore) _winHandler.ShowWinMenu();
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
