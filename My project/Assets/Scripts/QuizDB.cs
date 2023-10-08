using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizDB : MonoBehaviour
{
    [SerializeField] private List<Question> m_questionList = null;

   [SerializeField] private List<Question> m_backup;

    private void Awake()
    {
        m_backup = m_questionList.ToList(); // Crea una copia de la lista original
    }

    public Question GetRandom(bool remove = true)
    {
        if (m_questionList.Count == 0)
        {
            int index = Random.Range(0, m_backup.Count);

            if (!remove)
                return m_backup[index];

            Question randomQuestion = m_backup[index];
            m_questionList.Remove(randomQuestion);

            return randomQuestion;
        }
        else
        {
            int index = Random.Range(0, m_questionList.Count);

            if (!remove)
                return m_questionList[index];

            Question randomQuestion = m_questionList[index];
            m_questionList.RemoveAt(index);

            return randomQuestion;
        }
    }

    private void RestoreBackup()
    {
        m_questionList = m_backup.ToList(); // Restaura la lista original desde la copia
    }
}
