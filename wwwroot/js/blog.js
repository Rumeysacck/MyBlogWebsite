var app = angular.module('blogApp', []);

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

  firebase.initializeApp(firebaseConfig);

  // Check if the user is authenticated and admin
  firebase.auth().onAuthStateChanged((user) => {
    if (user) {
      // Firestore'da kullanıcıyı kontrol et (Firestore kullanıyorsanız)
      var userRef = firebase.firestore().collection('users').doc(user.uid);
      userRef.get().then((doc) => {
        if (doc.exists && doc.data().isAdmin) {
          // Kullanıcı admin, blog içeriklerini göster
          document.getElementById('loading').style.display = 'none';
          document.getElementById('blog-content').style.display = 'block';
          loadBlogs(); // Load blogs only if user is authenticated and admin
        } else {
          // Kullanıcı admin değil, giriş sayfasına yönlendir
          window.location.href = '/Home/Login';
        }
      });
    } else {
      // Giriş yapılmamışsa login sayfasına yönlendir
      window.location.href = '/Home/Login';
    }
  });

  // Function to load blogs
  function loadBlogs() {
    // Blogları çek
    var blogRef = firebase.database().ref('blogs');

    blogRef.on('value', function(snapshot) {
      var data = snapshot.val();
      var blogs = [];
      for (var key in data) {
        data[key].key = key;  // Anahtarı da kaydet
        blogs.push(data[key]);
      }

      // Instead of calling $scope.$apply directly, check for $$phase
      if (!$scope.$$phase) {
        $scope.$apply(function() {
          $scope.blogs = blogs;
        });
      } else {
        // Alternatively, use $scope.$applyAsync()
        $scope.blogs = blogs;
      }
    });
  }

  // Yeni blog ekle
  $scope.addBlog = function() {
    var newBlog = {
      title: $scope.newBlog.title,
      content: $scope.newBlog.content,
      author: $scope.newBlog.author,
      date: new Date().toISOString().slice(0, 10)
    };

    // Firebase'e kaydet
    var newBlogKey = firebase.database().ref().child('blogs').push().key;
    firebase.database().ref('blogs/' + newBlogKey).set(newBlog);

    // Formu temizle
    $scope.newBlog = {};
  };

  // Blog sil
  $scope.deleteBlog = function(blogKey) {
    firebase.database().ref('blogs/' + blogKey).remove();
  };
});
