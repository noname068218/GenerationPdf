document.getElementById('myForm').addEventListener('submit', function () {
    var loader = document.getElementById('loadingSpinner');
    loader.classList.remove('hidden');

    fetch('/submit', {
        method: 'POST',
        body: new FormData(this)
    })
        .then(response => response.json())
        .then(data => {
           
        })
        .catch(error => {
          
        })
        .finally(() => {
            setTimeout(() => {
                loader.classList.add('hidden'); 
            }, 3000); 
        });
});
