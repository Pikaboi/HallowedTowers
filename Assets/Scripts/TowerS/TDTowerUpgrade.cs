using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TDTowerUpgrade : MonoBehaviour
{
    public string m_UGString;
    public bool m_UGBought = false;
    public TDTowerUpgrade m_successor;
    public float m_UGCost;
    public float m_baseCost;

    public TMPro.TMP_Text m_UGName;
    public TMPro.TMP_Text m_UGCostString;

    public GameObject m_UGPrefab;

    public PlayerResourceManager m_resource;
    public TDTowerManager m_manager;

    public AudioSource m_sound;

    public Sprite m_Locked;
    public Sprite m_Purchased;
    public string resourcePath;

    public string lockedResource;
    public string purchasedResource;

    // Start is called before the first frame update
    public virtual void Start()
    {
        m_Locked = Resources.Load<Sprite>("" + lockedResource);
        m_Purchased = Resources.Load<Sprite>("" + purchasedResource);
        m_manager = GetComponentInParent<TDTowerManager>();
        m_resource = FindObjectOfType<PlayerResourceManager>();
        m_baseCost = m_UGCost;
        if (m_successor != null)
        {
            m_successor.gameObject.GetComponent<UnityEngine.UI.Button>().enabled = false;
        }
    }

    public virtual void Awake()
    {
        m_resource = FindObjectOfType<PlayerResourceManager>();
        m_baseCost = m_UGCost;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        m_UGCost = m_baseCost - (m_baseCost * m_manager.m_UGDiscount);
        m_UGName.text = m_UGString;
        m_UGCostString.text = m_UGCost.ToString();
        m_UGPrefab = Resources.Load<GameObject>("Towers/" + resourcePath);
    }

    public virtual void PurchaseUpgrade()
    {
        if (m_resource.m_Money >= m_UGCost)
        {
            m_manager.newUpgrade(m_UGPrefab, resourcePath);
            m_UGBought = true;
            GetComponent<Image>().sprite = m_Purchased;
            m_resource.SubMoney(m_UGCost);
            m_manager.m_sellCost += m_UGCost / 2;
            GetComponent<Button>().enabled = false;
            m_sound.Play();
            if (m_successor != null)
            {
                m_successor.gameObject.GetComponent<UnityEngine.UI.Button>().enabled = true;
            }
        }
    }
}
