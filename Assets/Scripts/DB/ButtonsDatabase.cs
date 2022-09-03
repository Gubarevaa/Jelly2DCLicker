using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static System.String;

namespace DB
{
    public class ButtonsDatabase : MonoBehaviour
    {

        [SerializeField] private InputField _emailField;
        [SerializeField] private InputField _passwordField;
        [SerializeField] private UnityEvent<string, string> _action;

        public void OnClickButton()
        {
            string email = _emailField.text;
            string password = _passwordField.text;
            if (IsNullOrEmpty(email) || IsNullOrEmpty(password)) return;
            _action?.Invoke(email,password);
        }
    }
}
