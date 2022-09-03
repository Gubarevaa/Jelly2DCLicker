using System.Collections;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DB
{
    public class Database : MonoBehaviour
    {
        private FirebaseAuth _auth;
        private FirebaseUser _user;
        private DatabaseReference _dbRef;
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
                    if (_auth.CurrentUser != null)
                    {
                        SceneManager.LoadScene(1);
                    }

                    // Set a flag here to indicate whether Firebase is ready to use by your app.
                } else {
                    Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
                    // Firebase Unity SDK is not safe to use here.
                }
            });
        
        }

        public void RegData(string email, string password)
        {
            _auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
                if (task.IsCanceled) {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted) {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }
                FirebaseUser newUser = task.Result;
                Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
            });
        }

        public void SignData(string email, string password)
        {
            if (_auth.CurrentUser == _user && _user != null)
            {
                SceneManager.LoadScene(1);
                return;
            }
            _auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted) {
                    Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }

                FirebaseUser newUser = task.Result;
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
                
            });
        }
        
        void AuthStateChanged(object sender, System.EventArgs eventArgs)
        {
            if (_auth.CurrentUser == _user) return;
            bool signedIn = _user != _auth.CurrentUser && _auth.CurrentUser != null;
            if (!signedIn && _user != null) {
                Debug.Log("Signed out " + _user.UserId);
            }
            _user = _auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + _user.UserId);
             
                // displayName = user.DisplayName ?? "";
                // emailAddress = user.Email ?? "";
                // photoUrl = user.PhotoUrl ?? "";
            }
        }

        public void SaveData(string key, int money)
        {
            string userId = _auth.CurrentUser.UserId;
            //_dbRef.Child(key).Child(email).Child("money").SetValueAsync(money.ToString());
            _dbRef.Child("users").Child(userId).SetValueAsync(money.ToString());
        }


    }
}