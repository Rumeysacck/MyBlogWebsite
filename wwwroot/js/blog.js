// Initialize Firebase
import { initializeApp } from "firebase/app";
import { getDatabase, ref, onValue } from "firebase/database";

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
const app = initializeApp(firebaseConfig);
const database = getDatabase(app);

// Retrieve and display blogs
function displayBlogs() {
    const blogRef = ref(database, 'blogs');
    const blogSlider = document.getElementById('blogSlider');
    
    // Listen for changes in the blogs
    onValue(blogRef, (snapshot) => {
        blogSlider.innerHTML = ''; // Clear the existing content
        
        snapshot.forEach((childSnapshot) => {
            const blog = childSnapshot.val();
            const blogItemHTML = `
                <div class="blog-slider__item swiper-slide">
                    <div class="blog-slider__img">
                        <img src="${blog.image}" alt="Blog Image">
                    </div>
                    <div class="blog-slider__content">
                        <span class="blog-slider__code">${blog.date}</span>
                        <div class="blog-slider__title">${blog.title}</div>
                        <div class="blog-slider__text">${blog.content.substring(0, 100)}...</div>
                        <a href="#" class="blog-slider__button">READ MORE</a>
                    </div>
                </div>
            `;
            blogSlider.innerHTML += blogItemHTML; // Append each blog
        });
    });
}

// Call the function to display blogs
displayBlogs();
