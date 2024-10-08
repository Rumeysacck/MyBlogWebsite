// Firebase başlatma kodları
import { initializeApp } from "firebase/app";
import { getDatabase, ref, push } from "firebase/database";

// Firebase config dosyası
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
const app = initializeApp(firebaseConfig);
const database = getDatabase(app);

// Blog formunu dinleme
document.getElementById('blogForm').addEventListener('submit', function (e) {
    e.preventDefault(); // Formun varsayılan davranışını durdur

    // Formdan değerleri al
    const title = document.getElementById('blogTitle').value;
    const author = document.getElementById('blogAuthor').value;
    const date = document.getElementById('blogDate').value;
    const content = document.getElementById('blogContent').value;
    const image = document.getElementById('blogImage').value || 'https://placehold.co/600x400'; // Varsayılan görsel URL

    // Blogu Firebase'e kaydet
    const blogRef = ref(database, 'blogs');
    push(blogRef, {
        title: title,
        author: author,
        date: date,
        content: content,
        image: image
    }).then(() => {
        alert("Blog başarıyla kaydedildi!");
        // Formu temizle
        document.getElementById('blogForm').reset();
    }).catch(error => {
        console.error("Hata oluştu:", error);
    });
});