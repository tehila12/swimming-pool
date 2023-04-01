

function getPsd() {
    sessionStorage.login = null;
    var psd = document.getElementById("password").value;
    var fullPath = 'https://localhost:44371/api/Users/Get/?psd=';
    return axios.get(fullPath + psd).then(
        (response) => {
            var result = response.data;
            console.log(result)
            if (result != null) {
                sessionStorage.login = JSON.stringify(result);
            }
            return result;
        }).catch((error) => {
            console.log(error);
            return null;
        });
}

function login() {
    getPsd().then((result) => {
        if (result != null) {
            window.location.href = '../HomePage/HomelPage.html'
        } else {
            alert("הנתונים שהוזנו שגויים")
        }
    });
}
