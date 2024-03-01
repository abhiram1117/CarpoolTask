function validations(element,elementError){
    const input = document.getElementById(element).value;
    document.getElementById(elementError).textContent="";
    if(input===""){
          document.getElementById(elementError).textContent="Field Required";
    }
    
    
}

function signinValidations(details,detailsError,matchingDetail){
    const input = document.getElementById(details).value;
    const matchingInput = document.getElementById(matchingDetail).value;
    if(input !== matchingInput){
        document.getElementById(detailsError).textContent="Passwords don't match";
    }
}
function signinValidationChecks(){
    validations('signupEmail','emailError');
    validations('signupPassword','passwordError');
    validations('confirmPassword','confirmPasswordError');
    signinValidations('signupPassword','confirmPasswordError','confirmPassword');
    
}
function loginValidationChecks(){
    validations('loginEmail','emailError');
    validations('loginPassword','passwordError');
}