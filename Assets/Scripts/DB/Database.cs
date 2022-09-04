using System.Collections;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace DB
{
    public class Database : MonoBehaviour
    {
        private FirebaseAuth _auth;
        private FirebaseUser _user;
        private DatabaseReference _dbRef;
        [SerializeField] Text userIDText;
        //[SerializeField] private Animator _notifyAnimator;
       // [SerializeField] private TMP_Text _textNotify;
        
        private static readonly int FadeKey = Animator.StringToHash("Fade");

        private void InitializeFirebase()
        {
            _dbRef = FirebaseDatabase.DefaultInstance.RootReference;
            _auth = FirebaseAuth.DefaultInstance;
            _auth.StateChanged += AuthStateChanged;
            AuthStateChanged(this, null);
        }
        public void BackButton()
        {
            _auth.SignOut();
            SceneManager.LoadScene(0);
        }

        private void Start()
        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
                var dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    // Create and hold a reference to your FirebaseApp,
                    // where app is a Firebase.FirebaseApp property of your application class.
                    var app = FirebaseApp.Create();
                    InitializeFirebase();
                    // Set a flag here to indicate whether Firebase is ready to use by your app.
                } else {
                    Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
                    // Firebase Unity SDK is not safe to use here.
                }
            });
        
        }
        void AuthStateChanged(object sender, System.EventArgs eventArgs)
        {
            bool signedIn = _user != _auth.CurrentUser && _auth.CurrentUser != null;
            if (!signedIn && _user != null) {
                Debug.Log("Signed out " + _user.UserId);
            }
            _user = _auth.CurrentUser;
            if (signedIn)
            {
                userIDText.text = _user.UserId;
                Debug.Log("Signed in " + _user.UserId);
            }
        }

        public void SaveData(string key, int value)
        {
            string userId = _auth.CurrentUser.UserId;
            //_dbRef.Child(key).Child(email).Child("money").SetValueAsync(money.ToString());
            _dbRef.Child("users").Child(userId).Child(key).SetValueAsync(value.ToString());

        }


    }
}