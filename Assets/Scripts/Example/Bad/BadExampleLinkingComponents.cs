using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Example.Bad
{
    public class BadExampleLinkingComponents : MonoBehaviour
    {
        [SerializeField] private GameObject _counterController;
        [SerializeField] private Text _counterText;
        [SerializeField] private List<Button> _buttons;
    }
}
