using UnityEngine;
using UnityEngine.UI;

public class LatencyMeasurement : MonoBehaviour {
    [SerializeField] GameObject m_trackedDevice;
    [SerializeField] Image m_RenderImage;

    float m_Y;
    Color m_transpRed, m_transpGreen;

    void Start()
    {
        m_RenderImage.color = new Color(0, 0, 0, 0.15f);

        m_transpRed = new Color(1, 0, 0, 0.15f);
        m_transpGreen = new Color(0, 1, 0, 0.15f);

        m_Y = m_trackedDevice.transform.position.y;
    }

    void Update()
    {
        if (m_trackedDevice.transform.position.y > m_Y)
        {
            m_RenderImage.color = m_transpGreen;
        }
        else if (m_trackedDevice.transform.position.y < m_Y)
        {
            m_RenderImage.color = m_transpRed;
        }
        else
        {
            return;
        }

        m_Y = m_trackedDevice.transform.position.y;
    }
}