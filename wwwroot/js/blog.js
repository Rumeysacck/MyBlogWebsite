

// BlogController
app.controller('BlogController', function($scope) {

  // Initialize Firebase
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


// Firebase'i başlat
firebase.initializeApp(firebaseConfig);

// Blog kaydetme fonksiyonu
function saveBlog() {
    const title = document.getElementById('blogTitle').value;
    const date = document.getElementById('blogDate').value;
    const summary = document.getElementById('blogSummary').value;
    const content = document.getElementById('blogContent').value;
    const image = document.getElementById('blogImage').value;

    // Tüm alanlar dolu mu kontrol edelim
    if (!title || !date || !summary || !content || !image) {
        alert("Lütfen tüm alanları doldurun!"); // Alanlar boş ise uyarı ver
        return;
    }

    const blogData = {
        title: title,
        date: date,
        summary: summary,
        content: content,
        image: image
    };

    // Firebase'e ekleme işlemi
    firebase.database().ref('blogs').push(blogData)
        .then(() => {
            alert("Blog başarıyla kaydedildi!");
            document.getElementById('blogForm').reset(); // Formu temizle
        })
        .catch((error) => {
            console.error("Hata:", error);
        });
}
})