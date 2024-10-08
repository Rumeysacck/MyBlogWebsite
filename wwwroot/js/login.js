

// Firebase config
const firebaseConfig = {
    apiKey: "AIzaSyBA9iw4sDlYn4BibKRSSDI2MpGdJWSymEA",
    authDomain: "myblog-f187d.firebaseapp.com",
    databaseURL: "https://myblog-f187d-default-rtdb.europe-west1.firebasedatabase.app",
    projectId: "myblog-f187d",
    storageBucket: "myblog-f187d.appspot.com",
    messagingSenderId: "561017129023",
    appId: "1:561017129023:web:3d91390a57affca1c7508a",
    measurementId: "G-56H676KPTL"
  };

// Initialize Firebase
firebase.initializeApp(firebaseConfig);

// Login işlemi
document.getElementById('loginForm').addEventListener('submit', function (event) {
    event.preventDefault(); // Formun varsayılan davranışını durdur

    var email = document.getElementById('email').value;
    var password = document.getElementById('password').value;

    firebase.auth().signInWithPopup(new firebase.auth.EmailAuthProvider())
  .then((userCredential) => {
    // Giriş başarılı
    window.location.href = '/Home/AdminPanel';
    HttpContext.Session.SetString("isAdmin", "true");
  })
        .catch((error) => {
            console.error("Login Error:", error);  // Hatayı konsola yazdırın
            document.getElementById('error').innerText = error.message;
        });
});
