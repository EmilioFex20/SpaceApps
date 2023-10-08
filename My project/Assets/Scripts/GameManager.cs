using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    private int correctAnswers = 0;

    [SerializeField] private AudioClip m_correctSound = null;
    [SerializeField] private AudioClip m_incorrectSound = null;
    [SerializeField] private Color m_correctColor = Color.black;
    [SerializeField] private Color m_incorrectColor = Color.black; // Corrección aquí
    [SerializeField] private float m_waitTime = 0.0f; // Corrección aquí
    private QuizDB m_quizDB = null;
    private QuizUI m_quizUI = null;
    private AudioSource m_audioSource = null;

    private void Start()
    {
        m_quizDB = FindObjectOfType<QuizDB>(); // Corrección aquí
        m_quizUI = FindObjectOfType<QuizUI>(); // Corrección aquí
        m_audioSource = GetComponent<AudioSource>();

        NextQuestion();
    }

    private void NextQuestion()
    {
        m_quizUI.Construct(m_quizDB.GetRandom(), GiveAnswer); // Corrección aquí
    }

    private void GiveAnswer(OptionButton optionButton)
    {
        StartCoroutine(GiveAnswerRoutine(optionButton)); // Corrección aquí
        if (optionButton.Option.correct)
    {
        correctAnswers++; // Incrementa el contador de respuestas correctas
        if (correctAnswers >= 3) // Si se responden 3 preguntas correctamente
        {
            LoadScene3(); // Llama a la función para cargar la escena 3
        }
    }
    }

    private IEnumerator GiveAnswerRoutine(OptionButton optionButton) // Corrección aquí
    {
        if (m_audioSource.isPlaying)
            m_audioSource.Stop();

        m_audioSource.clip = optionButton.Option.correct ? m_correctSound : m_incorrectSound;
        optionButton.SetColor(optionButton.Option.correct ? m_correctColor : m_incorrectColor);

        m_audioSource.Play();
        yield return new WaitForSecondsRealtime(m_waitTime);

        if(optionButton.Option.correct)
            NextQuestion();
        else
            GameOver();
    }

    public void GameOver()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(2);
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void LoadScene3()
    {
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(0); 

        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(4);

        }
   
    }
}
