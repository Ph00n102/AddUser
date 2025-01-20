function checkUncheck(selectAllCheckbox) {
    const checkboxes = document.querySelectorAll('tbody input[type="checkbox"]');
    const isChecked = selectAllCheckbox.checked;

    checkboxes.forEach((checkbox) => {
        checkbox.checked = isChecked;
        checkbox.dispatchEvent(new Event('change')); // Trigger the onchange event
    });
}

function checkUncheck(source) {
    const checkboxes = document.querySelectorAll('input[type="checkbox"]');
    checkboxes.forEach(checkbox => {
        if (checkbox !== source) {
            checkbox.checked = source.checked;
        }
    });
}