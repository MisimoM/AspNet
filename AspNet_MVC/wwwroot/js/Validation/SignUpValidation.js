document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('.sign-up-form');
    form.addEventListener('submit', function (event) {

        if (!form.checkValidity()) {
            event.preventDefault();
            event.stopPropagation();
        }

        form.classList.add('was-validated');
    });

    const inputFields = form.querySelectorAll('input');

    inputFields.forEach(function (input) {
        input.addEventListener('input', function (event) {
            validateField(input);
        });

        input.addEventListener('blur', function (event) {
            validateField(input);
        });
    });

    function validateField(input) {
        const fieldName = input.name;
        let isValid = false;
        let errorMessage = '';

        switch (fieldName) {
            case 'Form.FirstName':
                isValid = !isEmpty(input.value.trim());
                errorMessage = '\u26A0 First name is required';
                break;
            case 'Form.LastName':
                isValid = !isEmpty(input.value.trim());
                errorMessage = '\u26A0 Last name is required';
                break;
            case 'Form.Email':
                isValid = isValidEmail(input.value.trim());
                errorMessage = '\u26A0 Invalid email format';
                break;
            case 'Form.Password':
                isValid = isValidPassword(input.value);
                errorMessage = '\u26A0 Your password needs at least 8 characters, an uppercase letter, a number, and a special character (!@#$%^&*)';
                break;
            case 'Form.ConfirmPassword':
                isValid = validateConfirmPassword(input);
                errorMessage = '\u26A0 Passwords do not match';
                break;
            case 'Form.TermsAndConditions':
                isValid = input.checked;
                errorMessage = ' \u26A0 Please confirm the Terms and Conditions';
                break;
        }

        updateValidationStatus(input, isValid, errorMessage);
    }

    function isEmpty(value) {
        return value === '';
    }

    function isValidEmail(value) {
        const regex = /^(?=.{1,100}$)[a-zA-Z0-9._%+-]{1,64}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        return regex.test(value);
    }

    function isValidPassword(value) {
        const regex = /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+])[a-zA-Z\d!@#$%^&*()_+]{8,}$/;
        return regex.test(value);
    }

    function validateConfirmPassword(confirmPasswordInput) {
        const passwordInput = form.querySelector('input[name="Form.Password"]');
        return confirmPasswordInput.value === passwordInput.value;
    }

    function updateValidationStatus(input, isValid, errorMessage) {
        const validationSpan = form.querySelector(`span[data-valmsg-for="${input.name}"]`);

        if (isValid) {
            input.classList.remove('input-validation-error');
            input.classList.add('input-validation-valid');
            if (validationSpan) {
                validationSpan.textContent = '';
                validationSpan.classList.remove('field-validation-error');
            }
        } else {
            input.classList.remove('input-validation-valid');
            input.classList.add('input-validation-error');
            if (validationSpan) {
                validationSpan.textContent = errorMessage;
                validationSpan.classList.add('field-validation-error');
            }
        }
    }
});