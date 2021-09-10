function Modal() {
    function open() {
        document.querySelector('.modal-wrapper').classList.add("active");
    }
    function close() {
        document.querySelector('.modal-wrapper').classList.remove("active");
    }
    function markread(check = true, modalid) {
        if (check == false) {
            document.querySelector('.modal h2').innerHTML = "Mark as read";
            document.querySelector('.modal p').innerHTML = "Are you sure you want to mark this question as read ?";
            document.querySelector('.modal button').innerHTML = "Checked";
            document.querySelector('.modal button').classList.remove("red");
            document.querySelector('.modal').setAttribute('id', modalid);
        }
        else {
            document.querySelector('.modal h2').innerHTML = "Delete question";
            document.querySelector('.modal p').innerHTML = "Are you sure you want to delete this question ?";
            document.querySelector('.modal button').innerHTML = "Delete";
            document.querySelector('.modal button').classList.add("red");
            document.querySelector('.modal').setAttribute('id', modalid);
        }
        open();
    }
    return {
        open,
        close, 
        markread
    }
}