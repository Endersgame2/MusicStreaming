window.onload = () => {
    let currentUser = sessionStorage.getItem('currentUser')
    if (currentUser) {
        document.getElementById('UserId').value = JSON.parse(currentUser).id;
    }
    else {
        window.location.href = '/'
    }

}