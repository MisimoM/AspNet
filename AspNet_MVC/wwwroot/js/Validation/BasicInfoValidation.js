document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('.basic-info');

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

        if (inputName === 'Details.BasicInfo.Phone' || 'Details.BasicInfo.Bio') {
            return true;
        }

        return false;
    }

    function validateField(input) {
        const fieldName = input.name;
        let isValid = false;
        let errorMessage = '';

        switch (fieldName) {
            case 'Details.BasicInfo.FirstName':
                isValid = !isEmpty(input.value.trim());
                errorMessage = '\u26A0 First name is required';
                break;
            case 'Details.BasicInfo.LastName':
                isValid = !isEmpty(input.value.trim());
                errorMessage = '\u26A0 Last name is required';
                break;
            case 'Details.BasicInfo.Email':
                isValid = isValidEmail(input.value.trim());
                errorMessage = '\u26A0 Invalid email format';
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