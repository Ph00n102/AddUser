window.setTextareaRows = (textarea) => {
    if (!textarea) return;
    textarea.rows = 1;
    let lines = textarea.value.split("\n").length;
    textarea.rows = lines;
};
