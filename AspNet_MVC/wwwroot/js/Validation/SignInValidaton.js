document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('.sign-in-form');

    form.addEventListener('submit', function (event) {
        if (!form.checkValidity()) {
            event.preventDefault();
            event.stopPropagation();
        }
    });

    const inputFields = form.querySelectorAll('input');

    inputFields.forEach(function (input) {

        if (shouldSkipInput(input)) {
            return;
        }

        input.addEventListener('input', function (event) {
            validateField(input);
        });

        input.addEventListener('blur', function (event) {
            validateField(input);
        });
    });

    function shouldSkipInput(input) {

        const inputName = input.name;

        if (inputName === 'Form.Password') {
            return true;
        }

        return false;
    }

    function validateField(input) {
        const fieldName = input.name;
        let isValid = false;
        let errorMessage = '';

        switch (fieldName) {
            case 'Form.Email':
                isValid = isValidEmail(input.value.trim());
                errorMessage = '\u26A0 Email is required';
                break;
        }

        updateValidationStatus(input, isValid, errorMessage);
    }
    function isValidEmail(value) {
        const regex = /^(?=.{1,100}$)[a-zA-Z0-9._%+-]{1,64}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        return regex.test(value);
    }

    function updateValidationStatus(input, isValid, errorMessage) {
        const validationSpan = form.querySelector(`span[data-valmsg-for="${input.name}"]`);

        if (isValid) {
            input.classList.remove('input-validation-error');
            if (validationSpan) {
                validationSpan.textContent = '';
                validationSpan.classList.remove('field-validation-error');
            }
        } else {
            input.classList.add('input-validation-error');
            if (validationSpan) {
                validationSpan.textContent = errorMessage;
                validationSpan.classList.add('field-validation-error');
            }
        }
    }
});