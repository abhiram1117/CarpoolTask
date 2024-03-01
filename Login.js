document.getElementById("loginForm").addEventListener("submit", async function (event) {

    event.preventDefault();

//    document.getElementById("emailError").textContent = "";
//    document.getElementById("passwordError").textContent = "";

    var email = document.getElementById("loginEmail").value.trim();
    var password = document.getElementById("loginPassword").value.trim();    

    var isValid = true;
//    if (email === "") {
//        document.getElementById("emailError").textContent = "Invalid Email Address";
 //       isValid = false;
 //   }
//    if (password === "") {
//        document.getElementById("passwordError").textContent = "Password Required";
//        isValid = false;
//    }

    if (isValid) {
        const response = await fetch('https://localhost:7057/api/Users/Login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })

        });

        if (response.ok) {
            alert('Login Successful');
            window.location.href = "Homepage.html";
        }
    }


});