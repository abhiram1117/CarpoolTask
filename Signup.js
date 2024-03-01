document.getElementById("signupForm").addEventListener("submit", async function (event) {

    event.preventDefault();

    //document.getElementById("emailError").textContent = "";
    //document.getElementById("passwordError").textContent = "";
    //document.getElementById("confirmPasswordError").textContent = "";

    var email = document.getElementById("signupEmail").value.trim();
    var password = document.getElementById("signupPassword").value.trim();
    var confirmPassword = document.getElementById("confirmPassword").value.trim();

    var isValid = true;
//    if (email === "") {
  //      document.getElementById("emailError").textContent = "Invalid Email Address";
    //    isValid = false;
    //}
    //if (password === "") {
    //    document.getElementById("passwordError").textContent = "Password Required";
    //    isValid = false;
    //}
    //if (confirmPassword === "") {
      //  document.getElementById("confirmPasswordError").textContent = "Password Required";
        //isValid = false;
    //}
    //if (confirmPassword !== password) {
      //  document.getElementById("confirmPasswordError").textContent = "Passwords don't match";
        //isValid = false;
    //}

    if (isValid) {
        const response = await fetch('https://localhost:7057/api/Users/Signup', {
            method: 'POST',
            mode:'cors',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin':'*'               
            },
            
            body: JSON.stringify({ email, password })
        });

        if (response.ok) {
            alert("Account created successfully");
            window.location.href = "Homepage.html"; 
        }
    }

});