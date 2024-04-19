document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('.address-info');
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

        if (inputName === 'Details.Address.AddressLine_2') {
            return true;
        }

        return false;
    }

    function validateField(input) {
        const fieldName = input.name;
        let isValid = false;
        let errorMessage = '';

        switch (fieldName) {
            case 'Details.Address.AddressLine_1':
                isValid = !isEmpty(input.value.trim());
                errorMessage = '\u26A0 Address name is required';
                break;
            case 'Details.Address.PostalCode':
                isValid = !isEmpty(input.value.trim());
                errorMessage = '\u26A0 Postal code is required';
                break;
            case 'Details.Address.City':
                isValid = isEmpty(input.value.trim());
                errorMessage = '\u26A0 City is required';
                break;
        }

        updateValidationStatus(input, isValid, errorMessage);
    }

    function isEmpty(value) {
        return value === '';
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